namespace KMSMigration
{
    partial class frmMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.tsbStart = new System.Windows.Forms.ToolStripButton();
            this.tsbStop = new System.Windows.Forms.ToolStripButton();
            this.tsbConfig = new System.Windows.Forms.ToolStripButton();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbExit = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tpProcessLog = new System.Windows.Forms.TabPage();
            this.tlpLogs = new System.Windows.Forms.TableLayoutPanel();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.pnlWorkerLog = new System.Windows.Forms.Panel();
            this.lstWorkerLog = new System.Windows.Forms.ListBox();
            this.flpWorkerLogSelectors = new System.Windows.Forms.FlowLayoutPanel();
            this.tpConfigDB = new System.Windows.Forms.TabPage();
            this.grpWork = new System.Windows.Forms.GroupBox();
            this.lblSite = new System.Windows.Forms.Label();
            this.cboSite = new System.Windows.Forms.ComboBox();
            this.chkEnableDefaultConnectionLimit = new System.Windows.Forms.CheckBox();
            this.chkRunAtStart = new System.Windows.Forms.CheckBox();
            this.lblSec = new System.Windows.Forms.Label();
            this.lblRunTime = new System.Windows.Forms.Label();
            this.lblRunTime2 = new System.Windows.Forms.Label();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.lblWeekendRunTime = new System.Windows.Forms.Label();
            this.lblWeekendRunTime2 = new System.Windows.Forms.Label();
            this.dtpWeekendEndTime = new System.Windows.Forms.DateTimePicker();
            this.dtpWeekendStartTime = new System.Windows.Forms.DateTimePicker();
            this.txtInterval = new System.Windows.Forms.TextBox();
            this.lblInterval = new System.Windows.Forms.Label();
            this.grpConfDBSource = new System.Windows.Forms.GroupBox();
            this.checkTrustServer = new System.Windows.Forms.CheckBox();
            this.lblSourceYearDB = new System.Windows.Forms.Label();
            this.txtSourceDBIP = new System.Windows.Forms.TextBox();
            this.txtSourceYearDB = new System.Windows.Forms.TextBox();
            this.lblSourceDBIP = new System.Windows.Forms.Label();
            this.txtSourceDBNM = new System.Windows.Forms.TextBox();
            this.txtSourceSelectCondition = new System.Windows.Forms.TextBox();
            this.lblSourceDBNM = new System.Windows.Forms.Label();
            this.lblSourceSelectCondition = new System.Windows.Forms.Label();
            this.txtSourceTableNM = new System.Windows.Forms.TextBox();
            this.lblSourceTableNM = new System.Windows.Forms.Label();
            this.txtSourceMarkField = new System.Windows.Forms.TextBox();
            this.txtSourceDBID = new System.Windows.Forms.TextBox();
            this.lblSourceMarkField = new System.Windows.Forms.Label();
            this.lblSourceDBID = new System.Windows.Forms.Label();
            this.txtSourceDBPW = new System.Windows.Forms.TextBox();
            this.lblSourceDBPW = new System.Windows.Forms.Label();
            this.grpConfPathI360 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtI360NetBiosPath = new System.Windows.Forms.TextBox();
            this.lblI360NetBiosPath = new System.Windows.Forms.Label();
            this.txtI360IISPath = new System.Windows.Forms.TextBox();
            this.lblI360IISPath = new System.Windows.Forms.Label();
            this.txtI360HttpFullPathField = new System.Windows.Forms.TextBox();
            this.lblI360HttpFullPathField = new System.Windows.Forms.Label();
            this.grpConfPathAudiolog = new System.Windows.Forms.GroupBox();
            this.txtAudiologPathAddField = new System.Windows.Forms.TextBox();
            this.lblAudiologPathAddField = new System.Windows.Forms.Label();
            this.txtAudiologPath = new System.Windows.Forms.TextBox();
            this.lblAudiologPath = new System.Windows.Forms.Label();
            this.grpConfPathTarget = new System.Windows.Forms.GroupBox();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.lblBackupPath = new System.Windows.Forms.Label();
            this.txtTargetPath = new System.Windows.Forms.TextBox();
            this.lblTargetPath = new System.Windows.Forms.Label();
            this.tpWorkers = new System.Windows.Forms.TabPage();
            this.flpWorkerRows = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlWorkerCommand = new System.Windows.Forms.Panel();
            this.btnWorkerResetTotals = new System.Windows.Forms.Button();
            this.btnWorkerDelete = new System.Windows.Forms.Button();
            this.btnWorkerAdd = new System.Windows.Forms.Button();
            this.btnWorkerSelectAll = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblStatus = new System.Windows.Forms.Label();
            this.tmrBatch = new System.Windows.Forms.Timer(this.components);
            this.toolStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.grpConfig.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tpProcessLog.SuspendLayout();
            this.tlpLogs.SuspendLayout();
            this.pnlWorkerLog.SuspendLayout();
            this.tpConfigDB.SuspendLayout();
            this.grpWork.SuspendLayout();
            this.grpConfDBSource.SuspendLayout();
            this.grpConfPathI360.SuspendLayout();
            this.grpConfPathAudiolog.SuspendLayout();
            this.grpConfPathTarget.SuspendLayout();
            this.tpWorkers.SuspendLayout();
            this.pnlWorkerCommand.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbStart,
            this.tsbStop,
            this.tsbConfig,
            this.tsbSave,
            this.tsbExit});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1466, 25);
            this.toolStrip.TabIndex = 0;
            this.toolStrip.Text = "toolStrip1";
            // 
            // tsbStart
            // 
            this.tsbStart.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStart.Image = ((System.Drawing.Image)(resources.GetObject("tsbStart.Image")));
            this.tsbStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStart.Name = "tsbStart";
            this.tsbStart.Size = new System.Drawing.Size(23, 22);
            this.tsbStart.Text = "toolStripButton1";
            this.tsbStart.ToolTipText = "Start all workers";
            this.tsbStart.Click += new System.EventHandler(this.tsbStart_Click);
            // 
            // tsbStop
            // 
            this.tsbStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbStop.Image = ((System.Drawing.Image)(resources.GetObject("tsbStop.Image")));
            this.tsbStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbStop.Name = "tsbStop";
            this.tsbStop.Size = new System.Drawing.Size(23, 22);
            this.tsbStop.Text = "toolStripButton2";
            this.tsbStop.ToolTipText = "Stop all workers";
            this.tsbStop.Click += new System.EventHandler(this.tsbStop_Click);
            // 
            // tsbConfig
            // 
            this.tsbConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbConfig.Image = ((System.Drawing.Image)(resources.GetObject("tsbConfig.Image")));
            this.tsbConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbConfig.Name = "tsbConfig";
            this.tsbConfig.Size = new System.Drawing.Size(23, 22);
            this.tsbConfig.Text = "toolStripButton3";
            this.tsbConfig.ToolTipText = "Edit config";
            this.tsbConfig.Click += new System.EventHandler(this.tsbConfig_Click);
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(23, 22);
            this.tsbSave.Text = "toolStripButton4";
            this.tsbSave.ToolTipText = "Save config";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbExit
            // 
            this.tsbExit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbExit.Image = ((System.Drawing.Image)(resources.GetObject("tsbExit.Image")));
            this.tsbExit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExit.Name = "tsbExit";
            this.tsbExit.Size = new System.Drawing.Size(23, 22);
            this.tsbExit.Text = "toolStripButton5";
            this.tsbExit.ToolTipText = "Exit program";
            this.tsbExit.Click += new System.EventHandler(this.tsbExit_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.grpConfig, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1466, 537);
            this.tableLayoutPanel.TabIndex = 1;
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.tabControl);
            this.grpConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpConfig.Location = new System.Drawing.Point(3, 3);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(1460, 513);
            this.grpConfig.TabIndex = 2;
            this.grpConfig.TabStop = false;
            this.grpConfig.Text = "Log and Config";
            // 
            // tabControl
            // 
            this.tabControl.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabControl.Controls.Add(this.tpProcessLog);
            this.tabControl.Controls.Add(this.tpConfigDB);
            this.tabControl.Controls.Add(this.tpWorkers);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(3, 17);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1454, 493);
            this.tabControl.TabIndex = 1;
            // 
            // tpProcessLog
            // 
            this.tpProcessLog.Controls.Add(this.tlpLogs);
            this.tpProcessLog.Location = new System.Drawing.Point(4, 25);
            this.tpProcessLog.Name = "tpProcessLog";
            this.tpProcessLog.Padding = new System.Windows.Forms.Padding(3);
            this.tpProcessLog.Size = new System.Drawing.Size(1446, 464);
            this.tpProcessLog.TabIndex = 0;
            this.tpProcessLog.Text = "Logs";
            this.tpProcessLog.UseVisualStyleBackColor = true;
            // 
            // tlpLogs
            // 
            this.tlpLogs.ColumnCount = 2;
            this.tlpLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlpLogs.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tlpLogs.Controls.Add(this.lstLog, 0, 0);
            this.tlpLogs.Controls.Add(this.pnlWorkerLog, 1, 0);
            this.tlpLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLogs.Location = new System.Drawing.Point(3, 3);
            this.tlpLogs.Name = "tlpLogs";
            this.tlpLogs.RowCount = 1;
            this.tlpLogs.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLogs.Size = new System.Drawing.Size(1440, 458);
            this.tlpLogs.TabIndex = 2;
            // 
            // lstLog
            // 
            this.lstLog.BackColor = System.Drawing.Color.Black;
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.ForeColor = System.Drawing.Color.Cyan;
            this.lstLog.FormattingEnabled = true;
            this.lstLog.ItemHeight = 12;
            this.lstLog.Location = new System.Drawing.Point(3, 3);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(642, 452);
            this.lstLog.TabIndex = 1;
            // 
            // pnlWorkerLog
            // 
            this.pnlWorkerLog.Controls.Add(this.lstWorkerLog);
            this.pnlWorkerLog.Controls.Add(this.flpWorkerLogSelectors);
            this.pnlWorkerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkerLog.Location = new System.Drawing.Point(651, 3);
            this.pnlWorkerLog.Name = "pnlWorkerLog";
            this.pnlWorkerLog.Size = new System.Drawing.Size(786, 452);
            this.pnlWorkerLog.TabIndex = 2;
            // 
            // lstWorkerLog
            // 
            this.lstWorkerLog.BackColor = System.Drawing.Color.Black;
            this.lstWorkerLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstWorkerLog.ForeColor = System.Drawing.Color.LightGreen;
            this.lstWorkerLog.FormattingEnabled = true;
            this.lstWorkerLog.ItemHeight = 12;
            this.lstWorkerLog.Location = new System.Drawing.Point(0, 28);
            this.lstWorkerLog.Name = "lstWorkerLog";
            this.lstWorkerLog.Size = new System.Drawing.Size(786, 424);
            this.lstWorkerLog.TabIndex = 1;
            // 
            // flpWorkerLogSelectors
            // 
            this.flpWorkerLogSelectors.AutoScroll = true;
            this.flpWorkerLogSelectors.Dock = System.Windows.Forms.DockStyle.Top;
            this.flpWorkerLogSelectors.Location = new System.Drawing.Point(0, 0);
            this.flpWorkerLogSelectors.Name = "flpWorkerLogSelectors";
            this.flpWorkerLogSelectors.Size = new System.Drawing.Size(786, 28);
            this.flpWorkerLogSelectors.TabIndex = 0;
            this.flpWorkerLogSelectors.WrapContents = false;
            // 
            // tpConfigDB
            // 
            this.tpConfigDB.AutoScroll = true;
            this.tpConfigDB.Controls.Add(this.grpWork);
            this.tpConfigDB.Controls.Add(this.grpConfDBSource);
            this.tpConfigDB.Controls.Add(this.grpConfPathI360);
            this.tpConfigDB.Controls.Add(this.grpConfPathAudiolog);
            this.tpConfigDB.Controls.Add(this.grpConfPathTarget);
            this.tpConfigDB.Location = new System.Drawing.Point(4, 25);
            this.tpConfigDB.Name = "tpConfigDB";
            this.tpConfigDB.Size = new System.Drawing.Size(1446, 464);
            this.tpConfigDB.TabIndex = 1;
            this.tpConfigDB.Text = "Config";
            this.tpConfigDB.UseVisualStyleBackColor = true;
            // 
            // grpWork
            // 
            this.grpWork.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpWork.Controls.Add(this.lblSite);
            this.grpWork.Controls.Add(this.cboSite);
            this.grpWork.Controls.Add(this.chkEnableDefaultConnectionLimit);
            this.grpWork.Controls.Add(this.chkRunAtStart);
            this.grpWork.Controls.Add(this.lblSec);
            this.grpWork.Controls.Add(this.lblRunTime);
            this.grpWork.Controls.Add(this.lblRunTime2);
            this.grpWork.Controls.Add(this.dtpEndTime);
            this.grpWork.Controls.Add(this.dtpStartTime);
            this.grpWork.Controls.Add(this.lblWeekendRunTime);
            this.grpWork.Controls.Add(this.lblWeekendRunTime2);
            this.grpWork.Controls.Add(this.dtpWeekendEndTime);
            this.grpWork.Controls.Add(this.dtpWeekendStartTime);
            this.grpWork.Controls.Add(this.txtInterval);
            this.grpWork.Controls.Add(this.lblInterval);
            this.grpWork.Location = new System.Drawing.Point(3, 3);
            this.grpWork.Name = "grpWork";
            this.grpWork.Size = new System.Drawing.Size(1440, 100);
            this.grpWork.TabIndex = 1;
            this.grpWork.TabStop = false;
            this.grpWork.Text = "Schedule and Process";
            // 
            // lblSite
            // 
            this.lblSite.AutoSize = true;
            this.lblSite.Location = new System.Drawing.Point(269, 21);
            this.lblSite.Name = "lblSite";
            this.lblSite.Size = new System.Drawing.Size(26, 12);
            this.lblSite.TabIndex = 36;
            this.lblSite.Text = "Site";
            // 
            // cboSite
            // 
            this.cboSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSite.FormattingEnabled = true;
            this.cboSite.Items.AddRange(new object[] {
            "Default",
            "KBINSU"});
            this.cboSite.Location = new System.Drawing.Point(269, 39);
            this.cboSite.Name = "cboSite";
            this.cboSite.Size = new System.Drawing.Size(91, 20);
            this.cboSite.TabIndex = 35;
            this.cboSite.TextChanged += new System.EventHandler(this.cboSite_TextChanged);
            // 
            // chkEnableDefaultConnectionLimit
            // 
            this.chkEnableDefaultConnectionLimit.AutoSize = true;
            this.chkEnableDefaultConnectionLimit.Checked = true;
            this.chkEnableDefaultConnectionLimit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableDefaultConnectionLimit.Location = new System.Drawing.Point(370, 18);
            this.chkEnableDefaultConnectionLimit.Name = "chkEnableDefaultConnectionLimit";
            this.chkEnableDefaultConnectionLimit.Size = new System.Drawing.Size(72, 16);
            this.chkEnableDefaultConnectionLimit.TabIndex = 37;
            this.chkEnableDefaultConnectionLimit.Text = "Conn100";
            this.chkEnableDefaultConnectionLimit.UseVisualStyleBackColor = true;
            // 
            // chkRunAtStart
            // 
            this.chkRunAtStart.AutoSize = true;
            this.chkRunAtStart.Location = new System.Drawing.Point(184, 20);
            this.chkRunAtStart.Name = "chkRunAtStart";
            this.chkRunAtStart.Size = new System.Drawing.Size(78, 16);
            this.chkRunAtStart.TabIndex = 20;
            this.chkRunAtStart.Text = "Auto Start";
            this.chkRunAtStart.UseVisualStyleBackColor = true;
            // 
            // lblSec
            // 
            this.lblSec.AutoSize = true;
            this.lblSec.Location = new System.Drawing.Point(125, 22);
            this.lblSec.Name = "lblSec";
            this.lblSec.Size = new System.Drawing.Size(31, 12);
            this.lblSec.TabIndex = 31;
            this.lblSec.Text = "Sec.";
            // 
            // lblRunTime
            // 
            this.lblRunTime.AutoSize = true;
            this.lblRunTime.Location = new System.Drawing.Point(13, 46);
            this.lblRunTime.Name = "lblRunTime";
            this.lblRunTime.Size = new System.Drawing.Size(56, 12);
            this.lblRunTime.TabIndex = 30;
            this.lblRunTime.Text = "Weekday";
            // 
            // lblRunTime2
            // 
            this.lblRunTime2.AutoSize = true;
            this.lblRunTime2.Location = new System.Drawing.Point(164, 46);
            this.lblRunTime2.Name = "lblRunTime2";
            this.lblRunTime2.Size = new System.Drawing.Size(14, 12);
            this.lblRunTime2.TabIndex = 29;
            this.lblRunTime2.Text = "~";
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.CustomFormat = "HH:mm:ss";
            this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndTime.Location = new System.Drawing.Point(184, 42);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.ShowUpDown = true;
            this.dtpEndTime.Size = new System.Drawing.Size(81, 21);
            this.dtpEndTime.TabIndex = 28;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.CustomFormat = "HH:mm:ss";
            this.dtpStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartTime.Location = new System.Drawing.Point(77, 42);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.ShowUpDown = true;
            this.dtpStartTime.Size = new System.Drawing.Size(81, 21);
            this.dtpStartTime.TabIndex = 27;
            // 
            // lblWeekendRunTime
            // 
            this.lblWeekendRunTime.AutoSize = true;
            this.lblWeekendRunTime.Location = new System.Drawing.Point(13, 70);
            this.lblWeekendRunTime.Name = "lblWeekendRunTime";
            this.lblWeekendRunTime.Size = new System.Drawing.Size(56, 12);
            this.lblWeekendRunTime.TabIndex = 41;
            this.lblWeekendRunTime.Text = "Weekend";
            // 
            // lblWeekendRunTime2
            // 
            this.lblWeekendRunTime2.AutoSize = true;
            this.lblWeekendRunTime2.Location = new System.Drawing.Point(164, 70);
            this.lblWeekendRunTime2.Name = "lblWeekendRunTime2";
            this.lblWeekendRunTime2.Size = new System.Drawing.Size(14, 12);
            this.lblWeekendRunTime2.TabIndex = 40;
            this.lblWeekendRunTime2.Text = "~";
            // 
            // dtpWeekendEndTime
            // 
            this.dtpWeekendEndTime.CustomFormat = "HH:mm:ss";
            this.dtpWeekendEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWeekendEndTime.Location = new System.Drawing.Point(184, 66);
            this.dtpWeekendEndTime.Name = "dtpWeekendEndTime";
            this.dtpWeekendEndTime.ShowUpDown = true;
            this.dtpWeekendEndTime.Size = new System.Drawing.Size(81, 21);
            this.dtpWeekendEndTime.TabIndex = 39;
            // 
            // dtpWeekendStartTime
            // 
            this.dtpWeekendStartTime.CustomFormat = "HH:mm:ss";
            this.dtpWeekendStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWeekendStartTime.Location = new System.Drawing.Point(77, 66);
            this.dtpWeekendStartTime.Name = "dtpWeekendStartTime";
            this.dtpWeekendStartTime.ShowUpDown = true;
            this.dtpWeekendStartTime.Size = new System.Drawing.Size(81, 21);
            this.dtpWeekendStartTime.TabIndex = 38;
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(77, 18);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Size = new System.Drawing.Size(47, 21);
            this.txtInterval.TabIndex = 26;
            this.txtInterval.Text = "10";
            // 
            // lblInterval
            // 
            this.lblInterval.AutoSize = true;
            this.lblInterval.Location = new System.Drawing.Point(13, 22);
            this.lblInterval.Name = "lblInterval";
            this.lblInterval.Size = new System.Drawing.Size(45, 12);
            this.lblInterval.TabIndex = 25;
            this.lblInterval.Text = "Interval";
            // 
            // grpConfDBSource
            // 
            this.grpConfDBSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfDBSource.Controls.Add(this.checkTrustServer);
            this.grpConfDBSource.Controls.Add(this.lblSourceYearDB);
            this.grpConfDBSource.Controls.Add(this.txtSourceDBIP);
            this.grpConfDBSource.Controls.Add(this.txtSourceYearDB);
            this.grpConfDBSource.Controls.Add(this.lblSourceDBIP);
            this.grpConfDBSource.Controls.Add(this.txtSourceDBNM);
            this.grpConfDBSource.Controls.Add(this.txtSourceSelectCondition);
            this.grpConfDBSource.Controls.Add(this.lblSourceDBNM);
            this.grpConfDBSource.Controls.Add(this.lblSourceSelectCondition);
            this.grpConfDBSource.Controls.Add(this.txtSourceTableNM);
            this.grpConfDBSource.Controls.Add(this.lblSourceTableNM);
            this.grpConfDBSource.Controls.Add(this.txtSourceMarkField);
            this.grpConfDBSource.Controls.Add(this.txtSourceDBID);
            this.grpConfDBSource.Controls.Add(this.lblSourceMarkField);
            this.grpConfDBSource.Controls.Add(this.lblSourceDBID);
            this.grpConfDBSource.Controls.Add(this.txtSourceDBPW);
            this.grpConfDBSource.Controls.Add(this.lblSourceDBPW);
            this.grpConfDBSource.Location = new System.Drawing.Point(3, 111);
            this.grpConfDBSource.Name = "grpConfDBSource";
            this.grpConfDBSource.Size = new System.Drawing.Size(1440, 122);
            this.grpConfDBSource.TabIndex = 29;
            this.grpConfDBSource.TabStop = false;
            this.grpConfDBSource.Text = "DB - Source";
            // 
            // checkTrustServer
            // 
            this.checkTrustServer.AutoSize = true;
            this.checkTrustServer.Location = new System.Drawing.Point(370, 100);
            this.checkTrustServer.Name = "checkTrustServer";
            this.checkTrustServer.Size = new System.Drawing.Size(132, 16);
            this.checkTrustServer.TabIndex = 31;
            this.checkTrustServer.Text = "신뢰 서버 인증 유무";
            this.checkTrustServer.UseVisualStyleBackColor = true;
            // 
            // lblSourceYearDB
            // 
            this.lblSourceYearDB.AutoSize = true;
            this.lblSourceYearDB.Location = new System.Drawing.Point(368, 48);
            this.lblSourceYearDB.Name = "lblSourceYearDB";
            this.lblSourceYearDB.Size = new System.Drawing.Size(51, 12);
            this.lblSourceYearDB.TabIndex = 39;
            this.lblSourceYearDB.Text = "Year DB";
            // 
            // txtSourceDBIP
            // 
            this.txtSourceDBIP.Location = new System.Drawing.Point(68, 20);
            this.txtSourceDBIP.Name = "txtSourceDBIP";
            this.txtSourceDBIP.Size = new System.Drawing.Size(90, 21);
            this.txtSourceDBIP.TabIndex = 1;
            // 
            // txtSourceYearDB
            // 
            this.txtSourceYearDB.Location = new System.Drawing.Point(454, 44);
            this.txtSourceYearDB.Name = "txtSourceYearDB";
            this.txtSourceYearDB.Size = new System.Drawing.Size(90, 21);
            this.txtSourceYearDB.TabIndex = 40;
            // 
            // lblSourceDBIP
            // 
            this.lblSourceDBIP.AutoSize = true;
            this.lblSourceDBIP.Location = new System.Drawing.Point(12, 24);
            this.lblSourceDBIP.Name = "lblSourceDBIP";
            this.lblSourceDBIP.Size = new System.Drawing.Size(36, 12);
            this.lblSourceDBIP.TabIndex = 0;
            this.lblSourceDBIP.Text = "DB IP";
            // 
            // txtSourceDBNM
            // 
            this.txtSourceDBNM.Location = new System.Drawing.Point(254, 20);
            this.txtSourceDBNM.Name = "txtSourceDBNM";
            this.txtSourceDBNM.Size = new System.Drawing.Size(90, 21);
            this.txtSourceDBNM.TabIndex = 3;
            // 
            // txtSourceSelectCondition
            // 
            this.txtSourceSelectCondition.Location = new System.Drawing.Point(111, 69);
            this.txtSourceSelectCondition.Name = "txtSourceSelectCondition";
            this.txtSourceSelectCondition.Size = new System.Drawing.Size(233, 21);
            this.txtSourceSelectCondition.TabIndex = 24;
            // 
            // lblSourceDBNM
            // 
            this.lblSourceDBNM.AutoSize = true;
            this.lblSourceDBNM.Location = new System.Drawing.Point(189, 24);
            this.lblSourceDBNM.Name = "lblSourceDBNM";
            this.lblSourceDBNM.Size = new System.Drawing.Size(59, 12);
            this.lblSourceDBNM.TabIndex = 2;
            this.lblSourceDBNM.Text = "DB Name";
            // 
            // lblSourceSelectCondition
            // 
            this.lblSourceSelectCondition.AutoSize = true;
            this.lblSourceSelectCondition.Location = new System.Drawing.Point(12, 71);
            this.lblSourceSelectCondition.Name = "lblSourceSelectCondition";
            this.lblSourceSelectCondition.Size = new System.Drawing.Size(93, 12);
            this.lblSourceSelectCondition.TabIndex = 23;
            this.lblSourceSelectCondition.Text = "SelectCondition";
            // 
            // txtSourceTableNM
            // 
            this.txtSourceTableNM.Location = new System.Drawing.Point(454, 20);
            this.txtSourceTableNM.Name = "txtSourceTableNM";
            this.txtSourceTableNM.Size = new System.Drawing.Size(90, 21);
            this.txtSourceTableNM.TabIndex = 5;
            // 
            // lblSourceTableNM
            // 
            this.lblSourceTableNM.AutoSize = true;
            this.lblSourceTableNM.Location = new System.Drawing.Point(368, 24);
            this.lblSourceTableNM.Name = "lblSourceTableNM";
            this.lblSourceTableNM.Size = new System.Drawing.Size(75, 12);
            this.lblSourceTableNM.TabIndex = 4;
            this.lblSourceTableNM.Text = "Table Name";
            // 
            // txtSourceMarkField
            // 
            this.txtSourceMarkField.Location = new System.Drawing.Point(454, 69);
            this.txtSourceMarkField.Name = "txtSourceMarkField";
            this.txtSourceMarkField.Size = new System.Drawing.Size(90, 21);
            this.txtSourceMarkField.TabIndex = 17;
            // 
            // txtSourceDBID
            // 
            this.txtSourceDBID.Location = new System.Drawing.Point(68, 44);
            this.txtSourceDBID.Name = "txtSourceDBID";
            this.txtSourceDBID.Size = new System.Drawing.Size(90, 21);
            this.txtSourceDBID.TabIndex = 7;
            // 
            // lblSourceMarkField
            // 
            this.lblSourceMarkField.AutoSize = true;
            this.lblSourceMarkField.Location = new System.Drawing.Point(368, 73);
            this.lblSourceMarkField.Name = "lblSourceMarkField";
            this.lblSourceMarkField.Size = new System.Drawing.Size(64, 12);
            this.lblSourceMarkField.TabIndex = 16;
            this.lblSourceMarkField.Text = "Mark Field";
            // 
            // lblSourceDBID
            // 
            this.lblSourceDBID.AutoSize = true;
            this.lblSourceDBID.Location = new System.Drawing.Point(12, 48);
            this.lblSourceDBID.Name = "lblSourceDBID";
            this.lblSourceDBID.Size = new System.Drawing.Size(36, 12);
            this.lblSourceDBID.TabIndex = 6;
            this.lblSourceDBID.Text = "DB ID";
            // 
            // txtSourceDBPW
            // 
            this.txtSourceDBPW.Location = new System.Drawing.Point(254, 44);
            this.txtSourceDBPW.Name = "txtSourceDBPW";
            this.txtSourceDBPW.PasswordChar = '*';
            this.txtSourceDBPW.Size = new System.Drawing.Size(90, 21);
            this.txtSourceDBPW.TabIndex = 9;
            // 
            // lblSourceDBPW
            // 
            this.lblSourceDBPW.AutoSize = true;
            this.lblSourceDBPW.Location = new System.Drawing.Point(189, 48);
            this.lblSourceDBPW.Name = "lblSourceDBPW";
            this.lblSourceDBPW.Size = new System.Drawing.Size(43, 12);
            this.lblSourceDBPW.TabIndex = 8;
            this.lblSourceDBPW.Text = "DB PW";
            // 
            // grpConfPathI360
            // 
            this.grpConfPathI360.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfPathI360.Controls.Add(this.label4);
            this.grpConfPathI360.Controls.Add(this.txtI360NetBiosPath);
            this.grpConfPathI360.Controls.Add(this.lblI360NetBiosPath);
            this.grpConfPathI360.Controls.Add(this.txtI360IISPath);
            this.grpConfPathI360.Controls.Add(this.lblI360IISPath);
            this.grpConfPathI360.Controls.Add(this.txtI360HttpFullPathField);
            this.grpConfPathI360.Controls.Add(this.lblI360HttpFullPathField);
            this.grpConfPathI360.Location = new System.Drawing.Point(3, 241);
            this.grpConfPathI360.Name = "grpConfPathI360";
            this.grpConfPathI360.Size = new System.Drawing.Size(1440, 70);
            this.grpConfPathI360.TabIndex = 30;
            this.grpConfPathI360.TabStop = false;
            this.grpConfPathI360.Text = "Path - Impact360";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(283, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 33;
            this.label4.Text = ">>>";
            // 
            // txtI360NetBiosPath
            // 
            this.txtI360NetBiosPath.Location = new System.Drawing.Point(417, 43);
            this.txtI360NetBiosPath.Name = "txtI360NetBiosPath";
            this.txtI360NetBiosPath.Size = new System.Drawing.Size(124, 21);
            this.txtI360NetBiosPath.TabIndex = 32;
            // 
            // lblI360NetBiosPath
            // 
            this.lblI360NetBiosPath.AutoSize = true;
            this.lblI360NetBiosPath.Location = new System.Drawing.Point(321, 47);
            this.lblI360NetBiosPath.Name = "lblI360NetBiosPath";
            this.lblI360NetBiosPath.Size = new System.Drawing.Size(78, 12);
            this.lblI360NetBiosPath.TabIndex = 30;
            this.lblI360NetBiosPath.Text = "NetBios Path";
            // 
            // txtI360IISPath
            // 
            this.txtI360IISPath.Location = new System.Drawing.Point(142, 43);
            this.txtI360IISPath.Name = "txtI360IISPath";
            this.txtI360IISPath.Size = new System.Drawing.Size(124, 21);
            this.txtI360IISPath.TabIndex = 29;
            // 
            // lblI360IISPath
            // 
            this.lblI360IISPath.AutoSize = true;
            this.lblI360IISPath.Location = new System.Drawing.Point(12, 47);
            this.lblI360IISPath.Name = "lblI360IISPath";
            this.lblI360IISPath.Size = new System.Drawing.Size(48, 12);
            this.lblI360IISPath.TabIndex = 28;
            this.lblI360IISPath.Text = "IIS Path";
            // 
            // txtI360HttpFullPathField
            // 
            this.txtI360HttpFullPathField.Location = new System.Drawing.Point(142, 20);
            this.txtI360HttpFullPathField.Name = "txtI360HttpFullPathField";
            this.txtI360HttpFullPathField.Size = new System.Drawing.Size(124, 21);
            this.txtI360HttpFullPathField.TabIndex = 27;
            // 
            // lblI360HttpFullPathField
            // 
            this.lblI360HttpFullPathField.AutoSize = true;
            this.lblI360HttpFullPathField.Location = new System.Drawing.Point(12, 24);
            this.lblI360HttpFullPathField.Name = "lblI360HttpFullPathField";
            this.lblI360HttpFullPathField.Size = new System.Drawing.Size(110, 12);
            this.lblI360HttpFullPathField.TabIndex = 0;
            this.lblI360HttpFullPathField.Text = "Http Full Path Field";
            // 
            // grpConfPathAudiolog
            // 
            this.grpConfPathAudiolog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfPathAudiolog.Controls.Add(this.txtAudiologPathAddField);
            this.grpConfPathAudiolog.Controls.Add(this.lblAudiologPathAddField);
            this.grpConfPathAudiolog.Controls.Add(this.txtAudiologPath);
            this.grpConfPathAudiolog.Controls.Add(this.lblAudiologPath);
            this.grpConfPathAudiolog.Location = new System.Drawing.Point(3, 319);
            this.grpConfPathAudiolog.Name = "grpConfPathAudiolog";
            this.grpConfPathAudiolog.Size = new System.Drawing.Size(1440, 52);
            this.grpConfPathAudiolog.TabIndex = 28;
            this.grpConfPathAudiolog.TabStop = false;
            this.grpConfPathAudiolog.Text = "Path - Audiolog";
            // 
            // txtAudiologPathAddField
            // 
            this.txtAudiologPathAddField.Location = new System.Drawing.Point(417, 20);
            this.txtAudiologPathAddField.Name = "txtAudiologPathAddField";
            this.txtAudiologPathAddField.Size = new System.Drawing.Size(124, 21);
            this.txtAudiologPathAddField.TabIndex = 28;
            // 
            // lblAudiologPathAddField
            // 
            this.lblAudiologPathAddField.AutoSize = true;
            this.lblAudiologPathAddField.Location = new System.Drawing.Point(321, 24);
            this.lblAudiologPathAddField.Name = "lblAudiologPathAddField";
            this.lblAudiologPathAddField.Size = new System.Drawing.Size(87, 12);
            this.lblAudiologPathAddField.TabIndex = 27;
            this.lblAudiologPathAddField.Text = "Path Add Field";
            // 
            // txtAudiologPath
            // 
            this.txtAudiologPath.Location = new System.Drawing.Point(48, 20);
            this.txtAudiologPath.Name = "txtAudiologPath";
            this.txtAudiologPath.Size = new System.Drawing.Size(256, 21);
            this.txtAudiologPath.TabIndex = 26;
            // 
            // lblAudiologPath
            // 
            this.lblAudiologPath.AutoSize = true;
            this.lblAudiologPath.Location = new System.Drawing.Point(12, 24);
            this.lblAudiologPath.Name = "lblAudiologPath";
            this.lblAudiologPath.Size = new System.Drawing.Size(30, 12);
            this.lblAudiologPath.TabIndex = 25;
            this.lblAudiologPath.Text = "Path";
            // 
            // grpConfPathTarget
            // 
            this.grpConfPathTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfPathTarget.Controls.Add(this.txtBackupPath);
            this.grpConfPathTarget.Controls.Add(this.lblBackupPath);
            this.grpConfPathTarget.Controls.Add(this.txtTargetPath);
            this.grpConfPathTarget.Controls.Add(this.lblTargetPath);
            this.grpConfPathTarget.Location = new System.Drawing.Point(3, 379);
            this.grpConfPathTarget.Name = "grpConfPathTarget";
            this.grpConfPathTarget.Size = new System.Drawing.Size(1440, 52);
            this.grpConfPathTarget.TabIndex = 29;
            this.grpConfPathTarget.TabStop = false;
            this.grpConfPathTarget.Text = "Path - Target";
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Location = new System.Drawing.Point(365, 20);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(176, 21);
            this.txtBackupPath.TabIndex = 28;
            // 
            // lblBackupPath
            // 
            this.lblBackupPath.AutoSize = true;
            this.lblBackupPath.Location = new System.Drawing.Point(287, 24);
            this.lblBackupPath.Name = "lblBackupPath";
            this.lblBackupPath.Size = new System.Drawing.Size(72, 12);
            this.lblBackupPath.TabIndex = 27;
            this.lblBackupPath.Text = "BackupPath";
            // 
            // txtTargetPath
            // 
            this.txtTargetPath.Location = new System.Drawing.Point(48, 20);
            this.txtTargetPath.Name = "txtTargetPath";
            this.txtTargetPath.Size = new System.Drawing.Size(218, 21);
            this.txtTargetPath.TabIndex = 26;
            // 
            // lblTargetPath
            // 
            this.lblTargetPath.AutoSize = true;
            this.lblTargetPath.Location = new System.Drawing.Point(12, 24);
            this.lblTargetPath.Name = "lblTargetPath";
            this.lblTargetPath.Size = new System.Drawing.Size(30, 12);
            this.lblTargetPath.TabIndex = 25;
            this.lblTargetPath.Text = "Path";
            // 
            // tpWorkers
            // 
            this.tpWorkers.Controls.Add(this.flpWorkerRows);
            this.tpWorkers.Controls.Add(this.pnlWorkerCommand);
            this.tpWorkers.Location = new System.Drawing.Point(4, 25);
            this.tpWorkers.Name = "tpWorkers";
            this.tpWorkers.Padding = new System.Windows.Forms.Padding(3);
            this.tpWorkers.Size = new System.Drawing.Size(724, 438);
            this.tpWorkers.TabIndex = 3;
            this.tpWorkers.Text = "Multi Worker";
            this.tpWorkers.UseVisualStyleBackColor = true;
            // 
            // flpWorkerRows
            // 
            this.flpWorkerRows.AutoScroll = true;
            this.flpWorkerRows.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWorkerRows.Location = new System.Drawing.Point(3, 40);
            this.flpWorkerRows.Name = "flpWorkerRows";
            this.flpWorkerRows.Padding = new System.Windows.Forms.Padding(4);
            this.flpWorkerRows.Size = new System.Drawing.Size(718, 395);
            this.flpWorkerRows.TabIndex = 1;
            // 
            // pnlWorkerCommand
            // 
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerResetTotals);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerDelete);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerAdd);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerSelectAll);
            this.pnlWorkerCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWorkerCommand.Location = new System.Drawing.Point(3, 3);
            this.pnlWorkerCommand.Name = "pnlWorkerCommand";
            this.pnlWorkerCommand.Size = new System.Drawing.Size(718, 37);
            this.pnlWorkerCommand.TabIndex = 0;
            // 
            // btnWorkerResetTotals
            // 
            this.btnWorkerResetTotals.Location = new System.Drawing.Point(272, 7);
            this.btnWorkerResetTotals.Name = "btnWorkerResetTotals";
            this.btnWorkerResetTotals.Size = new System.Drawing.Size(149, 23);
            this.btnWorkerResetTotals.TabIndex = 3;
            this.btnWorkerResetTotals.Text = "전체 누적 현황 초기화";
            this.btnWorkerResetTotals.UseVisualStyleBackColor = true;
            // 
            // btnWorkerDelete
            // 
            this.btnWorkerDelete.Location = new System.Drawing.Point(184, 7);
            this.btnWorkerDelete.Name = "btnWorkerDelete";
            this.btnWorkerDelete.Size = new System.Drawing.Size(82, 23);
            this.btnWorkerDelete.TabIndex = 2;
            this.btnWorkerDelete.Text = "작업자 삭제";
            this.btnWorkerDelete.UseVisualStyleBackColor = true;
            // 
            // btnWorkerAdd
            // 
            this.btnWorkerAdd.Location = new System.Drawing.Point(96, 7);
            this.btnWorkerAdd.Name = "btnWorkerAdd";
            this.btnWorkerAdd.Size = new System.Drawing.Size(82, 23);
            this.btnWorkerAdd.TabIndex = 1;
            this.btnWorkerAdd.Text = "작업자 추가";
            this.btnWorkerAdd.UseVisualStyleBackColor = true;
            // 
            // btnWorkerSelectAll
            // 
            this.btnWorkerSelectAll.Location = new System.Drawing.Point(8, 7);
            this.btnWorkerSelectAll.Name = "btnWorkerSelectAll";
            this.btnWorkerSelectAll.Size = new System.Drawing.Size(82, 23);
            this.btnWorkerSelectAll.TabIndex = 0;
            this.btnWorkerSelectAll.Text = "전체 선택";
            this.btnWorkerSelectAll.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStatus);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 522);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1460, 12);
            this.panel1.TabIndex = 3;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(5, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(40, 12);
            this.lblStatus.TabIndex = 37;
            this.lblStatus.Text = "Status";
            // 
            // tmrBatch
            // 
            this.tmrBatch.Tick += new System.EventHandler(this.tmrBatch_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1466, 562);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(760, 480);
            this.Name = "frmMain";
            this.Text = "RecStorageMigration";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.grpConfig.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tpProcessLog.ResumeLayout(false);
            this.tlpLogs.ResumeLayout(false);
            this.pnlWorkerLog.ResumeLayout(false);
            this.tpConfigDB.ResumeLayout(false);
            this.grpWork.ResumeLayout(false);
            this.grpWork.PerformLayout();
            this.grpConfDBSource.ResumeLayout(false);
            this.grpConfDBSource.PerformLayout();
            this.grpConfPathI360.ResumeLayout(false);
            this.grpConfPathI360.PerformLayout();
            this.grpConfPathAudiolog.ResumeLayout(false);
            this.grpConfPathAudiolog.PerformLayout();
            this.grpConfPathTarget.ResumeLayout(false);
            this.grpConfPathTarget.PerformLayout();
            this.tpWorkers.ResumeLayout(false);
            this.pnlWorkerCommand.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.ToolStripButton tsbStart;
        private System.Windows.Forms.ToolStripButton tsbStop;
        private System.Windows.Forms.ToolStripButton tsbConfig;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbExit;
        private System.Windows.Forms.GroupBox grpWork;
        private System.Windows.Forms.GroupBox grpConfig;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tpProcessLog;
        private System.Windows.Forms.TableLayoutPanel tlpLogs;
        private System.Windows.Forms.Panel pnlWorkerLog;
        private System.Windows.Forms.FlowLayoutPanel flpWorkerLogSelectors;
        private System.Windows.Forms.ListBox lstWorkerLog;
        private System.Windows.Forms.TabPage tpConfigDB;
        private System.Windows.Forms.Label lblSec;
        private System.Windows.Forms.Label lblRunTime;
        private System.Windows.Forms.Label lblRunTime2;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.Label lblWeekendRunTime;
        private System.Windows.Forms.Label lblWeekendRunTime2;
        private System.Windows.Forms.DateTimePicker dtpWeekendEndTime;
        private System.Windows.Forms.DateTimePicker dtpWeekendStartTime;
        private System.Windows.Forms.TextBox txtInterval;
        private System.Windows.Forms.Label lblInterval;
        private System.Windows.Forms.CheckBox chkEnableDefaultConnectionLimit;
        private System.Windows.Forms.CheckBox chkRunAtStart;
        private System.Windows.Forms.Timer tmrBatch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grpConfDBSource;
        private System.Windows.Forms.TextBox txtSourceDBIP;
        private System.Windows.Forms.Label lblSourceDBIP;
        private System.Windows.Forms.TextBox txtSourceDBNM;
        private System.Windows.Forms.TextBox txtSourceSelectCondition;
        private System.Windows.Forms.Label lblSourceDBNM;
        private System.Windows.Forms.Label lblSourceSelectCondition;
        private System.Windows.Forms.TextBox txtSourceTableNM;
        private System.Windows.Forms.Label lblSourceTableNM;
        private System.Windows.Forms.TextBox txtSourceMarkField;
        private System.Windows.Forms.TextBox txtSourceDBID;
        private System.Windows.Forms.Label lblSourceMarkField;
        private System.Windows.Forms.Label lblSourceDBID;
        private System.Windows.Forms.TextBox txtSourceDBPW;
        private System.Windows.Forms.Label lblSourceDBPW;
        private System.Windows.Forms.GroupBox grpConfPathAudiolog;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.TabPage tpWorkers;
        private System.Windows.Forms.Panel pnlWorkerCommand;
        private System.Windows.Forms.Button btnWorkerResetTotals;
        private System.Windows.Forms.Button btnWorkerDelete;
        private System.Windows.Forms.Button btnWorkerAdd;
        private System.Windows.Forms.Button btnWorkerSelectAll;
        private System.Windows.Forms.FlowLayoutPanel flpWorkerRows;
        private System.Windows.Forms.GroupBox grpConfPathTarget;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Label lblTargetPath;
        private System.Windows.Forms.TextBox txtAudiologPath;
        private System.Windows.Forms.Label lblAudiologPath;
        private System.Windows.Forms.Label lblSourceYearDB;
        private System.Windows.Forms.TextBox txtSourceYearDB;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.GroupBox grpConfPathI360;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtI360NetBiosPath;
        private System.Windows.Forms.Label lblI360NetBiosPath;
        private System.Windows.Forms.TextBox txtI360IISPath;
        private System.Windows.Forms.Label lblI360IISPath;
        private System.Windows.Forms.TextBox txtI360HttpFullPathField;
        private System.Windows.Forms.Label lblI360HttpFullPathField;
        private System.Windows.Forms.TextBox txtAudiologPathAddField;
        private System.Windows.Forms.Label lblAudiologPathAddField;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.CheckBox checkTrustServer;
    }
}

