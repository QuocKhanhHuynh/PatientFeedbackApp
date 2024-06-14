using FeedbackApp.Data.Entities;
using FeedbackApp.Forms;
using FeedbackApp.Models.Score;
using FeedbackApp.Models.ScoreType;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FeedbackApp.UserControls
{
    public partial class ScoreUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public ScoreUserControl(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;

            this.pnLooking.Dock = DockStyle.Fill;

            this.pmLookingDetail.Location = new Point((this.pnLooking.Width - this.pmLookingDetail.Width) / 2, (this.pnLooking.Height - this.pmLookingDetail.Height) / 2);

            this.btSkip.PerformClick();
        }
        private bool updateFlag;
        private bool addFlag;
        private bool selectFlag;
        private void updateList(string keyword = null)
        {
            var score = Service.scoreService.GetScores(keyword).OrderBy(x => x.ScoreTypeId).ThenBy(x => x.Id).ToList();
            this.dtList.DataSource = score;
            this.dtList.Columns[0].HeaderText = "Mã mức độ điểm";
            this.dtList.Columns[1].HeaderText = "Mã loại mức độ điểm";
            this.dtList.Columns[2].HeaderText = "Tên mức độ điểm";
            this.dtList.Columns[3].HeaderText = "Điểm số";

            this.dtList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtList.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

                this.pnId.Visible = true;
                this.pnNumber.Visible = true;
                this.pnName.Visible = true;
                this.pnCategory.Visible = true;
                this.btnAdd.Visible = false;
                this.btUpdate.Visible = true;
                this.btnDelete.Visible = true;
                this.btSkip.Visible = true;
                this.btSave.Visible = false;

                this.dtList.ReadOnly = true;
                this.tbId.ReadOnly = true;
                this.tbNumber.ReadOnly = true;
                this.tbName.ReadOnly = true;

                this.cbbCategory.Enabled = false;

                return;
            }
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

            this.pnId.Visible = false;
            this.pnNumber.Visible = false;
            this.pnName.Visible = false;
            this.pnCategory.Visible = false;

            this.tbId.Text = "";
            this.tbNumber.Text = "";
            this.tbName.Text = "";
            this.cbbCategory.DroppedDown = false;
        }

        private int flag = 0;
        private int rowIndex = -1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.addFlag = true;

            this.btSave.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = false;
            this.btUpdate.Visible = false;
            this.btnAdd.Visible = true;

            this.pnId.Visible = false;
            this.pnNumber.Visible = false;
            this.pnName.Visible = false;
            this.pnCategory.Visible = false;

            this.tbId.Text = "";
            this.tbNumber.Text = "";
            this.tbName.Text = "";
            this.cbbCategory.DroppedDown = false;

            this.btnAdd.FillColor = Color.DarkGray;
            this.flag = 1;

            this.pnId.Visible = false;
            this.pnNumber.Visible = true;
            this.pnName.Visible = true;
            this.pnCategory.Visible = true;
            this.btUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;
            this.cbbCategory.Enabled = true;

            this.tbNumber.ReadOnly = false;
            this.tbName.ReadOnly = false;

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
            this.cbbCategory.DataSource = scoreTypes;
            this.cbbCategory.DisplayMember = "Name";
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                var scoreType = (ScoreTypeViewModel)this.cbbCategory.SelectedValue;
                var scoreTypeId = scoreType.Id;
                if (scoreTypeId == null)
                {
                    MessageBox.Show("Mã loại mức độ điểm không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbNumber.Text == null || this.tbNumber.Text.Trim() == "")
                {
                    MessageBox.Show("Điểm số không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbName.Text == null || this.tbName.Text.Trim() == "")
                {
                    MessageBox.Show("Tên mức độ điểm không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var number = short.Parse(this.tbNumber.Text);
                var name = this.tbName.Text.Trim();
                var data = new ScoreCreateModel()
                {

                    Number = number,
                    ScoreTypeId = scoreTypeId,
                    Name = name
                };
                var result = Service.scoreService.CreateScore(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.tbNumber.Text = "";
                this.tbName.Text = "";
                this.cbbCategory.DroppedDown = false;
                this.updateList();
                this.cbbCategory.SelectedIndex = 0;
                MessageBox.Show("Tạo mức độ điểm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (flag == 2)
            {
                var scoreType = (ScoreTypeViewModel)this.cbbCategory.SelectedValue;
                var scoreTypeId = scoreType.Id;
                if (scoreTypeId == null)
                {
                    MessageBox.Show("Mã loại mức độ điểm không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbNumber.Text == null || this.tbNumber.Text.Trim() == "")
                {
                    MessageBox.Show("Mã mức độ điểm không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbName.Text == null || this.tbName.Text.Trim() == "")
                {
                    MessageBox.Show("Tên mức độ điểm không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var id = short.Parse(this.tbId.Text);
                var number = short.Parse(this.tbNumber.Text);
                var name = this.tbName.Text.Trim();
                var data = new ScoreUpdateModel()
                {
                    Id = id,
                    ScoreTypeId = scoreTypeId,
                    Name = name,
                    Number = number
                };
                var result = Service.scoreService.UpdateScore(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MessageBox.Show("Chỉnh mức độ điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow row = this.dtList.Rows[this.rowIndex];
                row.Cells[0].Value = id;
                row.Cells[1].Value = scoreTypeId;
                row.Cells[2].Value = name;
                row.Cells[3].Value = number;
            }
        }

        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)/////////
        {
            this.selectFlag = true;

            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            short id = short.Parse(this.dtList.Rows[rowIndex].Cells[0].Value.ToString());
            var score = Service.scoreService.GetScoreById(id);

            this.pnId.Visible = true;
            this.pnNumber.Visible = true;
            this.pnName.Visible = true;
            this.pnCategory.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.dtList.ReadOnly = true;
            this.tbId.ReadOnly = true;
            this.tbNumber.ReadOnly = true;
            this.tbName.ReadOnly = true;

            this.cbbCategory.Enabled = false;

            this.tbId.Text = score.Id.ToString();
            this.tbNumber.Text = score.Number.ToString();
            this.tbName.Text = score.Name;
            var scoreTypes = new List<ScoreTypeViewModel>()
            {
                new ScoreTypeViewModel()
                {
                    Id = null,
                    Name = "Chọn loại mức độ điểm",
                }
            };
            var scoreTypePluses = Service.scoreTypeService.GetScoreTypes();
            scoreTypes.AddRange(scoreTypePluses);
            this.cbbCategory.DataSource = scoreTypes;
            this.cbbCategory.DisplayMember = "Name";
            int i = -1;
            foreach (var item in scoreTypes)
            {
                i++;
                if (item.Id == null)
                {
                    continue;
                }
                if (item.Id.Equals(score.ScoreTypeId))
                {
                    this.cbbCategory.SelectedIndex = i;
                    break;
                }
            }
            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }
        private void selectRow(int index)////
        {
            this.selectFlag = true;
            this.dtList.Rows[rowIndex].Selected = true;
            short id = short.Parse(this.dtList.Rows[rowIndex].Cells[0].Value.ToString());
            var score = Service.scoreService.GetScoreById(id);

            this.pnId.Visible = true;
            this.pnNumber.Visible = true;
            this.pnName.Visible = true;
            this.pnCategory.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.dtList.ReadOnly = true;
            this.tbId.ReadOnly = true;
            this.tbNumber.ReadOnly = true;
            this.tbName.ReadOnly = true;

            this.cbbCategory.Enabled = false;

            this.tbNumber.Text = score.Id.ToString();
            this.tbName.Text = score.Name;
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
            this.cbbCategory.DataSource = scoreTypes;
            this.cbbCategory.DisplayMember = "Name";
            int i = -1;
            foreach (var item in scoreTypes)
            {
                i++;
                if (item.Id == null)
                {
                    continue;
                }
                if (item.Id.Equals(score.ScoreTypeId))
                {
                    this.cbbCategory.SelectedIndex = i;
                    break;
                }
            }
            this.updatePageNumber();
        }
        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.updateFlag = true;

            this.btUpdate.FillColor = Color.DarkGray;
            this.flag = 2;

            this.pnId.Visible = true;
            this.pnNumber.Visible = true;
            this.pnName.Visible = true;
            this.pnCategory.Visible = true;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = false;
            this.btnAdd.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;

            this.tbId.ReadOnly = true;
            this.tbNumber.ReadOnly = false;
            this.tbName.ReadOnly = false;

            this.cbbCategory.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = short.Parse(this.tbId.Text);
            DialogResult option = MessageBox.Show($"Bạn có muốn xóa loại câu hỏi đóng {id}, việc xóa có thể dẫn đến mất các dữ liệu liên quan", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                var result = Service.scoreService.DeleteType(id);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.rowIndex = -1;
                this.updateList();
                MessageBox.Show("Xóa mức độ điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tbNumber_KeyPress(object sender, KeyPressEventArgs e)
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

            this.pnId.Visible = false;
            this.pnNumber.Visible = false;
            this.pnName.Visible = false;
            this.pnCategory.Visible = false;

            this.tbId.Text = "";
            this.tbNumber.Text = "";
            this.tbName.Text = "";
            this.cbbCategory.DroppedDown = false;
        }
    }
}
