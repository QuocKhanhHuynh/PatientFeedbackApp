using FeedbackApp.Forms;
using FeedbackApp.Models.Common;
using FeedbackApp.Models.Feedback;
using FeedbackApp.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.UserControls
{
    public partial class FeedbackStatisticsUserControl : UserControl
    {
        private readonly MainForm mainForm;
        private List<FeedbackStatisticsModel> Data { get; set; }
        public FeedbackStatisticsUserControl(MainForm mainForm)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.Size = this.mainForm.pnContent.Size;
            this.dtpStart1.Value = new DateTime(2024, 1, 1);
            this.dtpEnd1.Value = DateTime.Now;
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

            this.cbInsurance1.DataSource = insuranceses;
            this.cbInsurance1.DisplayMember = "Name";

            this.pnLooking1.Dock = DockStyle.Fill;
            //this.pnLooking.Controls.Add(this.pnLookingDetail1);


            this.pnLookingDetail1.Location = new Point((this.pnLooking1.Width - this.pnLookingDetail1.Width) / 2, (this.pnLooking1.Height - this.pnLookingDetail1.Height) / 2);

            this.btSkip.PerformClick();
        }

        private int rowIndex = -1;
        private bool selectFlag;
        private void updateList(string keyword = null)
        {
            Insurance isurance = (Insurance)this.cbInsurance1.SelectedValue;
            List<FeedbackStatisticsModel> feedbacks = null;
            if (isurance == null)
            {
                feedbacks = Service.feedbackService.CompileFeedback(this.dtpStart1.Value, this.dtpEnd1.Value).OrderByDescending(x => x.FeedbackTypeId).ToList();
            }
            else
            {
                feedbacks = Service.feedbackService.CompileFeedback(this.dtpStart1.Value, this.dtpEnd1.Value, isurance.Value).OrderByDescending(x => x.FeedbackTypeId).ToList();
            }
            this.Data = feedbacks;
            this.dtList.DataSource = feedbacks;
            this.dtList.Columns[0].HeaderText = "Mã loại phản hồi";
            this.dtList.Columns[1].HeaderText = "Tên loại phản hồi";
            this.dtList.Columns[2].HeaderText = "Số lượng đánh giá";

            this.dtList.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

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
            this.pnNumber.Visible = false;

            this.dtList.Enabled = true;
            this.dtpStart1.Enabled = true;
            this.dtpEnd1.Enabled = true;
            this.cbInsurance1.Enabled = true;

            this.tbId.Text = "";
            this.tbFeedbackType.Text = "";
            this.tbNumber.Text = "";
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
            var feedback = this.Data[rowIndex];

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnNumber.Visible = true;

            this.btSkip.Visible = true;
            this.btView.Visible = true;

            this.dtpStart1.Enabled = false;
            this.dtpEnd1.Enabled = false;
            this.cbInsurance1.Enabled = false;

            if (feedback.FeedbackNumber == 0)
            {
                this.btView.Enabled = false;
            }
            else
            {
                this.btView.Enabled = true;
            }

            this.tbId.Text = feedback.FeedbackTypeId;
            this.tbFeedbackType.Text = feedback.FeedbackName;
            this.tbNumber.Text = feedback.FeedbackNumber.ToString();

            this.rowIndex = rowIndex;
            this.updatePageNumber();
        }

        private void selectRow(int index)
        {
            this.selectFlag = true;
            var feedback = this.Data[index];

            this.pnId.Visible = true;
            this.pnName.Visible = true;
            this.pnNumber.Visible = true;

            this.btSkip.Visible = true;
            this.btView.Visible = true;

            this.dtpStart1.Enabled = false;
            this.dtpEnd1.Enabled = false;
            this.cbInsurance1.Enabled = false;

            this.tbId.Text = feedback.FeedbackTypeId;
            this.tbFeedbackType.Text = feedback.FeedbackName;
            this.tbNumber.Text = feedback.FeedbackNumber.ToString();

            //this.rowIndex = rowIndex;
            this.dtList.Rows[rowIndex].Selected = true;
            this.updatePageNumber();
        }

        private void btExport_Click(object sender, EventArgs e)
        {
            if (this.rowIndex == -1)
            {
                return;
            }
            Insurance isurance = (Insurance)this.cbInsurance1.SelectedValue;
            FeedbackStatisticsDetailForm feedbackStatisticsDetailForm = new FeedbackStatisticsDetailForm(this.dtpStart1.Value, this.dtpEnd1.Value, this.tbId.Text, this.tbFeedbackType.Text, isurance.Value);
            for (int i = 0; i < feedbackStatisticsDetailForm.Data.Count(); i++)
            {
                if (i != 0)
                {
                    feedbackStatisticsDetailForm.btRight.PerformClick();
                }
                feedbackStatisticsDetailForm.btExport.PerformClick();
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

        private void btLooking_Click(object sender, EventArgs e)
        {
            this.btSkip.PerformClick();
        }

        private void btView_Click(object sender, EventArgs e)
        {
            this.btView.FillColor = Color.DarkGray;
            Insurance isurance = (Insurance)this.cbInsurance1.SelectedValue;
            List<FeedbackStatisticsModel> feedbacks = null;
            FeedbackStatisticsDetailForm feedbackStatisticsDetailForm = new FeedbackStatisticsDetailForm(this.dtpStart1.Value, this.dtpEnd1.Value, this.tbId.Text, this.tbFeedbackType.Text, isurance.Value);
            feedbackStatisticsDetailForm.ShowDialog();
            this.btView.FillColor = Color.Silver;
        }

        private void btReLoad_Click(object sender, EventArgs e)
        {
            this.dtpStart1.Value = new DateTime(2024, 1, 1);
            this.dtpEnd1.Value = DateTime.Now;
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

            this.cbInsurance1.DataSource = insuranceses;
            this.cbInsurance1.DisplayMember = "Name";

            this.rowIndex = -1;
            this.updateList();

            this.btView.Visible = false;
            this.btSkip.Visible = false;

            this.pnId.Visible = false;
            this.pnName.Visible = false;
            this.pnNumber.Visible = false;

            this.dtList.Enabled = true;
            this.dtpStart1.Enabled = true;
            this.dtpEnd1.Enabled = true;
            this.cbInsurance1.Enabled = true;

            this.tbId.Text = "";
            this.tbFeedbackType.Text = "";
            this.tbNumber.Text = "";
        }

        private void btLooking_Click_1(object sender, EventArgs e)
        {
            this.btSkip.PerformClick();
        }

    }
}
