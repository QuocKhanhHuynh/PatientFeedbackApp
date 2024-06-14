namespace FeedbackApp.Forms
{
    partial class FeedbackDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeedbackDetailForm));
            panel1 = new Panel();
            panel2 = new Panel();
            flpContent = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(143, 904);
            panel1.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(1595, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(143, 904);
            panel2.TabIndex = 4;
            // 
            // flpContent
            // 
            flpContent.AutoScroll = true;
            flpContent.AutoSize = true;
            flpContent.Dock = DockStyle.Fill;
            flpContent.FlowDirection = FlowDirection.TopDown;
            flpContent.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            flpContent.Location = new Point(143, 0);
            flpContent.Margin = new Padding(0);
            flpContent.Name = "flpContent";
            flpContent.Size = new Size(1452, 904);
            flpContent.TabIndex = 6;
            flpContent.WrapContents = false;
            // 
            // FeedbackDetailForm1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(1738, 904);
            Controls.Add(flpContent);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FeedbackDetailForm1";
            Text = "Chi tiết phản hồi";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Panel panel2;
        public FlowLayoutPanel flpContent;
    }
}