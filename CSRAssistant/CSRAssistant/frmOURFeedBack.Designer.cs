namespace CSRAssistant
{
    partial class frmOURFeedBack
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
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroTab = new MetroFramework.Controls.MetroTabControl();
            this.tabFeedBack = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.chkRepair = new System.Windows.Forms.CheckBox();
            this.btnRatingSearch = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkEnable = new System.Windows.Forms.CheckBox();
            this.dtExTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.dtExFrom = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.chkExcludeCallCust = new System.Windows.Forms.CheckBox();
            this.txtJobID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Pager = new PagerControl.BBAPager();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSrch = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.dtto = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtfrom = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.outlookGrid1 = new OutlookStyleControls.OutlookGrid();
            this.tabRating = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.lblCounter = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.bbaPager1 = new PagerControl.BBAPager();
            this.chkBlankComment = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboRating = new System.Windows.Forms.ComboBox();
            this.dtRateTo = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSearchRating = new System.Windows.Forms.Button();
            this.dtRateFrom = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.metroToolTip2 = new MetroFramework.Components.MetroToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            this.metroTab.SuspendLayout();
            this.tabFeedBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlookGrid1)).BeginInit();
            this.tabRating.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.SuspendLayout();
            // 
            // lineShape1
            // 
            this.lineShape1.BorderColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = -5;
            this.lineShape1.X2 = 239;
            this.lineShape1.Y1 = 1;
            this.lineShape1.Y2 = 1;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(20, 60);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(965, 656);
            this.shapeContainer1.TabIndex = 0;
            this.shapeContainer1.TabStop = false;
            // 
            // metroStyleManager1
            // 
            this.metroStyleManager1.Owner = this;
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip1.StyleManager = this.metroStyleManager1;
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroTab
            // 
            this.metroTab.Controls.Add(this.tabFeedBack);
            this.metroTab.Controls.Add(this.tabRating);
            this.metroTab.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.metroTab.Location = new System.Drawing.Point(20, 77);
            this.metroTab.Name = "metroTab";
            this.metroTab.SelectedIndex = 0;
            this.metroTab.Size = new System.Drawing.Size(965, 639);
            this.metroTab.TabIndex = 1;
            this.metroTab.UseSelectable = true;
            this.metroTab.SelectedIndexChanged += new System.EventHandler(this.metroTab_SelectedIndexChanged);
            // 
            // tabFeedBack
            // 
            this.tabFeedBack.Controls.Add(this.splitContainer1);
            this.tabFeedBack.Location = new System.Drawing.Point(4, 38);
            this.tabFeedBack.Name = "tabFeedBack";
            this.tabFeedBack.Size = new System.Drawing.Size(957, 597);
            this.tabFeedBack.TabIndex = 0;
            this.tabFeedBack.Text = "FeedBack";
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
            this.splitContainer1.Panel1.Controls.Add(this.chkRepair);
            this.splitContainer1.Panel1.Controls.Add(this.btnRatingSearch);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.txtJobID);
            this.splitContainer1.Panel1.Controls.Add(this.label4);
            this.splitContainer1.Panel1.Controls.Add(this.Pager);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer1.Panel1.Controls.Add(this.lblSrch);
            this.splitContainer1.Panel1.Controls.Add(this.lblCount);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.splitContainer1.Panel1.Controls.Add(this.btnClose);
            this.splitContainer1.Panel1.Controls.Add(this.btnExport);
            this.splitContainer1.Panel1.Controls.Add(this.dtto);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel1.Controls.Add(this.dtfrom);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.outlookGrid1);
            this.splitContainer1.Size = new System.Drawing.Size(957, 597);
            this.splitContainer1.SplitterDistance = 178;
            this.splitContainer1.TabIndex = 0;
            // 
            // chkRepair
            // 
            this.chkRepair.AutoSize = true;
            this.chkRepair.Checked = true;
            this.chkRepair.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRepair.Location = new System.Drawing.Point(143, 119);
            this.chkRepair.Name = "chkRepair";
            this.chkRepair.Size = new System.Drawing.Size(69, 17);
            this.chkRepair.TabIndex = 39;
            this.chkRepair.Text = "Repaired";
            this.chkRepair.UseVisualStyleBackColor = true;
            this.chkRepair.CheckedChanged += new System.EventHandler(this.chkRepair_CheckedChanged);
            // 
            // btnRatingSearch
            // 
            this.btnRatingSearch.Location = new System.Drawing.Point(12, 119);
            this.btnRatingSearch.Name = "btnRatingSearch";
            this.btnRatingSearch.Size = new System.Drawing.Size(109, 23);
            this.btnRatingSearch.TabIndex = 38;
            this.btnRatingSearch.Text = "Search Rating";
            this.btnRatingSearch.UseVisualStyleBackColor = true;
            this.btnRatingSearch.Click += new System.EventHandler(this.btnRatingSearch_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkEnable);
            this.groupBox1.Controls.Add(this.dtExTo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtExFrom);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.chkExcludeCallCust);
            this.groupBox1.Location = new System.Drawing.Point(12, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(512, 47);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Range Exclude";
            // 
            // chkEnable
            // 
            this.chkEnable.AutoSize = true;
            this.chkEnable.Location = new System.Drawing.Point(445, 24);
            this.chkEnable.Name = "chkEnable";
            this.chkEnable.Size = new System.Drawing.Size(59, 17);
            this.chkEnable.TabIndex = 24;
            this.chkEnable.Text = "Enable";
            this.chkEnable.UseVisualStyleBackColor = true;
            this.chkEnable.CheckedChanged += new System.EventHandler(this.chkEnable_CheckedChanged);
            // 
            // dtExTo
            // 
            this.dtExTo.Enabled = false;
            this.dtExTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExTo.Location = new System.Drawing.Point(346, 19);
            this.dtExTo.Name = "dtExTo";
            this.dtExTo.Size = new System.Drawing.Size(93, 20);
            this.dtExTo.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(320, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "To";
            // 
            // dtExFrom
            // 
            this.dtExFrom.Enabled = false;
            this.dtExFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtExFrom.Location = new System.Drawing.Point(225, 19);
            this.dtExFrom.Name = "dtExFrom";
            this.dtExFrom.Size = new System.Drawing.Size(89, 20);
            this.dtExFrom.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(189, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "From";
            // 
            // chkExcludeCallCust
            // 
            this.chkExcludeCallCust.AutoSize = true;
            this.chkExcludeCallCust.Location = new System.Drawing.Point(13, 19);
            this.chkExcludeCallCust.Name = "chkExcludeCallCust";
            this.chkExcludeCallCust.Size = new System.Drawing.Size(165, 17);
            this.chkExcludeCallCust.TabIndex = 7;
            this.chkExcludeCallCust.Text = "Exclude Called Up Customers";
            this.chkExcludeCallCust.UseVisualStyleBackColor = true;
            // 
            // txtJobID
            // 
            this.txtJobID.Location = new System.Drawing.Point(49, 37);
            this.txtJobID.Name = "txtJobID";
            this.txtJobID.Size = new System.Drawing.Size(59, 20);
            this.txtJobID.TabIndex = 36;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Job ID";
            // 
            // Pager
            // 
            this.Pager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Pager.Location = new System.Drawing.Point(12, 148);
            this.Pager.MaximumNumberofLinks = 0;
            this.Pager.Name = "Pager";
            this.Pager.PageSize = 0;
            this.Pager.RecordCount = 0;
            this.Pager.Size = new System.Drawing.Size(515, 21);
            this.Pager.TabIndex = 34;
            this.Pager.PageClicked += new PagerControl.BBAPager.PageClick(this.Pager_PageClicked);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(225, 37);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(299, 20);
            this.txtSearch.TabIndex = 33;
            // 
            // lblSrch
            // 
            this.lblSrch.AutoSize = true;
            this.lblSrch.Location = new System.Drawing.Point(112, 40);
            this.lblSrch.Name = "lblSrch";
            this.lblSrch.Size = new System.Drawing.Size(110, 13);
            this.lblSrch.TabIndex = 32;
            this.lblSrch.Text = "Enter Customer Name";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(484, 119);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(27, 13);
            this.lblCount.TabIndex = 31;
            this.lblCount.Text = "N/A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(343, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Total records found : ";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(449, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 29;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(351, 7);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(89, 23);
            this.btnExport.TabIndex = 28;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            // 
            // dtto
            // 
            this.dtto.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtto.Location = new System.Drawing.Point(166, 9);
            this.dtto.Name = "dtto";
            this.dtto.Size = new System.Drawing.Size(93, 20);
            this.dtto.TabIndex = 27;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "To";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(265, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 25;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtfrom
            // 
            this.dtfrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtfrom.Location = new System.Drawing.Point(45, 9);
            this.dtfrom.Name = "dtfrom";
            this.dtfrom.Size = new System.Drawing.Size(89, 20);
            this.dtfrom.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "From";
            // 
            // outlookGrid1
            // 
            this.outlookGrid1.AllowUserToAddRows = false;
            this.outlookGrid1.AllowUserToDeleteRows = false;
            this.outlookGrid1.CollapseIcon = null;
            this.outlookGrid1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.outlookGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.outlookGrid1.ExpandIcon = null;
            this.outlookGrid1.Location = new System.Drawing.Point(0, 0);
            this.outlookGrid1.Name = "outlookGrid1";
            this.outlookGrid1.ReadOnly = true;
            this.outlookGrid1.Size = new System.Drawing.Size(957, 415);
            this.outlookGrid1.TabIndex = 1;
            this.outlookGrid1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outlookGrid1_CellClick);
            this.outlookGrid1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.outlookGrid1_CellDoubleClick);
            this.outlookGrid1.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.outlookGrid1_CellMouseDoubleClick);
            // 
            // tabRating
            // 
            this.tabRating.Controls.Add(this.splitContainer3);
            this.tabRating.Location = new System.Drawing.Point(4, 38);
            this.tabRating.Name = "tabRating";
            this.tabRating.Size = new System.Drawing.Size(957, 597);
            this.tabRating.TabIndex = 1;
            this.tabRating.Text = "Search Rating";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.lblCounter);
            this.splitContainer3.Panel1.Controls.Add(this.label8);
            this.splitContainer3.Panel1.Controls.Add(this.bbaPager1);
            this.splitContainer3.Panel1.Controls.Add(this.chkBlankComment);
            this.splitContainer3.Panel1.Controls.Add(this.label9);
            this.splitContainer3.Panel1.Controls.Add(this.cboRating);
            this.splitContainer3.Panel1.Controls.Add(this.dtRateTo);
            this.splitContainer3.Panel1.Controls.Add(this.label10);
            this.splitContainer3.Panel1.Controls.Add(this.btnSearchRating);
            this.splitContainer3.Panel1.Controls.Add(this.dtRateFrom);
            this.splitContainer3.Panel1.Controls.Add(this.label11);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.dgList);
            this.splitContainer3.Size = new System.Drawing.Size(957, 597);
            this.splitContainer3.SplitterDistance = 64;
            this.splitContainer3.TabIndex = 0;
            // 
            // lblCounter
            // 
            this.lblCounter.AutoSize = true;
            this.lblCounter.Location = new System.Drawing.Point(483, 41);
            this.lblCounter.Name = "lblCounter";
            this.lblCounter.Size = new System.Drawing.Size(27, 13);
            this.lblCounter.TabIndex = 40;
            this.lblCounter.Text = "N/A";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(342, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(130, 13);
            this.label8.TabIndex = 39;
            this.label8.Text = "Total records found : ";
            // 
            // bbaPager1
            // 
            this.bbaPager1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.bbaPager1.Location = new System.Drawing.Point(16, 37);
            this.bbaPager1.MaximumNumberofLinks = 0;
            this.bbaPager1.Name = "bbaPager1";
            this.bbaPager1.PageSize = 0;
            this.bbaPager1.RecordCount = 0;
            this.bbaPager1.Size = new System.Drawing.Size(299, 21);
            this.bbaPager1.TabIndex = 38;
            this.bbaPager1.PageClicked += new PagerControl.BBAPager.PageClick(this.bbaPager1_PageClicked);
            // 
            // chkBlankComment
            // 
            this.chkBlankComment.AutoSize = true;
            this.chkBlankComment.Location = new System.Drawing.Point(450, 11);
            this.chkBlankComment.Name = "chkBlankComment";
            this.chkBlankComment.Size = new System.Drawing.Size(107, 17);
            this.chkBlankComment.TabIndex = 37;
            this.chkBlankComment.Text = "Empty Comments";
            this.chkBlankComment.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(269, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 36;
            this.label9.Text = "Rating";
            // 
            // cboRating
            // 
            this.cboRating.FormattingEnabled = true;
            this.cboRating.Location = new System.Drawing.Point(313, 9);
            this.cboRating.Name = "cboRating";
            this.cboRating.Size = new System.Drawing.Size(121, 21);
            this.cboRating.TabIndex = 35;
            // 
            // dtRateTo
            // 
            this.dtRateTo.CustomFormat = "dd/MM/yyyy";
            this.dtRateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRateTo.Location = new System.Drawing.Point(170, 11);
            this.dtRateTo.Name = "dtRateTo";
            this.dtRateTo.Size = new System.Drawing.Size(93, 20);
            this.dtRateTo.TabIndex = 34;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(144, 12);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 33;
            this.label10.Text = "To";
            // 
            // btnSearchRating
            // 
            this.btnSearchRating.Location = new System.Drawing.Point(563, 8);
            this.btnSearchRating.Name = "btnSearchRating";
            this.btnSearchRating.Size = new System.Drawing.Size(75, 23);
            this.btnSearchRating.TabIndex = 32;
            this.btnSearchRating.Text = "Search";
            this.btnSearchRating.UseVisualStyleBackColor = true;
            this.btnSearchRating.Click += new System.EventHandler(this.btnSearchRating_Click);
            // 
            // dtRateFrom
            // 
            this.dtRateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtRateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtRateFrom.Location = new System.Drawing.Point(49, 11);
            this.dtRateFrom.Name = "dtRateFrom";
            this.dtRateFrom.Size = new System.Drawing.Size(89, 20);
            this.dtRateFrom.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 12);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 30;
            this.label11.Text = "From";
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.Location = new System.Drawing.Point(0, 0);
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.Size = new System.Drawing.Size(957, 529);
            this.dgList.TabIndex = 31;
            // 
            // metroToolTip2
            // 
            this.metroToolTip2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroToolTip2.StyleManager = null;
            this.metroToolTip2.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // frmOURFeedBack
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = global::CSRAssistant.Properties.Resources.part3;
            this.BackImagePadding = new System.Windows.Forms.Padding(170, 10, 10, 0);
            this.BackMaxSize = 50;
            this.ClientSize = new System.Drawing.Size(1005, 736);
            this.Controls.Add(this.metroTab);
            this.Controls.Add(this.shapeContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Movable = false;
            this.Name = "frmOURFeedBack";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StyleManager = this.metroStyleManager1;
            this.Text = "Comments";
            this.Load += new System.EventHandler(this.frmOURFeedBack_Load);
            this.Move += new System.EventHandler(this.frmOURFeedBack_Move);
            this.Resize += new System.EventHandler(this.Form2_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            this.metroTab.ResumeLayout(false);
            this.tabFeedBack.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.outlookGrid1)).EndInit();
            this.tabRating.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.PerformLayout();
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTabControl metroTab;
        private System.Windows.Forms.TabPage tabFeedBack;
        private System.Windows.Forms.TabPage tabRating;
        private MetroFramework.Components.MetroToolTip metroToolTip2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkRepair;
        private System.Windows.Forms.Button btnRatingSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkEnable;
        private System.Windows.Forms.DateTimePicker dtExTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtExFrom;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkExcludeCallCust;
        private System.Windows.Forms.TextBox txtJobID;
        private System.Windows.Forms.Label label4;
        private PagerControl.BBAPager Pager;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSrch;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DateTimePicker dtto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtfrom;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label lblCounter;
        private System.Windows.Forms.Label label8;
        private PagerControl.BBAPager bbaPager1;
        private System.Windows.Forms.CheckBox chkBlankComment;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboRating;
        private System.Windows.Forms.DateTimePicker dtRateTo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnSearchRating;
        private System.Windows.Forms.DateTimePicker dtRateFrom;
        private System.Windows.Forms.Label label11;
        private OutlookStyleControls.OutlookGrid outlookGrid1;
        private System.Windows.Forms.DataGridView dgList;
    }
}