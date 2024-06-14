using FeedbackApp.Forms;
using FeedbackApp.Models.Employee;
using FeedbackApp.Utilities;
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

namespace FeedbackApp.UserControls
{
    public partial class PasswordUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public PasswordUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;
            

            this.pnInfo.Location = new Point((this.Width - this.pnInfo.Width) / 2, (this.Height - this.pnInfo.Height) / 2);
        }

        private void cbShowOldPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowOldPassword.Checked)
            {
                tbOldPassword.PasswordChar = '\0';
            }
            else
            {
                tbOldPassword.PasswordChar = '●';
            }
        }

        private void cbShowNewPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (cbShowNewPassword.Checked)
            {
                tbNewPassword.PasswordChar = '\0';
            }
            else
            {
                tbNewPassword.PasswordChar = '●';
            }
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var currentPass = this.tbOldPassword.Text.Trim();
            var confirmPass = this.tbConfirmPassword.Text.Trim();
            var newPass = this.tbNewPassword.Text.Trim();
            var pattern = @"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";


            if (currentPass == null || currentPass == "")
            {
                MessageBox.Show("Mật khẩu cũ không được rỗng!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (newPass == null || newPass == "")
            {
                MessageBox.Show("Mật khẩu mới không được rỗng!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!Regex.IsMatch(newPass, pattern))
            {
                MessageBox.Show("Mật khẩu mới phải có ít nhất 8 ký tự. Có ít nhất 1 chữ cái in hoa, 1 chữ cái thường, 1 ký tự đặc biệt", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (confirmPass == null || confirmPass == "")
            {
                MessageBox.Show("Mật khẩu xác nhận không được rỗng!", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!confirmPass.Equals(newPass))
            {
                MessageBox.Show("Mật khẩu xác nhận và mật khẩu mới không khớp", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = new EmployeePasswordUpdateModel()
            {
                oldPassword = currentPass,
                newPassword = newPass,
                Username = LoginSession.MyAccount.Username
            };
            var result = Service.employeeService.updatePassword(data);

            if (!result.Status)
            {
                MessageBox.Show($"{result.Message}", "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.tbNewPassword.Text = "";
            this.tbOldPassword.Text = "";
            this.tbConfirmPassword.Text = "";
            MessageBox.Show("Chỉnh mật khẩu thành công", "Thông báo kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
