using FeedbackApp.Forms;
using FeedbackApp.Models.Function;
using FeedbackApp.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace FeedbackApp.UserControls
{
    public partial class FunctionUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public FunctionUserControl(MainForm mainForm)
        {
            InitializeComponent();

            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;

            this.pnLooking.Dock = DockStyle.Fill;

            this.pmLookingDetail.Location = new Point((this.pnLooking.Width - this.pmLookingDetail.Width) / 2, (this.pnLooking.Height - this.pmLookingDetail.Height) / 2);

            this.btSkip.PerformClick();
        }
        private int rowIndex = -1;
        private bool updateFlag;
        private bool addFlag;
        private bool selectFlag;
        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectFlag = true;
            this.rowIndex = this.dtList.CurrentCell.RowIndex;
            this.rowIndex = rowIndex;
            selectRow(this.rowIndex);
        }

        private void selectRow(int index)
        {

            this.dtList.Rows[index].Selected = true;
            short id = short.Parse(this.dtList.Rows[index].Cells[0].Value.ToString());
            var function = Service.functionService.GetFunctionById(id);
            this.tbId.Text = function.Id.ToString();
            this.tbName.Text = function.Name;
            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.btSkip.Visible = true;
            this.btUpdate.Visible = true;
            this.btUpdate.FillColor = Color.Silver;
            this.tbId.Visible = true;
            this.tbName.Visible = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;
            this.btSave.Visible = false;

            this.updatePageNumber();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            this.addFlag = true;

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnId.Visible = false;
            this.tbName.ReadOnly = false;
            this.btSave.Visible = true;
            this.btUpdate.FillColor = Color.Silver;
            this.btSkip.Visible = true;
            this.clear();
            this.dtList.ReadOnly = true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            short id = short.Parse(this.tbId.Text);
            var name = this.tbName.Text.Trim();
            if (this.tbId.Text == null || this.tbId.Text.Trim() == "")
            {
                MessageBox.Show("Mã quyền không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (name == null || name == "")
            {
                MessageBox.Show("Mã quyền không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = new FunctionUpdateModel()
            {
                Id = id,
                Name = name,
            };
            var result = Service.functionService.UpdateFunction(data);
            if (!result.Status)
            {
                MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            MessageBox.Show("Chỉnh quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //this.updateList();
            //this.btSkip.PerformClick();
            DataGridViewRow row = this.dtList.Rows[this.rowIndex];
            row.Cells[0].Value = id;
            row.Cells[1].Value = name;
        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.updateFlag = true;

            this.pnId.Visible = true;
            this.tbId.ReadOnly = true;
            //this.pnName.Visible = true;
            this.tbName.ReadOnly = false;
            this.btSave.Visible = true;
            this.btUpdate.FillColor = Color.DarkGray;
            this.btSkip.Visible = true;
            //this.clear();
            this.dtList.ReadOnly = true;

            this.dtList.Enabled = false;
        }

        private void updateList(string keyword = null)
        {
            var functions = Service.functionService.GetFunctions(keyword).OrderBy(x => x.Id).ToList();
            this.dtList.DataSource = functions;
            this.dtList.Columns[0].HeaderText = "Mã quyền";
            this.dtList.Columns[1].HeaderText = "Tên quyền";

            this.dtList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.updatePageNumber();
            this.dtList.ClearSelection();
            if (this.rowIndex > -1)
            {
                this.dtList.Rows[this.rowIndex].Selected = true;
            }

        }
        private void clear()
        {
            if (this.dtList.CurrentCell != null)
            {
                int rowIndex = this.dtList.CurrentCell.RowIndex;
                if (rowIndex > -1)
                {
                    this.dtList.Rows[rowIndex].Selected = false;
                }
            }
            this.tbId.Text = "";
            this.tbName.Text = "";
        }

        private void btSkip_Click(object sender, EventArgs e)
        {
            this.dtList.Enabled = true;
            if (this.updateFlag)
            {
                this.updateFlag = false;

                this.pnId.Visible = true;
                this.pnName.Visible = true;
                this.btSkip.Visible = true;
                this.btUpdate.Visible = true;
                this.btUpdate.FillColor = Color.Silver;
                this.tbId.Visible = true;
                this.tbName.Visible = true;
                this.tbId.ReadOnly = true;
                this.tbName.ReadOnly = true;
                this.btSave.Visible = false;

                return;
            }
            this.updateFlag = false;

            if (this.dtList.CurrentCell != null)
            {
                int rowIndex = this.dtList.CurrentCell.RowIndex;
                if (rowIndex > -1)
                {
                    this.dtList.Rows[rowIndex].Selected = false;
                }
            }
            this.clear();
            this.tbId.Visible = true;
            this.tbName.Visible = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;
            this.btSkip.Visible = false;
            this.btSave.Visible = false;
            this.btUpdate.Visible = false;
            this.dtList.ReadOnly = false;
            this.pnId.Visible = false;
            this.pnName.Visible = false;

            this.rowIndex = -1;
            if (this.selectFlag)
            {
                this.selectFlag = false;

                this.rowIndex = -1;
                this.updatePageNumber();
                this.dtList.ClearSelection();
            }
            else
            {
                var keyword = this.tbLooking.Text.Trim();
                if (keyword != null || keyword != "")
                {
                    this.updateList(keyword);
                }
                else
                {
                    this.updateList();
                }
                this.updatePageNumber();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show("Bạn có muốn xóa quyền?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                short id = short.Parse(tbId.Text.ToString());
                var result = Service.functionService.DeleteFunction(id);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("Xóa quyền thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.rowIndex = -1;
                this.updateList();
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

        private void updatePageNumber()
        {
            int rowNumber = this.dtList.RowCount;
            this.tbPageNumber.Text = $"{this.rowIndex + 1}/{rowNumber}";
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

        private void btStartRow_Click_1(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.rowIndex = 0;
            selectRow(0);
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
                this.rowIndex++;
                this.dtList.Rows[this.rowIndex].Selected = false;
                selectRow(this.rowIndex);
            }
        }

        private void btReLoad_Click(object sender, EventArgs e)
        {
            if (this.updateFlag || this.addFlag)
            {
                return;
            }
            this.dtList.Enabled = true;

            if (this.dtList.CurrentCell != null)
            {
                int rowIndex = this.dtList.CurrentCell.RowIndex;
                if (rowIndex > -1)
                {
                    this.dtList.Rows[rowIndex].Selected = false;
                }
            }
            this.clear();
            this.tbId.Visible = true;
            this.tbName.Visible = true;
            this.tbId.ReadOnly = true;
            this.tbName.ReadOnly = true;
            this.btSkip.Visible = false;
            this.btSave.Visible = false;
            this.btUpdate.Visible = false;
            this.dtList.ReadOnly = false;
            this.pnId.Visible = false;
            this.pnName.Visible = false;

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
            this.updatePageNumber();
        }
    }
}
