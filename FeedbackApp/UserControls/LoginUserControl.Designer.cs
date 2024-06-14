namespace FeedbackApp.UserControls
{
    partial class LoginUserControl
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            lbTitle = new Label();
            pnLogin = new Panel();
            panel2 = new Panel();
            cbShowPassword = new CheckBox();
            btnLogin = new Guna.UI2.WinForms.Guna2Button();
            pnUsername = new Panel();
            lbUsername = new Label();
            tbUsername = new Guna.UI2.WinForms.Guna2TextBox();
            panel1 = new Panel();
            lbName = new Label();
            tbPassword = new Guna.UI2.WinForms.Guna2TextBox();
            guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(components);
            pnLogin.SuspendLayout();
            panel2.SuspendLayout();
            pnUsername.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lbTitle
            // 
            lbTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.Location = new Point(279, 48);
            lbTitle.Margin = new Padding(0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(260, 50);
            lbTitle.TabIndex = 4;
            lbTitle.Text = "ĐĂNG NHẬP";
            lbTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnLogin
            // 
            pnLogin.BackColor = SystemColors.ActiveCaption;
            pnLogin.BorderStyle = BorderStyle.FixedSingle;
            pnLogin.Controls.Add(panel2);
            pnLogin.Controls.Add(btnLogin);
            pnLogin.Controls.Add(pnUsername);
            pnLogin.Controls.Add(lbTitle);
            pnLogin.Controls.Add(panel1);
            pnLogin.Location = new Point(568, 278);
            pnLogin.Margin = new Padding(0);
            pnLogin.Name = "pnLogin";
            pnLogin.Size = new Size(758, 390);
            pnLogin.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Controls.Add(cbShowPassword);
            panel2.Location = new Point(144, 218);
            panel2.Margin = new Padding(5, 5, 0, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(470, 40);
            panel2.TabIndex = 3;
            // 
            // cbShowPassword
            // 
            cbShowPassword.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            cbShowPassword.ForeColor = Color.Black;
            cbShowPassword.Location = new Point(157, 0);
            cbShowPassword.Margin = new Padding(0);
            cbShowPassword.Name = "cbShowPassword";
            cbShowPassword.Size = new Size(139, 40);
            cbShowPassword.TabIndex = 5;
            cbShowPassword.TabStop = false;
            cbShowPassword.Text = "Hiện mật khẩu";
            cbShowPassword.UseVisualStyleBackColor = true;
            cbShowPassword.CheckedChanged += cbShowPassword_CheckedChanged;
            // 
            // btnLogin
            // 
            btnLogin.BackColor = SystemColors.ActiveCaption;
            btnLogin.BorderRadius = 5;
            btnLogin.BorderThickness = 1;
            btnLogin.CustomizableEdges = customizableEdges1;
            btnLogin.DisabledState.BorderColor = Color.DarkGray;
            btnLogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnLogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnLogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnLogin.FillColor = SystemColors.HotTrack;
            btnLogin.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.White;
            btnLogin.ImageSize = new Size(25, 25);
            btnLogin.Location = new Point(477, 278);
            btnLogin.Margin = new Padding(15, 15, 0, 15);
            btnLogin.Name = "btnLogin";
            btnLogin.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnLogin.Size = new Size(137, 43);
            btnLogin.TabIndex = 1;
            btnLogin.TabStop = false;
            btnLogin.Text = "Đăng nhập";
            btnLogin.Click += btnLogin_Click;
            // 
            // pnUsername
            // 
            pnUsername.Controls.Add(lbUsername);
            pnUsername.Controls.Add(tbUsername);
            pnUsername.Location = new Point(144, 123);
            pnUsername.Margin = new Padding(5, 5, 0, 5);
            pnUsername.Name = "pnUsername";
            pnUsername.Size = new Size(470, 40);
            pnUsername.TabIndex = 3;
            // 
            // lbUsername
            // 
            lbUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbUsername.Location = new Point(0, 2);
            lbUsername.Margin = new Padding(0);
            lbUsername.Name = "lbUsername";
            lbUsername.Size = new Size(157, 38);
            lbUsername.TabIndex = 1;
            lbUsername.Text = "Tên đăng nhập:";
            lbUsername.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbUsername
            // 
            tbUsername.BorderColor = Color.Black;
            tbUsername.CustomizableEdges = customizableEdges3;
            tbUsername.DefaultText = "";
            tbUsername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbUsername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbUsername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbUsername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsername.ForeColor = Color.Black;
            tbUsername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbUsername.Location = new Point(157, 0);
            tbUsername.Margin = new Padding(0);
            tbUsername.Name = "tbUsername";
            tbUsername.PasswordChar = '\0';
            tbUsername.PlaceholderText = "";
            tbUsername.SelectedText = "";
            tbUsername.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbUsername.Size = new Size(313, 40);
            tbUsername.TabIndex = 0;
            tbUsername.TabStop = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(lbName);
            panel1.Controls.Add(tbPassword);
            panel1.Location = new Point(144, 173);
            panel1.Margin = new Padding(5, 5, 0, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 40);
            panel1.TabIndex = 4;
            // 
            // lbName
            // 
            lbName.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbName.Location = new Point(0, 2);
            lbName.Margin = new Padding(0);
            lbName.Name = "lbName";
            lbName.Size = new Size(157, 38);
            lbName.TabIndex = 1;
            lbName.Text = "Mật khẩu:";
            lbName.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbPassword
            // 
            tbPassword.BorderColor = Color.Black;
            tbPassword.CustomizableEdges = customizableEdges5;
            tbPassword.DefaultText = "";
            tbPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.ForeColor = Color.Black;
            tbPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPassword.Location = new Point(157, 0);
            tbPassword.Margin = new Padding(0);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '●';
            tbPassword.PlaceholderText = "";
            tbPassword.SelectedText = "";
            tbPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbPassword.Size = new Size(313, 40);
            tbPassword.TabIndex = 1;
            tbPassword.TabStop = false;
            // 
            // guna2Elipse1
            // 
            guna2Elipse1.BorderRadius = 40;
            guna2Elipse1.TargetControl = pnLogin;
            // 
            // LoginUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.InactiveCaption;
            Controls.Add(pnLogin);
            Margin = new Padding(0);
            Name = "LoginUserControl";
            Size = new Size(1894, 946);
            pnLogin.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnUsername.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lbTitle;
        private Panel pnLogin;
        private Panel panel2;
        private CheckBox cbShowPassword;
        private Guna.UI2.WinForms.Guna2Button btnLogin;
        private Panel pnUsername;
        private Label lbUsername;
        private Guna.UI2.WinForms.Guna2TextBox tbUsername;
        private Panel panel1;
        private Label lbName;
        private Guna.UI2.WinForms.Guna2TextBox tbPassword;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
    }
}
