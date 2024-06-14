using FeedbackApp.Data.Entities;
using FeedbackApp.Forms;
using FeedbackApp.Models.CloseQuestionCategory;
using FeedbackApp.Models.Common;
using FeedbackApp.Models.Score;
using FeedbackApp.Models.ScoreType;
using FeedbackApp.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.UserControls
{
    public partial class CloseQuestionCategoryUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public CloseQuestionCategoryUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;

            //this.pnLooking.Size = new Size(this.pnListFoot.Width - (this.pnPageNumber.Width + this.flpExport.Width), this.pnListFoot.Height);
            //this.pnLooking.Location = new Point((this.pnListFoot.Width - this.pnLooking.Width) / 2,0);

            this.pnListFoot.Controls.Add(this.pnLooking);
            this.pnLooking.Dock = DockStyle.Fill;

            this.pmLookingDetail.Location = new Point((this.pnLooking.Width - this.pmLookingDetail.Width) / 2, (this.pnLooking.Height - this.pmLookingDetail.Height) / 2);

            this.btSkip.PerformClick();
        }
        private bool updateFlag;
        private bool addFlag;
        private bool selectFlag;
        private void updateList(string keyword = null)
        {
            var closeQuestionCategories = Service.closeQuestionCategoyService.GetcloseQuestionCategories(keyword).OrderBy(x => x.Id).ToList();
            this.dtList.DataSource = closeQuestionCategories;

            this.dtList.Columns[0].HeaderText = "Mã loại câu hỏi đóng";
            this.dtList.Columns[1].HeaderText = "Tên loại câu hỏi đóng";
            this.dtList.Columns[2].HeaderText = "Trạng thái";
            /*
            DataGridViewTextBoxColumn sttColumn = new DataGridViewTextBoxColumn();
            //sttColumn.Name = "STT";
            sttColumn.HeaderText = "Số thứ tự";
            this.dtList.Columns.Insert(0, sttColumn);

            for (int i = 0; i < this.dtList.Rows.Count; i++)
            {
                this.dtList.Rows[i].Cells[0].Value = i +1;
            }

            this.dtList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            */
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

            this.btnDelete.Visible = true;
            this.btSave.Visible = false;

            this.dtList.Enabled = true;

            if (this.updateFlag)
            {
                this.updateFlag = false;
            }
            else
            {
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
                this.btnDelete.Visible = false;
                this.btSkip.Visible = false;
                this.btUpdate.Visible = false;
                this.btnAdd.Visible = true;

                this.pnId.Visible = false;
                this.pnName.Visible = false;
                this.pnStatus.Visible = false;

                this.tbId.Text = "";
                this.tbName.Text = "";
                this.cbbStatus.DroppedDown = false;
            }
        }

        private int flag = 0;
        private int rowIndex = -1;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.addFlag = true;

            this.btnDelete.Visible = false;
            this.btSkip.Visible = false;
            this.btUpdate.Visible = false;
            this.btnAdd.Visible = true;

            this.pnId.Visible = false;
            this.pnName.Visible = false;
            this.pnStatus.Visible = false;

            this.tbId.Text = "";
            this.tbName.Text = "";
            this.cbbStatus.DroppedDown = false;

            this.btnAdd.FillColor = Color.DarkGray;
            this.flag = 1;

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnStatus.Visible = false;
            this.btUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;
            this.pnStatus.Enabled = false;

            this.tbId.ReadOnly = false;
            this.tbName.ReadOnly = false;
            /*
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
            this.cbbStatus.DisplayMember = "Name";*/
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                //var status = (Status)this.cbbStatus.SelectedValue;
                //var statusValue = status.Value;
                if (this.tbId.Text == null || this.tbId.Text.Trim() == "")
                {
                    MessageBox.Show("Mã loại không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbName.Text == null || this.tbName.Text.Trim() == "")
                {
                    MessageBox.Show("Tên loại không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                /*
                if (status.Name.Equals("Chọn trạng thái"))
                {
                    MessageBox.Show("Mã loại không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                */
                var id = this.tbId.Text;
                var name = this.tbName.Text;
                var data = new CloseQuestionCategoryCreateModel()
                {
                    Id = id,
                    Name = name,
                };
                var result = Service.closeQuestionCategoyService.CreateCloseQuestionCategory(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.tbId.Text = "";
                this.tbName.Text = "";
                //this.cbbStatus.DroppedDown = false;
                this.updateList();
                //this.cbbStatus.SelectedIndex = 0;
                MessageBox.Show("Tạo loại câu hỏi đóng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (flag == 2)
            {
                var status = (Status)this.cbbStatus.SelectedValue;
                var statusValue = status.Value;
                if (this.tbId.Text == null || this.tbId.Text.Trim() == "")
                {
                    MessageBox.Show("Mã loại không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (this.tbName.Text == null || this.tbName.Text.Trim() == "")
                {
                    MessageBox.Show("Tên loại không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (status.Name.Equals("Chọn trạng thái"))
                {
                    MessageBox.Show("Trạng thái không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var id = this.tbId.Text;
                var name = this.tbName.Text;
                var data = new CloseQuestionCategoryUpdateModel()
                {
                    Id = id,
                    Name = name,
                    Status = statusValue
                };
                var result = Service.closeQuestionCategoyService.UpdateCloseQuestionCategory(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Chỉnh loại câu hỏi đóng mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow row = this.dtList.Rows[this.rowIndex];
                //row.Cells[0].Value = this.rowIndex + 1;
                row.Cells[0].Value = id;
                row.Cells[1].Value = name;
                row.Cells[2].Value = statusValue;
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.btUpdate.FillColor = Color.DarkGray;
            this.updateFlag = true;
            this.flag = 2;

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnStatus.Visible = true;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = false;
            this.btnAdd.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;
            this.pnStatus.Enabled = true;

            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = false;

        }

        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectFlag = true;
            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            string id = this.dtList.Rows[rowIndex].Cells[0].Value.ToString();
            var closeQuestionCategory = Service.closeQuestionCategoyService.GetCloseQuestionCategoryById(id);

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnStatus.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.dtList.ReadOnly = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;

            this.pnStatus.Enabled = false;


            this.tbId.Text = closeQuestionCategory.Id;
            this.tbName.Text = closeQuestionCategory.Name;
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
            int i = -1;
            foreach (var item in statuses)
            {
                i++;
                if (item.Name.Equals("Chọn trạng thái"))
                {
                    continue;
                }
                if (item.Value == closeQuestionCategory.Status)
                {
                    this.cbbStatus.SelectedIndex = i;
                    break;
                }
            }
            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }
        private void selectRow(int index)
        {
            this.selectFlag = true;
            this.dtList.Rows[index].Selected = true;
            string id = this.dtList.Rows[index].Cells[0].Value.ToString();
            var closeQuestionCategory = Service.closeQuestionCategoyService.GetCloseQuestionCategoryById(id);

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnStatus.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.dtList.ReadOnly = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;

            this.pnStatus.Enabled = false;

            this.tbId.Text = closeQuestionCategory.Id;
            this.tbName.Text = closeQuestionCategory.Name;
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
            int i = -1;
            foreach (var item in statuses)
            {
                i++;
                if (item.Name.Equals("Chọn trạng thái"))
                {
                    continue;
                }
                if (item.Value == closeQuestionCategory.Status)
                {
                    this.cbbStatus.SelectedIndex = i;
                    break;
                }
            }
            this.updatePageNumber();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.tbId.Text;
            DialogResult option = MessageBox.Show($"Bạn có muốn xóa loại câu hỏi đóng {id}, việc xóa có thể dẫn đến mất các dữ liệu liên quan", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                var result = Service.closeQuestionCategoyService.DeleteCloseQuestionCategory(id);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.rowIndex = -1;
                this.updateList();
                MessageBox.Show("Xóa loại câu hỏi đóng thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btEndRow_Click(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.rowIndex = this.dtList.RowCount - 1;
            selectRow(this.dtList.RowCount - 1);
        }

        private void btPreviousRow_Click(object sender, EventArgs e)
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

        private void btNextRow_Click(object sender, EventArgs e)
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
            this.btnDelete.Visible = false;
            this.btSkip.Visible = false;
            this.btUpdate.Visible = false;
            this.btnAdd.Visible = true;

            this.pnId.Visible = false;
            this.pnName.Visible = false;
            this.pnStatus.Visible = false;

            this.tbId.Text = "";
            this.tbName.Text = "";
            this.cbbStatus.DroppedDown = false;
            
        }
    }
}
