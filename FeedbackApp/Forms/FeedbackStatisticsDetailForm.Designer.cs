namespace FeedbackApp.Forms
{
    partial class FeedbackStatisticsDetailForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackStatisticsDetailForm));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            panel3 = new Panel();
            lbTitle = new Label();
            btExport = new Guna.UI2.WinForms.Guna2Button();
            btLeft = new Guna.UI2.WinForms.Guna2Button();
            btRight = new Guna.UI2.WinForms.Guna2Button();
            tbPageNumber = new Guna.UI2.WinForms.Guna2TextBox();
            dtList = new DataGridView();
            sfdExport = new SaveFileDialog();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtList).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.HotTrack;
            panel3.Controls.Add(lbTitle);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 0);
            panel3.Margin = new Padding(0);
            panel3.Name = "panel3";
            panel3.Size = new Size(1728, 60);
            panel3.TabIndex = 2;
            panel3.TabStop = true;
            // 
            // lbTitle
            // 
            lbTitle.AutoSize = true;
            lbTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTitle.ForeColor = Color.White;
            lbTitle.Location = new Point(0, 16);
            lbTitle.Margin = new Padding(210, 16, 3, 0);
            lbTitle.Name = "lbTitle";
            lbTitle.Size = new Size(135, 28);
            lbTitle.TabIndex = 1;
            lbTitle.Text = "Tên thống kê";
            // 
            // btExport
            // 
            btExport.BackColor = SystemColors.ActiveCaption;
            btExport.BorderThickness = 1;
            btExport.CustomizableEdges = customizableEdges1;
            btExport.DisabledState.BorderColor = Color.DarkGray;
            btExport.DisabledState.CustomBorderColor = Color.DarkGray;
            btExport.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btExport.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btExport.FillColor = Color.Silver;
            btExport.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btExport.ForeColor = Color.Black;
            btExport.Image = (Image)resources.GetObject("btExport.Image");
            btExport.ImageSize = new Size(25, 25);
            btExport.Location = new Point(1613, 9);
            btExport.Margin = new Padding(0, 9, 15, 15);
            btExport.Name = "btExport";
            btExport.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btExport.Size = new Size(100, 43);
            btExport.TabIndex = 18;
            btExport.Text = "Xuất";
            btExport.Click += btExport_Click;
            // 
            // btLeft
            // 
            btLeft.BackColor = SystemColors.ActiveCaption;
            btLeft.BorderThickness = 1;
            btLeft.CustomizableEdges = customizableEdges3;
            btLeft.DisabledState.BorderColor = Color.DarkGray;
            btLeft.DisabledState.CustomBorderColor = Color.DarkGray;
            btLeft.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btLeft.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btLeft.FillColor = Color.Silver;
            btLeft.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btLeft.ForeColor = Color.Black;
            btLeft.Image = (Image)resources.GetObject("btLeft.Image");
            btLeft.ImageSize = new Size(35, 35);
            btLeft.Location = new Point(1288, 9);
            btLeft.Margin = new Padding(0, 9, 15, 15);
            btLeft.Name = "btLeft";
            btLeft.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btLeft.Size = new Size(100, 43);
            btLeft.TabIndex = 17;
            btLeft.Click += btLeft_Click;
            // 
            // btRight
            // 
            btRight.BackColor = SystemColors.ActiveCaption;
            btRight.BorderThickness = 1;
            btRight.CustomizableEdges = customizableEdges5;
            btRight.DisabledState.BorderColor = Color.DarkGray;
            btRight.DisabledState.CustomBorderColor = Color.DarkGray;
            btRight.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btRight.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btRight.FillColor = Color.Silver;
            btRight.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btRight.ForeColor = Color.Black;
            btRight.Image = (Image)resources.GetObject("btRight.Image");
            btRight.ImageSize = new Size(35, 35);
            btRight.Location = new Point(1498, 9);
            btRight.Margin = new Padding(0, 9, 15, 15);
            btRight.Name = "btRight";
            btRight.ShadowDecoration.CustomizableEdges = customizableEdges6;
            btRight.Size = new Size(100, 43);
            btRight.TabIndex = 16;
            btRight.Click += btRight_Click;
            // 
            // tbPageNumber
            // 
            tbPageNumber.BorderColor = Color.Black;
            tbPageNumber.CustomizableEdges = customizableEdges7;
            tbPageNumber.DefaultText = "";
            tbPageNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            tbPageNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            tbPageNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            tbPageNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            tbPageNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPageNumber.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPageNumber.ForeColor = Color.Black;
            tbPageNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            tbPageNumber.Location = new Point(1403, 9);
            tbPageNumber.Margin = new Padding(0, 9, 15, 15);
            tbPageNumber.Name = "tbPageNumber";
            tbPageNumber.PasswordChar = '\0';
            tbPageNumber.PlaceholderText = "";
            tbPageNumber.ReadOnly = true;
            tbPageNumber.SelectedText = "";
            tbPageNumber.ShadowDecoration.CustomizableEdges = customizableEdges8;
            tbPageNumber.Size = new Size(80, 40);
            tbPageNumber.TabIndex = 15;
            tbPageNumber.TextAlign = HorizontalAlignment.Center;
            // 
            // dtList
            // 
            dtList.AllowUserToResizeColumns = false;
            dtList.AllowUserToResizeRows = false;
            dtList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtList.BackgroundColor = Color.LightGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dtList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dtList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dtList.Dock = DockStyle.Fill;
            dtList.Location = new Point(0, 60);
            dtList.Margin = new Padding(0);
            dtList.MultiSelect = false;
            dtList.Name = "dtList";
            dtList.RowHeadersVisible = false;
            dtList.RowHeadersWidth = 62;
            dtList.Size = new Size(1728, 839);
            dtList.TabIndex = 6;
            dtList.TabStop = false;
            dtList.CellClick += dtList_CellClick;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = SystemColors.InactiveCaption;
            flowLayoutPanel1.Controls.Add(btExport);
            flowLayoutPanel1.Controls.Add(btRight);
            flowLayoutPanel1.Controls.Add(tbPageNumber);
            flowLayoutPanel1.Controls.Add(btLeft);
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
            flowLayoutPanel1.Location = new Point(0, 839);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1728, 60);
            flowLayoutPanel1.TabIndex = 7;
            // 
            // FeedbackStatisticsDetailForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1728, 899);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(dtList);
            Controls.Add(panel3);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FeedbackStatisticsDetailForm";
            Text = "Chi tiết thống kê";
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtList).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel3;
        private Label lbTitle;
        private Guna.UI2.WinForms.Guna2TextBox tbPageNumber;
        public Guna.UI2.WinForms.Guna2Button btLeft;
        public Guna.UI2.WinForms.Guna2Button btRight;
        public Guna.UI2.WinForms.Guna2Button btExport;
        public DataGridView dtList;
        private SaveFileDialog sfdExport;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}