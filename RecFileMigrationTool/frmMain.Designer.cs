namespace RecFileMigrationTool
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
            this.colPathMappingEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colPathMappingVirtualPath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathMappingRealSourcePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPathMappingMemo = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.grpConfPathMapping = new System.Windows.Forms.GroupBox();
            this.tlpPathMappings = new System.Windows.Forms.TableLayoutPanel();
            this.lblI360HttpFullPathField = new System.Windows.Forms.Label();
            this.txtI360HttpFullPathField = new System.Windows.Forms.TextBox();
            this.flpPathMappingButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPathMappingAdd = new System.Windows.Forms.Button();
            this.btnPathMappingDelete = new System.Windows.Forms.Button();
            this.btnPathMappingMoveUp = new System.Windows.Forms.Button();
            this.btnPathMappingMoveDown = new System.Windows.Forms.Button();
            this.dgvPathMappings = new System.Windows.Forms.DataGridView();
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
            this.btnWorkerReport = new System.Windows.Forms.Button();
            this.btnWorkerResetTotals = new System.Windows.Forms.Button();
            this.btnWorkerDelete = new System.Windows.Forms.Button();
            this.btnWorkerAdd = new System.Windows.Forms.Button();
            this.btnWorkerSelectAll = new System.Windows.Forms.Button();
            this.tpManualRoboCopy = new System.Windows.Forms.TabPage();
            this.tlpManualRoboCopy = new System.Windows.Forms.TableLayoutPanel();
            this.grpManualRoboCopyPath = new System.Windows.Forms.GroupBox();
            this.lblManualRoboCopySource = new System.Windows.Forms.Label();
            this.txtManualRoboCopySourcePath = new System.Windows.Forms.TextBox();
            this.btnManualRoboCopySourceBrowse = new System.Windows.Forms.Button();
            this.lblManualRoboCopyTarget = new System.Windows.Forms.Label();
            this.txtManualRoboCopyTargetPath = new System.Windows.Forms.TextBox();
            this.btnManualRoboCopyTargetBrowse = new System.Windows.Forms.Button();
            this.lblManualRoboCopyPath = new System.Windows.Forms.Label();
            this.txtManualRoboCopyPath = new System.Windows.Forms.TextBox();
            this.lblManualRoboCopyFilePattern = new System.Windows.Forms.Label();
            this.txtManualRoboCopyFilePattern = new System.Windows.Forms.TextBox();
            this.lblManualRoboCopyExtraOptions = new System.Windows.Forms.Label();
            this.txtManualRoboCopyExtraOptions = new System.Windows.Forms.TextBox();
            this.grpManualRoboCopyOptions = new System.Windows.Forms.GroupBox();
            this.chkManualRoboCopyIncludeSubdirectories = new System.Windows.Forms.CheckBox();
            this.chkManualRoboCopyDryRun = new System.Windows.Forms.CheckBox();
            this.chkManualRoboCopyMirror = new System.Windows.Forms.CheckBox();
            this.lblManualRoboCopyRetryCount = new System.Windows.Forms.Label();
            this.txtManualRoboCopyRetryCount = new System.Windows.Forms.TextBox();
            this.lblManualRoboCopyWaitSeconds = new System.Windows.Forms.Label();
            this.txtManualRoboCopyWaitSeconds = new System.Windows.Forms.TextBox();
            this.lblManualRoboCopyThreadCount = new System.Windows.Forms.Label();
            this.txtManualRoboCopyThreadCount = new System.Windows.Forms.TextBox();
            this.lblManualRoboCopyTimeoutSeconds = new System.Windows.Forms.Label();
            this.txtManualRoboCopyTimeoutSeconds = new System.Windows.Forms.TextBox();
            this.lblManualRoboCopySuccessExitCodeMax = new System.Windows.Forms.Label();
            this.txtManualRoboCopySuccessExitCodeMax = new System.Windows.Forms.TextBox();
            this.chkManualRoboCopyNoProgress = new System.Windows.Forms.CheckBox();
            this.chkManualRoboCopyNoFileList = new System.Windows.Forms.CheckBox();
            this.chkManualRoboCopyNoDirectoryList = new System.Windows.Forms.CheckBox();
            this.btnManualRoboCopyPreview = new System.Windows.Forms.Button();
            this.btnManualRoboCopyStart = new System.Windows.Forms.Button();
            this.btnManualRoboCopyStop = new System.Windows.Forms.Button();
            this.btnManualRoboCopySave = new System.Windows.Forms.Button();
            this.grpManualRoboCopyReport = new System.Windows.Forms.GroupBox();
            this.chkManualRoboCopyReportEnabled = new System.Windows.Forms.CheckBox();
            this.lblManualRoboCopyReportDirectory = new System.Windows.Forms.Label();
            this.txtManualRoboCopyReportDirectory = new System.Windows.Forms.TextBox();
            this.btnManualRoboCopyReportBrowse = new System.Windows.Forms.Button();
            this.lblManualRoboCopyReportPrefix = new System.Windows.Forms.Label();
            this.txtManualRoboCopyReportPrefix = new System.Windows.Forms.TextBox();
            this.chkManualRoboCopyReportAppend = new System.Windows.Forms.CheckBox();
            this.chkManualRoboCopyReportTee = new System.Windows.Forms.CheckBox();
            this.chkManualRoboCopyOpenReportFolder = new System.Windows.Forms.CheckBox();
            this.grpManualRoboCopyCommand = new System.Windows.Forms.GroupBox();
            this.txtManualRoboCopyCommand = new System.Windows.Forms.TextBox();
            this.grpManualRoboCopyLog = new System.Windows.Forms.GroupBox();
            this.lstManualRoboCopyLog = new System.Windows.Forms.ListBox();
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
            this.grpConfPathMapping.SuspendLayout();
            this.tlpPathMappings.SuspendLayout();
            this.flpPathMappingButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathMappings)).BeginInit();
            this.grpConfPathAudiolog.SuspendLayout();
            this.grpConfPathTarget.SuspendLayout();
            this.tpWorkers.SuspendLayout();
            this.pnlWorkerCommand.SuspendLayout();
            this.tpManualRoboCopy.SuspendLayout();
            this.tlpManualRoboCopy.SuspendLayout();
            this.grpManualRoboCopyPath.SuspendLayout();
            this.grpManualRoboCopyOptions.SuspendLayout();
            this.grpManualRoboCopyReport.SuspendLayout();
            this.grpManualRoboCopyCommand.SuspendLayout();
            this.grpManualRoboCopyLog.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            //
            // colPathMappingEnabled
            //
            this.colPathMappingEnabled.FillWeight = 36F;
            this.colPathMappingEnabled.HeaderText = "Use";
            this.colPathMappingEnabled.MinimumWidth = 44;
            this.colPathMappingEnabled.Name = "colPathMappingEnabled";
            //
            // colPathMappingVirtualPath
            //
            this.colPathMappingVirtualPath.FillWeight = 140F;
            this.colPathMappingVirtualPath.HeaderText = "Virtual Path (DB)";
            this.colPathMappingVirtualPath.MinimumWidth = 160;
            this.colPathMappingVirtualPath.Name = "colPathMappingVirtualPath";
            //
            // colPathMappingRealSourcePath
            //
            this.colPathMappingRealSourcePath.FillWeight = 160F;
            this.colPathMappingRealSourcePath.HeaderText = "Real Source Path";
            this.colPathMappingRealSourcePath.MinimumWidth = 180;
            this.colPathMappingRealSourcePath.Name = "colPathMappingRealSourcePath";
            //
            // colPathMappingMemo
            //
            this.colPathMappingMemo.FillWeight = 80F;
            this.colPathMappingMemo.HeaderText = "Memo";
            this.colPathMappingMemo.MinimumWidth = 90;
            this.colPathMappingMemo.Name = "colPathMappingMemo";
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
            this.tabControl.Controls.Add(this.tpManualRoboCopy);
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
            this.tpConfigDB.Controls.Add(this.grpConfPathMapping);
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
            this.grpWork.Size = new System.Drawing.Size(1423, 100);
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
            this.grpConfDBSource.Size = new System.Drawing.Size(1423, 122);
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
            // grpConfPathMapping
            //
            this.grpConfPathMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfPathMapping.Controls.Add(this.tlpPathMappings);
            this.grpConfPathMapping.Location = new System.Drawing.Point(3, 241);
            this.grpConfPathMapping.Name = "grpConfPathMapping";
            this.grpConfPathMapping.Padding = new System.Windows.Forms.Padding(8, 18, 8, 8);
            this.grpConfPathMapping.Size = new System.Drawing.Size(1423, 260);
            this.grpConfPathMapping.TabIndex = 31;
            this.grpConfPathMapping.TabStop = false;
            this.grpConfPathMapping.Text = "Impact360 Path Mappings";
            //
            // tlpPathMappings
            //
            this.tlpPathMappings.ColumnCount = 2;
            this.tlpPathMappings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tlpPathMappings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPathMappings.Controls.Add(this.lblI360HttpFullPathField, 0, 0);
            this.tlpPathMappings.Controls.Add(this.txtI360HttpFullPathField, 1, 0);
            this.tlpPathMappings.Controls.Add(this.flpPathMappingButtons, 0, 1);
            this.tlpPathMappings.Controls.Add(this.dgvPathMappings, 0, 2);
            this.tlpPathMappings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPathMappings.Location = new System.Drawing.Point(8, 32);
            this.tlpPathMappings.Name = "tlpPathMappings";
            this.tlpPathMappings.RowCount = 3;
            this.tlpPathMappings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpPathMappings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpPathMappings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPathMappings.Size = new System.Drawing.Size(1407, 220);
            this.tlpPathMappings.TabIndex = 0;
            //
            // lblI360HttpFullPathField
            //
            this.lblI360HttpFullPathField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblI360HttpFullPathField.AutoSize = true;
            this.lblI360HttpFullPathField.Location = new System.Drawing.Point(0, 8);
            this.lblI360HttpFullPathField.Margin = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblI360HttpFullPathField.Name = "lblI360HttpFullPathField";
            this.lblI360HttpFullPathField.Size = new System.Drawing.Size(110, 12);
            this.lblI360HttpFullPathField.TabIndex = 0;
            this.lblI360HttpFullPathField.Text = "Http Full Path Field";
            //
            // txtI360HttpFullPathField
            //
            this.txtI360HttpFullPathField.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtI360HttpFullPathField.Location = new System.Drawing.Point(130, 3);
            this.txtI360HttpFullPathField.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.txtI360HttpFullPathField.Name = "txtI360HttpFullPathField";
            this.txtI360HttpFullPathField.Size = new System.Drawing.Size(220, 21);
            this.txtI360HttpFullPathField.TabIndex = 1;
            //
            // flpPathMappingButtons
            //
            this.tlpPathMappings.SetColumnSpan(this.flpPathMappingButtons, 2);
            this.flpPathMappingButtons.Controls.Add(this.btnPathMappingAdd);
            this.flpPathMappingButtons.Controls.Add(this.btnPathMappingDelete);
            this.flpPathMappingButtons.Controls.Add(this.btnPathMappingMoveUp);
            this.flpPathMappingButtons.Controls.Add(this.btnPathMappingMoveDown);
            this.flpPathMappingButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpPathMappingButtons.Location = new System.Drawing.Point(0, 28);
            this.flpPathMappingButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpPathMappingButtons.Name = "flpPathMappingButtons";
            this.flpPathMappingButtons.Size = new System.Drawing.Size(1407, 32);
            this.flpPathMappingButtons.TabIndex = 2;
            this.flpPathMappingButtons.WrapContents = false;
            //
            // btnPathMappingAdd
            //
            this.btnPathMappingAdd.Location = new System.Drawing.Point(0, 2);
            this.btnPathMappingAdd.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.btnPathMappingAdd.Name = "btnPathMappingAdd";
            this.btnPathMappingAdd.Size = new System.Drawing.Size(72, 24);
            this.btnPathMappingAdd.TabIndex = 0;
            this.btnPathMappingAdd.Text = "Add";
            this.btnPathMappingAdd.UseVisualStyleBackColor = true;
            this.btnPathMappingAdd.Click += new System.EventHandler(this.btnPathMappingAdd_Click);
            //
            // btnPathMappingDelete
            //
            this.btnPathMappingDelete.Location = new System.Drawing.Point(78, 2);
            this.btnPathMappingDelete.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.btnPathMappingDelete.Name = "btnPathMappingDelete";
            this.btnPathMappingDelete.Size = new System.Drawing.Size(72, 24);
            this.btnPathMappingDelete.TabIndex = 1;
            this.btnPathMappingDelete.Text = "Delete";
            this.btnPathMappingDelete.UseVisualStyleBackColor = true;
            this.btnPathMappingDelete.Click += new System.EventHandler(this.btnPathMappingDelete_Click);
            //
            // btnPathMappingMoveUp
            //
            this.btnPathMappingMoveUp.Location = new System.Drawing.Point(156, 2);
            this.btnPathMappingMoveUp.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.btnPathMappingMoveUp.Name = "btnPathMappingMoveUp";
            this.btnPathMappingMoveUp.Size = new System.Drawing.Size(72, 24);
            this.btnPathMappingMoveUp.TabIndex = 2;
            this.btnPathMappingMoveUp.Text = "Up";
            this.btnPathMappingMoveUp.UseVisualStyleBackColor = true;
            this.btnPathMappingMoveUp.Click += new System.EventHandler(this.btnPathMappingMoveUp_Click);
            //
            // btnPathMappingMoveDown
            //
            this.btnPathMappingMoveDown.Location = new System.Drawing.Point(234, 2);
            this.btnPathMappingMoveDown.Margin = new System.Windows.Forms.Padding(0, 2, 6, 2);
            this.btnPathMappingMoveDown.Name = "btnPathMappingMoveDown";
            this.btnPathMappingMoveDown.Size = new System.Drawing.Size(72, 24);
            this.btnPathMappingMoveDown.TabIndex = 3;
            this.btnPathMappingMoveDown.Text = "Down";
            this.btnPathMappingMoveDown.UseVisualStyleBackColor = true;
            this.btnPathMappingMoveDown.Click += new System.EventHandler(this.btnPathMappingMoveDown_Click);
            //
            // dgvPathMappings
            //
            this.dgvPathMappings.AllowUserToAddRows = false;
            this.dgvPathMappings.AllowUserToDeleteRows = false;
            this.dgvPathMappings.AllowUserToResizeRows = false;
            this.dgvPathMappings.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPathMappings.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvPathMappings.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPathMappingEnabled,
            this.colPathMappingVirtualPath,
            this.colPathMappingRealSourcePath,
            this.colPathMappingMemo});
            this.tlpPathMappings.SetColumnSpan(this.dgvPathMappings, 2);
            this.dgvPathMappings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPathMappings.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgvPathMappings.Location = new System.Drawing.Point(3, 63);
            this.dgvPathMappings.MultiSelect = false;
            this.dgvPathMappings.Name = "dgvPathMappings";
            this.dgvPathMappings.RowHeadersVisible = false;
            this.dgvPathMappings.RowTemplate.Height = 23;
            this.dgvPathMappings.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPathMappings.Size = new System.Drawing.Size(1401, 154);
            this.dgvPathMappings.TabIndex = 3;
            //
            // grpConfPathAudiolog
            //
            this.grpConfPathAudiolog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConfPathAudiolog.Controls.Add(this.txtAudiologPathAddField);
            this.grpConfPathAudiolog.Controls.Add(this.lblAudiologPathAddField);
            this.grpConfPathAudiolog.Controls.Add(this.txtAudiologPath);
            this.grpConfPathAudiolog.Controls.Add(this.lblAudiologPath);
            this.grpConfPathAudiolog.Location = new System.Drawing.Point(3, 509);
            this.grpConfPathAudiolog.Name = "grpConfPathAudiolog";
            this.grpConfPathAudiolog.Size = new System.Drawing.Size(1423, 52);
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
            this.grpConfPathTarget.Location = new System.Drawing.Point(3, 575);
            this.grpConfPathTarget.Name = "grpConfPathTarget";
            this.grpConfPathTarget.Size = new System.Drawing.Size(1423, 52);
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
            this.tpWorkers.Size = new System.Drawing.Size(1446, 464);
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
            this.flpWorkerRows.Size = new System.Drawing.Size(1440, 421);
            this.flpWorkerRows.TabIndex = 1;
            //
            // pnlWorkerCommand
            //
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerReport);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerResetTotals);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerDelete);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerAdd);
            this.pnlWorkerCommand.Controls.Add(this.btnWorkerSelectAll);
            this.pnlWorkerCommand.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlWorkerCommand.Location = new System.Drawing.Point(3, 3);
            this.pnlWorkerCommand.Name = "pnlWorkerCommand";
            this.pnlWorkerCommand.Size = new System.Drawing.Size(1440, 37);
            this.pnlWorkerCommand.TabIndex = 0;
            //
            // btnWorkerReport
            //
            this.btnWorkerReport.Location = new System.Drawing.Point(427, 7);
            this.btnWorkerReport.Name = "btnWorkerReport";
            this.btnWorkerReport.Size = new System.Drawing.Size(94, 23);
            this.btnWorkerReport.TabIndex = 4;
            this.btnWorkerReport.Text = "전체 현황";
            this.btnWorkerReport.UseVisualStyleBackColor = true;
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
            // tpManualRoboCopy
            //
            this.tpManualRoboCopy.Controls.Add(this.tlpManualRoboCopy);
            this.tpManualRoboCopy.Location = new System.Drawing.Point(4, 25);
            this.tpManualRoboCopy.Name = "tpManualRoboCopy";
            this.tpManualRoboCopy.Padding = new System.Windows.Forms.Padding(3);
            this.tpManualRoboCopy.Size = new System.Drawing.Size(1446, 464);
            this.tpManualRoboCopy.TabIndex = 4;
            this.tpManualRoboCopy.Text = "RoboCopy";
            this.tpManualRoboCopy.UseVisualStyleBackColor = true;
            //
            // tlpManualRoboCopy
            //
            this.tlpManualRoboCopy.ColumnCount = 1;
            this.tlpManualRoboCopy.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpManualRoboCopy.Controls.Add(this.grpManualRoboCopyPath, 0, 0);
            this.tlpManualRoboCopy.Controls.Add(this.grpManualRoboCopyOptions, 0, 1);
            this.tlpManualRoboCopy.Controls.Add(this.grpManualRoboCopyReport, 0, 2);
            this.tlpManualRoboCopy.Controls.Add(this.grpManualRoboCopyCommand, 0, 3);
            this.tlpManualRoboCopy.Controls.Add(this.grpManualRoboCopyLog, 0, 4);
            this.tlpManualRoboCopy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpManualRoboCopy.Location = new System.Drawing.Point(3, 3);
            this.tlpManualRoboCopy.Name = "tlpManualRoboCopy";
            this.tlpManualRoboCopy.RowCount = 5;
            this.tlpManualRoboCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 116F));
            this.tlpManualRoboCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tlpManualRoboCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tlpManualRoboCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tlpManualRoboCopy.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpManualRoboCopy.Size = new System.Drawing.Size(1440, 458);
            this.tlpManualRoboCopy.TabIndex = 0;
            //
            // grpManualRoboCopyPath
            //
            this.grpManualRoboCopyPath.Controls.Add(this.lblManualRoboCopySource);
            this.grpManualRoboCopyPath.Controls.Add(this.txtManualRoboCopySourcePath);
            this.grpManualRoboCopyPath.Controls.Add(this.btnManualRoboCopySourceBrowse);
            this.grpManualRoboCopyPath.Controls.Add(this.lblManualRoboCopyTarget);
            this.grpManualRoboCopyPath.Controls.Add(this.txtManualRoboCopyTargetPath);
            this.grpManualRoboCopyPath.Controls.Add(this.btnManualRoboCopyTargetBrowse);
            this.grpManualRoboCopyPath.Controls.Add(this.lblManualRoboCopyPath);
            this.grpManualRoboCopyPath.Controls.Add(this.txtManualRoboCopyPath);
            this.grpManualRoboCopyPath.Controls.Add(this.lblManualRoboCopyFilePattern);
            this.grpManualRoboCopyPath.Controls.Add(this.txtManualRoboCopyFilePattern);
            this.grpManualRoboCopyPath.Controls.Add(this.lblManualRoboCopyExtraOptions);
            this.grpManualRoboCopyPath.Controls.Add(this.txtManualRoboCopyExtraOptions);
            this.grpManualRoboCopyPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManualRoboCopyPath.Location = new System.Drawing.Point(3, 3);
            this.grpManualRoboCopyPath.Name = "grpManualRoboCopyPath";
            this.grpManualRoboCopyPath.Size = new System.Drawing.Size(1434, 110);
            this.grpManualRoboCopyPath.TabIndex = 0;
            this.grpManualRoboCopyPath.TabStop = false;
            this.grpManualRoboCopyPath.Text = "Manual RoboCopy Path";
            //
            // lblManualRoboCopySource
            //
            this.lblManualRoboCopySource.AutoSize = true;
            this.lblManualRoboCopySource.Location = new System.Drawing.Point(12, 25);
            this.lblManualRoboCopySource.Name = "lblManualRoboCopySource";
            this.lblManualRoboCopySource.Size = new System.Drawing.Size(45, 12);
            this.lblManualRoboCopySource.TabIndex = 0;
            this.lblManualRoboCopySource.Text = "Source";
            //
            // txtManualRoboCopySourcePath
            //
            this.txtManualRoboCopySourcePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManualRoboCopySourcePath.Location = new System.Drawing.Point(86, 21);
            this.txtManualRoboCopySourcePath.Name = "txtManualRoboCopySourcePath";
            this.txtManualRoboCopySourcePath.Size = new System.Drawing.Size(1258, 21);
            this.txtManualRoboCopySourcePath.TabIndex = 1;
            //
            // btnManualRoboCopySourceBrowse
            //
            this.btnManualRoboCopySourceBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopySourceBrowse.Location = new System.Drawing.Point(1352, 19);
            this.btnManualRoboCopySourceBrowse.Name = "btnManualRoboCopySourceBrowse";
            this.btnManualRoboCopySourceBrowse.Size = new System.Drawing.Size(70, 24);
            this.btnManualRoboCopySourceBrowse.TabIndex = 2;
            this.btnManualRoboCopySourceBrowse.Text = "Browse";
            this.btnManualRoboCopySourceBrowse.UseVisualStyleBackColor = true;
            //
            // lblManualRoboCopyTarget
            //
            this.lblManualRoboCopyTarget.AutoSize = true;
            this.lblManualRoboCopyTarget.Location = new System.Drawing.Point(12, 53);
            this.lblManualRoboCopyTarget.Name = "lblManualRoboCopyTarget";
            this.lblManualRoboCopyTarget.Size = new System.Drawing.Size(41, 12);
            this.lblManualRoboCopyTarget.TabIndex = 3;
            this.lblManualRoboCopyTarget.Text = "Target";
            //
            // txtManualRoboCopyTargetPath
            //
            this.txtManualRoboCopyTargetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManualRoboCopyTargetPath.Location = new System.Drawing.Point(86, 49);
            this.txtManualRoboCopyTargetPath.Name = "txtManualRoboCopyTargetPath";
            this.txtManualRoboCopyTargetPath.Size = new System.Drawing.Size(1258, 21);
            this.txtManualRoboCopyTargetPath.TabIndex = 4;
            //
            // btnManualRoboCopyTargetBrowse
            //
            this.btnManualRoboCopyTargetBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopyTargetBrowse.Location = new System.Drawing.Point(1352, 47);
            this.btnManualRoboCopyTargetBrowse.Name = "btnManualRoboCopyTargetBrowse";
            this.btnManualRoboCopyTargetBrowse.Size = new System.Drawing.Size(70, 24);
            this.btnManualRoboCopyTargetBrowse.TabIndex = 5;
            this.btnManualRoboCopyTargetBrowse.Text = "Browse";
            this.btnManualRoboCopyTargetBrowse.UseVisualStyleBackColor = true;
            //
            // lblManualRoboCopyPath
            //
            this.lblManualRoboCopyPath.AutoSize = true;
            this.lblManualRoboCopyPath.Location = new System.Drawing.Point(12, 81);
            this.lblManualRoboCopyPath.Name = "lblManualRoboCopyPath";
            this.lblManualRoboCopyPath.Size = new System.Drawing.Size(64, 12);
            this.lblManualRoboCopyPath.TabIndex = 6;
            this.lblManualRoboCopyPath.Text = "RoboCopy";
            //
            // txtManualRoboCopyPath
            //
            this.txtManualRoboCopyPath.Location = new System.Drawing.Point(86, 77);
            this.txtManualRoboCopyPath.Name = "txtManualRoboCopyPath";
            this.txtManualRoboCopyPath.Size = new System.Drawing.Size(230, 21);
            this.txtManualRoboCopyPath.TabIndex = 7;
            //
            // lblManualRoboCopyFilePattern
            //
            this.lblManualRoboCopyFilePattern.AutoSize = true;
            this.lblManualRoboCopyFilePattern.Location = new System.Drawing.Point(330, 81);
            this.lblManualRoboCopyFilePattern.Name = "lblManualRoboCopyFilePattern";
            this.lblManualRoboCopyFilePattern.Size = new System.Drawing.Size(44, 12);
            this.lblManualRoboCopyFilePattern.TabIndex = 8;
            this.lblManualRoboCopyFilePattern.Text = "Pattern";
            //
            // txtManualRoboCopyFilePattern
            //
            this.txtManualRoboCopyFilePattern.Location = new System.Drawing.Point(390, 77);
            this.txtManualRoboCopyFilePattern.Name = "txtManualRoboCopyFilePattern";
            this.txtManualRoboCopyFilePattern.Size = new System.Drawing.Size(116, 21);
            this.txtManualRoboCopyFilePattern.TabIndex = 9;
            //
            // lblManualRoboCopyExtraOptions
            //
            this.lblManualRoboCopyExtraOptions.AutoSize = true;
            this.lblManualRoboCopyExtraOptions.Location = new System.Drawing.Point(520, 81);
            this.lblManualRoboCopyExtraOptions.Name = "lblManualRoboCopyExtraOptions";
            this.lblManualRoboCopyExtraOptions.Size = new System.Drawing.Size(34, 12);
            this.lblManualRoboCopyExtraOptions.TabIndex = 10;
            this.lblManualRoboCopyExtraOptions.Text = "Extra";
            //
            // txtManualRoboCopyExtraOptions
            //
            this.txtManualRoboCopyExtraOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManualRoboCopyExtraOptions.Location = new System.Drawing.Point(566, 77);
            this.txtManualRoboCopyExtraOptions.Name = "txtManualRoboCopyExtraOptions";
            this.txtManualRoboCopyExtraOptions.Size = new System.Drawing.Size(856, 21);
            this.txtManualRoboCopyExtraOptions.TabIndex = 11;
            //
            // grpManualRoboCopyOptions
            //
            this.grpManualRoboCopyOptions.Controls.Add(this.chkManualRoboCopyIncludeSubdirectories);
            this.grpManualRoboCopyOptions.Controls.Add(this.chkManualRoboCopyDryRun);
            this.grpManualRoboCopyOptions.Controls.Add(this.chkManualRoboCopyMirror);
            this.grpManualRoboCopyOptions.Controls.Add(this.lblManualRoboCopyRetryCount);
            this.grpManualRoboCopyOptions.Controls.Add(this.txtManualRoboCopyRetryCount);
            this.grpManualRoboCopyOptions.Controls.Add(this.lblManualRoboCopyWaitSeconds);
            this.grpManualRoboCopyOptions.Controls.Add(this.txtManualRoboCopyWaitSeconds);
            this.grpManualRoboCopyOptions.Controls.Add(this.lblManualRoboCopyThreadCount);
            this.grpManualRoboCopyOptions.Controls.Add(this.txtManualRoboCopyThreadCount);
            this.grpManualRoboCopyOptions.Controls.Add(this.lblManualRoboCopyTimeoutSeconds);
            this.grpManualRoboCopyOptions.Controls.Add(this.txtManualRoboCopyTimeoutSeconds);
            this.grpManualRoboCopyOptions.Controls.Add(this.lblManualRoboCopySuccessExitCodeMax);
            this.grpManualRoboCopyOptions.Controls.Add(this.txtManualRoboCopySuccessExitCodeMax);
            this.grpManualRoboCopyOptions.Controls.Add(this.chkManualRoboCopyNoProgress);
            this.grpManualRoboCopyOptions.Controls.Add(this.chkManualRoboCopyNoFileList);
            this.grpManualRoboCopyOptions.Controls.Add(this.chkManualRoboCopyNoDirectoryList);
            this.grpManualRoboCopyOptions.Controls.Add(this.btnManualRoboCopyPreview);
            this.grpManualRoboCopyOptions.Controls.Add(this.btnManualRoboCopyStart);
            this.grpManualRoboCopyOptions.Controls.Add(this.btnManualRoboCopyStop);
            this.grpManualRoboCopyOptions.Controls.Add(this.btnManualRoboCopySave);
            this.grpManualRoboCopyOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManualRoboCopyOptions.Location = new System.Drawing.Point(3, 119);
            this.grpManualRoboCopyOptions.Name = "grpManualRoboCopyOptions";
            this.grpManualRoboCopyOptions.Size = new System.Drawing.Size(1434, 88);
            this.grpManualRoboCopyOptions.TabIndex = 1;
            this.grpManualRoboCopyOptions.TabStop = false;
            this.grpManualRoboCopyOptions.Text = "Options";
            //
            // chkManualRoboCopyIncludeSubdirectories
            //
            this.chkManualRoboCopyIncludeSubdirectories.Location = new System.Drawing.Point(12, 22);
            this.chkManualRoboCopyIncludeSubdirectories.Name = "chkManualRoboCopyIncludeSubdirectories";
            this.chkManualRoboCopyIncludeSubdirectories.Size = new System.Drawing.Size(90, 20);
            this.chkManualRoboCopyIncludeSubdirectories.TabIndex = 0;
            this.chkManualRoboCopyIncludeSubdirectories.Text = "/E subdirs";
            this.chkManualRoboCopyIncludeSubdirectories.UseVisualStyleBackColor = true;
            //
            // chkManualRoboCopyDryRun
            //
            this.chkManualRoboCopyDryRun.Location = new System.Drawing.Point(112, 22);
            this.chkManualRoboCopyDryRun.Name = "chkManualRoboCopyDryRun";
            this.chkManualRoboCopyDryRun.Size = new System.Drawing.Size(90, 20);
            this.chkManualRoboCopyDryRun.TabIndex = 1;
            this.chkManualRoboCopyDryRun.Text = "/L dry run";
            this.chkManualRoboCopyDryRun.UseVisualStyleBackColor = true;
            //
            // chkManualRoboCopyMirror
            //
            this.chkManualRoboCopyMirror.Location = new System.Drawing.Point(212, 22);
            this.chkManualRoboCopyMirror.Name = "chkManualRoboCopyMirror";
            this.chkManualRoboCopyMirror.Size = new System.Drawing.Size(96, 20);
            this.chkManualRoboCopyMirror.TabIndex = 2;
            this.chkManualRoboCopyMirror.Text = "/MIR mirror";
            this.chkManualRoboCopyMirror.UseVisualStyleBackColor = true;
            //
            // lblManualRoboCopyRetryCount
            //
            this.lblManualRoboCopyRetryCount.AutoSize = true;
            this.lblManualRoboCopyRetryCount.Location = new System.Drawing.Point(330, 26);
            this.lblManualRoboCopyRetryCount.Name = "lblManualRoboCopyRetryCount";
            this.lblManualRoboCopyRetryCount.Size = new System.Drawing.Size(34, 12);
            this.lblManualRoboCopyRetryCount.TabIndex = 3;
            this.lblManualRoboCopyRetryCount.Text = "Retry";
            //
            // txtManualRoboCopyRetryCount
            //
            this.txtManualRoboCopyRetryCount.Location = new System.Drawing.Point(374, 22);
            this.txtManualRoboCopyRetryCount.Name = "txtManualRoboCopyRetryCount";
            this.txtManualRoboCopyRetryCount.Size = new System.Drawing.Size(45, 21);
            this.txtManualRoboCopyRetryCount.TabIndex = 4;
            //
            // lblManualRoboCopyWaitSeconds
            //
            this.lblManualRoboCopyWaitSeconds.AutoSize = true;
            this.lblManualRoboCopyWaitSeconds.Location = new System.Drawing.Point(432, 26);
            this.lblManualRoboCopyWaitSeconds.Name = "lblManualRoboCopyWaitSeconds";
            this.lblManualRoboCopyWaitSeconds.Size = new System.Drawing.Size(28, 12);
            this.lblManualRoboCopyWaitSeconds.TabIndex = 5;
            this.lblManualRoboCopyWaitSeconds.Text = "Wait";
            //
            // txtManualRoboCopyWaitSeconds
            //
            this.txtManualRoboCopyWaitSeconds.Location = new System.Drawing.Point(474, 22);
            this.txtManualRoboCopyWaitSeconds.Name = "txtManualRoboCopyWaitSeconds";
            this.txtManualRoboCopyWaitSeconds.Size = new System.Drawing.Size(45, 21);
            this.txtManualRoboCopyWaitSeconds.TabIndex = 6;
            //
            // lblManualRoboCopyThreadCount
            //
            this.lblManualRoboCopyThreadCount.AutoSize = true;
            this.lblManualRoboCopyThreadCount.Location = new System.Drawing.Point(532, 26);
            this.lblManualRoboCopyThreadCount.Name = "lblManualRoboCopyThreadCount";
            this.lblManualRoboCopyThreadCount.Size = new System.Drawing.Size(45, 12);
            this.lblManualRoboCopyThreadCount.TabIndex = 7;
            this.lblManualRoboCopyThreadCount.Text = "Thread";
            //
            // txtManualRoboCopyThreadCount
            //
            this.txtManualRoboCopyThreadCount.Location = new System.Drawing.Point(584, 22);
            this.txtManualRoboCopyThreadCount.Name = "txtManualRoboCopyThreadCount";
            this.txtManualRoboCopyThreadCount.Size = new System.Drawing.Size(45, 21);
            this.txtManualRoboCopyThreadCount.TabIndex = 8;
            //
            // lblManualRoboCopyTimeoutSeconds
            //
            this.lblManualRoboCopyTimeoutSeconds.AutoSize = true;
            this.lblManualRoboCopyTimeoutSeconds.Location = new System.Drawing.Point(642, 26);
            this.lblManualRoboCopyTimeoutSeconds.Name = "lblManualRoboCopyTimeoutSeconds";
            this.lblManualRoboCopyTimeoutSeconds.Size = new System.Drawing.Size(51, 12);
            this.lblManualRoboCopyTimeoutSeconds.TabIndex = 9;
            this.lblManualRoboCopyTimeoutSeconds.Text = "Timeout";
            //
            // txtManualRoboCopyTimeoutSeconds
            //
            this.txtManualRoboCopyTimeoutSeconds.Location = new System.Drawing.Point(702, 22);
            this.txtManualRoboCopyTimeoutSeconds.Name = "txtManualRoboCopyTimeoutSeconds";
            this.txtManualRoboCopyTimeoutSeconds.Size = new System.Drawing.Size(60, 21);
            this.txtManualRoboCopyTimeoutSeconds.TabIndex = 10;
            //
            // lblManualRoboCopySuccessExitCodeMax
            //
            this.lblManualRoboCopySuccessExitCodeMax.AutoSize = true;
            this.lblManualRoboCopySuccessExitCodeMax.Location = new System.Drawing.Point(776, 26);
            this.lblManualRoboCopySuccessExitCodeMax.Name = "lblManualRoboCopySuccessExitCodeMax";
            this.lblManualRoboCopySuccessExitCodeMax.Size = new System.Drawing.Size(85, 12);
            this.lblManualRoboCopySuccessExitCodeMax.TabIndex = 11;
            this.lblManualRoboCopySuccessExitCodeMax.Text = "SuccessCode";
            //
            // txtManualRoboCopySuccessExitCodeMax
            //
            this.txtManualRoboCopySuccessExitCodeMax.Location = new System.Drawing.Point(856, 22);
            this.txtManualRoboCopySuccessExitCodeMax.Name = "txtManualRoboCopySuccessExitCodeMax";
            this.txtManualRoboCopySuccessExitCodeMax.Size = new System.Drawing.Size(40, 21);
            this.txtManualRoboCopySuccessExitCodeMax.TabIndex = 12;
            //
            // chkManualRoboCopyNoProgress
            //
            this.chkManualRoboCopyNoProgress.Location = new System.Drawing.Point(12, 55);
            this.chkManualRoboCopyNoProgress.Name = "chkManualRoboCopyNoProgress";
            this.chkManualRoboCopyNoProgress.Size = new System.Drawing.Size(58, 20);
            this.chkManualRoboCopyNoProgress.TabIndex = 13;
            this.chkManualRoboCopyNoProgress.Text = "/NP";
            this.chkManualRoboCopyNoProgress.UseVisualStyleBackColor = true;
            //
            // chkManualRoboCopyNoFileList
            //
            this.chkManualRoboCopyNoFileList.Location = new System.Drawing.Point(82, 55);
            this.chkManualRoboCopyNoFileList.Name = "chkManualRoboCopyNoFileList";
            this.chkManualRoboCopyNoFileList.Size = new System.Drawing.Size(62, 20);
            this.chkManualRoboCopyNoFileList.TabIndex = 14;
            this.chkManualRoboCopyNoFileList.Text = "/NFL";
            this.chkManualRoboCopyNoFileList.UseVisualStyleBackColor = true;
            //
            // chkManualRoboCopyNoDirectoryList
            //
            this.chkManualRoboCopyNoDirectoryList.Location = new System.Drawing.Point(154, 55);
            this.chkManualRoboCopyNoDirectoryList.Name = "chkManualRoboCopyNoDirectoryList";
            this.chkManualRoboCopyNoDirectoryList.Size = new System.Drawing.Size(66, 20);
            this.chkManualRoboCopyNoDirectoryList.TabIndex = 15;
            this.chkManualRoboCopyNoDirectoryList.Text = "/NDL";
            this.chkManualRoboCopyNoDirectoryList.UseVisualStyleBackColor = true;
            //
            // btnManualRoboCopyPreview
            //
            this.btnManualRoboCopyPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopyPreview.Location = new System.Drawing.Point(1072, 20);
            this.btnManualRoboCopyPreview.Name = "btnManualRoboCopyPreview";
            this.btnManualRoboCopyPreview.Size = new System.Drawing.Size(82, 24);
            this.btnManualRoboCopyPreview.TabIndex = 16;
            this.btnManualRoboCopyPreview.Text = "Preview";
            this.btnManualRoboCopyPreview.UseVisualStyleBackColor = true;
            //
            // btnManualRoboCopyStart
            //
            this.btnManualRoboCopyStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopyStart.Location = new System.Drawing.Point(1162, 20);
            this.btnManualRoboCopyStart.Name = "btnManualRoboCopyStart";
            this.btnManualRoboCopyStart.Size = new System.Drawing.Size(82, 24);
            this.btnManualRoboCopyStart.TabIndex = 17;
            this.btnManualRoboCopyStart.Text = "Start";
            this.btnManualRoboCopyStart.UseVisualStyleBackColor = true;
            //
            // btnManualRoboCopyStop
            //
            this.btnManualRoboCopyStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopyStop.Enabled = false;
            this.btnManualRoboCopyStop.Location = new System.Drawing.Point(1252, 20);
            this.btnManualRoboCopyStop.Name = "btnManualRoboCopyStop";
            this.btnManualRoboCopyStop.Size = new System.Drawing.Size(82, 24);
            this.btnManualRoboCopyStop.TabIndex = 18;
            this.btnManualRoboCopyStop.Text = "Stop";
            this.btnManualRoboCopyStop.UseVisualStyleBackColor = true;
            //
            // btnManualRoboCopySave
            //
            this.btnManualRoboCopySave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopySave.Location = new System.Drawing.Point(1342, 20);
            this.btnManualRoboCopySave.Name = "btnManualRoboCopySave";
            this.btnManualRoboCopySave.Size = new System.Drawing.Size(82, 24);
            this.btnManualRoboCopySave.TabIndex = 19;
            this.btnManualRoboCopySave.Text = "Save";
            this.btnManualRoboCopySave.UseVisualStyleBackColor = true;
            //
            // grpManualRoboCopyReport
            //
            this.grpManualRoboCopyReport.Controls.Add(this.chkManualRoboCopyReportEnabled);
            this.grpManualRoboCopyReport.Controls.Add(this.lblManualRoboCopyReportDirectory);
            this.grpManualRoboCopyReport.Controls.Add(this.txtManualRoboCopyReportDirectory);
            this.grpManualRoboCopyReport.Controls.Add(this.btnManualRoboCopyReportBrowse);
            this.grpManualRoboCopyReport.Controls.Add(this.lblManualRoboCopyReportPrefix);
            this.grpManualRoboCopyReport.Controls.Add(this.txtManualRoboCopyReportPrefix);
            this.grpManualRoboCopyReport.Controls.Add(this.chkManualRoboCopyReportAppend);
            this.grpManualRoboCopyReport.Controls.Add(this.chkManualRoboCopyReportTee);
            this.grpManualRoboCopyReport.Controls.Add(this.chkManualRoboCopyOpenReportFolder);
            this.grpManualRoboCopyReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManualRoboCopyReport.Location = new System.Drawing.Point(3, 213);
            this.grpManualRoboCopyReport.Name = "grpManualRoboCopyReport";
            this.grpManualRoboCopyReport.Size = new System.Drawing.Size(1434, 68);
            this.grpManualRoboCopyReport.TabIndex = 2;
            this.grpManualRoboCopyReport.TabStop = false;
            this.grpManualRoboCopyReport.Text = "Report";
            //
            // chkManualRoboCopyReportEnabled
            //
            this.chkManualRoboCopyReportEnabled.Location = new System.Drawing.Point(12, 21);
            this.chkManualRoboCopyReportEnabled.Name = "chkManualRoboCopyReportEnabled";
            this.chkManualRoboCopyReportEnabled.Size = new System.Drawing.Size(112, 20);
            this.chkManualRoboCopyReportEnabled.TabIndex = 0;
            this.chkManualRoboCopyReportEnabled.Text = "Report output";
            this.chkManualRoboCopyReportEnabled.UseVisualStyleBackColor = true;
            //
            // lblManualRoboCopyReportDirectory
            //
            this.lblManualRoboCopyReportDirectory.AutoSize = true;
            this.lblManualRoboCopyReportDirectory.Location = new System.Drawing.Point(138, 25);
            this.lblManualRoboCopyReportDirectory.Name = "lblManualRoboCopyReportDirectory";
            this.lblManualRoboCopyReportDirectory.Size = new System.Drawing.Size(55, 12);
            this.lblManualRoboCopyReportDirectory.TabIndex = 1;
            this.lblManualRoboCopyReportDirectory.Text = "Directory";
            //
            // txtManualRoboCopyReportDirectory
            //
            this.txtManualRoboCopyReportDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManualRoboCopyReportDirectory.Location = new System.Drawing.Point(208, 21);
            this.txtManualRoboCopyReportDirectory.Name = "txtManualRoboCopyReportDirectory";
            this.txtManualRoboCopyReportDirectory.Size = new System.Drawing.Size(1136, 21);
            this.txtManualRoboCopyReportDirectory.TabIndex = 2;
            //
            // btnManualRoboCopyReportBrowse
            //
            this.btnManualRoboCopyReportBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManualRoboCopyReportBrowse.Location = new System.Drawing.Point(1352, 19);
            this.btnManualRoboCopyReportBrowse.Name = "btnManualRoboCopyReportBrowse";
            this.btnManualRoboCopyReportBrowse.Size = new System.Drawing.Size(70, 24);
            this.btnManualRoboCopyReportBrowse.TabIndex = 3;
            this.btnManualRoboCopyReportBrowse.Text = "Browse";
            this.btnManualRoboCopyReportBrowse.UseVisualStyleBackColor = true;
            //
            // lblManualRoboCopyReportPrefix
            //
            this.lblManualRoboCopyReportPrefix.AutoSize = true;
            this.lblManualRoboCopyReportPrefix.Location = new System.Drawing.Point(12, 50);
            this.lblManualRoboCopyReportPrefix.Name = "lblManualRoboCopyReportPrefix";
            this.lblManualRoboCopyReportPrefix.Size = new System.Drawing.Size(37, 12);
            this.lblManualRoboCopyReportPrefix.TabIndex = 4;
            this.lblManualRoboCopyReportPrefix.Text = "Prefix";
            //
            // txtManualRoboCopyReportPrefix
            //
            this.txtManualRoboCopyReportPrefix.Location = new System.Drawing.Point(86, 46);
            this.txtManualRoboCopyReportPrefix.Name = "txtManualRoboCopyReportPrefix";
            this.txtManualRoboCopyReportPrefix.Size = new System.Drawing.Size(220, 21);
            this.txtManualRoboCopyReportPrefix.TabIndex = 5;
            //
            // chkManualRoboCopyReportAppend
            //
            this.chkManualRoboCopyReportAppend.Location = new System.Drawing.Point(330, 47);
            this.chkManualRoboCopyReportAppend.Name = "chkManualRoboCopyReportAppend";
            this.chkManualRoboCopyReportAppend.Size = new System.Drawing.Size(108, 20);
            this.chkManualRoboCopyReportAppend.TabIndex = 6;
            this.chkManualRoboCopyReportAppend.Text = "Append";
            this.chkManualRoboCopyReportAppend.UseVisualStyleBackColor = true;
            //
            // chkManualRoboCopyReportTee
            //
            this.chkManualRoboCopyReportTee.Location = new System.Drawing.Point(450, 47);
            this.chkManualRoboCopyReportTee.Name = "chkManualRoboCopyReportTee";
            this.chkManualRoboCopyReportTee.Size = new System.Drawing.Size(96, 20);
            this.chkManualRoboCopyReportTee.TabIndex = 7;
            this.chkManualRoboCopyReportTee.Text = "/TEE";
            this.chkManualRoboCopyReportTee.UseVisualStyleBackColor = true;
            //
            // chkManualRoboCopyOpenReportFolder
            //
            this.chkManualRoboCopyOpenReportFolder.Location = new System.Drawing.Point(560, 47);
            this.chkManualRoboCopyOpenReportFolder.Name = "chkManualRoboCopyOpenReportFolder";
            this.chkManualRoboCopyOpenReportFolder.Size = new System.Drawing.Size(186, 20);
            this.chkManualRoboCopyOpenReportFolder.TabIndex = 8;
            this.chkManualRoboCopyOpenReportFolder.Text = "Open folder after finish";
            this.chkManualRoboCopyOpenReportFolder.UseVisualStyleBackColor = true;
            //
            // grpManualRoboCopyCommand
            //
            this.grpManualRoboCopyCommand.Controls.Add(this.txtManualRoboCopyCommand);
            this.grpManualRoboCopyCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManualRoboCopyCommand.Location = new System.Drawing.Point(3, 287);
            this.grpManualRoboCopyCommand.Name = "grpManualRoboCopyCommand";
            this.grpManualRoboCopyCommand.Size = new System.Drawing.Size(1434, 70);
            this.grpManualRoboCopyCommand.TabIndex = 3;
            this.grpManualRoboCopyCommand.TabStop = false;
            this.grpManualRoboCopyCommand.Text = "Command Preview";
            //
            // txtManualRoboCopyCommand
            //
            this.txtManualRoboCopyCommand.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtManualRoboCopyCommand.Location = new System.Drawing.Point(3, 17);
            this.txtManualRoboCopyCommand.Multiline = true;
            this.txtManualRoboCopyCommand.Name = "txtManualRoboCopyCommand";
            this.txtManualRoboCopyCommand.ReadOnly = true;
            this.txtManualRoboCopyCommand.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtManualRoboCopyCommand.Size = new System.Drawing.Size(1428, 50);
            this.txtManualRoboCopyCommand.TabIndex = 0;
            this.txtManualRoboCopyCommand.WordWrap = false;
            //
            // grpManualRoboCopyLog
            //
            this.grpManualRoboCopyLog.Controls.Add(this.lstManualRoboCopyLog);
            this.grpManualRoboCopyLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpManualRoboCopyLog.Location = new System.Drawing.Point(3, 363);
            this.grpManualRoboCopyLog.Name = "grpManualRoboCopyLog";
            this.grpManualRoboCopyLog.Size = new System.Drawing.Size(1434, 92);
            this.grpManualRoboCopyLog.TabIndex = 4;
            this.grpManualRoboCopyLog.TabStop = false;
            this.grpManualRoboCopyLog.Text = "RoboCopy Log";
            //
            // lstManualRoboCopyLog
            //
            this.lstManualRoboCopyLog.BackColor = System.Drawing.Color.Black;
            this.lstManualRoboCopyLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstManualRoboCopyLog.ForeColor = System.Drawing.Color.LightGreen;
            this.lstManualRoboCopyLog.FormattingEnabled = true;
            this.lstManualRoboCopyLog.HorizontalScrollbar = true;
            this.lstManualRoboCopyLog.ItemHeight = 12;
            this.lstManualRoboCopyLog.Location = new System.Drawing.Point(3, 17);
            this.lstManualRoboCopyLog.Name = "lstManualRoboCopyLog";
            this.lstManualRoboCopyLog.Size = new System.Drawing.Size(1428, 72);
            this.lstManualRoboCopyLog.TabIndex = 0;
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
            this.Text = "RecFileMigrationTool";
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
            this.grpConfPathMapping.ResumeLayout(false);
            this.tlpPathMappings.ResumeLayout(false);
            this.tlpPathMappings.PerformLayout();
            this.flpPathMappingButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPathMappings)).EndInit();
            this.grpConfPathAudiolog.ResumeLayout(false);
            this.grpConfPathAudiolog.PerformLayout();
            this.grpConfPathTarget.ResumeLayout(false);
            this.grpConfPathTarget.PerformLayout();
            this.tpWorkers.ResumeLayout(false);
            this.pnlWorkerCommand.ResumeLayout(false);
            this.tpManualRoboCopy.ResumeLayout(false);
            this.tlpManualRoboCopy.ResumeLayout(false);
            this.grpManualRoboCopyPath.ResumeLayout(false);
            this.grpManualRoboCopyPath.PerformLayout();
            this.grpManualRoboCopyOptions.ResumeLayout(false);
            this.grpManualRoboCopyOptions.PerformLayout();
            this.grpManualRoboCopyReport.ResumeLayout(false);
            this.grpManualRoboCopyReport.PerformLayout();
            this.grpManualRoboCopyCommand.ResumeLayout(false);
            this.grpManualRoboCopyCommand.PerformLayout();
            this.grpManualRoboCopyLog.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnWorkerReport;
        private System.Windows.Forms.Button btnWorkerResetTotals;
        private System.Windows.Forms.Button btnWorkerDelete;
        private System.Windows.Forms.Button btnWorkerAdd;
        private System.Windows.Forms.Button btnWorkerSelectAll;
        private System.Windows.Forms.FlowLayoutPanel flpWorkerRows;
        private System.Windows.Forms.TabPage tpManualRoboCopy;
        private System.Windows.Forms.TableLayoutPanel tlpManualRoboCopy;
        private System.Windows.Forms.GroupBox grpManualRoboCopyPath;
        private System.Windows.Forms.Label lblManualRoboCopySource;
        private System.Windows.Forms.TextBox txtManualRoboCopySourcePath;
        private System.Windows.Forms.Button btnManualRoboCopySourceBrowse;
        private System.Windows.Forms.Label lblManualRoboCopyTarget;
        private System.Windows.Forms.TextBox txtManualRoboCopyTargetPath;
        private System.Windows.Forms.Button btnManualRoboCopyTargetBrowse;
        private System.Windows.Forms.Label lblManualRoboCopyPath;
        private System.Windows.Forms.TextBox txtManualRoboCopyPath;
        private System.Windows.Forms.Label lblManualRoboCopyFilePattern;
        private System.Windows.Forms.TextBox txtManualRoboCopyFilePattern;
        private System.Windows.Forms.Label lblManualRoboCopyExtraOptions;
        private System.Windows.Forms.TextBox txtManualRoboCopyExtraOptions;
        private System.Windows.Forms.GroupBox grpManualRoboCopyOptions;
        private System.Windows.Forms.CheckBox chkManualRoboCopyIncludeSubdirectories;
        private System.Windows.Forms.CheckBox chkManualRoboCopyDryRun;
        private System.Windows.Forms.CheckBox chkManualRoboCopyMirror;
        private System.Windows.Forms.Label lblManualRoboCopyRetryCount;
        private System.Windows.Forms.TextBox txtManualRoboCopyRetryCount;
        private System.Windows.Forms.Label lblManualRoboCopyWaitSeconds;
        private System.Windows.Forms.TextBox txtManualRoboCopyWaitSeconds;
        private System.Windows.Forms.Label lblManualRoboCopyThreadCount;
        private System.Windows.Forms.TextBox txtManualRoboCopyThreadCount;
        private System.Windows.Forms.Label lblManualRoboCopyTimeoutSeconds;
        private System.Windows.Forms.TextBox txtManualRoboCopyTimeoutSeconds;
        private System.Windows.Forms.Label lblManualRoboCopySuccessExitCodeMax;
        private System.Windows.Forms.TextBox txtManualRoboCopySuccessExitCodeMax;
        private System.Windows.Forms.CheckBox chkManualRoboCopyNoProgress;
        private System.Windows.Forms.CheckBox chkManualRoboCopyNoFileList;
        private System.Windows.Forms.CheckBox chkManualRoboCopyNoDirectoryList;
        private System.Windows.Forms.Button btnManualRoboCopyPreview;
        private System.Windows.Forms.Button btnManualRoboCopyStart;
        private System.Windows.Forms.Button btnManualRoboCopyStop;
        private System.Windows.Forms.Button btnManualRoboCopySave;
        private System.Windows.Forms.GroupBox grpManualRoboCopyReport;
        private System.Windows.Forms.CheckBox chkManualRoboCopyReportEnabled;
        private System.Windows.Forms.Label lblManualRoboCopyReportDirectory;
        private System.Windows.Forms.TextBox txtManualRoboCopyReportDirectory;
        private System.Windows.Forms.Button btnManualRoboCopyReportBrowse;
        private System.Windows.Forms.Label lblManualRoboCopyReportPrefix;
        private System.Windows.Forms.TextBox txtManualRoboCopyReportPrefix;
        private System.Windows.Forms.CheckBox chkManualRoboCopyReportAppend;
        private System.Windows.Forms.CheckBox chkManualRoboCopyReportTee;
        private System.Windows.Forms.CheckBox chkManualRoboCopyOpenReportFolder;
        private System.Windows.Forms.GroupBox grpManualRoboCopyCommand;
        private System.Windows.Forms.TextBox txtManualRoboCopyCommand;
        private System.Windows.Forms.GroupBox grpManualRoboCopyLog;
        private System.Windows.Forms.ListBox lstManualRoboCopyLog;
        private System.Windows.Forms.GroupBox grpConfPathTarget;
        private System.Windows.Forms.TextBox txtTargetPath;
        private System.Windows.Forms.Label lblTargetPath;
        private System.Windows.Forms.TextBox txtAudiologPath;
        private System.Windows.Forms.Label lblAudiologPath;
        private System.Windows.Forms.Label lblSourceYearDB;
        private System.Windows.Forms.TextBox txtSourceYearDB;
        private System.Windows.Forms.Label lblSite;
        private System.Windows.Forms.ComboBox cboSite;
        private System.Windows.Forms.GroupBox grpConfPathMapping;
        private System.Windows.Forms.DataGridView dgvPathMappings;
        private System.Windows.Forms.Button btnPathMappingAdd;
        private System.Windows.Forms.Button btnPathMappingDelete;
        private System.Windows.Forms.Button btnPathMappingMoveUp;
        private System.Windows.Forms.Button btnPathMappingMoveDown;
        private System.Windows.Forms.TextBox txtI360HttpFullPathField;
        private System.Windows.Forms.Label lblI360HttpFullPathField;
        private System.Windows.Forms.TextBox txtAudiologPathAddField;
        private System.Windows.Forms.Label lblAudiologPathAddField;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.Label lblBackupPath;
        private System.Windows.Forms.CheckBox checkTrustServer;
        private System.Windows.Forms.TableLayoutPanel tlpPathMappings;
        private System.Windows.Forms.FlowLayoutPanel flpPathMappingButtons;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colPathMappingEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathMappingVirtualPath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathMappingRealSourcePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPathMappingMemo;
    }
}

