using FeedbackApp.Data.Entities;
using FeedbackApp.Forms;
using FeedbackApp.Models.Employee;
using FeedbackApp.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XAct;

namespace FeedbackApp.UserControls
{
    public partial class EmployeeUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public EmployeeUserControl(MainForm mainForm)
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
        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectFlag = true;
            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            string username = this.dtList.Rows[rowIndex].Cells[0].Value.ToString();
            var employee = Service.employeeService.GetEmployeesByUserName(username);

            this.pnUsername.Visible = true;
            this.pnFullname.Visible = true;
            this.pnPhoneNumber.Visible = true;
            this.pnEmail.Visible = true;
            this.pnLimit.Visible = true;
            this.pnPassword.Visible = false;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;
            this.pnShowPassword.Visible = false;
            this.cbShowPassword.Visible = false;

            this.dtList.ReadOnly = true;
            this.txtUsername.ReadOnly = true;
            this.tbFullname.ReadOnly = true;
            this.tbPhoneNumber.ReadOnly = true;
            this.txtEmail.ReadOnly = true;

            this.txtUsername.Text = employee.Username;
            this.tbFullname.Text = employee.Fullname;
            this.tbPhoneNumber.Text = employee.PhoneNumber;
            this.txtEmail.Text = employee.Email;

            while (this.flpLitmitDetail.Controls.Count > 0)
            {
                Control control = this.flpLitmitDetail.Controls[0];
                this.flpLitmitDetail.Controls.Remove(control);
                control.Dispose();
            }


