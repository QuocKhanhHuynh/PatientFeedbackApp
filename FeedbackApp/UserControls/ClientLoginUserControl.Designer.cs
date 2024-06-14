namespace FeedbackApp.UserControls
{
    partial class ClientLoginUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbTitle = new Label();
            pnLogin = new Panel();
            flpClientLogin = new FlowLayoutPanel();
            pnUsername = new Panel();
            lbPhoneNumber = new Label();
            tbPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            panel3 = new Panel();
            label2 = new Label();
            tbDayNumber = new Guna.UI2.WinForms.Guna2TextBox();
            pnIsInsurance = new Panel();
            lbIsInsurance = new Label();
            flpIsInsurance = new FlowLayoutPanel();
            rbYes = new RadioButton();
            rbNo = new RadioButton();
            flpFeedbackOption = new FlowLayoutPanel();
            pnInfor = new Panel();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnLogin.SuspendLayout();
            flpClientLogin.SuspendLayout();
            pnUsername.SuspendLayout();
            panel3.SuspendLayout();
            pnIsInsurance.SuspendLayout();
            flpIsInsurance.SuspendLayout();
            pnInfor.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(64, 2);
            lbTitle.Margin = new Padding(0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(365, 51);
            lbTitle.TabIndex = 4;
            lbTitle.Text = "THÔNG TIN";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnLogin
            // 
            pnLogin.BackColor = SystemColors.ActiveCaption;
            pnLogin.BorderStyle = BorderStyle.FixedSingle;
            pnLogin.Controls.Add(flpClientLogin);
            pnLogin.Controls.Add(flpFeedbackOption);
            pnLogin.Controls.Add(pnInfor);
            pnLogin.Location = new Point(568, 278);
            pnLogin.Margin = new Padding(0);
            pnLogin.Name = "pnLogin";
            pnLogin.Size = new Size(758, 390);
            pnLogin.TabIndex = 3;
            // 
            // flpClientLogin
            // 
            flpClientLogin.Controls.Add(pnUsername);
            flpClientLogin.Controls.Add(panel3);
            flpClientLogin.Controls.Add(pnIsInsurance);
            flpClientLogin.Location = new Point(131, 56);
            flpClientLogin.Margin = new Padding(0);
            flpClientLogin.Name = "flpClientLogin";
            flpClientLogin.Size = new Size(498, 149);
            flpClientLogin.TabIndex = 5;
            // 
            // pnUsername
            // 
            pnUsername.Controls.Add(lbPhoneNumber);
            pnUsername.Controls.Add(tbPhoneNumber);
            pnUsername.Location = new Point(0, 5);
            pnUsername.Margin = new Padding(0, 5, 0, 5);
            pnUsername.Name = "pnUsername";
            pnUsername.Size = new Size(498, 40);
            pnUsername.TabIndex = 3;
            // 
            // lbPhoneNumber
            // 
            lbPhoneNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbPhoneNumber.Location = new Point(34, 0);
            lbPhoneNumber.Margin = new Padding(0);
            lbPhoneNumber.Name = "lbPhoneNumber";
            lbPhoneNumber.Size = new Size(151, 38);
            lbPhoneNumber.TabIndex = 2;
            lbPhoneNumber.Text = "Số điện thoại:";
            lbPhoneNumber.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbPhoneNumber
            // 
            tbPhoneNumber.BorderColor = Color.Black;
            tbPhoneNumber.CustomizableEdges = customizableEdges1;
            tbPhoneNumber.DefaultText = "";
            tbPhoneNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPhoneNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPhoneNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPhoneNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPhoneNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPhoneNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPhoneNumber.ForeColor = Color.Black;
            tbPhoneNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPhoneNumber.Location = new Point(185, 0);
            tbPhoneNumber.Margin = new Padding(0);
            tbPhoneNumber.MaxLength = 11;
            tbPhoneNumber.Name = "tbPhoneNumber";
            tbPhoneNumber.PasswordChar = '\0';
            tbPhoneNumber.PlaceholderText = "";
            tbPhoneNumber.SelectedText = "";
            tbPhoneNumber.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbPhoneNumber.Size = new Size(313, 40);
            tbPhoneNumber.TabIndex = 0;
            tbPhoneNumber.TabStop = false;
            tbPhoneNumber.KeyPress += tbPhoneNumber_KeyPress;
            // 
            // panel3
            // 
            panel3.Controls.Add(label2);
            panel3.Controls.Add(tbDayNumber);
            panel3.Location = new Point(0, 55);
            panel3.Margin = new Padding(0, 5, 0, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(498, 40);
            panel3.TabIndex = 5;
            // 
            // label2
            // 
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(3, 0);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(182, 38);
            label2.TabIndex = 2;
            label2.Text = "Số ngày điều trị:";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tbDayNumber
            // 
            tbDayNumber.BorderColor = Color.Black;
            tbDayNumber.CustomizableEdges = customizableEdges3;
            tbDayNumber.DefaultText = "";
            tbDayNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbDayNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbDayNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbDayNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbDayNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbDayNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbDayNumber.ForeColor = Color.Black;
            tbDayNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbDayNumber.Location = new Point(185, 0);
            tbDayNumber.Margin = new Padding(0);
            tbDayNumber.MaxLength = 11;
            tbDayNumber.Name = "tbDayNumber";
            tbDayNumber.PasswordChar = '\0';
            tbDayNumber.PlaceholderText = "";
            tbDayNumber.SelectedText = "";
            tbDayNumber.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbDayNumber.Size = new Size(313, 40);
            tbDayNumber.TabIndex = 1;
            tbDayNumber.TabStop = false;
            tbDayNumber.KeyPress += tbDayNumber_KeyPress;
            // 
            // pnIsInsurance
            // 
            pnIsInsurance.Controls.Add(lbIsInsurance);
            pnIsInsurance.Controls.Add(flpIsInsurance);
            pnIsInsurance.Location = new Point(0, 105);
            pnIsInsurance.Margin = new Padding(0, 5, 0, 5);
            pnIsInsurance.Name = "pnIsInsurance";
            pnIsInsurance.Size = new Size(498, 40);
            pnIsInsurance.TabIndex = 4;
            // 
            // lbIsInsurance
            // 
            lbIsInsurance.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbIsInsurance.Location = new Point(34, 0);
            lbIsInsurance.Margin = new Padding(0);
            lbIsInsurance.Name = "lbIsInsurance";
            lbIsInsurance.Size = new Size(151, 38);
            lbIsInsurance.TabIndex = 2;
            lbIsInsurance.Text = "Sử dụng BHYT:";
            lbIsInsurance.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // flpIsInsurance
            // 
            flpIsInsurance.Controls.Add(rbYes);
            flpIsInsurance.Controls.Add(rbNo);
            flpIsInsurance.Location = new Point(182, 0);
            flpIsInsurance.Margin = new Padding(0);
            flpIsInsurance.Name = "flpIsInsurance";
            flpIsInsurance.Size = new Size(316, 40);
            flpIsInsurance.TabIndex = 6;
            // 
            // rbYes
            // 
            rbYes.AutoSize = true;
            rbYes.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbYes.Location = new Point(5, 0);
            rbYes.Margin = new Padding(5, 0, 0, 0);
            rbYes.Name = "rbYes";
            rbYes.Size = new Size(61, 32);
            rbYes.TabIndex = 2;
            rbYes.Text = "Có";
            rbYes.UseVisualStyleBackColor = true;
            rbYes.CheckedChanged += rbYes_CheckedChanged;
            // 
            // rbNo
            // 
            rbNo.AutoSize = true;
            rbNo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rbNo.Location = new Point(76, 0);
            rbNo.Margin = new Padding(10, 0, 0, 0);
            rbNo.Name = "rbNo";
            rbNo.Size = new Size(95, 32);
            rbNo.TabIndex = 3;
            rbNo.Text = "Không";
            rbNo.UseVisualStyleBackColor = true;
            rbNo.CheckedChanged += rbNo_CheckedChanged;
            // 
            // flpFeedbackOption
            // 
            flpFeedbackOption.AutoSize = true;
            flpFeedbackOption.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpFeedbackOption.FlowDirection = FlowDirection.TopDown;
            flpFeedbackOption.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flpFeedbackOption.Location = new Point(131, 207);
            flpFeedbackOption.Margin = new Padding(0);
            flpFeedbackOption.Name = "flpFeedbackOption";
            flpFeedbackOption.Size = new Size(0, 0);
            flpFeedbackOption.TabIndex = 6;
            // 
            // pnInfor
            // 
            pnInfor.Controls.Add(lbTitle);
            pnInfor.Location = new Point(131, 3);
            pnInfor.Name = "pnInfor";
            pnInfor.Size = new Size(498, 202);
            pnInfor.TabIndex = 4;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 40;
            guna2Elipse1.TargetControl = pnLogin;
            // 
            // ClientLoginUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            Controls.Add(pnLogin);
            Margin = new Padding(0);
            Name = "ClientLoginUserControl";
            Size = new Size(1894, 946);
            pnLogin.ResumeLayout(false);
            pnLogin.PerformLayout();
            flpClientLogin.ResumeLayout(false);
            pnUsername.ResumeLayout(false);
            panel3.ResumeLayout(false);
            pnIsInsurance.ResumeLayout(false);
            flpIsInsurance.ResumeLayout(false);
            flpIsInsurance.PerformLayout();
            pnInfor.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Panel pnLogin;
        private CheckBox cbShowPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Panel pnUsername;
        private Label lbUsername;
        private Guna.UI2.WinForms.Guna2TextBox tbPhoneNumber;
        private Panel panel1;
        private Label lbName;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private Label lbPhoneNumber;
        private FlowLayoutPanel flpClientLogin;
        private Panel pnIsInsurance;
        private Label lbIsInsurance;
        private Panel panel3;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbDayNumber;
        private RadioButton rbNo;
        private RadioButton rbYes;
        private FlowLayoutPanel flpIsInsurance;
        private FlowLayoutPanel flpFeedbackOption;
        private Panel pnInfor;
    }
}
