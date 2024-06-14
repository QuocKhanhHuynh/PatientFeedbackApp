using FeedbackApp.Forms;
using FeedbackApp.Models.FeedbackType;
using FeedbackApp.Models.ScoreType;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FeedbackApp.UserControls
{
    public partial class ScoreTypeUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public ScoreTypeUserControl(MainForm mainForm)
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
            var scoreType = Service.scoreTypeService.GetScoreTypes(keyword).OrderBy(x => x.Id).ToList();
            this.dtList.DataSource = scoreType;
            this.dtList.Columns[0].HeaderText = "Mã loại mức độ điểm";
            this.dtList.Columns[1].HeaderText = "Tên loại mức độ điểm";
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
                this.pnName.Visible = true;
                this.btnAdd.Visible = false;
                this.btUpdate.Visible = true;
                this.btnDelete.Visible = true;
                this.btSkip.Visible = true;
                this.btSave.Visible = false;

                this.dtList.ReadOnly = true;
                this.tbId.ReadOnly = true;
                this.tbName.ReadOnly = true;

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
            this.pnName.Visible = false;

            this.tbId.Text = "";
            this.tbName.Text = "";
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
            this.pnName.Visible = false;

            this.tbId.Text = "";
            this.tbName.Text = "";

            this.btnAdd.FillColor = Color.DarkGray;
            this.flag = 1;

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.btUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;

            this.tbId.ReadOnly = false;
            this.tbName.ReadOnly = false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                var id = this.tbId.Text.Trim();
                var name = this.tbName.Text.Trim();
                if (id == null || id == "")
                {
                    MessageBox.Show("Mã loại mức độ điểm không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (name == null || name == "")
                {
                    MessageBox.Show("Tên loại mức độ điểm không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var data = new ScoreTypeCreateViewModel()
                {
                    Id = id,
                    Name = name
                };
                var result = Service.scoreTypeService.CreateScoreType(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.tbId.Text = "";
                this.tbName.Text = "";
                this.updateList();
                MessageBox.Show("Tạo loại mức độ điểm mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (flag == 2)
            {
                var id = this.tbId.Text.Trim();
                var name = this.tbName.Text.Trim();
                if (name == null || name == "")
                {
                    MessageBox.Show("Tên loại mức độ điểm không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var data = new ScoreTypeUpdateViewModel()
                {
                    Id = id,
                    Name = name
                };
                var result = Service.scoreTypeService.UpdateScoreType(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MessageBox.Show("Chỉnh loại mức độ điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow row = this.dtList.Rows[this.rowIndex];
                row.Cells[0].Value = id;
                row.Cells[1].Value = name;
            }
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.btUpdate.FillColor = Color.DarkGray;
            this.flag = 2;
            this.updateFlag = true;

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = false;
            this.btnAdd.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.dtList.Enabled = false;

            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = false;

            var id = this.tbId.Text;
            var scoreType = Service.scoreTypeService.GetScoreTypeById(id);

            this.tbId.Text = scoreType.Id;
            this.tbName.Text = scoreType.Name;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = this.tbId.Text;
            DialogResult option = MessageBox.Show($"Bạn có muốn xóa loại câu hỏi đóng {id}, việc xóa có thể dẫn đến mất các dữ liệu liên quan", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                var result = Service.scoreTypeService.DeleteScoreType(id);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.rowIndex = -1;
                this.updateList();
                MessageBox.Show("Xóa loại mức độ điểm thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.btSkip.PerformClick();
            }
        }

        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectFlag = true;

            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            string id = this.dtList.Rows[rowIndex].Cells[0].Value.ToString();
            var scoreType = Service.scoreTypeService.GetScoreTypeById(id);

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.dtList.ReadOnly = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;

            this.tbId.Text = scoreType.Id;
            this.tbName.Text = scoreType.Name;
            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }
        private void selectRow(int index)
        {
            this.selectFlag = true;
            this.dtList.Rows[index].Selected = true;
            string id = this.dtList.Rows[index].Cells[0].Value.ToString();
            var scoreType = Service.scoreTypeService.GetScoreTypeById(id);

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;

            this.dtList.ReadOnly = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;

            this.tbId.Text = scoreType.Id;
            this.tbName.Text = scoreType.Name;
            this.updatePageNumber();
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
            this.pnName.Visible = false;

            this.tbId.Text = "";
            this.tbName.Text = "";
        }
    }
}
