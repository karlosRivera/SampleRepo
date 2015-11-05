namespace PartIndexer
{
    partial class frmPartIndex
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPartIndex));
            this.Notifier = new System.Windows.Forms.NotifyIcon(this.components);
            this.SuspendLayout();
            // 
            // Notifier
            // 
            this.Notifier.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.Notifier.Icon = ((System.Drawing.Icon)(resources.GetObject("Notifier.Icon")));
            this.Notifier.Text = "Scheduler";
            this.Notifier.Visible = true;
            // 
            // frmPartIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 102);
            this.Name = "frmPartIndex";
            this.Text = "Part Indexer";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Resize += new System.EventHandler(this.frmPartIndex_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon Notifier;
    }
}

