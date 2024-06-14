using FeedbackApp.Data.Entities;
using FeedbackApp.Forms;
using FeedbackApp.Models.Client;
using FeedbackApp.Models.Feedback;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.UserControls
{
    public partial class ClientCreateUserControl : UserControl
    {
        private readonly MainForm mainForm;
        private readonly string PhoneNumber;
        public ClientCreateUserControl(MainForm mainForm, string phoneNumber)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            PhoneNumber = phoneNumber;

            this.Size = this.mainForm.tpClient.Size;

            this.pnLeft.Size = new Size((this.Width - this.pnInfo.Width) / 2, this.pnInfo.Height);
            this.pnRight.Size = new Size((this.Width - this.pnInfo.Width) / 2, this.pnInfo.Height);
            this.pnTop.Height = (this.Height - this.pnInfo.Height) / 2;
            this.pnBottom.Height = (this.Height - this.pnInfo.Height) / 2;
            this.pnInfo.Dock = DockStyle.Fill;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            var fullName = this.tbFullname.Text.Trim();
            if (fullName == null || fullName == "")
            {
                MessageBox.Show("Họ tên không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string gender = null;
            foreach (RadioButton item in this.pnGenderResult.Controls)
            {
                if (item.Checked)
                {
                    gender = item.Text;
                }
            }
            if (gender == null)
            {
                MessageBox.Show("Giới tính không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ageText = this.tbAge.Text.Trim();
            if (ageText == null || ageText == "")
            {
                MessageBox.Show("Tuổi không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short age;
            var ageConvert = short.TryParse(ageText, out age);
            if (!ageConvert)
            {
                MessageBox.Show("Tuổi phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*
            bool isInsurance = false;
            bool hasCheckInsurance = false;
            foreach (RadioButton item in this.pnInsuranceResult.Controls)
            {
                if (item.Checked)
                {
                    hasCheckInsurance = true;
                    if (item.Name.Equals("Có"))
                    {
                        isInsurance = true;
                        break;
                    }
                }
            }
            if (!hasCheckInsurance)
            {
                MessageBox.Show("Sử dụng bảo hiểm y tế không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string DayNumberText = this.tbDayNumber.Text.Trim();
            if (DayNumberText == null || DayNumberText == "")
            {
                MessageBox.Show("Số ngày điều trị không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short dayNumber;
            var dayNumberConvert = short.TryParse(DayNumberText, out dayNumber);
            if (!dayNumberConvert)
            {
                MessageBox.Show("Số ngày điều trị phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            */
            string distancetext = this.tbDistance.Text.Trim();
            if (distancetext == null || distancetext == "")
            {
                MessageBox.Show("Khoảng cách đến bệnh viện không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short distance;
            var distanceConvert = short.TryParse(distancetext, out distance);
            if (!distanceConvert)
            {
                MessageBox.Show("Khoảng cách đến bệnh viện phải là số", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var data = new ClientCreateModel()
            {
                PhoneNumber = this.PhoneNumber,
                Age = age,
                Gender = gender,
                Distance = distance,
                FullName = fullName,
            };
            var result = Service.clientService.CreateClient(data);
            if (!result.Status)
            {
                MessageBox.Show($"{result.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.mainForm.tpClient.Controls.Remove(this);
            this.Dispose();
            foreach (Control item in this.mainForm.tpClient.Controls)
            {
                item.Visible = true;
            }
            ClientLoginSession.Status = true;
            ClientLoginSession.ClientAccount = Service.clientService.GetClient(this.PhoneNumber);
            ClientLoginSession.FeedbackResult = new FeedbackCreateModel();
            ClientLoginSession.FeedbackResult.PhoneNumber = this.PhoneNumber;
            ClientLoginSession.FeedbackResult.CloseFeedbacks = new List<CloseFeedbackCreateModel>();
            ClientLoginSession.FeedbackResult.OpenFeedbacks = new List<OpenFeedbackCreateModel>();
            ClientLoginSession.FeedbackLoad = Service.feedbackService.LoadFeedbackQuestion(ClientLoginSession.FeedbackResult.FeedbackTypeId);

            this.mainForm.btNext.PerformClick();
        }

        private void btSkip_Click(object sender, EventArgs e)
        {
            tbFullname.Text = "";
            tbAge.Text = "";
            tbDistance.Text = "";
            foreach (RadioButton item in this.pnGenderResult.Controls)
            {
                item.Checked = false;
            }
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.mainForm.tpClient.Controls.Remove(this);
            this.Dispose();
            ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this.mainForm);
            this.mainForm.tpClient.Controls.Add(clientLoginUserControl);
            clientLoginUserControl.Dock = DockStyle.Fill;
        }

        private void btSubmit_Click(object sender, EventArgs e)
        {
            var fullName = this.tbFullname.Text.Trim();
            if (fullName == null || fullName == "")
            {
                MessageBox.Show("Họ tên không được rỗng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string gender = null;
            foreach (RadioButton item in this.pnGenderResult.Controls)
            {
                if (item.Checked)
                {
                    gender = item.Text;
                }
            }
            if (gender == null)
            {
                MessageBox.Show("Giới tính không được bỏ qua", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string ageText = this.tbAge.Text.Trim();
            if (ageText == null || ageText == "")
            {
                MessageBox.Show("Tuổi không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short age = short.Parse(ageText);
            string distancetext = this.tbDistance.Text.Trim();
            if (distancetext == null || distancetext == "")
            {
                MessageBox.Show("Khoảng cách đến bệnh viện không được rỗng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            short distance = short.Parse(distancetext);
            var data = new ClientCreateModel()
            {
                PhoneNumber = this.PhoneNumber,
                Age = age,
                Gender = gender,
                Distance = distance,
                FullName = fullName,
            };
            var result = Service.clientService.CreateClient(data);
            if (!result.Status)
            {
                MessageBox.Show($"{result.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.mainForm.tpClient.Controls.Remove(this);
            this.Dispose();
            foreach (Control item in this.mainForm.tpClient.Controls)
            {
                item.Visible = true;
            }
            ClientLoginSession.FeedbackLoad = Service.feedbackService.LoadFeedbackQuestion(ClientLoginSession.FeedbackResult.FeedbackTypeId);
            ClientLoginSession.Status = true;
            ClientLoginSession.ClientAccount = Service.clientService.GetClient(this.PhoneNumber);
            ClientLoginSession.FeedbackResult.PhoneNumber = this.PhoneNumber;
            this.mainForm.btNext.PerformClick();
        }

        private void btDestroy_Click(object sender, EventArgs e)
        {
            this.mainForm.tpClient.Controls.Remove(this);
            this.Dispose();
            ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this.mainForm);
            this.mainForm.tpClient.Controls.Add(clientLoginUserControl);
            clientLoginUserControl.Dock = DockStyle.Fill;
        }

        private void tbAge_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbDistance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
