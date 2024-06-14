using FeedbackApp.Forms;
using FeedbackApp.Models.Common;
using FeedbackApp.Models.Feedback;
using FeedbackApp.Utilities;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.UserControls
{
    public partial class FeedbackUserControl : UserControl
    {
        private readonly MainForm mainForm;
        private bool selectFlag;
        public FeedbackUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;
            this.dtpStart.Value = new DateTime(2024, 1, 1);
            this.dtpEnd.Value = DateTime.Now;
            List<Insurance> insuranceses = new List<Insurance>()
            {
                new Insurance()
                {
                    Name = "Lọc BHYT",
                    Value = null
                },
                new Insurance()
                {
                    Name = "Có BHYT",
                    Value = true
                },
                new Insurance()
                {
                    Name = "Không BHYT",
                    Value = false
                }
            };

            this.cbInsurance.DataSource = insuranceses;
            this.cbInsurance.DisplayMember = "Name";

            this.pnLooking.Dock = DockStyle.Fill;
            this.pnLooking.Controls.Add(this.pnLookingDetail);

            this.pnLookingDetail.Location = new Point((this.pnLooking.Width - this.pnLookingDetail.Width) / 2, (this.pnLooking.Height - this.pnLookingDetail.Height) / 2);

            this.btSkip.PerformClick();
        }
        private int rowIndex = -1;
        private void updateList(string keyword = null)
        {
            Insurance isurance = (Insurance)this.cbInsurance.SelectedValue;
            List<FeedbackViewModel> feedbacks = null;
            if (isurance != null)
            {
                feedbacks = Service.feedbackService.GetFeedbacks(this.dtpStart.Value, this.dtpEnd.Value, isurance.Value).OrderByDescending(x => x.FeedbackDate).ToList();
            }
            else
            {
                feedbacks = Service.feedbackService.GetFeedbacks(this.dtpStart.Value, this.dtpEnd.Value).OrderByDescending(x => x.FeedbackDate).ToList();
            }
            this.dtList.DataSource = feedbacks;
            this.dtList.Columns[0].HeaderText = "Mã phản hồi";
            this.dtList.Columns[1].HeaderText = "Loại phản hồi";
            this.dtList.Columns[2].HeaderText = "Ngày thực hiện";
            this.dtList.Columns[3].HeaderText = "Sử dụng bảo hiểm";
            this.dtList.Columns[4].HeaderText = "Số ngày điều trị";

            this.dtList.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dtList.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.updatePageNumber();
            this.dtList.ClearSelection();
            if (this.rowIndex > -1)
            {
                this.dtList.Rows[this.rowIndex].Selected = true;
            }
        }
        private void btSkip_Click(object sender, EventArgs e)
        {
            if (this.selectFlag)
            {
                this.selectFlag = false;

                this.rowIndex = -1;
                this.updatePageNumber();
                this.dtList.ClearSelection();
            }
            else
            {
                this.rowIndex = -1;
                this.updateList();
            }
           

            this.btView.Visible = false;
            this.btSkip.Visible = false;

            this.pnId.Visible = false;
            this.pnName.Visible = false;
            this.pnCreateDate.Visible = false;
            this.pnPhoneNumber.Visible = false;
            this.pnFullName.Visible = false;
            this.pnAge.Visible = false;
            this.pnGender.Visible = false;
            this.pnDistance.Visible = false;
            this.pnDayNumber.Visible = false;
            this.pnIsInsurance.Visible = false;

            this.dtList.Enabled = true;
            this.dtpStart.Enabled = true;
            this.dtpEnd.Enabled = true;
            this.cbInsurance.Enabled = true;

            this.tbId.Text = "";
            this.tbFeedbackType.Text = "";
            this.tbCreateDate.Text = "";
            this.tbPhoneNumber.Text = "";
            this.tbFullName.Text = "";
            this.tbAge.Text = "";
            this.tbGender.Text = "";
            this.tbDistance.Text = "";
            this.tbDayNumber.Text = "";
            this.tbIsInsurance.Text = "";
        }
        private void updatePageNumber()
        {
            int rowNumber = this.dtList.RowCount;
            this.tbPageNumber.Text = $"{this.rowIndex + 1}/{rowNumber}";
        }

        private void dtList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.selectFlag = true;
            int rowIndex = this.dtList.CurrentCell.RowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            long id = long.Parse(this.dtList.Rows[rowIndex].Cells[0].Value.ToString());
            var feedback = Service.feedbackService.GetFeedbackById(id);

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnCreateDate.Visible = true;
            this.pnPhoneNumber.Visible = true;
            this.pnFullName.Visible = true;
            this.pnAge.Visible = true;
            this.pnGender.Visible = true;
            this.pnDistance.Visible = true;
            this.pnDayNumber.Visible = true;
            this.pnIsInsurance.Visible = true;

            this.btSkip.Visible = true;
            this.btView.Visible = true;

            this.dtpStart.Enabled = false;
            this.dtpEnd.Enabled = false;
            this.cbInsurance.Enabled = false;

            this.tbId.Text = feedback.Id.ToString();
            this.tbFeedbackType.Text = feedback.FeebackTypeId;
            this.tbCreateDate.Text = feedback.FeedbackDate.ToString();
            this.tbPhoneNumber.Text = feedback.PhoneNumber;
            this.tbFullName.Text = feedback.FullName;
            this.tbAge.Text = feedback.Age.ToString();
            this.tbGender.Text = feedback.Gender;
            this.tbDistance.Text = feedback.Distance.ToString();
            this.tbDayNumber.Text = feedback.DayNumber.ToString();
            this.tbIsInsurance.Text = feedback.IsInsurance == true ? "Có" : "Không";

            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }

        private void selectRow(int index)
        {
            this.selectFlag = true;
            this.dtList.Rows[index].Selected = true;
            long id = long.Parse(this.dtList.Rows[index].Cells[0].Value.ToString());
            var feedback = Service.feedbackService.GetFeedbackById(id);

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnCreateDate.Visible = true;
            this.pnPhoneNumber.Visible = true;
            this.pnFullName.Visible = true;
            this.pnAge.Visible = true;
            this.pnGender.Visible = true;
            this.pnDistance.Visible = true;
            this.pnDayNumber.Visible = true;
            this.pnIsInsurance.Visible = true;

            this.btSkip.Visible = true;
            this.btView.Visible = true;

            this.dtpStart.Enabled = false;
            this.dtpEnd.Enabled = false;
            this.cbInsurance.Enabled = false;

            this.tbId.Text = feedback.Id.ToString();
            this.tbFeedbackType.Text = feedback.FeebackTypeId;
            this.tbCreateDate.Text = feedback.FeedbackDate.ToString();
            this.tbPhoneNumber.Text = feedback.PhoneNumber;
            this.tbFullName.Text = feedback.FullName;
            this.tbAge.Text = feedback.Age.ToString();
            this.tbGender.Text = feedback.Gender;
            this.tbDistance.Text = feedback.Distance.ToString();
            this.tbDayNumber.Text = feedback.DayNumber.ToString();
            this.tbIsInsurance.Text = feedback.IsInsurance == true ? "Có" : "Không";

            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (this.sfdExport.ShowDialog() == DialogResult.OK)
            {
                //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                Excel.toExcel(this.dtList, this.sfdExport.FileName);
            }
        }

        private void btStartRow_Click(object sender, EventArgs e)
        {
            this.rowIndex = 0;
            this.selectRow(0);
        }

        private void btEndRow_Click(object sender, EventArgs e)
        {
            this.rowIndex = this.dtList.RowCount - 1;
            selectRow(this.dtList.RowCount - 1);
        }

        private void btPreviousRow_Click(object sender, EventArgs e)
        {
            if (this.rowIndex - 1 >= 0)
            {
                this.dtList.Rows[this.rowIndex].Selected = false;
                this.rowIndex--;
                selectRow(this.rowIndex);
            }
        }

        private void btNextRow_Click(object sender, EventArgs e)
        {
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

        private void btView_Click(object sender, EventArgs e)
        {
            this.btView.FillColor = Color.DarkGray;
            var id = long.Parse(this.tbId.Text.Trim());
            var feebackDetailViewModel = Service.feedbackService.GetFeedbackDetail(id);
            FeedbackDetailForm feedbackDetailForm = new FeedbackDetailForm(feebackDetailViewModel);
            feedbackDetailForm.ShowDialog();
            this.btView.FillColor = Color.Silver;

        }

        private void btLooking_Click(object sender, EventArgs e)
        {
            this.btSkip.PerformClick();
        }

        private void btReLoad_Click(object sender, EventArgs e)
        {
            this.dtpStart.Value = new DateTime(2024, 1, 1);
            this.dtpEnd.Value = DateTime.Now;
            List<Insurance> insuranceses = new List<Insurance>()
            {
                new Insurance()
                {
                    Name = "Lọc BHYT",
                    Value = null
                },
                new Insurance()
                {
                    Name = "Có BHYT",
                    Value = true
                },
                new Insurance()
                {
                    Name = "Không BHYT",
                    Value = false
                }
            };

            this.cbInsurance.DataSource = insuranceses;
            this.cbInsurance.DisplayMember = "Name";

            this.rowIndex = -1;
            this.updateList();

            this.btView.Visible = false;
            this.btSkip.Visible = false;

            this.pnId.Visible = false;
            this.pnName.Visible = false;
            this.pnCreateDate.Visible = false;
            this.pnPhoneNumber.Visible = false;
            this.pnFullName.Visible = false;
            this.pnAge.Visible = false;
            this.pnGender.Visible = false;
            this.pnDistance.Visible = false;
            this.pnDayNumber.Visible = false;
            this.pnIsInsurance.Visible = false;

            this.dtList.Enabled = true;
            this.dtpStart.Enabled = true;
            this.dtpEnd.Enabled = true;
            this.cbInsurance.Enabled = true;

            this.tbId.Text = "";
            this.tbFeedbackType.Text = "";
            this.tbCreateDate.Text = "";
            this.tbPhoneNumber.Text = "";
            this.tbFullName.Text = "";
            this.tbAge.Text = "";
            this.tbGender.Text = "";
            this.tbDistance.Text = "";
            this.tbDayNumber.Text = "";
            this.tbIsInsurance.Text = "";
        }
    }
}
