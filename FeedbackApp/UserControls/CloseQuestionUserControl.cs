using FeedbackApp.Data.Entities;
using FeedbackApp.Forms;
using FeedbackApp.Models.CloseQuestion;
using FeedbackApp.Models.CloseQuestionCategory;
using FeedbackApp.Models.Common;
using FeedbackApp.Models.Employee;
using FeedbackApp.Models.Score;
using FeedbackApp.Models.ScoreType;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.UserControls
{
    public partial class CloseQuestionUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public CloseQuestionUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;

            this.pmLookingDetail.Location = new Point((this.pnLooking.Width - this.pmLookingDetail.Width) / 2, (this.pnLooking.Height - this.pmLookingDetail.Height) / 2);

            this.btSkip.PerformClick();
        }
        private bool updateFlag;
        private bool addFlag;
        private bool selectFlag;
        private void updateList(string keyword = null)
        {

            var closeQuestions = Service.closeQuestionService.GetCloseQuestions(keyword).OrderBy(x => x.CloseQuestionCategoryId).ThenBy(x => x.OrdinalNumber).ToList();
            this.dtList.DataSource = closeQuestions;
            this.dtList.Columns[0].HeaderText = "Mã danh mục";
            this.dtList.Columns[1].HeaderText = "Mã câu hỏi";
            this.dtList.Columns[2].HeaderText = "Tên câu hỏi";
            this.dtList.Columns[3].HeaderText = "Mã mức độ điểm";
            this.dtList.Columns[4].HeaderText = "Thứ tự hiển thị";
            this.dtList.Columns[5].HeaderText = "Trạng thái";

            this.dtList.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.updatePageNumber();
            this.dtList.ClearSelection();
            if (this.rowIndex > -1)
            {
                this.dtList.Rows[this.rowIndex].Selected = true;
            }
        }

        private void btSkip_Click(object sender, EventArgs e)
        {
            this.btnAdd.FillColor = Color.Silver;
            this.btUpdate.FillColor = Color.Silver;

            this.dtList.Enabled = true;
            if (this.updateFlag)
            {
                this.updateFlag = false;

                this.pnId1.Visible = true;
                this.pnName.Visible = true;
                this.pnOrdinalNumber.Visible = true;
                this.pnCategory.Visible = true;
                this.pnScoreType.Visible = true;
                this.pnStatus.Visible = true;
                this.pnFeeedbackType.Visible = true;
                this.btnAdd.Visible = false;
                this.btUpdate.Visible = true;
                this.btnDelete.Visible = true;
                this.btSkip.Visible = true;
                this.btSave.Visible = false;

                this.tbId1.ReadOnly = true;
                this.tbName.ReadOnly = true;
                this.tbOrdinalNumber.ReadOnly = true;

                this.cbbCategory.Enabled = false;
                this.cbbScoreType.Enabled = false;
                this.cbbStatus.Enabled = false;
                this.flpFeebackTypeDetail.Enabled = false;
                return;
            }
            this.updateFlag = false;
            if (!this.selectFlag && !this.addFlag)
            {
                this.rowIndex = -1;
                var keyword = this.tbLooking.Text.Trim();
                if (keyword != null || keyword != "")
                {
                    this.updateList(keyword);
                }
                else
                {
                    this.updateList();
                }
            }
            if (this.selectFlag)
            {
                this.selectFlag = false;

                this.rowIndex = -1;
                this.updatePageNumber();
                this.dtList.ClearSelection();
            }
            if (this.addFlag)
            {
                this.addFlag = false;
            }

            this.btSave.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = false;
            this.btUpdate.Visible = false;
            this.btnAdd.Visible = true;

            this.pnId1.Visible = false;
            this.pnName.Visible = false;
            this.pnOrdinalNumber.Visible = false;
            this.pnCategory.Visible = false;
            this.pnFeeedbackType.Visible = false;
            this.pnStatus.Visible = false;
            this.pnScoreType.Visible = false;


            while (this.flpFeebackTypeDetail.Controls.Count > 0)
            {
                Control control = this.flpFeebackTypeDetail.Controls[0];
                this.flpFeebackTypeDetail.Controls.Remove(control);
                control.Dispose();
            }

            this.tbId1.Text = "";
            this.tbName.Text = "";
            this.tbOrdinalNumber.Text = "";
            this.cbbCategory.DroppedDown = false;
            this.cbbStatus.DroppedDown = false;
            this.cbbScoreType.DroppedDown = false;

        }
        private int flag = 0;
        private int rowIndex = -1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.addFlag = true;
            //this.btSkip.PerformClick();
            this.btSave.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = false;
            this.btUpdate.Visible = false;
            this.btnAdd.Visible = true;

            this.pnId1.Visible = false;
            this.pnName.Visible = false;
            this.pnOrdinalNumber.Visible = false;
            this.pnCategory.Visible = false;
            this.pnFeeedbackType.Visible = false;
            this.pnStatus.Visible = false;
            this.pnScoreType.Visible = false;


            while (this.flpFeebackTypeDetail.Controls.Count > 0)
            {
                Control control = this.flpFeebackTypeDetail.Controls[0];
                this.flpFeebackTypeDetail.Controls.Remove(control);
                control.Dispose();
            }

            this.tbId1.Text = "";
            this.tbName.Text = "";
            this.tbOrdinalNumber.Text = "";
            this.cbbCategory.DroppedDown = false;
            this.cbbStatus.DroppedDown = false;
            this.cbbScoreType.DroppedDown = false;

            this.btnAdd.FillColor = Color.DarkGray;
            this.flag = 1;

            this.pnId1.Visible = false;
            this.pnName.Visible = true;
            this.pnOrdinalNumber.Visible = true;
            this.pnScoreType.Visible = true;
            this.pnStatus.Visible = false;
            this.pnCategory.Visible = true;
            this.pnFeeedbackType.Visible = true;
            this.btUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;
            this.cbbCategory.Enabled = true;
            this.cbbScoreType.Enabled = true;
            this.flpFeebackTypeDetail.Enabled = true;

            this.tbId1.ReadOnly = false;
            this.tbName.ReadOnly = false;
            this.tbOrdinalNumber.ReadOnly = false;

            var feedbackTypes = Service.feedbackTypeService.GetFeedbackTypes();
            foreach (var item in feedbackTypes)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Id;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = true;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(150, 40);
                this.flpFeebackTypeDetail.Controls.Add(tempCheckbox);
            }

            var scoreTypes = new List<ScoreTypeViewModel>()
            {
                new ScoreTypeViewModel()
                {
                    Id = null,
                    Name = "Chọn loại mức độ điểm"
                }
            };
            var scoreTypePluses = Service.scoreTypeService.GetScoreTypes();
            scoreTypes.AddRange(scoreTypePluses);
            this.cbbScoreType.DataSource = scoreTypes;
            this.cbbScoreType.DisplayMember = "Name";

            var closeQuestionCategories = new List<CloseQuestionCategoryViewModel>()
            {
                new CloseQuestionCategoryViewModel()
                {
                    Id = null,
                    Name = "Chọn danh mục câu hỏi"
                }
            };
            var closeQuestionCategoriesPlus = Service.closeQuestionCategoyService.GetcloseQuestionCategories();
            closeQuestionCategories.AddRange(closeQuestionCategoriesPlus);
            this.cbbCategory.DataSource = closeQuestionCategories;
            this.cbbCategory.DisplayMember = "Name";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                var scoreType = (ScoreTypeViewModel)this.cbbScoreType.SelectedValue;
                var scoreTypeId = scoreType.Id;
                var closeQuestionCategory = (CloseQuestionCategoryViewModel)this.cbbCategory.SelectedValue;
                var closeQuestionCategoryId = closeQuestionCategory.Id;
                var feedbackTypeList = new List<string>();
                foreach (var item in this.flpFeebackTypeDetail.Controls)
                {
                    CheckBox cb = (CheckBox)item;
                    if (cb.Checked)
                    {
                        string idFeedbackType = cb.Name.Substring(2).ToString();
                        feedbackTypeList.Add(idFeedbackType);
                    }
                }
                if (this.tbName.Text == null || this.tbName.Text.Trim() == "")
                {
                    MessageBox.Show("Tên câu hỏi không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbOrdinalNumber.Text == null || this.tbOrdinalNumber.Text.Trim() == "")
                {
                    MessageBox.Show("Số thứ tự câu hỏi không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (closeQuestionCategoryId == null)
                {
                    MessageBox.Show("Mã danh mục câu hỏi đóng không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (scoreTypeId == null)
                {
                    MessageBox.Show("Mã loại mức độ điểm không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (feedbackTypeList.Count == 0)
                {
                    MessageBox.Show("Phải thuộc ít nhất 1 loại khảo sát", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var name = this.tbName.Text;
                var ordinalNumber = short.Parse(this.tbOrdinalNumber.Text);
                var data = new CloseQuestionCreateModel()
                {
                    Name = name,
                    OrdinalNumber = ordinalNumber,
                    CloseQuestionCategoryId = closeQuestionCategoryId,
                    ScoreTypeId = scoreTypeId,
                    FeedTypeIds = feedbackTypeList
                };
                var result = Service.closeQuestionService.CreateCloseQuestion(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.tbId1.Text = "";
                this.tbName.Text = "";
                this.tbOrdinalNumber.Text = "";
                this.cbbCategory.SelectedIndex = 0;
                this.cbbScoreType.SelectedIndex = 0;
                foreach (var item in this.flpFeebackTypeDetail.Controls)
                {
                    CheckBox cb = (CheckBox)item;
                    cb.Checked = false;
                }
                this.updateList();
                MessageBox.Show("Tạo câu hỏi mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (flag == 2)
            {
                var scoreType = (ScoreTypeViewModel)this.cbbScoreType.SelectedValue;
                var scoreTypeId = scoreType.Id;
                var closeQuestionCategory = (CloseQuestionCategoryViewModel)this.cbbCategory.SelectedValue;
                var closeQuestionCategoryId = closeQuestionCategory.Id;
                var Status = (Status)this.cbbStatus.SelectedValue;
                var feedbackTypeList = new List<string>();
                foreach (var item in this.flpFeebackTypeDetail.Controls)
                {
                    CheckBox cb = (CheckBox)item;
                    if (cb.Checked)
                    {
                        string idFeedbackType = cb.Name.Substring(2).ToString();
                        feedbackTypeList.Add(idFeedbackType);
                    }
                }
                if (this.tbName.Text == null || this.tbName.Text.Trim() == "")
                {
                    MessageBox.Show("Tên câu hỏi không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbOrdinalNumber.Text == null || this.tbOrdinalNumber.Text.Trim() == "")
                {
                    MessageBox.Show("Số thứ tự câu hỏi không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (closeQuestionCategoryId == null)
                {
                    MessageBox.Show("Mã danh mục câu hỏi đóng không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (scoreTypeId == null)
                {
                    MessageBox.Show("Mã loại mức độ điểm không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (Status.Name.Equals("Chọn trạng thái"))
                {
                    MessageBox.Show("Trạng thái không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (feedbackTypeList.Count == 0)
                {
                    MessageBox.Show("Phải thuộc ít nhất 1 loại khảo sát", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var id = short.Parse(this.tbId1.Text);
                var name = this.tbName.Text;
                var ordinalNumber = short.Parse(this.tbOrdinalNumber.Text);
                var data = new CloseQuestionUpdateModel()
                {
                    Id = id,
                    Name = name,
                    OrdinalNumber = ordinalNumber,
                    CloseQuestionCategoryId = closeQuestionCategoryId,
                    ScoreTypeId = scoreTypeId,
                    FeedTypeIds = feedbackTypeList,
                    Status = Status.Value
                };
                var result = Service.closeQuestionService.UpdateCloseQuestion(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //this.updateList();

                DataGridViewRow row = this.dtList.Rows[this.rowIndex];
                row.Cells[0].Value = closeQuestionCategoryId;
                row.Cells[1].Value = id;
                row.Cells[2].Value = name;
                row.Cells[3].Value = scoreTypeId;
                row.Cells[4].Value = ordinalNumber;
                row.Cells[5].Value = Status.Value;

                MessageBox.Show("Cập nhật câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectFlag = true;
            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            short id = short.Parse(this.dtList.Rows[rowIndex].Cells[1].Value.ToString());
            var closeQuestion = Service.closeQuestionService.GetCloseQuestionById(id);

            this.pnId1.Visible = true;
            this.pnName.Visible = true;
            this.pnOrdinalNumber.Visible = true;
            this.pnCategory.Visible = true;
            this.pnScoreType.Visible = true;
            this.pnStatus.Visible = true;
            this.pnFeeedbackType.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.tbId1.ReadOnly = true;
            this.tbName.ReadOnly = true;
            this.tbOrdinalNumber.ReadOnly = true;

            this.cbbCategory.Enabled = false;
            this.cbbScoreType.Enabled = false;
            this.cbbStatus.Enabled = false;
            this.flpFeebackTypeDetail.Enabled = false;

            this.tbId1.Text = closeQuestion.Id.ToString();
            this.tbName.Text = closeQuestion.Name;
            this.tbOrdinalNumber.Text = closeQuestion.OrdinalNumber.ToString();

            var scoreTypes = new List<ScoreTypeViewModel>()
            {
                new ScoreTypeViewModel()
                {
                    Id = null,
                    Name = "Chọn loại mức độ điểm"
                }
            };
            var scoreTypePluses = Service.scoreTypeService.GetScoreTypes();
            scoreTypes.AddRange(scoreTypePluses);
            this.cbbScoreType.DataSource = scoreTypes;
            this.cbbScoreType.DisplayMember = "Name";
            int i = -1;
            foreach (var item in scoreTypes)
            {
                i++;
                if (item.Id == null)
                {
                    continue;
                }
                if (item.Id.Equals(closeQuestion.ScoreTypeId))
                {
                    this.cbbScoreType.SelectedIndex = i;
                    break;
                }
            }

            var closeQuestionCategories = new List<CloseQuestionCategoryViewModel>()
            {
                new CloseQuestionCategoryViewModel()
                {
                    Id = null,
                    Name = "Chọn danh mục câu hỏi"
                }
            };
            var closeQuestionCategoriesPlus = Service.closeQuestionCategoyService.GetcloseQuestionCategories();
            closeQuestionCategories.AddRange(closeQuestionCategoriesPlus);
            this.cbbCategory.DataSource = closeQuestionCategories;
            this.cbbCategory.DisplayMember = "Name";
            i = -1;
            foreach (var item in closeQuestionCategories)
            {
                i++;
                if (item.Id == null)
                {
                    continue;
                }
                if (item.Id.Equals(closeQuestion.CloseQuestionCategoryId))
                {
                    this.cbbCategory.SelectedIndex = i;
                    break;
                }
            }

            var statuses = new List<Status>()
            {
                new Status()
                {
                    Name = "Chọn trạng thái",
                    Value = false
                },
                new Status()
                {
                    Name = "Đang sử dụng",
                    Value = true
                },
                new Status()
                {
                    Name = "Không còn sử dụng",
                    Value = false
                }
            };

            this.cbbStatus.DataSource = statuses;
            this.cbbStatus.DisplayMember = "Name";
            i = -1;
            foreach (var item in statuses)
            {
                i++;
                if (item.Name.Equals("Chọn trạng thái"))
                {
                    continue;
                }
                if (item.Value == closeQuestion.Status)
                {
                    this.cbbStatus.SelectedIndex = i;
                    break;
                }
            }

            while (this.flpFeebackTypeDetail.Controls.Count > 0)
            {
                Control control = this.flpFeebackTypeDetail.Controls[0];
                this.flpFeebackTypeDetail.Controls.Remove(control);
                control.Dispose();
            }


            var feedbackTypes = Service.feedbackTypeService.GetFeedbackTypes();
            foreach (var item in feedbackTypes)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Id;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = closeQuestion.FeedbackTypeIds.Contains(item.Id) ? true : false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = false;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(150, 40);
                this.flpFeebackTypeDetail.Controls.Add(tempCheckbox);
            }
            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }

        private void selectRow(int index)
        {
            this.selectFlag = true;
            this.dtList.Rows[index].Selected = true;
            short id = short.Parse(this.dtList.Rows[index].Cells[1].Value.ToString());
            var closeQuestion = Service.closeQuestionService.GetCloseQuestionById(id);

            this.pnId1.Visible = true;
            this.pnName.Visible = true;
            this.pnOrdinalNumber.Visible = true;
            this.pnCategory.Visible = true;
            this.pnScoreType.Visible = true;
            this.pnStatus.Visible = true;
            this.pnFeeedbackType.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.tbId1.ReadOnly = true;
            this.tbName.ReadOnly = true;
            this.tbOrdinalNumber.ReadOnly = true;



            this.cbbCategory.Enabled = false;
            this.cbbScoreType.Enabled = false;
            this.cbbStatus.Enabled = false;
            this.flpFeebackTypeDetail.Enabled = false;

            this.tbId1.Text = closeQuestion.Id.ToString();
            this.tbName.Text = closeQuestion.Name;
            this.tbOrdinalNumber.Text = closeQuestion.OrdinalNumber.ToString();

            var scoreTypes = new List<ScoreTypeViewModel>()
            {
                new ScoreTypeViewModel()
                {
                    Id = null,
                    Name = "Chọn loại mức độ điểm"
                }
            };
            var scoreTypePluses = Service.scoreTypeService.GetScoreTypes();
            scoreTypes.AddRange(scoreTypePluses);
            this.cbbScoreType.DataSource = scoreTypes;
            this.cbbScoreType.DisplayMember = "Name";
            int i = -1;
            foreach (var item in scoreTypes)
            {
                i++;
                if (item.Id == null)
                {
                    continue;
                }
                if (item.Id.Equals(closeQuestion.ScoreTypeId))
                {
                    this.cbbScoreType.SelectedIndex = i;
                    break;
                }
            }

            var closeQuestionCategories = new List<CloseQuestionCategoryViewModel>()
            {
                new CloseQuestionCategoryViewModel()
                {
                    Id = null,
                    Name = "Chọn danh mục câu hỏi"
                }
            };
            var closeQuestionCategoriesPlus = Service.closeQuestionCategoyService.GetcloseQuestionCategories();
            closeQuestionCategories.AddRange(closeQuestionCategoriesPlus);
            this.cbbCategory.DataSource = closeQuestionCategories;
            this.cbbCategory.DisplayMember = "Name";
            i = -1;
            foreach (var item in closeQuestionCategories)
            {
                i++;
                if (item.Id == null)
                {
                    continue;
                }
                if (item.Id.Equals(closeQuestion.CloseQuestionCategoryId))
                {
                    this.cbbCategory.SelectedIndex = i;
                    break;
                }
            }

            var statuses = new List<Status>()
            {
                new Status()
                {
                    Name = "Chọn trạng thái",
                    Value = false
                },
                new Status()
                {
                    Name = "Đang sử dụng",
                    Value = true
                },
                new Status()
                {
                    Name = "Không còn sử dụng",
                    Value = false
                }
            };

            this.cbbStatus.DataSource = statuses;
            this.cbbStatus.DisplayMember = "Name";
            i = -1;
            foreach (var item in statuses)
            {
                i++;
                if (item.Name.Equals("Chọn trạng thái"))
                {
                    continue;
                }
                if (item.Value == closeQuestion.Status)
                {
                    this.cbbStatus.SelectedIndex = i;
                    break;
                }
            }

            while (this.flpFeebackTypeDetail.Controls.Count > 0)
            {
                Control control = this.flpFeebackTypeDetail.Controls[0];
                this.flpFeebackTypeDetail.Controls.Remove(control);
                control.Dispose();
            }


            var feedbackTypes = Service.feedbackTypeService.GetFeedbackTypes();
            foreach (var item in feedbackTypes)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Id;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = closeQuestion.FeedbackTypeIds.Contains(item.Id) ? true : false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = false;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(150, 40);
                this.flpFeebackTypeDetail.Controls.Add(tempCheckbox);
            }
            this.updatePageNumber();
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.btUpdate.FillColor = Color.DarkGray;
            this.flag = 2;
            this.updateFlag = true;

            this.btnDelete.Visible = false;

            this.cbbCategory.Enabled = true;
            this.cbbScoreType.Enabled = true;
            this.cbbStatus.Enabled = true;
            this.pnFeeedbackType.Enabled = true;
            this.flpFeebackTypeDetail.Enabled = true;
            this.dtList.Enabled = false;
            this.btSave.Visible = true;

            this.tbName.ReadOnly = false;
            this.tbOrdinalNumber.ReadOnly = false;
            foreach (var item in this.flpFeebackTypeDetail.Controls)
            {
                var cb = (CheckBox)item;
                cb.Enabled = true;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = short.Parse(this.tbId1.Text);
            DialogResult option = MessageBox.Show($"Bạn có muốn xóa loại câu hỏi đóng {id}, việc xóa có thể dẫn đến mất các dữ liệu liên quan", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                var result = Service.closeQuestionService.deleteCloseQuestion(id);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.rowIndex = -1;

                this.updateList();
                MessageBox.Show("Xóa câu hỏi thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btSkip.PerformClick();
            }
        }

        private void btLooking_Click(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.btSkip.PerformClick();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            if (this.sfdExport.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                Excel.toExcel(this.dtList, this.sfdExport.FileName);
            }
        }
        private void updatePageNumber()
        {
            int rowNumber = this.dtList.RowCount;
            this.tbPageNumber.Text = $"{this.rowIndex + 1}/{rowNumber}";
        }
        private void btStartRow_Click(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.rowIndex = 0;
            this.selectRow(0);
        }

        private void btStartRow_Click_1(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.rowIndex = 0;
            this.selectRow(0);
        }

        private void btEndRow_Click_1(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.rowIndex = this.dtList.RowCount - 1;
            selectRow(this.dtList.RowCount - 1);
        }

        private void btPreviousRow_Click_1(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            if (this.rowIndex - 1 >= 0)
            {
                this.dtList.Rows[this.rowIndex].Selected = false;
                this.rowIndex--;
                selectRow(this.rowIndex);
            }
        }

        private void btNextRow_Click_1(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            if (this.rowIndex + 1 <= this.dtList.RowCount - 1)
            {
                if (this.rowIndex > -1)
                {
                    this.dtList.Rows[this.rowIndex].Selected = false;
                }
                this.rowIndex++;
                selectRow(this.rowIndex);
            }
        }

        private void tbOrdinalNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btReLoad_Click(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.btnAdd.FillColor = Color.Silver;
            this.btUpdate.FillColor = Color.Silver;

            this.dtList.Enabled = true;

            this.tbLooking.Text = "";

            this.updateFlag = false;
            this.rowIndex = -1;
            var keyword = this.tbLooking.Text;
            if (keyword != null || keyword != "")
            {
                this.updateList(keyword);
            }
            else
            {
                this.updateList();
            }

            this.btSave.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = false;
            this.btUpdate.Visible = false;
            this.btnAdd.Visible = true;

            this.pnId1.Visible = false;
            this.pnName.Visible = false;
            this.pnOrdinalNumber.Visible = false;
            this.pnCategory.Visible = false;
            this.pnFeeedbackType.Visible = false;
            this.pnStatus.Visible = false;
            this.pnScoreType.Visible = false;


            while (this.flpFeebackTypeDetail.Controls.Count > 0)
            {
                Control control = this.flpFeebackTypeDetail.Controls[0];
                this.flpFeebackTypeDetail.Controls.Remove(control);
                control.Dispose();
            }

            this.tbId1.Text = "";
            this.tbName.Text = "";
            this.tbOrdinalNumber.Text = "";
            this.cbbCategory.DroppedDown = false;
            this.cbbStatus.DroppedDown = false;
            this.cbbScoreType.DroppedDown = false;
        }
    }
}
