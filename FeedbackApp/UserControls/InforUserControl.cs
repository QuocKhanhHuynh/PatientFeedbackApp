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
    public partial class InforUserControl : UserControl
    {
        private readonly MainForm mainForm;
        public InforUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;

            this.Size = this.mainForm.pnContent.Size;

            this.pnInfo.Location = new Point((this.Width - this.pnInfo.Width) / 2, (this.Height - this.pnInfo.Height) / 2);

            this.btSkip.PerformClick();
        }
        private void Update()
        {
            var account = Service.employeeService.GetEmployeesByUserName(LoginSession.MyAccount.Username);
            this.txtUsername.Text = account.Username;
            this.tbFullname.Text = account.Fullname;
            this.tbPhoneNumber.Text = account.PhoneNumber;
            this.txtEmail.Text = account.Email;
        }

        private void btSkip_Click(object sender, EventArgs e)
        {
            this.btUpdate.FillColor = Color.Silver;

            this.btUpdate.Visible = true;
            this.btSkip.Visible = false;
            this.btSave.Visible = false;

            this.txtUsername.ReadOnly = true;
            this.tbFullname.ReadOnly = true;
            this.tbPhoneNumber.ReadOnly = true;
            this.txtEmail.ReadOnly = true;

            this.Update();

        }

        private void btUpdate_Click(object sender, EventArgs e)
        {
            this.btUpdate.FillColor = Color.DarkGray;

            this.btUpdate.Visible = true;
            this.btSkip.Visible = true;
            this.btSave.Visible = true;

            this.txtUsername.ReadOnly = true;
            this.tbFullname.ReadOnly = false;
            this.tbPhoneNumber.ReadOnly = false;
            this.txtEmail.ReadOnly = false;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var username = this.txtUsername.Text.Trim();
            var fullname = this.tbFullname.Text.Trim();
            var phoneNumber = this.tbPhoneNumber.Text.Trim();
            var email = this.txtEmail.Text.Trim();

            if (fullname == null || fullname == "")
            {
                MessageBox.Show("Họ tên không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (phoneNumber == null || phoneNumber == "")
            {
                MessageBox.Show("Số điện thoại không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string pattern1 = @"^(84|0[3|5|7|8|9])+([0-9]{8})\b$";
            if (!Regex.IsMatch(phoneNumber, pattern1))
            {
                MessageBox.Show("Không đúng định dạng số điện thoại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (email == null || email == "")
            {
                MessageBox.Show("Email không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var data = new EmployeeUpdateModel()
            {
                Username = username,
                Fullname = fullname,
                Email = email,
                PhoneNumber = phoneNumber
            };
            var result = Service.employeeService.UpdateEmployee(data);
            if (!result.Status)
            {
                MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Update();
            MessageBox.Show("Chỉnh tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbPhoneNumber_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