            var Limits = Service.functionService.GetFunctions();
            foreach (var item in Limits)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Name;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = employee.Functions.Contains(item.Id) ? true : false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = false;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(313, 40);
                this.flpLitmitDetail.Controls.Add(tempCheckbox);
            }
            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }
        private void selectRow(int index)
        {
            this.selectFlag = true;
            this.dtList.Rows[index].Selected = true;
            string username = this.dtList.Rows[index].Cells[0].Value.ToString();
            var employee = Service.employeeService.GetEmployeesByUserName(username);

            this.pnUsername.Visible = true;
            this.pnFullname.Visible = true;
            this.pnPhoneNumber.Visible = true;
            this.pnEmail.Visible = true;
            this.pnLimit.Visible = true;
            this.pnPassword.Visible = false;
            this.btnAdd.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = false;
            this.pnShowPassword.Visible = false;
            this.cbShowPassword.Visible = false;

            this.dtList.ReadOnly = true;
            this.txtUsername.ReadOnly = true;
            this.tbFullname.ReadOnly = true;
            this.tbPhoneNumber.ReadOnly = true;
            this.txtEmail.ReadOnly = true;

            this.txtUsername.Text = employee.Username;
            this.tbFullname.Text = employee.Fullname;
            this.tbPhoneNumber.Text = employee.PhoneNumber;
            this.txtEmail.Text = employee.Email;

            while (this.flpLitmitDetail.Controls.Count > 0)
            {
                Control control = this.flpLitmitDetail.Controls[0];
                this.flpLitmitDetail.Controls.Remove(control);
                control.Dispose();
            }


            var Limits = Service.functionService.GetFunctions();
            foreach (var item in Limits)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Name;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = employee.Functions.Contains(item.Id) ? true : false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = false;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(313, 40);
                this.flpLitmitDetail.Controls.Add(tempCheckbox);
            }
            this.updatePageNumber();
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

            this.pnUsername.Visible = false;
            this.pnFullname.Visible = false;
            this.pnPhoneNumber.Visible = false;
            this.pnEmail.Visible = false;
            this.pnPassword.Visible = false;
            this.pnLimit.Visible = false;
            this.pnShowPassword.Visible = false;

            while (this.flpLitmitDetail.Controls.Count > 0)
            {
                Control control = this.flpLitmitDetail.Controls[0];
                this.flpLitmitDetail.Controls.Remove(control);
                control.Dispose();
            }

            this.txtUsername.Text = "";
            this.tbFullname.Text = "";
            this.tbPhoneNumber.Text = "";
            this.txtEmail.Text = "";
            this.tbPassword.Text = "";

            this.btnAdd.FillColor = Color.DarkGray;
            this.flag = 1;

            this.pnUsername.Visible = true;
            this.pnFullname.Visible = true;
            this.pnPhoneNumber.Visible = true;
            this.pnEmail.Visible = true;
            this.pnLimit.Visible = true;
            this.pnPassword.Visible = true;
            this.btUpdate.Visible = false;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;
            this.pnShowPassword.Visible = true;
            this.cbShowPassword.Visible = true;

            this.dtList.Enabled = false;
            this.pnLimit.Enabled = true;
            

            this.txtUsername.ReadOnly = false;
            this.tbFullname.ReadOnly = false;
            this.tbPassword.ReadOnly = false;
            this.tbPhoneNumber.ReadOnly = false;
            this.txtEmail.ReadOnly = false;

            var Limits = Service.functionService.GetFunctions();
            foreach (var item in Limits)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Name;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = true;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(313, 40);
                this.flpLitmitDetail.Controls.Add(tempCheckbox);
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (flag == 1)
            {
                var username = this.txtUsername.Text.Trim();
                var fullname = this.tbFullname.Text.Trim();
                var password = this.tbPassword.Text.Trim();
                var phoneNumber = this.tbPhoneNumber.Text.Trim();
                var email = this.txtEmail.Text.Trim();
                var limitList = new List<short>();
                foreach (var item in flpLitmitDetail.Controls)
                {
                    CheckBox cb = (CheckBox)item;
                    if (cb.Checked)
                    {
                        short idLimit = short.Parse(cb.Name[cb.Name.Length - 1].ToString());
                        limitList.Add(idLimit);
                    }
                }
                if (username == null || username == "")
                {
                    MessageBox.Show("Tên đăng nhập không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (fullname == null || fullname == "")
                {
                    MessageBox.Show("Họ tên không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (password == null || password == "")
                {
                    MessageBox.Show("Mật khẩu không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (phoneNumber == null || phoneNumber == "")
                {
                    MessageBox.Show("Số điện thoại không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (email == null || email == "")
                {
                    MessageBox.Show("Email không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string pattern1 = @"^(84|0[3|5|7|8|9])+([0-9]{8})\b$";
                if (!Regex.IsMatch(phoneNumber, pattern1))
                {
                    MessageBox.Show("Không đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string pattern2 = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
                if (!Regex.IsMatch(email, pattern2))
                {
                    MessageBox.Show("Không đúng định dạng email", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

                if (!Regex.IsMatch(password, pattern))
                {
                    MessageBox.Show("Mật khẩu phải có ít nhất 8 ký tự. Có ít nhất 1 chữ cái in hoa, 1 chữ cái thường, 1 ký tự đặc biệt", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (limitList.Count == 0)
                {
                    MessageBox.Show("Tài khoản phải có ít nhất một quyền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var data = new EmployeeCreateModel()
                {
                    Username = username,
                    Email = email,
                    Fullname = fullname,
                    Password = password,
                    PhoneNumber = phoneNumber,
                    Functions = limitList
                };
                var result = Service.employeeService.CreateEmployee(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.txtUsername.Text = "";
                this.tbFullname.Text = "";
                this.tbPassword.Text = "";
                this.tbPhoneNumber.Text = "";
                this.txtEmail.Text = "";
                foreach (var item in flpLitmitDetail.Controls)
                {
                    CheckBox cb = (CheckBox)item;
                    cb.Checked = false;
                }
                this.updateList();
                MessageBox.Show("Tạo tài khoản mới thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (flag == 2)
            {
                var username = this.txtUsername.Text.Trim();
                var fullname = this.tbFullname.Text.Trim();
                var phoneNumber = this.tbPhoneNumber.Text.Trim();
                var email = this.txtEmail.Text.Trim();
                var limitList = new List<short>();
                foreach (var item in flpLitmitDetail.Controls)
                {
                    CheckBox cb = (CheckBox)item;
                    if (cb.Checked)
                    {
                        short idLimit = short.Parse(cb.Name[cb.Name.Length - 1].ToString());
                        limitList.Add(idLimit);
                    }
                }
                if (LoginSession.MyAccount.Username.Equals(username))
                {
                    MessageBox.Show("Không thể cập nhật tài khoản chính bạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (limitList.Count == 0)
                {
                    MessageBox.Show("Tài khoản phải có ít nhất một quyền", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var data = new EmployeeUpdateModel()
                {
                    Username = username,
                    Fullname = fullname,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    Functions = limitList
                };
                var result = Service.employeeService.UpdateEmployee(data);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                MessageBox.Show("Chỉnh tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGridViewRow row = this.dtList.Rows[this.rowIndex];
                row.Cells[0].Value = username;
                row.Cells[1].Value = fullname;
                row.Cells[2].Value = phoneNumber;
                row.Cells[3].Value = email;
            }
        }

        private void cbShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowPassword.Checked)
            {
                tbPassword.PasswordChar = '\0';
            }
            else
            {
                tbPassword.PasswordChar = '●';
            }
        }

        private void updateList(string keyword = null)
        {
            var employees = Service.employeeService.GetEmployees(keyword).OrderBy(x => x.Username).ToList();
            this.dtList.DataSource = employees;
            this.dtList.Columns[0].HeaderText = "Tên đăng nhập";
            this.dtList.Columns[1].HeaderText = "Họ tên";
            this.dtList.Columns[2].HeaderText = "Số điện thoại";
            this.dtList.Columns[3].HeaderText = "Email";
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

                this.pnUsername.Visible = true;
                this.pnFullname.Visible = true;
                this.pnPhoneNumber.Visible = true;
                this.pnEmail.Visible = true;
                this.pnLimit.Visible = true;
                this.pnPassword.Visible = false;
                this.btnAdd.Visible = false;
                this.btUpdate.Visible = true;
                this.btnDelete.Visible = true;
                this.btSkip.Visible = true;
                this.btSave.Visible = false;
                this.pnShowPassword.Visible = false;
                this.cbShowPassword.Visible = false;

                this.pnLimit.Enabled = false;

                this.dtList.ReadOnly = true;
                this.txtUsername.ReadOnly = true;
                this.tbFullname.ReadOnly = true;
                this.tbPhoneNumber.ReadOnly = true;
                this.txtEmail.ReadOnly = true;

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

            this.pnUsername.Visible = false;
            this.pnFullname.Visible = false;
            this.pnPhoneNumber.Visible = false;
            this.pnEmail.Visible = false;
            this.pnPassword.Visible = false;
            this.pnLimit.Visible = false;
            this.pnShowPassword.Visible = false;

            while (this.flpLitmitDetail.Controls.Count > 0)
            {
                Control control = this.flpLitmitDetail.Controls[0];
                this.flpLitmitDetail.Controls.Remove(control);
                control.Dispose();
            }

            this.txtUsername.Text = "";
            this.tbFullname.Text = "";
            this.tbPhoneNumber.Text = "";
            this.txtEmail.Text = "";
            this.tbPassword.Text = "";

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.btUpdate.FillColor = Color.DarkGray;
            this.flag = 2;
            this.updateFlag = true;

            this.pnUsername.Visible = true;
            this.pnFullname.Visible = false;
            this.pnPhoneNumber.Visible = false;
            this.pnEmail.Visible = false;
            this.pnLimit.Visible = true;
            this.pnPassword.Visible = false;
            this.btUpdate.Visible = true;
            this.btnDelete.Visible = false;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;
            this.pnShowPassword.Visible = false;
            this.cbShowPassword.Visible = false;

            this.dtList.Enabled = false;
            this.flpLitmitDetail.Enabled = true;
            this.pnLimit.Enabled = true;

            this.txtUsername.ReadOnly = true;

            while (this.flpLitmitDetail.Controls.Count > 0)
            {
                Control control = this.flpLitmitDetail.Controls[0];
                this.flpLitmitDetail.Controls.Remove(control);
                control.Dispose();
            }

            var username = this.txtUsername.Text;
            var employee = Service.employeeService.GetEmployeesByUserName(username);

            this.txtUsername.Text = employee.Username;

            var Limits = Service.functionService.GetFunctions();
            foreach (var item in Limits)
            {
                var tempCheckbox = new CheckBox();
                tempCheckbox.Name = "cb" + item.Id.ToString();
                tempCheckbox.Text = item.Name;
                tempCheckbox.ForeColor = Color.Black;
                tempCheckbox.Checked = employee.Functions.Contains(item.Id) ? true : false;
                tempCheckbox.Visible = true;
                tempCheckbox.Enabled = true;
                tempCheckbox.Margin = new Padding(5, 5, 0, 5);
                tempCheckbox.Padding = new Padding(0, 0, 0, 0);
                tempCheckbox.Size = new Size(313, 40);
                this.flpLitmitDetail.Controls.Add(tempCheckbox);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var username = this.txtUsername.Text;
            if (username.Equals(LoginSession.MyAccount.Username))
            {
                MessageBox.Show("Không thể xóa tài khoản của bạn", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult option = MessageBox.Show($"Bạn có muốn xóa loại câu hỏi đóng {username}", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (option == DialogResult.Yes)
            {
                var result = Service.employeeService.deleteEmployee(username);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                this.rowIndex = -1;
                this.updateList();
                MessageBox.Show("Xóa tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (this.updateFlag)
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

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
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

            this.pnUsername.Visible = false;
            this.pnFullname.Visible = false;
            this.pnPhoneNumber.Visible = false;
            this.pnEmail.Visible = false;
            this.pnPassword.Visible = false;
            this.pnLimit.Visible = false;
            this.pnShowPassword.Visible = false;

            while (this.flpLitmitDetail.Controls.Count > 0)
            {
                Control control = this.flpLitmitDetail.Controls[0];
                this.flpLitmitDetail.Controls.Remove(control);
                control.Dispose();
            }

            this.txtUsername.Text = "";
            this.tbFullname.Text = "";
            this.tbPhoneNumber.Text = "";
            this.txtEmail.Text = "";
            this.tbPassword.Text = "";
        }
    }
}
