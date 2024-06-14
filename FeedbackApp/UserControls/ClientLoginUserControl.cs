using FeedbackApp.Forms;
using FeedbackApp.Models.Feedback;
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
    public partial class ClientLoginUserControl : UserControl
    {
        private MainForm mainForm;
        public ClientLoginUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.tpClient.Size;
            var feedbackTypes = Service.feedbackTypeService.GetFeedbackTypes();
            foreach (var item in feedbackTypes)
            {
                var tempButton = new Guna.UI2.WinForms.Guna2Button();
                tempButton.Name = "bt" + item.Id.ToString();
                tempButton.Text = item.Name;
                tempButton.ForeColor = Color.Black;
                tempButton.FillColor = Color.White;
                tempButton.Visible = true;
                tempButton.Enabled = true;
                tempButton.Padding = new Padding(0, 0, 0, 0);
                tempButton.Margin = new Padding(0, 5, 0, 5);
                tempButton.Size = new Size(this.pnInfor.Width -1, 50);
                tempButton.BorderColor = Color.Black;
                tempButton.BorderRadius = 5;
                tempButton.BorderThickness = 1;
                tempButton.ImageSize = new Size(25, 25);
                tempButton.ImageAlign = HorizontalAlignment.Left;
                tempButton.TextAlign = HorizontalAlignment.Left;
                tempButton.Image = new Bitmap($"{Application.StartupPath}\\Images\\feedback.png");

                tempButton.Click += new EventHandler(bt_Click);
                this.flpFeedbackOption.Controls.Add(tempButton);

            }
            this.pnLogin.Height = this.pnInfor.Height + this.flpFeedbackOption.Size.Height + 30;

            this.pnLogin.Location = new Point((this.Width - this.pnLogin.Width) / 2, (this.Height - this.pnLogin.Height) / 2);

        }
        private bool isIsIsurance = false;
        private void bt_Click(object sender, EventArgs e)
        {
            var phoneNumber = this.tbPhoneNumber.Text.Trim();
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
            var dayNumberText = this.tbDayNumber.Text.Trim();
            if (dayNumberText == null || dayNumberText == "")
            {
                MessageBox.Show("Số ngày điều trị không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short dayNumber = short.Parse(dayNumberText);
            //bool isIsIsurance = false;
            bool isHasCheck = false;
            foreach (RadioButton item in this.flpIsInsurance.Controls)
            {
                if (item.Checked)
                {
                    isHasCheck = true;
                }
            }
            if (!isHasCheck)
            {
                MessageBox.Show("Sử dụng BHYT không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.mainForm.tpClient.Controls.Remove(this);
            this.Dispose();
            Guna.UI2.WinForms.Guna2Button bt = sender as Guna.UI2.WinForms.Guna2Button;
            var feedbackTypeId = bt.Name.Substring(2);
            ClientLoginSession.FeedbackResult = new FeedbackCreateModel();
            ClientLoginSession.FeedbackResult.DayNumber = dayNumber;
            ClientLoginSession.FeedbackResult.IsInsurance = this.isIsIsurance;
            ClientLoginSession.FeedbackResult.FeedbackTypeId = feedbackTypeId;
            ClientLoginSession.FeedbackResult.CloseFeedbacks = new List<CloseFeedbackCreateModel>();
            ClientLoginSession.FeedbackResult.OpenFeedbacks = new List<OpenFeedbackCreateModel>();
            var result1 = Service.clientService.CheckClient1(phoneNumber);
            if (result1.Status)
            {
                var result2 = Service.clientService.CheckClient2(phoneNumber, feedbackTypeId);
                if (!result2.Status)
                {
                    ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this.mainForm);
                    this.mainForm.tpClient.Controls.Add(clientLoginUserControl);
                    clientLoginUserControl.Dock = DockStyle.Fill;
                    MessageBox.Show("Bạn đã thực hiện đánh giá hôm nay với loại khảo sát này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (Control item in this.mainForm.tpClient.Controls)
                {
                    item.Visible = true;
                }
                ClientLoginSession.FeedbackLoad = Service.feedbackService.LoadFeedbackQuestion(feedbackTypeId);
                ClientLoginSession.Status = true;
                ClientLoginSession.ClientAccount = Service.clientService.GetClient(phoneNumber);
                ClientLoginSession.FeedbackResult.PhoneNumber = phoneNumber;


                this.mainForm.btNext.PerformClick();
            }
            else
            {
                ClientCreateUserControl clientCreateUserControl = new ClientCreateUserControl(this.mainForm, phoneNumber);
                this.mainForm.tpClient.Controls.Add(clientCreateUserControl);
                clientCreateUserControl.Dock = DockStyle.Fill;
            }
        }

        private void rbYes_CheckedChanged(object sender, EventArgs e)
        {
            this.isIsIsurance = true;
        }

        private void rbNo_CheckedChanged(object sender, EventArgs e)
        {
            this.isIsIsurance = false;
        }

        private void tbPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbDayNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
