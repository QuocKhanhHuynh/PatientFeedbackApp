using FeedbackApp.Data.Entities;
using FeedbackApp.Models.Feedback;
using FeedbackApp.UserControls;
using FeedbackApp.Utilities;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;

namespace FeedbackApp.Forms
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            
            this.tbFeedback.SelectedIndex = 0;

            this.tbFeedback_SelectedIndexChanged(this.tbFeedback, EventArgs.Empty);

            /*
            if (this.tbFeedback.SelectedIndex == 0)
            {
                if (!ClientLoginSession.Status)
                {
                    this.loadLoginClient();
                }
            }
            */
        }
        private void tbFeedback_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tbFeedback.SelectedIndex == 0)
            {
                if (!ClientLoginSession.Status)
                {
                    this.loadLoginClient();
                }
            }
            else
            {
                if (!LoginSession.Status)
                {
                    this.loadLogin();
                }

            }
        }
        private void btFuction_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btFuction.FillColor = Color.Gainsboro;

            FunctionUserControl functionUserControl = new FunctionUserControl(this);
            this.clearControl(functionUserControl);
        }


        private void btEmployee_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btEmployee.FillColor = Color.Gainsboro;
            EmployeeUserControl employeeUserControl = new EmployeeUserControl(this);
            this.clearControl(employeeUserControl);
        }

        private void btFeedbackType_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btFeedbackType.FillColor = Color.Gainsboro;
            FeedbackTypeUserControl feedbackTypeUserControl = new FeedbackTypeUserControl(this);
            this.clearControl(feedbackTypeUserControl);
        }

        private void clearControl(Control usercontrol)
        {
            while (this.pnContent.Controls.Count > 0)
            {
                Control control = this.pnContent.Controls[0];
                this.pnContent.Controls.Remove(control);
                control.Dispose();
            }
            this.pnContent.Controls.Add(usercontrol);
            usercontrol.Dock = DockStyle.Fill;
        }

        private void btEvaluationLevelType_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btEvaluationLevelType.FillColor = Color.Gainsboro;
            ScoreTypeUserControl scoreTypeUserControl = new ScoreTypeUserControl(this);
            this.clearControl(scoreTypeUserControl);
        }

        private void btEvaluationLevel_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btEvaluationLevel.FillColor = Color.Gainsboro;
            ScoreUserControl scoreUserControl = new ScoreUserControl(this);
            this.clearControl(scoreUserControl);
        }

        private void btCloseQuestion_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btCloseQuestion.FillColor = Color.Gainsboro;
            CloseQuestionCategoryUserControl closeQuestionCategoryUserControl = new CloseQuestionCategoryUserControl(this);
            this.clearControl(closeQuestionCategoryUserControl);
        }

        private void btQuestionCloseType_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btQuestionCloseType.FillColor = Color.Gainsboro;
            CloseQuestionUserControl closeQuestionUserControl = new CloseQuestionUserControl(this);
            this.clearControl(closeQuestionUserControl);
        }

        private void btOpenQuestion_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btOpenQuestion.FillColor = Color.Gainsboro;
            OpenQuestionUserControl openQuestionUserControl = new OpenQuestionUserControl(this);
            this.clearControl(openQuestionUserControl);
        }

        private void btMyInfor_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btMyInfor.FillColor = Color.Gainsboro;
            InforUserControl inforUserControl = new InforUserControl(this);
            this.clearControl(inforUserControl);
        }

        private void loadLogin()
        {
            foreach (Control item in this.tpAdmin.Controls)
            {
                item.Visible = false;
            }
            LoginUserControl loginUserControl = new LoginUserControl(this);
            this.tpAdmin.Controls.Add(loginUserControl);
            loginUserControl.Dock = DockStyle.Fill;
        }

        private void btLogout_Click(object sender, EventArgs e)
        {
            LoginSession.Status = false;
            LoginSession.MyAccount = null;
            loadLogin();
        }

        private void updateColorButton()
        {
            this.btListFeedback.FillColor = Color.White;
            this.btStatistics.FillColor = Color.White;
            this.btFeedbackType.FillColor = Color.White;
            this.btListFeedback.FillColor = Color.White;
            this.btEvaluationLevelType.FillColor = Color.White;
            this.btEvaluationLevel.FillColor = Color.White;
            this.btQuestionCloseType.FillColor = Color.White;
            this.btCloseQuestion.FillColor = Color.White;
            this.btOpenQuestion.FillColor = Color.White;
            this.btEmployee.FillColor = Color.White;
            this.btFuction.FillColor = Color.White;
            this.btMyInfor.FillColor = Color.White;
            this.btPassword.FillColor = Color.White;
            this.btListFeedback.FillColor = Color.White;
            this.btStatistics.FillColor = Color.White;
        }

        private void btPassword_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btPassword.FillColor = Color.Gainsboro;
            PasswordUserControl passwordUserControl = new PasswordUserControl(this);
            this.clearControl(passwordUserControl);
        }

        private void loadLoginClient()
        {
            foreach (Control item in this.tpClient.Controls)
            {
                item.Visible = false;
            }
            ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this);
            this.tpClient.Controls.Add(clientLoginUserControl);
            clientLoginUserControl.Dock = DockStyle.Fill;
        }

        private int currentNumberQuestion = 0;
        private void btNext_Click(object sender, EventArgs e)
        {
            if (ClientLoginSession.FeedbackLoad.OpenFeedbacks.Count == 0 && ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count == 0)
            {
                this.label2.Visible = false;
                this.tbPageNumber.Visible = false;
                this.tbQuestionNumber.Visible = false;
                this.tbPrevious.Visible = false;
                this.btNext.Visible = false;

                return;
            }
            this.label2.Visible = true;
            this.tbPageNumber.Visible = true;
            this.tbQuestionNumber.Visible = true;
            if (ClientLoginSession.CategoryIndex > 0 && ClientLoginSession.CategoryIndex < ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count + 1)
            {
                short i = 0;
                string index = "";
                foreach (Guna.UI2.WinForms.Guna2Panel pn in this.flpContent.Controls)
                {
                    i++;
                    bool flag = false;
                    foreach (Control ctr in pn.Controls)
                    {
                        FlowLayoutPanel flp = ctr as FlowLayoutPanel;
                        if (flp != null)
                        {
                            foreach (RadioButton rb in flp.Controls)
                            {
                                if (rb.Checked)
                                {

                                    flag = true;
                                    break;
                                }
                            }
                        }
                    }
                    if (!flag)
                    {
                        index += $"{i} ";
                    }
                }
                if (index != "")
                {
                    MessageBox.Show("Bạn chưa đánh giá câu hỏi số " + index, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (Guna.UI2.WinForms.Guna2Panel pn in this.flpContent.Controls)
                {
                    short closeQuestionId = short.Parse(pn.Name.Substring(2));
                    short scoreId = 0;
                    foreach (Control ctr in pn.Controls)
                    {
                        FlowLayoutPanel flp = ctr as FlowLayoutPanel;
                        if (flp != null)
                        {
                            foreach (RadioButton rb in flp.Controls)
                            {
                                if (rb.Checked)
                                {
                                    scoreId = short.Parse(rb.Name.Substring(2));
                                    break;
                                }
                            }
                        }
                    }
                    ClientLoginSession.FeedbackResult.CloseFeedbacks.Add(new CloseFeedbackCreateModel()
                    {
                        CloseQuestionId = closeQuestionId,
                        ScoreId = scoreId
                    });

                 
                }
                if (ClientLoginSession.CategoryIndex == ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count && ClientLoginSession.FeedbackLoad.OpenFeedbacks.Count == 0)
                {
                    var result = Service.feedbackService.CreateFeedback(ClientLoginSession.FeedbackResult);
                    if (!result.Status)
                    {
                        MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    foreach (Control item in this.tpClient.Controls)
                    {
                        item.Visible = false;
                    }
                    ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this);
                    this.tpClient.Controls.Add(clientLoginUserControl);
                    clientLoginUserControl.Dock = DockStyle.Fill;

                    ClientLoginSession.FeedbackResult = null;
                    ClientLoginSession.FeedbackLoad = null;
                    ClientLoginSession.ClientAccount = null;
                    ClientLoginSession.CategoryIndex = 0;
                    ClientLoginSession.Status = false;

                    MessageBox.Show("Thực hiện đánh giá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            else if (ClientLoginSession.CategoryIndex == ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count + 1)
            {
                foreach (Guna.UI2.WinForms.Guna2Panel pn in this.flpContent.Controls)
                {
                    short openQuestionId = short.Parse(pn.Name.Substring(2));
                    string contentResult = null;
                    foreach (Control ctr in pn.Controls)
                    {
                        Guna.UI2.WinForms.Guna2TextBox tb = ctr as Guna.UI2.WinForms.Guna2TextBox;
                        if (tb != null)
                        {
                            contentResult = tb.Text.Trim() != "" ? tb.Text.Trim() : null;
                        }
                    }

                    ClientLoginSession.FeedbackResult.OpenFeedbacks.Add(new OpenFeedbackCreateModel()
                    {
                        OpenQuestionId = openQuestionId,
                        Content = contentResult
                    });
                }
                var result = Service.feedbackService.CreateFeedback(ClientLoginSession.FeedbackResult);
                if (!result.Status)
                {
                    MessageBox.Show(result.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (Control item in this.tpClient.Controls)
                {
                    item.Visible = false;
                }
                ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this);
                this.tpClient.Controls.Add(clientLoginUserControl);
                clientLoginUserControl.Dock = DockStyle.Fill;

                ClientLoginSession.FeedbackResult = null;
                ClientLoginSession.FeedbackLoad = null;
                ClientLoginSession.ClientAccount = null;
                ClientLoginSession.CategoryIndex = 0;
                ClientLoginSession.Status = false;

                MessageBox.Show("Thực hiện đánh giá thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            while (this.flpContent.Controls.Count > 0)
            {
                Control control = this.flpContent.Controls[0];
                this.flpContent.Controls.Remove(control);
                control.Dispose();
            }

            ClientLoginSession.CategoryIndex++;
            if (ClientLoginSession.CategoryIndex == 1)
            {
                this.btNext.Visible = true;
                this.tbPrevious.Visible = false;
            }
           else
            {
                this.btNext.Visible = true;
                this.tbPrevious.Visible = true;
            }
            if (ClientLoginSession.CategoryIndex <= ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count)
            {
                List<CloseFeedbackViewModel> closeFeedbackQuestion = null;
                CloseQuestionCategoryLoadViewModel questionCategory = null;
                short i = 0;
                foreach (var item in ClientLoginSession.FeedbackLoad.CloseFeedbacks)
                {
                    i++;
                    if (i == ClientLoginSession.CategoryIndex)
                    {
                        questionCategory = item.Key;
                        closeFeedbackQuestion = item.Value;
                        break;
                    }
                }
                this.lbQuestionCatgory.Text = $"{questionCategory.Id}. {questionCategory.Name}";
                short index = 0;
                foreach (var item in closeFeedbackQuestion)
                {
                    index++;
                    var pnQuestion = new Guna.UI2.WinForms.Guna2Panel();
                    pnQuestion.Size = new Size(this.flpContent.Width-40, 150);
                    pnQuestion.BorderRadius = 20;
                    pnQuestion.BorderThickness = 1;
                    pnQuestion.BorderColor = Color.Black;
                    pnQuestion.Margin = new Padding(5, 20, 5, 0);
                    pnQuestion.Padding = new Padding(0, 0, 0, 0);
                    pnQuestion.FillColor = Color.White;
                    pnQuestion.Name = $"pn{item.CloseQuestionId}";
                    pnQuestion.Visible = true;
                    pnQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Regular);

                    var question = ClientLoginSession.FeedbackResult.CloseFeedbacks.FirstOrDefault(x => x.CloseQuestionId == item.CloseQuestionId);
                    if (question != null)
                    {
                        ClientLoginSession.FeedbackResult.CloseFeedbacks.Remove(question);
                    }

                    var lbNameQuestion = new Label();
                    lbNameQuestion.AutoSize = false;
                    lbNameQuestion.MaximumSize = new Size(this.flpContent.Width - 70, 75);
                    lbNameQuestion.BackColor = Color.White;
                    lbNameQuestion.Margin = new Padding(2, 2, 2, 0);
                    lbNameQuestion.Padding = new Padding(0, 0, 0, 0);
                    lbNameQuestion.TextAlign = ContentAlignment.MiddleLeft;
                    lbNameQuestion.ForeColor = Color.Black;
                    lbNameQuestion.Size = new Size(this.flpContent.Width - 70, 55);
                    lbNameQuestion.Visible = true;
                    pnQuestion.Controls.Add(lbNameQuestion);
                    lbNameQuestion.Location = new Point(7, 7);
                    lbNameQuestion.Text = $"{index}. {item.CloseQuestionName}";
                    lbNameQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Bold);

                    var lbHr = new Label();
                    lbHr.BorderStyle = BorderStyle.FixedSingle;
                    lbHr.AutoSize = false;
                    lbHr.Margin = new Padding(0, 0, 0, 0);
                    lbHr.Padding = new Padding(0, 0, 10, 0);
                    lbHr.Size = new Size(this.flpContent.Width - 40, 1);
                    lbHr.Visible = true;
                    pnQuestion.Controls.Add(lbHr);
                    lbHr.Location = new Point(0, lbNameQuestion.Size.Height + 8);

                    var flpQuestionResult = new FlowLayoutPanel();
                    flpQuestionResult.AutoSize = false;
                    flpQuestionResult.Name = $"flp{item.CloseQuestionId}";
                    flpQuestionResult.FlowDirection = FlowDirection.LeftToRight;
                    flpQuestionResult.BackColor = Color.White;
                    flpQuestionResult.Margin = new Padding(2, 0, 2, 0);
                    flpQuestionResult.Padding = new Padding(0, 15, 0, 22);
                    flpQuestionResult.Size = new Size(this.flpContent.Width - 44, 70);
                    flpQuestionResult.Location = new Point(2, lbNameQuestion.Size.Height + 8);
                    var scoreType = Service.scoreService.GetScoreByTypeId(item.ScoreTypeId);
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
                        rbResult.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                        flpQuestionResult.Controls.Add(rbResult);
                        if (question != null)
                        {
                            if (question.ScoreId == s.Id)
                            {
                                rbResult.Checked = true;
                            }
                        }
                    }
                    pnQuestion.Controls.Add(flpQuestionResult);
                    this.flpContent.Controls.Add(pnQuestion);
                    this.btNext.Text = "Tiếp theo";

                    if (ClientLoginSession.CategoryIndex == ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count && ClientLoginSession.FeedbackLoad.OpenFeedbacks.Count == 0)
                    {
                        this.btNext.Text = "Hoàn thành";
                    }

                }

                var number = 0;
                foreach (Control pn in this.flpContent.Controls)
                {
                    foreach (Control control in pn.Controls)
                    {
                        FlowLayoutPanel flp = control as FlowLayoutPanel;
                        bool flag = false;
                        if (flp != null)
                        {
                            foreach (RadioButton item in flp.Controls)
                            {
                                if (item.Checked)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        if (flag)
                        {
                            number++;
                        }
                    }
                }
                this.currentNumberQuestion = number;
                this.tbQuestionNumber.Text = $"{this.currentNumberQuestion}/{closeFeedbackQuestion.Count}";
            }

            if (ClientLoginSession.CategoryIndex == ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count + 1 && ClientLoginSession.FeedbackLoad.OpenFeedbacks.Count > 0)
            {
                List<OpenFeedbackViewModel> openFeedbackQuestion = ClientLoginSession.FeedbackLoad.OpenFeedbacks;

                this.lbQuestionCatgory.Text = "Ý kiến từ ông bà (có thể bỏ qua)";
                short index = 0;
                foreach (var item in openFeedbackQuestion)
                {
                    index++;
                    var pnQuestion = new Guna.UI2.WinForms.Guna2Panel();
                    pnQuestion.Size = new Size(this.flpContent.Width - 40, 150);
                    pnQuestion.BorderThickness = 0;
                    pnQuestion.BorderColor = Color.Black;
                    pnQuestion.Margin = new Padding(5, 20, 5, 0);
                    pnQuestion.Padding = new Padding(0, 0, 0, 0);
                    pnQuestion.FillColor = Color.White;
                    pnQuestion.Name = $"pn{item.OpenQuestionId}";
                    pnQuestion.Visible = true;
                    pnQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Regular);

                    var question = ClientLoginSession.FeedbackResult.OpenFeedbacks.FirstOrDefault(x => x.OpenQuestionId == item.OpenQuestionId);
                    if (question != null)
                    {
                        ClientLoginSession.FeedbackResult.OpenFeedbacks.Remove(question);
                    }

                    var lbNameQuestion = new Label();
                    lbNameQuestion.BorderStyle = BorderStyle.FixedSingle;
                    lbNameQuestion.AutoSize = false;
                    lbNameQuestion.MaximumSize = new Size(this.flpContent.Width - 40, 75);
                    lbNameQuestion.BackColor = Color.White;
                    lbNameQuestion.Margin = new Padding(0, 0, 0, 0);
                    lbNameQuestion.Padding = new Padding(0, 0, 0, 0);
                    lbNameQuestion.TextAlign = ContentAlignment.MiddleLeft;
                    lbNameQuestion.ForeColor = Color.Black;
                    lbNameQuestion.Size = new Size(this.flpContent.Width - 40, 55);
                    lbNameQuestion.Visible = true;
                    pnQuestion.Controls.Add(lbNameQuestion);
                    lbNameQuestion.Location = new Point(0, 0);
                    lbNameQuestion.Text = $"{index}. {item.OpenQuestionName}";
                    lbNameQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Bold);
                    
                    var tbQuestionResult = new Guna.UI2.WinForms.Guna2TextBox();
                    tbQuestionResult.BorderThickness = 1;
                    tbQuestionResult.BorderColor = Color.Black;
                    tbQuestionResult.PlaceholderText = "Vui lòng cho ý kiến";
                    tbQuestionResult.Multiline = true;
                    tbQuestionResult.Name = $"tb{item.OpenQuestionId}";
                    tbQuestionResult.ScrollBars = ScrollBars.Vertical;
                    tbQuestionResult.Size = new Size(this.flpContent.Width - 40, 95);
                    tbQuestionResult.BackColor = Color.White;
                    tbQuestionResult.TextAlign = HorizontalAlignment.Left;
                    tbQuestionResult.ForeColor = Color.Black;
                    tbQuestionResult.Margin = new Padding(0, 0, 0, 0);
                    tbQuestionResult.Location = new Point(0, lbNameQuestion.Size.Height);
                    tbQuestionResult.Font = new Font("Seogoe UI", 10, FontStyle.Regular);
                    tbQuestionResult.Leave += new EventHandler(TextBox_Leave);
                    if (question != null)
                    {
                        tbQuestionResult.Text = question.Content;
                    }

                    pnQuestion.Controls.Add(tbQuestionResult);
                    this.flpContent.Controls.Add(pnQuestion);

                    this.btNext.Text = "Hoàn thành";

                    var number = 0;
                    foreach (Control pn in this.flpContent.Controls)
                    {
                        foreach (Control control in pn.Controls)
                        {
                            Guna.UI2.WinForms.Guna2TextBox tb = control as Guna.UI2.WinForms.Guna2TextBox;
                            if (tb != null)
                            {
                                if (tb.Text.Trim() != null && tb.Text.Trim() != "")
                                {
                                    number++;
                                }
                            }
                        }
                    }
                    this.currentNumberQuestion = number;
                    this.tbQuestionNumber.Text = $"{this.currentNumberQuestion}/{this.flpContent.Controls.Count}";

                }
            }

            this.tbPageNumber.Text = $"{ClientLoginSession.CategoryIndex}/{ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count + 1}";

            if (ClientLoginSession.FeedbackLoad.OpenFeedbacks.Count == 0)
            {
                this.tbPageNumber.Text = $"{ClientLoginSession.CategoryIndex}/{ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count}";
            }
        }

        private void btDestroy_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show($"Sau khi hủy kết quả sẽ không được lưu lại", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (option == DialogResult.Yes)
            {
                foreach (Control item in this.tpClient.Controls)
                {
                    item.Visible = false;
                }
                ClientLoginUserControl clientLoginUserControl = new ClientLoginUserControl(this);
                this.tpClient.Controls.Add(clientLoginUserControl);
                clientLoginUserControl.Dock = DockStyle.Fill;

                ClientLoginSession.FeedbackResult = null;
                ClientLoginSession.FeedbackLoad = null;
                ClientLoginSession.ClientAccount = null;
                ClientLoginSession.CategoryIndex = 0;
                ClientLoginSession.Status = false;
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var number = 0;
            foreach (Control pn in this.flpContent.Controls)
            {
                foreach (Control control in pn.Controls)
                {
                    FlowLayoutPanel flp = control as FlowLayoutPanel;
                    bool flag = false;
                    if (flp != null)
                    {
                        foreach (RadioButton item in flp.Controls)
                        {
                            if (item.Checked)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        number++;
                    }
                }
            }
            this.currentNumberQuestion = number;
            this.tbQuestionNumber.Text = $"{this.currentNumberQuestion}/{this.flpContent.Controls.Count}";
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            var number = 0;
            foreach (Control pn in this.flpContent.Controls)
            {
                foreach (Control control in pn.Controls)
                {
                    Guna.UI2.WinForms.Guna2TextBox tb = control as Guna.UI2.WinForms.Guna2TextBox;
                    if (tb != null)
                    {
                        if (tb.Text.Trim() != null && tb.Text.Trim() != "")
                        {
                            number++;
                        }
                    }
                }
            }
            this.currentNumberQuestion = number;
            this.tbQuestionNumber.Text = $"{this.currentNumberQuestion}/{this.flpContent.Controls.Count}";
        }

        private void btListFeedback_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btListFeedback.FillColor = Color.Gainsboro;
            FeedbackUserControl feedbackUserControl = new FeedbackUserControl(this);
            this.clearControl(feedbackUserControl);
        }

        private void btStatistics_Click(object sender, EventArgs e)
        {
            this.updateColorButton();
            this.btStatistics.FillColor = Color.Gainsboro;
            FeedbackStatisticsUserControl feedbackStatisticsUserControl = new FeedbackStatisticsUserControl(this);
            this.clearControl(feedbackStatisticsUserControl);
        }

        private void tbPrevious_Click(object sender, EventArgs e)
        {
            if (ClientLoginSession.CategoryIndex > 0 && ClientLoginSession.CategoryIndex <= ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count)
            {

                foreach (Guna.UI2.WinForms.Guna2Panel pn in this.flpContent.Controls)
                {
                    short closeQuestionId = short.Parse(pn.Name.Substring(2));
                    short scoreId = 0;
                    foreach (Control ctr in pn.Controls)
                    {
                        FlowLayoutPanel flp = ctr as FlowLayoutPanel;
                        if (flp != null)
                        {
                            foreach (RadioButton rb in flp.Controls)
                            {
                                if (rb.Checked)
                                {
                                    scoreId = short.Parse(rb.Name.Substring(2));
                                    break;
                                }
                            }
                        }
                    }
                    ClientLoginSession.FeedbackResult.CloseFeedbacks.Add(new CloseFeedbackCreateModel()
                    {
                        CloseQuestionId = closeQuestionId,
                        ScoreId = scoreId
                    });
                }
            }
            else if (ClientLoginSession.CategoryIndex == ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count + 1)
            {
                foreach (Guna.UI2.WinForms.Guna2Panel pn in this.flpContent.Controls)
                {
                    short openQuestionId = short.Parse(pn.Name.Substring(2));
                    string contentResult = null;
                    foreach (Control ctr in pn.Controls)
                    {
                        Guna.UI2.WinForms.Guna2TextBox tb = ctr as Guna.UI2.WinForms.Guna2TextBox;
                        if (tb != null)
                        {
                            contentResult = tb.Text.Trim() != "" ? tb.Text.Trim() : null;
                        }
                    }

                    ClientLoginSession.FeedbackResult.OpenFeedbacks.Add(new OpenFeedbackCreateModel()
                    {
                        OpenQuestionId = openQuestionId,
                        Content = contentResult
                    });
                }
            }


            while (this.flpContent.Controls.Count > 0)
            {
                Control control = this.flpContent.Controls[0];
                this.flpContent.Controls.Remove(control);
                control.Dispose();
            }

            ClientLoginSession.CategoryIndex--;
            if (ClientLoginSession.CategoryIndex == 1)
            {
                this.btNext.Visible = true;
                this.tbPrevious.Visible = false;
            }
            List<CloseFeedbackViewModel> closeFeedbackQuestion = null;
            CloseQuestionCategoryLoadViewModel questionCategory = null;
            short i = 0;
            foreach (var item in ClientLoginSession.FeedbackLoad.CloseFeedbacks)
            {
                i++;
                if (i == ClientLoginSession.CategoryIndex)
                {
                    questionCategory = item.Key;
                    closeFeedbackQuestion = item.Value;
                    break;
                }
            }
            this.lbQuestionCatgory.Text = $"{questionCategory.Id}. {questionCategory.Name}";
            short index = 0;
            foreach (var item in closeFeedbackQuestion)
            {
                index++;
                var pnQuestion = new Guna.UI2.WinForms.Guna2Panel();
                pnQuestion.Size = new Size(this.flpContent.Width - 40, 150);
                pnQuestion.BorderRadius = 20;
                pnQuestion.BorderThickness = 1;
                pnQuestion.BorderColor = Color.Black;
                pnQuestion.Margin = new Padding(5, 20, 5, 0);
                pnQuestion.Padding = new Padding(0, 0, 0, 0);
                pnQuestion.FillColor = Color.White;
                pnQuestion.Name = $"pn{item.CloseQuestionId}";
                pnQuestion.Visible = true;
                pnQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Regular);

                var question = ClientLoginSession.FeedbackResult.CloseFeedbacks.FirstOrDefault(x => x.CloseQuestionId == item.CloseQuestionId);
                if (question != null)
                {
                    ClientLoginSession.FeedbackResult.CloseFeedbacks.Remove(question);
                }

                var lbNameQuestion = new Label();
                lbNameQuestion.AutoSize = false;
                lbNameQuestion.MaximumSize = new Size(this.flpContent.Width - 70, 75);
                lbNameQuestion.BackColor = Color.White;
                lbNameQuestion.Margin = new Padding(2, 2, 2, 0);
                lbNameQuestion.Padding = new Padding(0, 0, 0, 0);
                lbNameQuestion.TextAlign = ContentAlignment.MiddleLeft;
                lbNameQuestion.ForeColor = Color.Black;
                lbNameQuestion.Size = new Size(this.flpContent.Width - 70, 55);
                lbNameQuestion.Visible = true;
                pnQuestion.Controls.Add(lbNameQuestion);
                lbNameQuestion.Location = new Point(7, 7);
                lbNameQuestion.Text = $"{index}. {item.CloseQuestionName}";
                lbNameQuestion.Font = new Font("Seogoe UI", 10, FontStyle.Bold);

                var lbHr = new Label();
                lbHr.BorderStyle = BorderStyle.FixedSingle;
                lbHr.AutoSize = false;
                lbHr.Margin = new Padding(0, 0, 0, 0);
                lbHr.Padding = new Padding(0, 0, 10, 0);
                lbHr.Size = new Size(this.flpContent.Width - 40, 1);
                lbHr.Visible = true;
                pnQuestion.Controls.Add(lbHr);
                lbHr.Location = new Point(0, lbNameQuestion.Size.Height + 8);

                var flpQuestionResult = new FlowLayoutPanel();
                flpQuestionResult.AutoSize = false;
                flpQuestionResult.Name = $"flp{item.CloseQuestionId}";
                flpQuestionResult.FlowDirection = FlowDirection.LeftToRight;
                flpQuestionResult.BackColor = Color.White;
                flpQuestionResult.Margin = new Padding(2, 0, 2, 0);
                flpQuestionResult.Padding = new Padding(0, 15, 0, 22);
                flpQuestionResult.Size = new Size(this.flpContent.Width - 44, 70);
                flpQuestionResult.Location = new Point(2, lbNameQuestion.Size.Height + 8);
                var scoreType = Service.scoreService.GetScoreByTypeId(item.ScoreTypeId);
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
                    rbResult.CheckedChanged += new EventHandler(RadioButton_CheckedChanged);
                    flpQuestionResult.Controls.Add(rbResult);
                    if (question != null)
                    {
                        if (question.ScoreId == s.Id)
                        {
                            rbResult.Checked = true;
                        }
                    }
                }
                pnQuestion.Controls.Add(flpQuestionResult);
                this.flpContent.Controls.Add(pnQuestion);
                this.btNext.Text = "Tiếp theo";
            }

            var number = 0;
            foreach (Control pn in this.flpContent.Controls)
            {
                foreach (Control control in pn.Controls)
                {
                    FlowLayoutPanel flp = control as FlowLayoutPanel;
                    bool flag = false;
                    if (flp != null)
                    {
                        foreach (RadioButton item in flp.Controls)
                        {
                            if (item.Checked)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    if (flag)
                    {
                        number++;
                    }
                }
            }
            this.currentNumberQuestion = number;
            this.tbQuestionNumber.Text = $"{this.currentNumberQuestion}/{closeFeedbackQuestion.Count}";

            this.tbPageNumber.Text = $"{ClientLoginSession.CategoryIndex}/{ClientLoginSession.FeedbackLoad.CloseFeedbacks.Count + 1}";


        }
    }
}
