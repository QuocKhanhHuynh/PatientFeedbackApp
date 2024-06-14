namespace FeedbackApp.UserControls
{
    partial class ClientCreateUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            pnTop = new Panel();
            pnBottom = new Panel();
            pnCenter = new Panel();
            pnInfo = new GroupBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btSubmit = new Guna.UI2.WinForms.Guna2Button();
            btDestroy = new Guna.UI2.WinForms.Guna2Button();
            flpInfor = new FlowLayoutPanel();
            pnFullname = new Panel();
            lbFullname = new Label();
            tbFullname = new Guna.UI2.WinForms.Guna2TextBox();
            pnGender = new Panel();
            pnGenderResult = new Panel();
            rbFemale = new RadioButton();
            rbMale = new RadioButton();
            lb = new Label();
            pnAge = new Panel();
            label1 = new Label();
            tbAge = new Guna.UI2.WinForms.Guna2TextBox();
            pnDistance = new Panel();
            tbDistance = new Guna.UI2.WinForms.Guna2TextBox();
            label3 = new Label();
            guna2TextBox1 = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            pnRight = new Panel();
            pnLeft = new Panel();
            pnCenter.SuspendLayout();
            pnInfo.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            flpInfor.SuspendLayout();
            pnFullname.SuspendLayout();
            pnGender.SuspendLayout();
            pnGenderResult.SuspendLayout();
            pnAge.SuspendLayout();
            pnDistance.SuspendLayout();
            SuspendLayout();
            // 
            // pnTop
            // 
            pnTop.BackColor = SystemColors.ActiveCaption;
            pnTop.Dock = DockStyle.Top;
            pnTop.Location = new Point(0, 0);
            pnTop.Margin = new Padding(0);
            pnTop.Name = "pnTop";
            pnTop.Size = new Size(1894, 220);
            pnTop.TabIndex = 0;
            // 
            // pnBottom
            // 
            pnBottom.BackColor = SystemColors.ActiveCaption;
            pnBottom.Dock = DockStyle.Bottom;
            pnBottom.Location = new Point(0, 750);
            pnBottom.Margin = new Padding(0);
            pnBottom.Name = "pnBottom";
            pnBottom.Size = new Size(1894, 196);
            pnBottom.TabIndex = 1;
            // 
            // pnCenter
            // 
            pnCenter.BackColor = SystemColors.ActiveCaption;
            pnCenter.Controls.Add(pnInfo);
            pnCenter.Controls.Add(pnRight);
            pnCenter.Controls.Add(pnLeft);
            pnCenter.Dock = DockStyle.Fill;
            pnCenter.Location = new Point(0, 220);
            pnCenter.Margin = new Padding(0);
            pnCenter.Name = "pnCenter";
            pnCenter.Size = new Size(1894, 530);
            pnCenter.TabIndex = 2;
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(flowLayoutPanel1);
            pnInfo.Controls.Add(flpInfor);
            pnInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnInfo.Location = new Point(632, 5);
            pnInfo.Margin = new Padding(0);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(630, 501);
            pnInfo.TabIndex = 0;
            pnInfo.TabStop = false;
            pnInfo.Text = "Tạo thông tin đánh giá";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.InactiveCaption;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(btSubmit);
            flowLayoutPanel1.Controls.Add(btDestroy);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 417);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(624, 81);
            flowLayoutPanel1.TabIndex = 0;
            // 
            // btSubmit
            // 
            btSubmit.BackColor = SystemColors.ActiveCaption;
            btSubmit.BorderRadius = 5;
            btSubmit.BorderThickness = 1;
            btSubmit.CustomizableEdges = customizableEdges1;
            btSubmit.DisabledState.BorderColor = Color.DarkGray;
            btSubmit.DisabledState.CustomBorderColor = Color.DarkGray;
            btSubmit.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btSubmit.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btSubmit.FillColor = SystemColors.HotTrack;
            btSubmit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btSubmit.ForeColor = Color.White;
            btSubmit.ImageSize = new Size(25, 25);
            btSubmit.Location = new Point(465, 20);
            btSubmit.Margin = new Padding(15, 20, 20, 15);
            btSubmit.Name = "btSubmit";
            btSubmit.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btSubmit.Size = new Size(137, 43);
            btSubmit.TabIndex = 6;
            btSubmit.TabStop = false;
            btSubmit.Text = "Hoàn thành";
            btSubmit.Click += btSubmit_Click;
            // 
            // btDestroy
            // 
            btDestroy.BackColor = SystemColors.ActiveCaption;
            btDestroy.BorderRadius = 5;
            btDestroy.BorderThickness = 1;
            btDestroy.CustomizableEdges = customizableEdges3;
            btDestroy.DisabledState.BorderColor = Color.DarkGray;
            btDestroy.DisabledState.CustomBorderColor = Color.DarkGray;
            btDestroy.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btDestroy.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btDestroy.FillColor = Color.White;
            btDestroy.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btDestroy.ForeColor = Color.Black;
            btDestroy.ImageSize = new Size(25, 25);
            btDestroy.Location = new Point(313, 20);
            btDestroy.Margin = new Padding(15, 20, 0, 15);
            btDestroy.Name = "btDestroy";
            btDestroy.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btDestroy.Size = new Size(137, 43);
            btDestroy.TabIndex = 7;
            btDestroy.TabStop = false;
            btDestroy.Text = "Hủy";
            btDestroy.Click += btDestroy_Click;
            // 
            // flpInfor
            // 
            flpInfor.Controls.Add(pnFullname);
            flpInfor.Controls.Add(pnGender);
            flpInfor.Controls.Add(pnAge);
            flpInfor.Controls.Add(pnDistance);
            flpInfor.Controls.Add(label2);
            flpInfor.Location = new Point(3, 30);
            flpInfor.Margin = new Padding(0);
            flpInfor.Name = "flpInfor";
            flpInfor.Size = new Size(624, 374);
            flpInfor.TabIndex = 0;
            // 
            // pnFullname
            // 
            pnFullname.Controls.Add(lbFullname);
            pnFullname.Controls.Add(tbFullname);
            pnFullname.Font = new Font("Segoe UI", 10F);
            pnFullname.Location = new Point(95, 5);
            pnFullname.Margin = new Padding(95, 5, 0, 5);
            pnFullname.Name = "pnFullname";
            pnFullname.Size = new Size(470, 40);
            pnFullname.TabIndex = 9;
            // 
            // lbFullname
            // 
            lbFullname.Location = new Point(0, 2);
            lbFullname.Margin = new Padding(0, 0, 0, 5);
            lbFullname.Name = "lbFullname";
            lbFullname.Size = new Size(157, 38);
            lbFullname.TabIndex = 1;
            lbFullname.Text = "Họ tên:";
            lbFullname.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbFullname
            // 
            tbFullname.BorderColor = Color.Black;
            tbFullname.CustomizableEdges = customizableEdges5;
            tbFullname.DefaultText = "";
            tbFullname.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbFullname.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbFullname.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbFullname.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbFullname.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbFullname.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbFullname.ForeColor = Color.Black;
            tbFullname.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbFullname.Location = new Point(157, 0);
            tbFullname.Margin = new Padding(0);
            tbFullname.MaxLength = 30;
            tbFullname.Name = "tbFullname";
            tbFullname.PasswordChar = '\0';
            tbFullname.PlaceholderText = "";
            tbFullname.SelectedText = "";
            tbFullname.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbFullname.Size = new Size(313, 40);
            tbFullname.TabIndex = 1;
            tbFullname.TabStop = false;
            // 
            // pnGender
            // 
            pnGender.Controls.Add(pnGenderResult);
            pnGender.Controls.Add(lb);
            pnGender.Font = new Font("Segoe UI", 10F);
            pnGender.Location = new Point(95, 55);
            pnGender.Margin = new Padding(95, 5, 0, 5);
            pnGender.Name = "pnGender";
            pnGender.Size = new Size(470, 40);
            pnGender.TabIndex = 10;
            // 
            // pnGenderResult
            // 
            pnGenderResult.Controls.Add(rbFemale);
            pnGenderResult.Controls.Add(rbMale);
            pnGenderResult.Location = new Point(157, 0);
            pnGenderResult.Margin = new Padding(0);
            pnGenderResult.Name = "pnGenderResult";
            pnGenderResult.Size = new Size(313, 40);
            pnGenderResult.TabIndex = 1;
            // 
            // rbFemale
            // 
            rbFemale.AutoSize = true;
            rbFemale.Location = new Point(90, 9);
            rbFemale.Margin = new Padding(0);
            rbFemale.Name = "rbFemale";
            rbFemale.Size = new Size(64, 32);
            rbFemale.TabIndex = 3;
            rbFemale.Text = "Nữ";
            rbFemale.UseVisualStyleBackColor = true;
            // 
            // rbMale
            // 
            rbMale.AutoSize = true;
            rbMale.Location = new Point(0, 9);
            rbMale.Margin = new Padding(0);
            rbMale.Name = "rbMale";
            rbMale.Size = new Size(79, 32);
            rbMale.TabIndex = 2;
            rbMale.Text = "Nam";
            rbMale.UseVisualStyleBackColor = true;
            // 
            // lb
            // 
            lb.Location = new Point(0, 2);
            lb.Margin = new Padding(0, 0, 0, 5);
            lb.Name = "lb";
            lb.Size = new Size(157, 38);
            lb.TabIndex = 1;
            lb.Text = "Giới tính:";
            lb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // pnAge
            // 
            pnAge.Controls.Add(label1);
            pnAge.Controls.Add(tbAge);
            pnAge.Font = new Font("Segoe UI", 10F);
            pnAge.Location = new Point(95, 105);
            pnAge.Margin = new Padding(95, 5, 0, 5);
            pnAge.Name = "pnAge";
            pnAge.Size = new Size(470, 40);
            pnAge.TabIndex = 11;
            // 
            // label1
            // 
            label1.Location = new Point(0, 2);
            label1.Margin = new Padding(0, 0, 0, 5);
            label1.Name = "label1";
            label1.Size = new Size(157, 38);
            label1.TabIndex = 1;
            label1.Text = "Tuổi:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbAge
            // 
            tbAge.BorderColor = Color.Black;
            tbAge.CustomizableEdges = customizableEdges7;
            tbAge.DefaultText = "";
            tbAge.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbAge.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbAge.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbAge.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbAge.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbAge.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAge.ForeColor = Color.Black;
            tbAge.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbAge.Location = new Point(157, 0);
            tbAge.Margin = new Padding(0);
            tbAge.MaxLength = 20;
            tbAge.Name = "tbAge";
            tbAge.PasswordChar = '\0';
            tbAge.PlaceholderText = "";
            tbAge.SelectedText = "";
            tbAge.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbAge.Size = new Size(313, 40);
            tbAge.TabIndex = 4;
            tbAge.TabStop = false;
            tbAge.KeyPress += tbAge_KeyPress;
            // 
            // pnDistance
            // 
            pnDistance.Controls.Add(tbDistance);
            pnDistance.Controls.Add(label3);
            pnDistance.Controls.Add(guna2TextBox1);
            pnDistance.Font = new Font("Segoe UI", 10F);
            pnDistance.Location = new Point(0, 155);
            pnDistance.Margin = new Padding(0, 5, 0, 0);
            pnDistance.Name = "pnDistance";
            pnDistance.Size = new Size(565, 46);
            pnDistance.TabIndex = 13;
            // 
            // tbDistance
            // 
            tbDistance.BorderColor = Color.Black;
            tbDistance.CustomizableEdges = customizableEdges9;
            tbDistance.DefaultText = "";
            tbDistance.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbDistance.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbDistance.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbDistance.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbDistance.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbDistance.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbDistance.ForeColor = Color.Black;
            tbDistance.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbDistance.Location = new Point(252, 2);
            tbDistance.Margin = new Padding(0);
            tbDistance.MaxLength = 20;
            tbDistance.Name = "tbDistance";
            tbDistance.PasswordChar = '\0';
            tbDistance.PlaceholderText = "";
            tbDistance.SelectedText = "";
            tbDistance.ShadowDecoration.CustomizableEdges = customizableEdges10;
            tbDistance.Size = new Size(313, 40);
            tbDistance.TabIndex = 5;
            tbDistance.TabStop = false;
            tbDistance.KeyPress += tbDistance_KeyPress;
            // 
            // label3
            // 
            label3.Location = new Point(-44, 2);
            label3.Margin = new Padding(0, 0, 0, 5);
            label3.Name = "label3";
            label3.Size = new Size(296, 38);
            label3.TabIndex = 1;
            label3.Text = "Khoảng cách đến bệnh viện:";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // guna2TextBox1
            // 
            guna2TextBox1.BorderColor = Color.Black;
            guna2TextBox1.CustomizableEdges = customizableEdges11;
            guna2TextBox1.DefaultText = "";
            guna2TextBox1.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            guna2TextBox1.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            guna2TextBox1.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            guna2TextBox1.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2TextBox1.ForeColor = Color.Black;
            guna2TextBox1.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            guna2TextBox1.Location = new Point(0, 300);
            guna2TextBox1.Margin = new Padding(0);
            guna2TextBox1.MaxLength = 20;
            guna2TextBox1.Name = "guna2TextBox1";
            guna2TextBox1.PasswordChar = '\0';
            guna2TextBox1.PlaceholderText = "";
            guna2TextBox1.SelectedText = "";
            guna2TextBox1.ShadowDecoration.CustomizableEdges = customizableEdges12;
            guna2TextBox1.Size = new Size(313, 40);
            guna2TextBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(250, 201);
            label2.Margin = new Padding(250, 0, 3, 0);
            label2.Name = "label2";
            label2.Size = new Size(103, 25);
            label2.TabIndex = 14;
            label2.Text = "(Đơn vị km)";
            // 
            // pnRight
            // 
            pnRight.Dock = DockStyle.Right;
            pnRight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnRight.Location = new Point(1263, 0);
            pnRight.Margin = new Padding(0);
            pnRight.Name = "pnRight";
            pnRight.Size = new Size(631, 530);
            pnRight.TabIndex = 1;
            // 
            // pnLeft
            // 
            pnLeft.Dock = DockStyle.Left;
            pnLeft.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnLeft.Location = new Point(0, 0);
            pnLeft.Margin = new Padding(0);
            pnLeft.Name = "pnLeft";
            pnLeft.Size = new Size(631, 530);
            pnLeft.TabIndex = 1;
            // 
            // ClientCreateUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gainsboro;
            Controls.Add(pnCenter);
            Controls.Add(pnBottom);
            Controls.Add(pnTop);
            Name = "ClientCreateUserControl";
            Size = new Size(1894, 946);
            pnCenter.ResumeLayout(false);
            pnInfo.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            flpInfor.ResumeLayout(false);
            flpInfor.PerformLayout();
            pnFullname.ResumeLayout(false);
            pnGender.ResumeLayout(false);
            pnGenderResult.ResumeLayout(false);
            pnGenderResult.PerformLayout();
            pnAge.ResumeLayout(false);
            pnDistance.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTop;
        private Panel pnBottom;
        private Panel pnCenter;
        private Panel pnLeft;
        private Panel pnRight;
        public Panel pnOldPassword;
        private Label lbPassword;
        private Guna.UI2.WinForms.Guna2TextBox tbOldPassword;
        public Panel pnShowOldPassword;
        private CheckBox cbShowOldPassword;
        public Panel pnNewPassword;
        private Label lb;
        private Guna.UI2.WinForms.Guna2TextBox tbShowNewPassword;
        public Panel pnShowNewPassword;
        private CheckBox cbShowNewPassword;
        public Panel pnConfirmPassword;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmPassword;
        private GroupBox pnInfo;
        private FlowLayoutPanel flpInfor;
        public Panel pnFullname;
        private Label lbFullname;
        private Guna.UI2.WinForms.Guna2TextBox tbFullname;
        public Panel pnGender;
        public Panel pnAge;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbAge;
        private RadioButton rbFemale;
        private RadioButton rbMale;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel pnGenderResult;
        private Guna.UI2.WinForms.Guna2Button btSubmit;
        private Guna.UI2.WinForms.Guna2Button btDestroy;
        public Panel pnDistance;
        private Guna.UI2.WinForms.Guna2TextBox tbDistance;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox guna2TextBox1;
        private Label label2;
    }
}
