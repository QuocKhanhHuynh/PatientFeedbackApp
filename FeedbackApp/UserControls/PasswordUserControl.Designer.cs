namespace FeedbackApp.UserControls
{
    partial class PasswordUserControl
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
            pnInfo = new GroupBox();
            flpInfor = new FlowLayoutPanel();
            pnOldPassword = new Panel();
            lbPassword = new Label();
            tbOldPassword = new Guna.UI2.WinForms.Guna2TextBox();
            pnShowOldPassword = new Panel();
            cbShowOldPassword = new CheckBox();
            pnNewPassword = new Panel();
            label1 = new Label();
            tbNewPassword = new Guna.UI2.WinForms.Guna2TextBox();
            pnShowNewPassword = new Panel();
            cbShowNewPassword = new CheckBox();
            pnConfirmPassword = new Panel();
            label2 = new Label();
            tbConfirmPassword = new Guna.UI2.WinForms.Guna2TextBox();
            flowLayoutPanel1 = new FlowLayoutPanel();
            btSave = new Guna.UI2.WinForms.Guna2Button();
            pnInfo.SuspendLayout();
            flpInfor.SuspendLayout();
            pnOldPassword.SuspendLayout();
            pnShowOldPassword.SuspendLayout();
            pnNewPassword.SuspendLayout();
            pnShowNewPassword.SuspendLayout();
            pnConfirmPassword.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnInfo
            // 
            pnInfo.Controls.Add(flpInfor);
            pnInfo.Controls.Add(flowLayoutPanel1);
            pnInfo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pnInfo.Location = new Point(523, 49);
            pnInfo.Margin = new Padding(0);
            pnInfo.Name = "pnInfo";
            pnInfo.Size = new Size(630, 568);
            pnInfo.TabIndex = 0;
            pnInfo.TabStop = false;
            pnInfo.Text = "Cập nhật mật khẩu của bạn";
            // 
            // flpInfor
            // 
            flpInfor.Controls.Add(pnOldPassword);
            flpInfor.Controls.Add(pnShowOldPassword);
            flpInfor.Controls.Add(pnNewPassword);
            flpInfor.Controls.Add(pnShowNewPassword);
            flpInfor.Controls.Add(pnConfirmPassword);
            flpInfor.Location = new Point(3, 30);
            flpInfor.Margin = new Padding(0);
            flpInfor.Name = "flpInfor";
            flpInfor.Size = new Size(624, 441);
            flpInfor.TabIndex = 0;
            // 
            // pnOldPassword
            // 
            pnOldPassword.Controls.Add(lbPassword);
            pnOldPassword.Controls.Add(tbOldPassword);
            pnOldPassword.Location = new Point(65, 5);
            pnOldPassword.Margin = new Padding(65, 5, 0, 5);
            pnOldPassword.Name = "pnOldPassword";
            pnOldPassword.Size = new Size(470, 40);
            pnOldPassword.TabIndex = 12;
            // 
            // lbPassword
            // 
            lbPassword.Location = new Point(0, 2);
            lbPassword.Margin = new Padding(0, 0, 0, 5);
            lbPassword.Name = "lbPassword";
            lbPassword.Size = new Size(157, 38);
            lbPassword.TabIndex = 1;
            lbPassword.Text = "Mật khẩu cũ:";
            lbPassword.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbOldPassword
            // 
            tbOldPassword.BorderColor = Color.Black;
            tbOldPassword.CustomizableEdges = customizableEdges1;
            tbOldPassword.DefaultText = "";
            tbOldPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbOldPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbOldPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbOldPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbOldPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbOldPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbOldPassword.ForeColor = Color.Black;
            tbOldPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbOldPassword.Location = new Point(157, 0);
            tbOldPassword.Margin = new Padding(0);
            tbOldPassword.MaxLength = 60;
            tbOldPassword.Name = "tbOldPassword";
            tbOldPassword.PasswordChar = '●';
            tbOldPassword.PlaceholderText = "";
            tbOldPassword.SelectedText = "";
            tbOldPassword.ShadowDecoration.CustomizableEdges = customizableEdges2;
            tbOldPassword.Size = new Size(313, 40);
            tbOldPassword.TabIndex = 0;
            tbOldPassword.TabStop = false;
            // 
            // pnShowOldPassword
            // 
            pnShowOldPassword.Controls.Add(cbShowOldPassword);
            pnShowOldPassword.Location = new Point(65, 55);
            pnShowOldPassword.Margin = new Padding(65, 5, 0, 5);
            pnShowOldPassword.Name = "pnShowOldPassword";
            pnShowOldPassword.Size = new Size(470, 40);
            pnShowOldPassword.TabIndex = 13;
            // 
            // cbShowOldPassword
            // 
            cbShowOldPassword.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            cbShowOldPassword.ForeColor = Color.Black;
            cbShowOldPassword.Location = new Point(166, 0);
            cbShowOldPassword.Margin = new Padding(0);
            cbShowOldPassword.Name = "cbShowOldPassword";
            cbShowOldPassword.Size = new Size(160, 40);
            cbShowOldPassword.TabIndex = 6;
            cbShowOldPassword.TabStop = false;
            cbShowOldPassword.Text = "Hiện mật khẩu cũ";
            cbShowOldPassword.UseVisualStyleBackColor = true;
            cbShowOldPassword.CheckedChanged += cbShowOldPassword_CheckedChanged;
            // 
            // pnNewPassword
            // 
            pnNewPassword.Controls.Add(label1);
            pnNewPassword.Controls.Add(tbNewPassword);
            pnNewPassword.Location = new Point(65, 105);
            pnNewPassword.Margin = new Padding(65, 5, 0, 5);
            pnNewPassword.Name = "pnNewPassword";
            pnNewPassword.Size = new Size(470, 40);
            pnNewPassword.TabIndex = 14;
            // 
            // label1
            // 
            label1.Location = new Point(0, 2);
            label1.Margin = new Padding(0, 0, 0, 5);
            label1.Name = "label1";
            label1.Size = new Size(157, 38);
            label1.TabIndex = 1;
            label1.Text = "Mật khẩu mới:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbNewPassword
            // 
            tbNewPassword.BorderColor = Color.Black;
            tbNewPassword.CustomizableEdges = customizableEdges3;
            tbNewPassword.DefaultText = "";
            tbNewPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbNewPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbNewPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbNewPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbNewPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbNewPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNewPassword.ForeColor = Color.Black;
            tbNewPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbNewPassword.Location = new Point(157, 0);
            tbNewPassword.Margin = new Padding(0);
            tbNewPassword.MaxLength = 60;
            tbNewPassword.Name = "tbNewPassword";
            tbNewPassword.PasswordChar = '●';
            tbNewPassword.PlaceholderText = "";
            tbNewPassword.SelectedText = "";
            tbNewPassword.ShadowDecoration.CustomizableEdges = customizableEdges4;
            tbNewPassword.Size = new Size(313, 40);
            tbNewPassword.TabIndex = 1;
            tbNewPassword.TabStop = false;
            // 
            // pnShowNewPassword
            // 
            pnShowNewPassword.Controls.Add(cbShowNewPassword);
            pnShowNewPassword.Location = new Point(65, 155);
            pnShowNewPassword.Margin = new Padding(65, 5, 0, 5);
            pnShowNewPassword.Name = "pnShowNewPassword";
            pnShowNewPassword.Size = new Size(470, 40);
            pnShowNewPassword.TabIndex = 15;
            // 
            // cbShowNewPassword
            // 
            cbShowNewPassword.Font = new Font("Segoe UI", 8F, FontStyle.Italic);
            cbShowNewPassword.ForeColor = Color.Black;
            cbShowNewPassword.Location = new Point(166, 0);
            cbShowNewPassword.Margin = new Padding(0);
            cbShowNewPassword.Name = "cbShowNewPassword";
            cbShowNewPassword.Size = new Size(183, 40);
            cbShowNewPassword.TabIndex = 6;
            cbShowNewPassword.TabStop = false;
            cbShowNewPassword.Text = "Hiện mật khẩu mới";
            cbShowNewPassword.UseVisualStyleBackColor = true;
            cbShowNewPassword.CheckedChanged += cbShowNewPassword_CheckedChanged;
            // 
            // pnConfirmPassword
            // 
            pnConfirmPassword.Controls.Add(label2);
            pnConfirmPassword.Controls.Add(tbConfirmPassword);
            pnConfirmPassword.Location = new Point(65, 205);
            pnConfirmPassword.Margin = new Padding(65, 5, 0, 5);
            pnConfirmPassword.Name = "pnConfirmPassword";
            pnConfirmPassword.Size = new Size(470, 40);
            pnConfirmPassword.TabIndex = 16;
            // 
            // label2
            // 
            label2.Location = new Point(0, 2);
            label2.Margin = new Padding(0, 0, 0, 5);
            label2.Name = "label2";
            label2.Size = new Size(157, 38);
            label2.TabIndex = 1;
            label2.Text = "Xác nhận:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tbConfirmPassword
            // 
            tbConfirmPassword.BorderColor = Color.Black;
            tbConfirmPassword.CustomizableEdges = customizableEdges5;
            tbConfirmPassword.DefaultText = "";
            tbConfirmPassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbConfirmPassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbConfirmPassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbConfirmPassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbConfirmPassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbConfirmPassword.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbConfirmPassword.ForeColor = Color.Black;
            tbConfirmPassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbConfirmPassword.Location = new Point(157, 0);
            tbConfirmPassword.Margin = new Padding(0);
            tbConfirmPassword.MaxLength = 60;
            tbConfirmPassword.Name = "tbConfirmPassword";
            tbConfirmPassword.PasswordChar = '●';
            tbConfirmPassword.PlaceholderText = "";
            tbConfirmPassword.SelectedText = "";
            tbConfirmPassword.ShadowDecoration.CustomizableEdges = customizableEdges6;
            tbConfirmPassword.Size = new Size(313, 40);
            tbConfirmPassword.TabIndex = 2;
            tbConfirmPassword.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.InactiveCaption;
            flowLayoutPanel1.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel1.Controls.Add(btSave);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(3, 492);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(0, 0, 15, 0);
            flowLayoutPanel1.Size = new Size(624, 73);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // btSave
            // 
            btSave.BackColor = SystemColors.ActiveCaption;
            btSave.BorderThickness = 1;
            btSave.CustomizableEdges = customizableEdges7;
            btSave.DisabledState.BorderColor = Color.DarkGray;
            btSave.DisabledState.CustomBorderColor = Color.DarkGray;
            btSave.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btSave.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btSave.FillColor = Color.Silver;
            btSave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btSave.ForeColor = Color.Black;
            btSave.Image = Properties.Resources.save;
            btSave.ImageSize = new Size(25, 25);
            btSave.Location = new Point(507, 15);
            btSave.Margin = new Padding(15, 15, 0, 15);
            btSave.Name = "btSave";
            btSave.ShadowDecoration.CustomizableEdges = customizableEdges8;
            btSave.Size = new Size(100, 43);
            btSave.TabIndex = 7;
            btSave.TabStop = false;
            btSave.Text = "Lưu";
            btSave.Click += btSave_Click;
            // 
            // PasswordUserControl
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            Controls.Add(pnInfo);
            Name = "PasswordUserControl";
            Size = new Size(1654, 946);
            pnInfo.ResumeLayout(false);
            flpInfor.ResumeLayout(false);
            pnOldPassword.ResumeLayout(false);
            pnShowOldPassword.ResumeLayout(false);
            pnNewPassword.ResumeLayout(false);
            pnShowNewPassword.ResumeLayout(false);
            pnConfirmPassword.ResumeLayout(false);
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private GroupBox pnInfo;
        private FlowLayoutPanel flowLayoutPanel1;
        public Guna.UI2.WinForms.Guna2Button btSave;
        private FlowLayoutPanel flpInfor;
        public Panel pnOldPassword;
        private Label lbPassword;
        public Panel pnShowOldPassword;
        private CheckBox cbShowOldPassword;
        private Guna.UI2.WinForms.Guna2TextBox tbOldPassword;
        public Panel pnNewPassword;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox tbNewPassword;
        public Panel pnShowNewPassword;
        private CheckBox cbShowNewPassword;
        public Panel pnConfirmPassword;
        private Label label2;
        private Guna.UI2.WinForms.Guna2TextBox tbConfirmPassword;
    }
}
