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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.UserControls
{
    public partial class LoginUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public LoginUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.tpAdmin.Size;

            this.pnLogin.Location = new Point((this.Width - this.pnLogin.Width) / 2, (this.Height - this.pnLogin.Height) / 2);
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var username = tbUsername.Text.Trim();
            var password = tbPassword.Text.Trim();
            if (username == null || username == "")
            {
                MessageBox.Show("Tên đăng nhập không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (password == null || password == "")
            {
                MessageBox.Show("Mật khẩu không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = new LoginModel()
            {
                Username = username,
                Password = password
            };

            var result = Service.employeeService.Login(data);
            if (result.Status)
            {
                LoginSession.Status = true;
                LoginSession.MyAccount = Service.employeeService.GetEmployeesByUserName(username);
                this.mainForm.tpAdmin.Controls.Remove(this);
                this.Dispose();
                foreach (Control item in this.mainForm.tpAdmin.Controls)
                {
                    item.Visible = true;
                }
                
                foreach (Control item in this.mainForm.flpMenu.Controls)
                {
                    
                    if (LoginSession.MyAccount.Functions.Contains(short.Parse(item.Name[item.Name.Length - 1].ToString())))
                    {
                        item.Visible = true;
                    }
                    else
                    {
                        item.Visible = false;
                    }
                    if (item.Name[item.Name.Length - 1] == '4')
                    {
                        item.Visible = true;
                    }
                }
                this.mainForm.btMyInfor.PerformClick();
                return;
            }
            else
            {
                MessageBox.Show($"{result.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
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
    }
}
