namespace CSRAssistant
{
    partial class frmCallAssistant
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.rdFrom = new MetroFramework.Controls.MetroCheckBox();
            this.rdAllEscalated = new MetroFramework.Controls.MetroRadioButton();
            this.rdCallNotDone = new MetroFramework.Controls.MetroRadioButton();
            this.rdAllDoneShip = new MetroFramework.Controls.MetroRadioButton();
            this.rdAllCallbacks = new MetroFramework.Controls.MetroRadioButton();
            this.rdAllDebtorJobs = new MetroFramework.Controls.MetroRadioButton();
            this.txtTrackNo = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel5 = new MetroFramework.Controls.MetroLabel();
            this.btnFillJobs = new MetroFramework.Controls.MetroButton();
            this.dtpkFrom = new System.Windows.Forms.DateTimePicker();
            this.dtpkTo = new System.Windows.Forms.DateTimePicker();
            this.btnGo = new MetroFramework.Controls.MetroButton();
            this.txtJID = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.dtpkJobDate = new System.Windows.Forms.DateTimePicker();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.shapeContainer1 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape1 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.metroLabel28 = new MetroFramework.Controls.MetroLabel();
            this.txtTemplate = new MetroFramework.Controls.MetroTextBox();
            this.btnRemTemplate = new MetroFramework.Controls.MetroButton();
            this.btnTemplate = new MetroFramework.Controls.MetroButton();
            this.btnSave = new MetroFramework.Controls.MetroButton();
            this.lstTemplate = new System.Windows.Forms.ListBox();
            this.rdEscalated = new MetroFramework.Controls.MetroRadioButton();
            this.rdNotDone = new MetroFramework.Controls.MetroRadioButton();
            this.rdDonewithShip = new MetroFramework.Controls.MetroRadioButton();
            this.rdCallBack = new MetroFramework.Controls.MetroRadioButton();
            this.rdDone = new MetroFramework.Controls.MetroRadioButton();
            this.txtShopRemarks = new MetroFramework.Controls.MetroTextBox();
            this.txtRem = new MetroFramework.Controls.MetroTextBox();
            this.txtOldRem = new MetroFramework.Controls.MetroTextBox();
            this.cboRetShipNo = new MetroFramework.Controls.MetroComboBox();
            this.cboShipNo = new MetroFramework.Controls.MetroComboBox();
            this.btnExport = new MetroFramework.Controls.MetroButton();
            this.btnCall = new MetroFramework.Controls.MetroButton();
            this.txtAddress = new MetroFramework.Controls.MetroTextBox();
            this.txtPhNo = new MetroFramework.Controls.MetroTextBox();
            this.lblAccRef = new MetroFramework.Controls.MetroLabel();
            this.metroLabel13 = new MetroFramework.Controls.MetroLabel();
            this.lblOERef = new MetroFramework.Controls.MetroLabel();
            this.metroLabel17 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel11 = new MetroFramework.Controls.MetroLabel();
            this.lblContactName = new MetroFramework.Controls.MetroLabel();
            this.lblRetCount = new MetroFramework.Controls.MetroLabel();
            this.lblShipCount = new MetroFramework.Controls.MetroLabel();
            this.lblJID = new MetroFramework.Controls.MetroLabel();
            this.lblCustName = new MetroFramework.Controls.MetroLabel();
            this.metroLabel18 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel26 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel15 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel27 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel25 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel23 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel21 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel19 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel9 = new MetroFramework.Controls.MetroLabel();
            this.shapeContainer2 = new Microsoft.VisualBasic.PowerPacks.ShapeContainer();
            this.lineShape2 = new Microsoft.VisualBasic.PowerPacks.LineShape();
            this.metroTile1 = new MetroFramework.Controls.MetroTile();
            this.metroStyleExtender1 = new MetroFramework.Components.MetroStyleExtender(this.components);
            this.metroStyleManager1 = new MetroFramework.Components.MetroStyleManager(this.components);
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.picSound = new System.Windows.Forms.PictureBox();
            this.lblCallStatus = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(20, 60);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.lblCallStatus);
            this.splitContainer1.Panel1.Controls.Add(this.picSound);
            this.splitContainer1.Panel1.Controls.Add(this.rdFrom);
            this.splitContainer1.Panel1.Controls.Add(this.rdAllEscalated);
            this.splitContainer1.Panel1.Controls.Add(this.rdCallNotDone);
            this.splitContainer1.Panel1.Controls.Add(this.rdAllDoneShip);
            this.splitContainer1.Panel1.Controls.Add(this.rdAllCallbacks);
            this.splitContainer1.Panel1.Controls.Add(this.rdAllDebtorJobs);
            this.splitContainer1.Panel1.Controls.Add(this.txtTrackNo);
            this.splitContainer1.Panel1.Controls.Add(this.metroLabel5);
            this.splitContainer1.Panel1.Controls.Add(this.btnFillJobs);
            this.splitContainer1.Panel1.Controls.Add(this.dtpkFrom);
            this.splitContainer1.Panel1.Controls.Add(this.dtpkTo);
            this.splitContainer1.Panel1.Controls.Add(this.btnGo);
            this.splitContainer1.Panel1.Controls.Add(this.txtJID);
            this.splitContainer1.Panel1.Controls.Add(this.metroLabel3);
            this.splitContainer1.Panel1.Controls.Add(this.dtpkJobDate);
            this.splitContainer1.Panel1.Controls.Add(this.metroLabel2);
            this.splitContainer1.Panel1.Controls.Add(this.shapeContainer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(811, 714);
            this.splitContainer1.SplitterDistance = 110;
            this.splitContainer1.TabIndex = 0;
            // 
            // rdFrom
            // 
            this.rdFrom.AutoSize = true;
            this.rdFrom.Location = new System.Drawing.Point(238, 53);
            this.rdFrom.Name = "rdFrom";
            this.rdFrom.Size = new System.Drawing.Size(51, 15);
            this.rdFrom.TabIndex = 39;
            this.rdFrom.Text = "From";
            this.rdFrom.UseSelectable = true;
            this.rdFrom.UseStyleColors = true;
            this.rdFrom.CheckedChanged += new System.EventHandler(this.rdFrom_CheckedChanged);
            // 
            // rdAllEscalated
            // 
            this.rdAllEscalated.AutoSize = true;
            this.rdAllEscalated.Location = new System.Drawing.Point(559, 80);
            this.rdAllEscalated.Name = "rdAllEscalated";
            this.rdAllEscalated.Size = new System.Drawing.Size(115, 15);
            this.rdAllEscalated.TabIndex = 38;
            this.rdAllEscalated.Text = "All Escalated Jobs";
            this.rdAllEscalated.UseSelectable = true;
            // 
            // rdCallNotDone
            // 
            this.rdCallNotDone.AutoSize = true;
            this.rdCallNotDone.Location = new System.Drawing.Point(413, 80);
            this.rdCallNotDone.Name = "rdCallNotDone";
            this.rdCallNotDone.Size = new System.Drawing.Size(140, 15);
            this.rdCallNotDone.TabIndex = 37;
            this.rdCallNotDone.Text = "All Call Not Done Jobs";
            this.rdCallNotDone.UseSelectable = true;
            // 
            // rdAllDoneShip
            // 
            this.rdAllDoneShip.AutoSize = true;
            this.rdAllDoneShip.Location = new System.Drawing.Point(254, 80);
            this.rdAllDoneShip.Name = "rdAllDoneShip";
            this.rdAllDoneShip.Size = new System.Drawing.Size(153, 15);
            this.rdAllDoneShip.TabIndex = 36;
            this.rdAllDoneShip.Text = "All Done && Shipped Jobs";
            this.rdAllDoneShip.UseSelectable = true;
            // 
            // rdAllCallbacks
            // 
            this.rdAllCallbacks.AutoSize = true;
            this.rdAllCallbacks.Location = new System.Drawing.Point(121, 80);
            this.rdAllCallbacks.Name = "rdAllCallbacks";
            this.rdAllCallbacks.Size = new System.Drawing.Size(125, 15);
            this.rdAllCallbacks.TabIndex = 35;
            this.rdAllCallbacks.Text = "Only Call Back Jobs";
            this.rdAllCallbacks.UseSelectable = true;
            // 
            // rdAllDebtorJobs
            // 
            this.rdAllDebtorJobs.AutoSize = true;
            this.rdAllDebtorJobs.Location = new System.Drawing.Point(13, 80);
            this.rdAllDebtorJobs.Name = "rdAllDebtorJobs";
            this.rdAllDebtorJobs.Size = new System.Drawing.Size(102, 15);
            this.rdAllDebtorJobs.TabIndex = 34;
            this.rdAllDebtorJobs.Text = "All Debtor Jobs";
            this.rdAllDebtorJobs.UseSelectable = true;
            // 
            // txtTrackNo
            // 
            this.txtTrackNo.Lines = new string[0];
            this.txtTrackNo.Location = new System.Drawing.Point(304, 7);
            this.txtTrackNo.MaxLength = 32767;
            this.txtTrackNo.Name = "txtTrackNo";
            this.txtTrackNo.PasswordChar = '\0';
            this.txtTrackNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTrackNo.SelectedText = "";
            this.txtTrackNo.Size = new System.Drawing.Size(218, 23);
            this.txtTrackNo.TabIndex = 32;
            this.txtTrackNo.UseSelectable = true;
            this.txtTrackNo.UseStyleColors = true;
            // 
            // metroLabel5
            // 
            this.metroLabel5.AutoSize = true;
            this.metroLabel5.Location = new System.Drawing.Point(205, 7);
            this.metroLabel5.Name = "metroLabel5";
            this.metroLabel5.Size = new System.Drawing.Size(93, 19);
            this.metroLabel5.TabIndex = 31;
            this.metroLabel5.Text = "Track Number";
            this.metroLabel5.UseStyleColors = true;
            // 
            // btnFillJobs
            // 
            this.btnFillJobs.Location = new System.Drawing.Point(528, 49);
            this.btnFillJobs.Name = "btnFillJobs";
            this.btnFillJobs.Size = new System.Drawing.Size(146, 23);
            this.btnFillJobs.TabIndex = 30;
            this.btnFillJobs.Text = "Fill Jobs";
            this.btnFillJobs.UseSelectable = true;
            this.btnFillJobs.UseStyleColors = true;
            this.btnFillJobs.Click += new System.EventHandler(this.btnFillJobs_Click);
            // 
            // dtpkFrom
            // 
            this.dtpkFrom.CustomFormat = "dd/MM/yyyy";
            this.dtpkFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkFrom.Location = new System.Drawing.Point(294, 49);
            this.dtpkFrom.Name = "dtpkFrom";
            this.dtpkFrom.Size = new System.Drawing.Size(104, 21);
            this.dtpkFrom.TabIndex = 24;
            // 
            // dtpkTo
            // 
            this.dtpkTo.CustomFormat = "dd/MM/yyyy";
            this.dtpkTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkTo.Location = new System.Drawing.Point(413, 49);
            this.dtpkTo.Name = "dtpkTo";
            this.dtpkTo.Size = new System.Drawing.Size(104, 21);
            this.dtpkTo.TabIndex = 23;
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(528, 7);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(146, 23);
            this.btnGo.TabIndex = 16;
            this.btnGo.Text = "Go";
            this.btnGo.UseSelectable = true;
            this.btnGo.UseStyleColors = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtJID
            // 
            this.txtJID.Lines = new string[0];
            this.txtJID.Location = new System.Drawing.Point(62, 7);
            this.txtJID.MaxLength = 32767;
            this.txtJID.Name = "txtJID";
            this.txtJID.PasswordChar = '\0';
            this.txtJID.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtJID.SelectedText = "";
            this.txtJID.Size = new System.Drawing.Size(132, 23);
            this.txtJID.TabIndex = 15;
            this.txtJID.UseSelectable = true;
            this.txtJID.UseStyleColors = true;
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(11, 7);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(46, 19);
            this.metroLabel3.TabIndex = 14;
            this.metroLabel3.Text = "Job ID";
            this.metroLabel3.UseStyleColors = true;
            // 
            // dtpkJobDate
            // 
            this.dtpkJobDate.CustomFormat = "dd/MM/yyyy";
            this.dtpkJobDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpkJobDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpkJobDate.Location = new System.Drawing.Point(116, 49);
            this.dtpkJobDate.Name = "dtpkJobDate";
            this.dtpkJobDate.Size = new System.Drawing.Size(104, 21);
            this.dtpkJobDate.TabIndex = 13;
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(11, 49);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(36, 19);
            this.metroLabel2.TabIndex = 2;
            this.metroLabel2.Text = "Date";
            this.metroLabel2.UseStyleColors = true;
            // 
            // shapeContainer1
            // 
            this.shapeContainer1.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer1.Name = "shapeContainer1";
            this.shapeContainer1.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape1});
            this.shapeContainer1.Size = new System.Drawing.Size(811, 110);
            this.shapeContainer1.TabIndex = 29;
            this.shapeContainer1.TabStop = false;
            // 
            // lineShape1
            // 
            this.lineShape1.Name = "lineShape1";
            this.lineShape1.X1 = 13;
            this.lineShape1.X2 = 797;
            this.lineShape1.Y1 = 40;
            this.lineShape1.Y2 = 40;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dgList);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel28);
            this.splitContainer2.Panel2.Controls.Add(this.txtTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.btnRemTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.btnTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.btnSave);
            this.splitContainer2.Panel2.Controls.Add(this.lstTemplate);
            this.splitContainer2.Panel2.Controls.Add(this.rdEscalated);
            this.splitContainer2.Panel2.Controls.Add(this.rdNotDone);
            this.splitContainer2.Panel2.Controls.Add(this.rdDonewithShip);
            this.splitContainer2.Panel2.Controls.Add(this.rdCallBack);
            this.splitContainer2.Panel2.Controls.Add(this.rdDone);
            this.splitContainer2.Panel2.Controls.Add(this.txtShopRemarks);
            this.splitContainer2.Panel2.Controls.Add(this.txtRem);
            this.splitContainer2.Panel2.Controls.Add(this.txtOldRem);
            this.splitContainer2.Panel2.Controls.Add(this.cboRetShipNo);
            this.splitContainer2.Panel2.Controls.Add(this.cboShipNo);
            this.splitContainer2.Panel2.Controls.Add(this.btnExport);
            this.splitContainer2.Panel2.Controls.Add(this.btnCall);
            this.splitContainer2.Panel2.Controls.Add(this.txtAddress);
            this.splitContainer2.Panel2.Controls.Add(this.txtPhNo);
            this.splitContainer2.Panel2.Controls.Add(this.lblAccRef);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel13);
            this.splitContainer2.Panel2.Controls.Add(this.lblOERef);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel17);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel11);
            this.splitContainer2.Panel2.Controls.Add(this.lblContactName);
            this.splitContainer2.Panel2.Controls.Add(this.lblRetCount);
            this.splitContainer2.Panel2.Controls.Add(this.lblShipCount);
            this.splitContainer2.Panel2.Controls.Add(this.lblJID);
            this.splitContainer2.Panel2.Controls.Add(this.lblCustName);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel18);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel26);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel15);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel27);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel25);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel23);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel21);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel19);
            this.splitContainer2.Panel2.Controls.Add(this.metroLabel9);
            this.splitContainer2.Panel2.Controls.Add(this.shapeContainer2);
            this.splitContainer2.Size = new System.Drawing.Size(811, 600);
            this.splitContainer2.SplitterDistance = 207;
            this.splitContainer2.TabIndex = 0;
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
            this.dgList.Size = new System.Drawing.Size(811, 207);
            this.dgList.TabIndex = 0;
            this.dgList.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgList_CellDoubleClick);
            // 
            // metroLabel28
            // 
            this.metroLabel28.AutoSize = true;
            this.metroLabel28.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.metroLabel28.Location = new System.Drawing.Point(663, 139);
            this.metroLabel28.Name = "metroLabel28";
            this.metroLabel28.Size = new System.Drawing.Size(78, 19);
            this.metroLabel28.TabIndex = 37;
            this.metroLabel28.Text = "Templates";
            this.metroLabel28.UseStyleColors = true;
            // 
            // txtTemplate
            // 
            this.txtTemplate.Lines = new string[0];
            this.txtTemplate.Location = new System.Drawing.Point(663, 267);
            this.txtTemplate.MaxLength = 32767;
            this.txtTemplate.Name = "txtTemplate";
            this.txtTemplate.PasswordChar = '\0';
            this.txtTemplate.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtTemplate.SelectedText = "";
            this.txtTemplate.Size = new System.Drawing.Size(140, 23);
            this.txtTemplate.TabIndex = 36;
            this.txtTemplate.UseSelectable = true;
            this.txtTemplate.UseStyleColors = true;
            // 
            // btnRemTemplate
            // 
            this.btnRemTemplate.Location = new System.Drawing.Point(663, 325);
            this.btnRemTemplate.Name = "btnRemTemplate";
            this.btnRemTemplate.Size = new System.Drawing.Size(140, 23);
            this.btnRemTemplate.TabIndex = 35;
            this.btnRemTemplate.Text = "Remove Template";
            this.btnRemTemplate.UseSelectable = true;
            this.btnRemTemplate.UseStyleColors = true;
            this.btnRemTemplate.Click += new System.EventHandler(this.btnRemTemplate_Click);
            // 
            // btnTemplate
            // 
            this.btnTemplate.Location = new System.Drawing.Point(663, 296);
            this.btnTemplate.Name = "btnTemplate";
            this.btnTemplate.Size = new System.Drawing.Size(140, 23);
            this.btnTemplate.TabIndex = 34;
            this.btnTemplate.Text = "Add Template";
            this.btnTemplate.UseSelectable = true;
            this.btnTemplate.UseStyleColors = true;
            this.btnTemplate.Click += new System.EventHandler(this.btnTemplate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(404, 335);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(205, 23);
            this.btnSave.TabIndex = 31;
            this.btnSave.Text = "Save";
            this.btnSave.UseSelectable = true;
            this.btnSave.UseStyleColors = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstTemplate
            // 
            this.lstTemplate.FormattingEnabled = true;
            this.lstTemplate.Location = new System.Drawing.Point(663, 160);
            this.lstTemplate.Name = "lstTemplate";
            this.lstTemplate.Size = new System.Drawing.Size(140, 95);
            this.lstTemplate.TabIndex = 29;
            // 
            // rdEscalated
            // 
            this.rdEscalated.AutoSize = true;
            this.rdEscalated.Location = new System.Drawing.Point(404, 222);
            this.rdEscalated.Name = "rdEscalated";
            this.rdEscalated.Size = new System.Drawing.Size(104, 15);
            this.rdEscalated.TabIndex = 28;
            this.rdEscalated.Text = "Escalated to UK";
            this.rdEscalated.UseSelectable = true;
            // 
            // rdNotDone
            // 
            this.rdNotDone.AutoSize = true;
            this.rdNotDone.Location = new System.Drawing.Point(404, 201);
            this.rdNotDone.Name = "rdNotDone";
            this.rdNotDone.Size = new System.Drawing.Size(95, 15);
            this.rdNotDone.TabIndex = 28;
            this.rdNotDone.Text = "Call not Done";
            this.rdNotDone.UseSelectable = true;
            // 
            // rdDonewithShip
            // 
            this.rdDonewithShip.AutoSize = true;
            this.rdDonewithShip.Location = new System.Drawing.Point(404, 180);
            this.rdDonewithShip.Name = "rdDonewithShip";
            this.rdDonewithShip.Size = new System.Drawing.Size(167, 15);
            this.rdDonewithShip.TabIndex = 28;
            this.rdDonewithShip.Text = "Done and Ship with the Job";
            this.rdDonewithShip.UseSelectable = true;
            // 
            // rdCallBack
            // 
            this.rdCallBack.AutoSize = true;
            this.rdCallBack.Location = new System.Drawing.Point(404, 159);
            this.rdCallBack.Name = "rdCallBack";
            this.rdCallBack.Size = new System.Drawing.Size(112, 15);
            this.rdCallBack.TabIndex = 28;
            this.rdCallBack.Text = "Call Back the Job";
            this.rdCallBack.UseSelectable = true;
            // 
            // rdDone
            // 
            this.rdDone.AutoSize = true;
            this.rdDone.Location = new System.Drawing.Point(404, 138);
            this.rdDone.Name = "rdDone";
            this.rdDone.Size = new System.Drawing.Size(118, 15);
            this.rdDone.TabIndex = 28;
            this.rdDone.Text = "Done with the Job";
            this.rdDone.UseSelectable = true;
            // 
            // txtShopRemarks
            // 
            this.txtShopRemarks.Lines = new string[0];
            this.txtShopRemarks.Location = new System.Drawing.Point(404, 267);
            this.txtShopRemarks.MaxLength = 32767;
            this.txtShopRemarks.Multiline = true;
            this.txtShopRemarks.Name = "txtShopRemarks";
            this.txtShopRemarks.PasswordChar = '\0';
            this.txtShopRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtShopRemarks.SelectedText = "";
            this.txtShopRemarks.Size = new System.Drawing.Size(205, 63);
            this.txtShopRemarks.TabIndex = 22;
            this.txtShopRemarks.UseSelectable = true;
            this.txtShopRemarks.UseStyleColors = true;
            // 
            // txtRem
            // 
            this.txtRem.Lines = new string[0];
            this.txtRem.Location = new System.Drawing.Point(171, 286);
            this.txtRem.MaxLength = 32767;
            this.txtRem.Multiline = true;
            this.txtRem.Name = "txtRem";
            this.txtRem.PasswordChar = '\0';
            this.txtRem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtRem.SelectedText = "";
            this.txtRem.Size = new System.Drawing.Size(205, 46);
            this.txtRem.TabIndex = 22;
            this.txtRem.UseSelectable = true;
            this.txtRem.UseStyleColors = true;
            // 
            // txtOldRem
            // 
            this.txtOldRem.Lines = new string[0];
            this.txtOldRem.Location = new System.Drawing.Point(171, 234);
            this.txtOldRem.MaxLength = 32767;
            this.txtOldRem.Multiline = true;
            this.txtOldRem.Name = "txtOldRem";
            this.txtOldRem.PasswordChar = '\0';
            this.txtOldRem.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtOldRem.SelectedText = "";
            this.txtOldRem.Size = new System.Drawing.Size(205, 46);
            this.txtOldRem.TabIndex = 22;
            this.txtOldRem.UseSelectable = true;
            this.txtOldRem.UseStyleColors = true;
            // 
            // cboRetShipNo
            // 
            this.cboRetShipNo.FormattingEnabled = true;
            this.cboRetShipNo.ItemHeight = 23;
            this.cboRetShipNo.Location = new System.Drawing.Point(171, 199);
            this.cboRetShipNo.Name = "cboRetShipNo";
            this.cboRetShipNo.Size = new System.Drawing.Size(205, 29);
            this.cboRetShipNo.TabIndex = 21;
            this.cboRetShipNo.UseSelectable = true;
            // 
            // cboShipNo
            // 
            this.cboShipNo.FormattingEnabled = true;
            this.cboShipNo.ItemHeight = 23;
            this.cboShipNo.Location = new System.Drawing.Point(171, 164);
            this.cboShipNo.Name = "cboShipNo";
            this.cboShipNo.Size = new System.Drawing.Size(205, 29);
            this.cboShipNo.TabIndex = 20;
            this.cboShipNo.UseSelectable = true;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(663, 64);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(118, 67);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.UseSelectable = true;
            this.btnExport.UseStyleColors = true;
            // 
            // btnCall
            // 
            this.btnCall.Location = new System.Drawing.Point(663, 35);
            this.btnCall.Name = "btnCall";
            this.btnCall.Size = new System.Drawing.Size(118, 23);
            this.btnCall.TabIndex = 18;
            this.btnCall.Text = "Call Number";
            this.btnCall.UseSelectable = true;
            this.btnCall.UseStyleColors = true;
            this.btnCall.Click += new System.EventHandler(this.btnCall_Click);
            // 
            // txtAddress
            // 
            this.txtAddress.Lines = new string[0];
            this.txtAddress.Location = new System.Drawing.Point(171, 64);
            this.txtAddress.MaxLength = 32767;
            this.txtAddress.Multiline = true;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.PasswordChar = '\0';
            this.txtAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtAddress.SelectedText = "";
            this.txtAddress.Size = new System.Drawing.Size(481, 67);
            this.txtAddress.TabIndex = 17;
            this.txtAddress.UseSelectable = true;
            this.txtAddress.UseStyleColors = true;
            // 
            // txtPhNo
            // 
            this.txtPhNo.Lines = new string[0];
            this.txtPhNo.Location = new System.Drawing.Point(453, 35);
            this.txtPhNo.MaxLength = 32767;
            this.txtPhNo.Name = "txtPhNo";
            this.txtPhNo.PasswordChar = '\0';
            this.txtPhNo.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPhNo.SelectedText = "";
            this.txtPhNo.Size = new System.Drawing.Size(199, 23);
            this.txtPhNo.TabIndex = 16;
            this.txtPhNo.UseSelectable = true;
            this.txtPhNo.UseStyleColors = true;
            // 
            // lblAccRef
            // 
            this.lblAccRef.Location = new System.Drawing.Point(748, 11);
            this.lblAccRef.Name = "lblAccRef";
            this.lblAccRef.Size = new System.Drawing.Size(60, 19);
            this.lblAccRef.TabIndex = 8;
            this.lblAccRef.Text = "N/A";
            this.lblAccRef.UseStyleColors = true;
            // 
            // metroLabel13
            // 
            this.metroLabel13.AutoSize = true;
            this.metroLabel13.Location = new System.Drawing.Point(663, 11);
            this.metroLabel13.Name = "metroLabel13";
            this.metroLabel13.Size = new System.Drawing.Size(79, 19);
            this.metroLabel13.TabIndex = 7;
            this.metroLabel13.Text = "Account Ref";
            this.metroLabel13.UseStyleColors = true;
            // 
            // lblOERef
            // 
            this.lblOERef.Location = new System.Drawing.Point(453, 11);
            this.lblOERef.Name = "lblOERef";
            this.lblOERef.Size = new System.Drawing.Size(199, 19);
            this.lblOERef.TabIndex = 6;
            this.lblOERef.Text = "N/A";
            this.lblOERef.UseStyleColors = true;
            // 
            // metroLabel17
            // 
            this.metroLabel17.AutoSize = true;
            this.metroLabel17.Location = new System.Drawing.Point(362, 35);
            this.metroLabel17.Name = "metroLabel17";
            this.metroLabel17.Size = new System.Drawing.Size(68, 19);
            this.metroLabel17.TabIndex = 5;
            this.metroLabel17.Text = "Phone No";
            this.metroLabel17.UseStyleColors = true;
            // 
            // metroLabel11
            // 
            this.metroLabel11.AutoSize = true;
            this.metroLabel11.Location = new System.Drawing.Point(362, 11);
            this.metroLabel11.Name = "metroLabel11";
            this.metroLabel11.Size = new System.Drawing.Size(85, 19);
            this.metroLabel11.TabIndex = 5;
            this.metroLabel11.Text = "OEReference";
            this.metroLabel11.UseStyleColors = true;
            // 
            // lblContactName
            // 
            this.lblContactName.Location = new System.Drawing.Point(125, 35);
            this.lblContactName.Name = "lblContactName";
            this.lblContactName.Size = new System.Drawing.Size(231, 19);
            this.lblContactName.TabIndex = 4;
            this.lblContactName.Text = "N/A";
            this.lblContactName.UseStyleColors = true;
            // 
            // lblRetCount
            // 
            this.lblRetCount.AutoSize = true;
            this.lblRetCount.Location = new System.Drawing.Point(382, 207);
            this.lblRetCount.Name = "lblRetCount";
            this.lblRetCount.Size = new System.Drawing.Size(16, 19);
            this.lblRetCount.TabIndex = 4;
            this.lblRetCount.Text = "0";
            this.lblRetCount.UseStyleColors = true;
            // 
            // lblShipCount
            // 
            this.lblShipCount.AutoSize = true;
            this.lblShipCount.Location = new System.Drawing.Point(382, 172);
            this.lblShipCount.Name = "lblShipCount";
            this.lblShipCount.Size = new System.Drawing.Size(16, 19);
            this.lblShipCount.TabIndex = 4;
            this.lblShipCount.Text = "0";
            this.lblShipCount.UseStyleColors = true;
            // 
            // lblJID
            // 
            this.lblJID.Location = new System.Drawing.Point(168, 136);
            this.lblJID.Name = "lblJID";
            this.lblJID.Size = new System.Drawing.Size(208, 19);
            this.lblJID.TabIndex = 4;
            this.lblJID.Text = "N/A";
            this.lblJID.UseStyleColors = true;
            // 
            // lblCustName
            // 
            this.lblCustName.Location = new System.Drawing.Point(125, 11);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(231, 19);
            this.lblCustName.TabIndex = 4;
            this.lblCustName.Text = "N/A";
            this.lblCustName.UseStyleColors = true;
            // 
            // metroLabel18
            // 
            this.metroLabel18.AutoSize = true;
            this.metroLabel18.Location = new System.Drawing.Point(13, 64);
            this.metroLabel18.Name = "metroLabel18";
            this.metroLabel18.Size = new System.Drawing.Size(56, 19);
            this.metroLabel18.TabIndex = 3;
            this.metroLabel18.Text = "Address";
            this.metroLabel18.UseStyleColors = true;
            // 
            // metroLabel26
            // 
            this.metroLabel26.AutoSize = true;
            this.metroLabel26.Location = new System.Drawing.Point(404, 245);
            this.metroLabel26.Name = "metroLabel26";
            this.metroLabel26.Size = new System.Drawing.Size(93, 19);
            this.metroLabel26.TabIndex = 3;
            this.metroLabel26.Text = "Shop Remarks";
            this.metroLabel26.UseStyleColors = true;
            // 
            // metroLabel15
            // 
            this.metroLabel15.AutoSize = true;
            this.metroLabel15.Location = new System.Drawing.Point(13, 35);
            this.metroLabel15.Name = "metroLabel15";
            this.metroLabel15.Size = new System.Drawing.Size(94, 19);
            this.metroLabel15.TabIndex = 3;
            this.metroLabel15.Text = "Contact Name";
            this.metroLabel15.UseStyleColors = true;
            // 
            // metroLabel27
            // 
            this.metroLabel27.AutoSize = true;
            this.metroLabel27.Location = new System.Drawing.Point(13, 286);
            this.metroLabel27.Name = "metroLabel27";
            this.metroLabel27.Size = new System.Drawing.Size(88, 19);
            this.metroLabel27.TabIndex = 3;
            this.metroLabel27.Text = "Add Remarks";
            this.metroLabel27.UseStyleColors = true;
            // 
            // metroLabel25
            // 
            this.metroLabel25.AutoSize = true;
            this.metroLabel25.Location = new System.Drawing.Point(13, 233);
            this.metroLabel25.Name = "metroLabel25";
            this.metroLabel25.Size = new System.Drawing.Size(106, 19);
            this.metroLabel25.TabIndex = 3;
            this.metroLabel25.Text = "Existing Remarks";
            this.metroLabel25.UseStyleColors = true;
            // 
            // metroLabel23
            // 
            this.metroLabel23.AutoSize = true;
            this.metroLabel23.Location = new System.Drawing.Point(11, 202);
            this.metroLabel23.Name = "metroLabel23";
            this.metroLabel23.Size = new System.Drawing.Size(155, 19);
            this.metroLabel23.TabIndex = 3;
            this.metroLabel23.Text = "Return Shipping Number";
            this.metroLabel23.UseStyleColors = true;
            // 
            // metroLabel21
            // 
            this.metroLabel21.AutoSize = true;
            this.metroLabel21.Location = new System.Drawing.Point(13, 173);
            this.metroLabel21.Name = "metroLabel21";
            this.metroLabel21.Size = new System.Drawing.Size(113, 19);
            this.metroLabel21.TabIndex = 3;
            this.metroLabel21.Text = "Shipping Number";
            this.metroLabel21.UseStyleColors = true;
            // 
            // metroLabel19
            // 
            this.metroLabel19.AutoSize = true;
            this.metroLabel19.Location = new System.Drawing.Point(13, 136);
            this.metroLabel19.Name = "metroLabel19";
            this.metroLabel19.Size = new System.Drawing.Size(46, 19);
            this.metroLabel19.TabIndex = 3;
            this.metroLabel19.Text = "Job ID";
            this.metroLabel19.UseStyleColors = true;
            // 
            // metroLabel9
            // 
            this.metroLabel9.AutoSize = true;
            this.metroLabel9.Location = new System.Drawing.Point(13, 11);
            this.metroLabel9.Name = "metroLabel9";
            this.metroLabel9.Size = new System.Drawing.Size(106, 19);
            this.metroLabel9.TabIndex = 3;
            this.metroLabel9.Text = "Customer Name";
            this.metroLabel9.UseStyleColors = true;
            // 
            // shapeContainer2
            // 
            this.shapeContainer2.Location = new System.Drawing.Point(0, 0);
            this.shapeContainer2.Margin = new System.Windows.Forms.Padding(0);
            this.shapeContainer2.Name = "shapeContainer2";
            this.shapeContainer2.Shapes.AddRange(new Microsoft.VisualBasic.PowerPacks.Shape[] {
            this.lineShape2});
            this.shapeContainer2.Size = new System.Drawing.Size(811, 389);
            this.shapeContainer2.TabIndex = 38;
            this.shapeContainer2.TabStop = false;
            // 
            // lineShape2
            // 
            this.lineShape2.Name = "lineShape2";
            this.lineShape2.X1 = 629;
            this.lineShape2.X2 = 629;
            this.lineShape2.Y1 = 138;
            this.lineShape2.Y2 = 357;
            // 
            // metroTile1
            // 
            this.metroTile1.ActiveControl = null;
            this.metroTile1.Location = new System.Drawing.Point(20, 780);
            this.metroTile1.Name = "metroTile1";
            this.metroTile1.Size = new System.Drawing.Size(808, 10);
            this.metroTile1.TabIndex = 31;
            this.metroTile1.UseSelectable = true;
            this.metroTile1.UseStyleColors = true;
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
            // picSound
            // 
            this.picSound.Image = global::CSRAssistant.Properties.Resources.sound;
            this.picSound.Location = new System.Drawing.Point(691, 49);
            this.picSound.Name = "picSound";
            this.picSound.Size = new System.Drawing.Size(29, 24);
            this.picSound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSound.TabIndex = 40;
            this.picSound.TabStop = false;
            this.picSound.Visible = false;
            // 
            // lblCallStatus
            // 
            this.lblCallStatus.AutoSize = true;
            this.lblCallStatus.Location = new System.Drawing.Point(691, 76);
            this.lblCallStatus.Name = "lblCallStatus";
            this.lblCallStatus.Size = new System.Drawing.Size(33, 19);
            this.lblCallStatus.TabIndex = 41;
            this.lblCallStatus.Text = "N/A";
            this.lblCallStatus.UseStyleColors = true;
            this.lblCallStatus.Visible = false;
            // 
            // frmCallAssistant
            // 
            this.AcceptButton = this.btnGo;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 794);
            this.Controls.Add(this.metroTile1);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCallAssistant";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.StyleManager = this.metroStyleManager1;
            this.Text = "Call Assistance";
            this.Load += new System.EventHandler(this.frmCallAssistant_Load);
            this.Move += new System.EventHandler(this.frmCallAssistant_Move);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.metroStyleManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSound)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private MetroFramework.Controls.MetroTextBox txtJID;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        private System.Windows.Forms.DateTimePicker dtpkJobDate;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroButton btnGo;
        private System.Windows.Forms.DateTimePicker dtpkFrom;
        private System.Windows.Forms.DateTimePicker dtpkTo;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer1;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape1;
        private MetroFramework.Controls.MetroButton btnFillJobs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView dgList;
        private MetroFramework.Controls.MetroLabel lblAccRef;
        private MetroFramework.Controls.MetroLabel metroLabel13;
        private MetroFramework.Controls.MetroLabel lblOERef;
        private MetroFramework.Controls.MetroLabel metroLabel11;
        private MetroFramework.Controls.MetroLabel lblCustName;
        private MetroFramework.Controls.MetroLabel metroLabel9;
        private MetroFramework.Controls.MetroTextBox txtPhNo;
        private MetroFramework.Controls.MetroLabel metroLabel17;
        private MetroFramework.Controls.MetroLabel lblContactName;
        private MetroFramework.Controls.MetroLabel metroLabel15;
        private MetroFramework.Controls.MetroButton btnExport;
        private MetroFramework.Controls.MetroButton btnCall;
        private MetroFramework.Controls.MetroTextBox txtAddress;
        private MetroFramework.Controls.MetroLabel metroLabel18;
        private MetroFramework.Controls.MetroLabel lblJID;
        private MetroFramework.Controls.MetroLabel metroLabel19;
        private MetroFramework.Controls.MetroLabel lblRetCount;
        private MetroFramework.Controls.MetroLabel lblShipCount;
        private MetroFramework.Controls.MetroLabel metroLabel23;
        private MetroFramework.Controls.MetroLabel metroLabel21;
        private MetroFramework.Controls.MetroLabel metroLabel25;
        private MetroFramework.Controls.MetroLabel metroLabel27;
        private MetroFramework.Controls.MetroComboBox cboRetShipNo;
        private MetroFramework.Controls.MetroComboBox cboShipNo;
        private MetroFramework.Controls.MetroTextBox txtOldRem;
        private MetroFramework.Controls.MetroTextBox txtRem;
        private MetroFramework.Controls.MetroRadioButton rdEscalated;
        private MetroFramework.Controls.MetroRadioButton rdNotDone;
        private MetroFramework.Controls.MetroRadioButton rdDonewithShip;
        private MetroFramework.Controls.MetroRadioButton rdCallBack;
        private MetroFramework.Controls.MetroRadioButton rdDone;
        private MetroFramework.Controls.MetroTextBox txtShopRemarks;
        private MetroFramework.Controls.MetroLabel metroLabel26;
        private System.Windows.Forms.ListBox lstTemplate;
        private MetroFramework.Controls.MetroLabel metroLabel28;
        private MetroFramework.Controls.MetroTextBox txtTemplate;
        private MetroFramework.Controls.MetroButton btnRemTemplate;
        private MetroFramework.Controls.MetroButton btnTemplate;
        private MetroFramework.Controls.MetroButton btnSave;
        private Microsoft.VisualBasic.PowerPacks.ShapeContainer shapeContainer2;
        private Microsoft.VisualBasic.PowerPacks.LineShape lineShape2;
        private MetroFramework.Controls.MetroTile metroTile1;
        private MetroFramework.Components.MetroStyleExtender metroStyleExtender1;
        private MetroFramework.Components.MetroStyleManager metroStyleManager1;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroTextBox txtTrackNo;
        private MetroFramework.Controls.MetroLabel metroLabel5;
        private MetroFramework.Controls.MetroRadioButton rdAllEscalated;
        private MetroFramework.Controls.MetroRadioButton rdCallNotDone;
        private MetroFramework.Controls.MetroRadioButton rdAllDoneShip;
        private MetroFramework.Controls.MetroRadioButton rdAllCallbacks;
        private MetroFramework.Controls.MetroRadioButton rdAllDebtorJobs;
        private MetroFramework.Controls.MetroCheckBox rdFrom;
        private System.Windows.Forms.PictureBox picSound;
        private MetroFramework.Controls.MetroLabel lblCallStatus;
    }
}