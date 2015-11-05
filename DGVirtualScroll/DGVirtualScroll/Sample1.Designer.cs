namespace DGVirtualScroll
{
    partial class Sample1
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ucVirtualScrollGrid1 = new ucDGVirtualScroll.ucVirtualScrollGrid();
            this.txtFilters = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lblComents = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ucVirtualScrollGrid1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lblComents);
            this.splitContainer1.Panel2.Controls.Add(this.txtFilters);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btnLoad);
            this.splitContainer1.Size = new System.Drawing.Size(942, 536);
            this.splitContainer1.SplitterDistance = 482;
            this.splitContainer1.TabIndex = 0;
            // 
            // ucVirtualScrollGrid1
            // 
            this.ucVirtualScrollGrid1.ConnectionString = "";
            this.ucVirtualScrollGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucVirtualScrollGrid1.Filters = "";
            this.ucVirtualScrollGrid1.Location = new System.Drawing.Point(0, 0);
            this.ucVirtualScrollGrid1.Name = "ucVirtualScrollGrid1";
            this.ucVirtualScrollGrid1.PageSize = 0;
            this.ucVirtualScrollGrid1.ShowRowNumber = true;
            this.ucVirtualScrollGrid1.Size = new System.Drawing.Size(942, 482);
            this.ucVirtualScrollGrid1.SortColumn = "";
            this.ucVirtualScrollGrid1.SortOrder = "";
            this.ucVirtualScrollGrid1.TabIndex = 0;
            this.ucVirtualScrollGrid1.TableName = "";
            // 
            // txtFilters
            // 
            this.txtFilters.Location = new System.Drawing.Point(53, 6);
            this.txtFilters.Name = "txtFilters";
            this.txtFilters.Size = new System.Drawing.Size(796, 20);
            this.txtFilters.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Filters";
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(855, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 0;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lblComents
            // 
            this.lblComents.AutoSize = true;
            this.lblComents.Location = new System.Drawing.Point(13, 29);
            this.lblComents.Name = "lblComents";
            this.lblComents.Size = new System.Drawing.Size(27, 13);
            this.lblComents.TabIndex = 3;
            this.lblComents.Text = "N/A";
            // 
            // Sample1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 536);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Sample1";
            this.Text = "Sample1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private ucDGVirtualScroll.ucVirtualScrollGrid ucVirtualScrollGrid1;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtFilters;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblComents;
    }
}