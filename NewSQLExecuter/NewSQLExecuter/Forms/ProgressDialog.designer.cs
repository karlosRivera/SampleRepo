namespace NewSQLExecuter
{
    partial class ProgressDialog
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
            this.fpPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMsg = new System.Windows.Forms.Label();
            this.lblClose = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // fpPanel
            // 
            this.fpPanel.AutoScroll = true;
            this.fpPanel.BackColor = System.Drawing.Color.Transparent;
            this.fpPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.fpPanel.Location = new System.Drawing.Point(8, 12);
            this.fpPanel.Name = "fpPanel";
            this.fpPanel.Size = new System.Drawing.Size(422, 550);
            this.fpPanel.TabIndex = 9;
            this.fpPanel.WrapContents = false;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Location = new System.Drawing.Point(13, 569);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(27, 13);
            this.lblMsg.TabIndex = 10;
            this.lblMsg.Text = "N/A";
            // 
            // lblClose
            // 
            this.lblClose.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblClose.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblClose.Location = new System.Drawing.Point(357, 569);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(73, 27);
            this.lblClose.TabIndex = 11;
            this.lblClose.Text = "Close";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            // 
            // ProgressDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 602);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.fpPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProgressDialog";
            this.ShowInTaskbar = false;
            this.Text = "Form3";
            this.Activated += new System.EventHandler(this.ProgressDialog_Activated);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ProgressDialog_Paint);
            this.Resize += new System.EventHandler(this.ProgressDialog_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel fpPanel;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Label lblClose;

    }
}