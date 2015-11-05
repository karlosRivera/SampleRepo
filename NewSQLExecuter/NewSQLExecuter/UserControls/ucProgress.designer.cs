namespace NewSQLExecuter
{
    partial class ucProgress
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
            this.pbStatus = new System.Windows.Forms.ProgressBar();
            this.lblMsg = new System.Windows.Forms.Label();
            this.picStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // pbStatus
            // 
            this.pbStatus.Location = new System.Drawing.Point(6, 3);
            this.pbStatus.Name = "pbStatus";
            this.pbStatus.Size = new System.Drawing.Size(402, 10);
            this.pbStatus.TabIndex = 0;
            // 
            // lblMsg
            // 
            this.lblMsg.AutoSize = true;
            this.lblMsg.Location = new System.Drawing.Point(3, 16);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(56, 13);
            this.lblMsg.TabIndex = 3;
            this.lblMsg.Text = "Running...";
            // 
            // picStatus
            // 
            this.picStatus.Location = new System.Drawing.Point(382, 17);
            this.picStatus.Name = "picStatus";
            this.picStatus.Size = new System.Drawing.Size(24, 19);
            this.picStatus.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picStatus.TabIndex = 4;
            this.picStatus.TabStop = false;
            // 
            // ucProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picStatus);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.pbStatus);
            this.DoubleBuffered = true;
            this.Name = "ucProgress";
            this.Size = new System.Drawing.Size(416, 42);
            ((System.ComponentModel.ISupportInitialize)(this.picStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbStatus;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.PictureBox picStatus;
    }
}
