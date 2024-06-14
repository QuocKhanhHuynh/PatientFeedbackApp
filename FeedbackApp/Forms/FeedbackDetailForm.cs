using FeedbackApp.Data.Entities;
using FeedbackApp.Models.Feedback;
using FeedbackApp.Utilities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FeedbackApp.Forms
{
    public partial class FeedbackDetailForm : Form
    {
        private readonly FeedbackDetailViewModel feedbackDetailViewModel;
        public FeedbackDetailForm(FeedbackDetailViewModel feedbackDetailViewModel)
        {
            InitializeComponent();
            this.feedbackDetailViewModel = feedbackDetailViewModel;
            foreach (var item in this.feedbackDetailViewModel.CloseFeedbacks)
            {
                int index = 0;
                var categoryTitle = item.Key;

                var flpLarg = new FlowLayoutPanel();
                flpLarg.AutoSize = true;
                flpLarg.WrapContents = true;
                flpLarg.AutoScroll = false;
                flpLarg.Margin = new Padding(0, 0, 0, 20);
                flpLarg.Padding = new Padding(0, 0, 0, 0);
                flpLarg.FlowDirection = FlowDirection.TopDown;
                this.flpContent.Controls.Add(flpLarg);

                var lbQuestionTitle = new Label();
                lbQuestionTitle.AutoSize = false;
                lbQuestionTitle.MaximumSize = new Size(this.flpContent.Width - 22, 75);
                lbQuestionTitle.BackColor = Color.White;
                lbQuestionTitle.Margin = new Padding(0, 0, 0, 5);
                lbQuestionTitle.Padding = new Padding(0, 0, 0, 0);
                lbQuestionTitle.TextAlign = ContentAlignment.MiddleLeft;
                lbQuestionTitle.ForeColor = Color.White;
                lbQuestionTitle.Size = new Size(this.flpContent.Width - 22, 55);
                lbQuestionTitle.Visible = true;
                lbQuestionTitle.Text = $"{categoryTitle.Id}. {categoryTitle.Name}";
                lbQuestionTitle.BackColor = Color.FromArgb(0, 102, 204);
                lbQuestionTitle.BorderStyle = BorderStyle.FixedSingle;
                lbQuestionTitle.Font = new Font("Seogoe UI", 10, FontStyle.Bold);
                flpLarg.Controls.Add(lbQuestionTitle);

                foreach (var i in item.Value)
                {
                    index++;
                    var pnQuestion = new Guna.UI2.WinForms.Guna2Panel();
                    pnQuestion.Name = $"pn{i.CloseQuestionId}";
                    pnQuestion.Size = new Size(this.flpContent.Width - 32, 150);
                    pnQuestion.BorderRadius = 20;
                    pnQuestion.BorderThickness = 1;
                    pnQuestion.BorderColor = Color.Black;
                    pnQuestion.Margin = new Padding(5, 0, 5, 10);
                    pnQuestion.Padding = new Padding(0, 0, 0, 0);
                    pnQuestion.FillColor = Color.White;
                    pnQuestion.Visible = true;
                    pnQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Regular);
                    flpLarg.Controls.Add(pnQuestion);

                    var lbNameQuestion = new Label();
                    lbNameQuestion.AutoSize = false;
                    lbNameQuestion.MaximumSize = new Size(1400, 75);
                    lbNameQuestion.BackColor = Color.White;
                    lbNameQuestion.Margin = new Padding(30, 2, 2, 0);
                    lbNameQuestion.Padding = new Padding(0, 0, 0, 0);
                    lbNameQuestion.TextAlign = ContentAlignment.MiddleLeft;
                    lbNameQuestion.ForeColor = Color.Black;
                    lbNameQuestion.Size = new Size(this.flpContent.Width - 52, 55);
                    lbNameQuestion.Visible = true;
                    pnQuestion.Controls.Add(lbNameQuestion);
                    lbNameQuestion.Location = new Point(7, 7);
                    lbNameQuestion.Text = $"{index}. {i.CloseQuestionName}";
                    lbNameQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Bold);

                    var lbHr = new Label();
                    lbHr.BorderStyle = BorderStyle.FixedSingle;
                    lbHr.AutoSize = false;
                    lbHr.Margin = new Padding(0, 0, 0, 0);
                    lbHr.Padding = new Padding(0, 0, 10, 0);
                    lbHr.Size = new Size(this.flpContent.Width - 32, 1);
                    lbHr.Visible = true;
                    pnQuestion.Controls.Add(lbHr);
                    lbHr.Location = new Point(0, lbNameQuestion.Size.Height + 8);

                    var flpQuestionResult = new FlowLayoutPanel();
                    flpQuestionResult.Name = $"flp{i.CloseQuestionId}";
                    flpQuestionResult.AutoSize = false;
                    flpQuestionResult.FlowDirection = FlowDirection.LeftToRight;
                    flpQuestionResult.BackColor = Color.White;
                    flpQuestionResult.Margin = new Padding(2, 0, 2, 0);
                    flpQuestionResult.Padding = new Padding(0, 15, 0, 22);
                    flpQuestionResult.Size = new Size(this.flpContent.Width - 37, 70);
                    flpQuestionResult.Location = new Point(2, lbNameQuestion.Size.Height + 8);
                    //flpQuestionResult.Enabled = false;

                    var scoreType = Service.scoreService.GetScoreByTypeId(i.ScoreTypeId);
                    foreach (var s in scoreType)
                    {
                        var rbResult = new RadioButton();
                        rbResult.BackColor = Color.White;
                        rbResult.ForeColor = Color.Black;
                        rbResult.Name = $"rb{s.Id}";
                        rbResult.Size = new Size(250, 60);
                        rbResult.Margin = new Padding(30, 0, 0, 0);
                        rbResult.Padding = new Padding(0, 0, 0, 0);
                        rbResult.Text = s.Name;
                        if (s.Id == i.ScoreId)
                        {
                            rbResult.Checked = true;
                        }
                        //rbResult.Enabled = false;
                        rbResult.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                        flpQuestionResult.Controls.Add(rbResult);
                    }
                    pnQuestion.Controls.Add(flpQuestionResult);
                    flpLarg.Controls.Add(pnQuestion);
                }

            }
            if (this.feedbackDetailViewModel.OpenFeedbacks.Count > 0)
            {
                int openIndex = 0;
                var openCategoryTitle = $"Ý kiến từ bệnh nhân";

                var flpOpenLarg = new FlowLayoutPanel();
                flpOpenLarg.AutoSize = true;
                flpOpenLarg.WrapContents = true;
                flpOpenLarg.AutoScroll = false;
                flpOpenLarg.Margin = new Padding(0, 0, 0, 20);
                flpOpenLarg.Padding = new Padding(0, 0, 0, 0);
                flpOpenLarg.FlowDirection = FlowDirection.TopDown;
                this.flpContent.Controls.Add(flpOpenLarg);

                var lbOpenQuestionTitle = new Label();
                lbOpenQuestionTitle.AutoSize = false;
                lbOpenQuestionTitle.MaximumSize = new Size(this.flpContent.Width - 22, 75);
                lbOpenQuestionTitle.BackColor = Color.White;
                lbOpenQuestionTitle.Margin = new Padding(0, 0, 0, 5);
                lbOpenQuestionTitle.Padding = new Padding(0, 0, 0, 0);
                lbOpenQuestionTitle.TextAlign = ContentAlignment.MiddleLeft;
                lbOpenQuestionTitle.ForeColor = Color.White;
                lbOpenQuestionTitle.Size = new Size(this.flpContent.Width - 22, 55);
                lbOpenQuestionTitle.Visible = true;
                lbOpenQuestionTitle.Text = $"{openCategoryTitle}";
                lbOpenQuestionTitle.BackColor = Color.FromArgb(0, 102, 204);
                lbOpenQuestionTitle.BorderStyle = BorderStyle.FixedSingle;
                lbOpenQuestionTitle.Font = new Font("Seogoe UI", 10, FontStyle.Bold);
                flpOpenLarg.Controls.Add(lbOpenQuestionTitle);

                foreach (var item in this.feedbackDetailViewModel.OpenFeedbacks)
                {
                    openIndex++;
                    var pnOpenQuestion = new Guna.UI2.WinForms.Guna2Panel();
                    pnOpenQuestion.Size = new Size(this.flpContent.Width - 32, 150);
                    pnOpenQuestion.BorderThickness = 0;
                    pnOpenQuestion.BorderColor = Color.Black;
                    pnOpenQuestion.Margin = new Padding(5, 20, 5, 0);
                    pnOpenQuestion.Padding = new Padding(0, 0, 0, 0);
                    pnOpenQuestion.FillColor = Color.White;
                    pnOpenQuestion.Visible = true;
                    pnOpenQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Regular);

                    var lbOpenNameQuestion = new Label();
                    lbOpenNameQuestion.BorderStyle = BorderStyle.FixedSingle;
                    lbOpenNameQuestion.AutoSize = false;
                    lbOpenNameQuestion.MaximumSize = new Size(this.flpContent.Width - 32, 75);
                    lbOpenNameQuestion.BackColor = Color.White;
                    lbOpenNameQuestion.Margin = new Padding(0, 0, 0, 0);
                    lbOpenNameQuestion.Padding = new Padding(0, 0, 0, 0);
                    lbOpenNameQuestion.TextAlign = ContentAlignment.MiddleLeft;
                    lbOpenNameQuestion.ForeColor = Color.Black;
                    lbOpenNameQuestion.Size = new Size(this.flpContent.Width - 32, 55);
                    lbOpenNameQuestion.Visible = true;
                    pnOpenQuestion.Controls.Add(lbOpenNameQuestion);
                    lbOpenNameQuestion.Location = new Point(0, 0);
                    lbOpenNameQuestion.Text = $"{openIndex}. {item.OpenQuestionName}";
                    lbOpenNameQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Bold);

                    var tbQuestionResult = new Guna.UI2.WinForms.Guna2TextBox();
                    tbQuestionResult.BorderThickness = 1;
                    tbQuestionResult.BorderColor = Color.Black;
                    tbQuestionResult.Multiline = true;
                    tbQuestionResult.ScrollBars = ScrollBars.Vertical;
                    tbQuestionResult.Size = new Size(this.flpContent.Width - 32, 95);
                    tbQuestionResult.BackColor = Color.White;
                    tbQuestionResult.TextAlign = HorizontalAlignment.Left;
                    tbQuestionResult.ForeColor = Color.Black;
                    tbQuestionResult.Margin = new Padding(0, 0, 0, 0);
                    tbQuestionResult.Location = new Point(0, lbOpenNameQuestion.Size.Height);
                    tbQuestionResult.Font = new Font("Seogoe UI", 10, FontStyle.Regular);
                    tbQuestionResult.Text = item.Content;
                    tbQuestionResult.ReadOnly = true;

                    pnOpenQuestion.Controls.Add(tbQuestionResult);
                    flpOpenLarg.Controls.Add(pnOpenQuestion);
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var closeQuestions = new List<CloseFeedbackResultModel>();
            foreach (var item in this.feedbackDetailViewModel.CloseFeedbacks)
            {
                closeQuestions.AddRange(item.Value);
            }
            foreach(FlowLayoutPanel flpLarg in this.flpContent.Controls)
            {
                foreach(Control pnControl in  flpLarg.Controls)
                {
                    Panel pn = pnControl as Panel;
                    if (pn != null)
                    {
                        foreach(Control flpControl in pn.Controls)
                        {
                            FlowLayoutPanel flp = flpControl as FlowLayoutPanel;
                            if (flp != null)
                            {
                                short closeQuestionId = short.Parse(flp.Name.Substring(3));
                                var scoreId = (closeQuestions.FirstOrDefault(x => x.CloseQuestionId == closeQuestionId)).ScoreId;
                                foreach(RadioButton rb in flp.Controls)
                                {
                                    var rbId = short.Parse(rb.Name.Substring(2));
                                    if (rbId == scoreId)
                                    {
                                        rb.Checked = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
