using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.Net;
using System.Xml;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using Common;
using System.Globalization;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace KMSMigration
{
    public partial class frmMain : Form
    {
        #region [ 전역 변수 선언 ]
        // 폼 닫기 버튼 비활성화
        private const int MF_BYPOSITION = 0x400;
        [DllImport("user32.dll")]
        private static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        private static extern int GetMenuItemCount(IntPtr hWnd);
        
        IniManager _Ini = new IniManager();
        LogManager _Log = new LogManager();
        LogManager _LogErr = new LogManager();
        SqlAccount _SqlAccount = new SqlAccount();
        KMSManager _KMS = null;

        int _Wait = 0;
        bool _Work = false;

        // General
        string _Title;
        string _LogDate;
        int _LogLevel;
        int _LogRetentionPeriod;
        string _EnableDefaultConnectionLimit = "1";

        // Work
        string _Site;
        int _Interval;
        DateTime _StartTime;
        DateTime _EndTime;
        DateTime _WeekdayStartTime;
        DateTime _WeekdayEndTime;
        DateTime _WeekendStartTime;
        DateTime _WeekendEndTime;
        string _RunAutoStart;
        string _LastTime;
        string _FileDelete = "0";

        // Work - Retry
        bool _RetryWork = false;
        int _CurrentCycle = 0;
        int _RetryCycle;
        string _RetrySelectCondition;

        // DB - Source
        string _SourceDBIP;
        string _SourceDBNM;
        string _SourceDBID;
        string _SourceDBPW;
        string _SourceTableNM;
        string _SourceMarkTableNM;
        string _SourceYearDB;
        string _SourceMarkField;
        string _SourceSelectCondition;
        string _TopCount;

        string _FromDate;
        string _ToDate;
        string _JobCurrenWorkingtDate;

        string _CheckTrustDBServer;

        // DB - Target
        string _TargetDBIP;
        string _TargetDBNM;
        string _TargetDBID;
        string _TargetDBPW;
        string _TargetTableNM;
        string _TargetYearDB;
        string _TargetBuffer03;

        // Path
        string _I360HttpFullPathField;
        string _I360IISPath;
        string _I360NetBiosPath;
        string _AudiologPath;
        string _AudiologPathAddField;
        string _TargetPath;
        string _BackupPath;

        // KMS
        string _KMSServerIP;
        string _KMSDomain;
        string _KMSServerID;
        string _KMSServerPW;
        string _KMSAuthIP;
        string _KMSAuthPort;
        string _KMSKeyValue;
        int _KMSFileSize = 1024;

        string _CheckTelNoEncrypt;

        const int WorkerPanelMinimumWidth = 660;
        const int WorkerPanelTwoColumnWidth = 1360;
        const int WorkerLogMaxItems = 1000;
        const int WorkerLogFlushMaxItems = 100;
        const int DefaultWorkerStatsSaveIntervalSec = 5;
        const int DefaultWorkerLogFlushIntervalMs = 500;

        List<WorkerRowControls> _WorkerRows = new List<WorkerRowControls>();
        FlowLayoutPanel _WorkerFlowPanel;
        int _NextWorkerId = 1;
        int _WorkerStatsSaveIntervalSec = DefaultWorkerStatsSaveIntervalSec;
        int _WorkerLogFlushIntervalMs = DefaultWorkerLogFlushIntervalMs;
        readonly object _WorkerEventLock = new object();
        System.Windows.Forms.Timer _WorkerUiFlushTimer;

        #endregion [ 전역 변수 선언 ]

        #region [ ini - Read, Show, Write ]


        

        private void ReadINI()
        {
            try
            {
                // General
                _Title = _Ini.GetIniValue("General", "Title", _Ini.IniFilePath);
                _LogDate = _Ini.GetIniValue("General", "LogDate", _Ini.IniFilePath);
                _LogLevel = Convert.ToInt32(_Ini.GetIniValue("General", "LogLevel", _Ini.IniFilePath));
                _LogRetentionPeriod = Convert.ToInt32(_Ini.GetIniValue("General", "LogRetentionPeriod", _Ini.IniFilePath));
                _EnableDefaultConnectionLimit = _Ini.GetIniValue("General", "EnableDefaultConnectionLimit", _Ini.IniFilePath);
                if (_EnableDefaultConnectionLimit == "")
                    _EnableDefaultConnectionLimit = "1";
                _WorkerStatsSaveIntervalSec = ReadGeneralInt("WorkerStatsSaveIntervalSec", DefaultWorkerStatsSaveIntervalSec);
                _WorkerLogFlushIntervalMs = Math.Max(100, ReadGeneralInt("WorkerLogFlushIntervalMs", DefaultWorkerLogFlushIntervalMs));
                _Log.LogFileRetentionPeriod = _LogRetentionPeriod;
                // WorkInfo
                _Site = _Ini.GetIniValue("WorkInfo", "Site", _Ini.IniFilePath);
                _Interval = Convert.ToInt32(_Ini.GetIniValue("WorkInfo", "Interval", _Ini.IniFilePath));
                _StartTime = Convert.ToDateTime(_Ini.GetIniValue("WorkInfo", "StartTime", _Ini.IniFilePath));
                _EndTime = Convert.ToDateTime(_Ini.GetIniValue("WorkInfo", "EndTime", _Ini.IniFilePath));
                _WeekdayStartTime = ReadWorkTime("WeekdayStartTime", _StartTime);
                _WeekdayEndTime = ReadWorkTime("WeekdayEndTime", _EndTime);
                _WeekendStartTime = ReadWorkTime("WeekendStartTime", _StartTime);
                _WeekendEndTime = ReadWorkTime("WeekendEndTime", _EndTime);
                _LastTime = _Ini.GetIniValue("WorkInfo", "LastTime", _Ini.IniFilePath);
                _RunAutoStart = _Ini.GetIniValue("WorkInfo", "RunAutoStart", _Ini.IniFilePath);                
                _FileDelete = _Ini.GetIniValue("WorkInfo", "FileDelete", _Ini.IniFilePath);
                // DBInfo - Source
                _SourceDBIP = _Ini.GetIniValue("DBInfoSource", "DBIP", _Ini.IniFilePath);
                _SourceDBNM = _Ini.GetIniValue("DBInfoSource", "DBNM", _Ini.IniFilePath);
                _SourceDBID = _Ini.GetIniValue("DBInfoSource", "DBID", _Ini.IniFilePath);
                _SourceDBPW = _Ini.GetIniValue("DBInfoSource", "DBPW", _Ini.IniFilePath);
                _SourceDBPW = _SqlAccount.DecodeSqlAccount(_SourceDBPW);
                _SourceTableNM = _Ini.GetIniValue("DBInfoSource", "TableNM", _Ini.IniFilePath);
                _SourceMarkTableNM = _Ini.GetIniValue("DBInfoSource", "MarkTableNM", _Ini.IniFilePath);
                if (_SourceMarkTableNM == "")
                    _SourceMarkTableNM = _SourceTableNM;
                _SourceYearDB = _Ini.GetIniValue("DBInfoSource", "YearDB", _Ini.IniFilePath);
                _SourceMarkField = _Ini.GetIniValue("DBInfoSource", "MarkField", _Ini.IniFilePath);
                _SourceSelectCondition = _Ini.GetIniValue("DBInfoSource", "SelectCondition", _Ini.IniFilePath);
                _TopCount = _Ini.GetIniValue("DBInfoSource", "TopCount", _Ini.IniFilePath);
                if (_TopCount == "")
                    _TopCount = "5000";
                _RetryCycle = Convert.ToInt32(_Ini.GetIniValue("DBInfoSource", "RetryCycle", _Ini.IniFilePath));
                _RetrySelectCondition = _Ini.GetIniValue("DBInfoSource", "RetrySelectCondition", _Ini.IniFilePath);

                _FromDate = _Ini.GetIniValue("DBInfoSource", "FromDate",_Ini.IniFilePath);
                _ToDate = _Ini.GetIniValue("DBInfoSource", "ToDate", _Ini.IniFilePath);


                _JobCurrenWorkingtDate = _Ini.GetIniValue("DBInfoSource", "The current working date", _Ini.IniFilePath);

                _CheckTrustDBServer = _Ini.GetIniValue("DBInfoSource", "Enable Trust DB Server", _Ini.IniFilePath);

                if (_CheckTrustDBServer == "1")
                    checkTrustServer.Checked = true;
                else
                    checkTrustServer.Checked = false;

                // DBInfo - Target
                _TargetDBIP = _Ini.GetIniValue("DBInfoTarget", "DBIP", _Ini.IniFilePath);
                _TargetDBNM = _Ini.GetIniValue("DBInfoTarget", "DBNM", _Ini.IniFilePath);
                _TargetDBID = _Ini.GetIniValue("DBInfoTarget", "DBID", _Ini.IniFilePath);
                _TargetDBPW = _Ini.GetIniValue("DBInfoTarget", "DBPW", _Ini.IniFilePath);
                _TargetDBPW = _SqlAccount.DecodeSqlAccount(_TargetDBPW);
                _TargetTableNM = _Ini.GetIniValue("DBInfoTarget", "TableNM", _Ini.IniFilePath);
                _TargetYearDB = _Ini.GetIniValue("DBInfoTarget", "YearDB", _Ini.IniFilePath);
                _TargetBuffer03 = _Ini.GetIniValue("DBInfoTarget", "Buffer03", _Ini.IniFilePath);
                // PathInfo
                _I360HttpFullPathField = _Ini.GetIniValue("PathInfo", "I360HttpFullPathField", _Ini.IniFilePath);
                _I360IISPath = _Ini.GetIniValue("PathInfo", "I360IISPath", _Ini.IniFilePath);
                _I360NetBiosPath = _Ini.GetIniValue("PathInfo", "I360NetBiosPath", _Ini.IniFilePath);
                _AudiologPath = _Ini.GetIniValue("PathInfo", "AudiologPath", _Ini.IniFilePath);
                _AudiologPathAddField = _Ini.GetIniValue("PathInfo", "AudiologPathAddField", _Ini.IniFilePath);
                _TargetPath = _Ini.GetIniValue("PathInfo", "TargetPath", _Ini.IniFilePath);
                _BackupPath = _Ini.GetIniValue("PathInfo", "BackupPath", _Ini.IniFilePath);
                // KMSInfo
                _KMSServerIP = _Ini.GetIniValue("KMSInfo", "KMSServerIP", _Ini.IniFilePath);
                _KMSDomain = _Ini.GetIniValue("KMSInfo", "KMSDomain", _Ini.IniFilePath);
                _KMSServerID = _Ini.GetIniValue("KMSInfo", "KMSServerID", _Ini.IniFilePath);
                //_KMSServerPW = _Ini.GetIniValue("KMSInfo", "KMSServerPW", _Ini.IniFilePath);
                _KMSServerPW = _Ini.GetIniValue("KMSInfo", "KMSServerPW", _Ini.IniFilePath);
                _KMSServerPW = _SqlAccount.DecodeSqlAccount(_KMSServerPW);

                _KMSAuthIP = _Ini.GetIniValue("KMSInfo", "KMSAuthIP", _Ini.IniFilePath);
                _KMSAuthPort = _Ini.GetIniValue("KMSInfo", "KMSAuthPort", _Ini.IniFilePath);
                _KMSKeyValue = _Ini.GetIniValue("KMSInfo", "KMSKeyValue", _Ini.IniFilePath);
                string nKMSFileSize = _Ini.GetIniValue("KMSInfo", "KMSFileSize", _Ini.IniFilePath);
                if (nKMSFileSize != "")
                    _KMSFileSize = Convert.ToInt32(nKMSFileSize);


                _CheckTelNoEncrypt = _Ini.GetIniValue("KMSInfo", "Enable TelNo data encryptoin.", _Ini.IniFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[Error__] [Message] " + MethodBase.GetCurrentMethod().Name);
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private DateTime ReadWorkTime(string key, DateTime defaultValue)
        {
            DateTime value;
            string text = _Ini.GetIniValue("WorkInfo", key, _Ini.IniFilePath);

            if (!String.IsNullOrWhiteSpace(text) && DateTime.TryParse(text, out value))
                return value;

            return defaultValue;
        }

        private int ReadGeneralInt(string key, int defaultValue)
        {
            int value;
            string text = _Ini.GetIniValue("General", key, _Ini.IniFilePath);

            if (Int32.TryParse(text, out value) && value > 0)
                return value;

            _Ini.SetIniValue("General", key, defaultValue.ToString(), _Ini.IniFilePath);
            return defaultValue;
        }

        private void ShowINI()
        {
            try
            {
                // WorkInfo
                cboSite.Text = _Site;
                txtInterval.Text = _Interval.ToString();
                dtpStartTime.Value = _WeekdayStartTime;
                dtpEndTime.Value = _WeekdayEndTime;
                dtpWeekendStartTime.Value = _WeekendStartTime;
                dtpWeekendEndTime.Value = _WeekendEndTime;
                if (_RunAutoStart == "1")
                    chkRunAtStart.Checked = true;
                else
                    chkRunAtStart.Checked = false;                

                chkEnableDefaultConnectionLimit.Checked = _EnableDefaultConnectionLimit == "1";

                // DBInfo - Source
                txtSourceDBIP.Text = _SourceDBIP;
                txtSourceDBNM.Text = _SourceDBNM;
                txtSourceDBID.Text = _SourceDBID;
                txtSourceDBPW.Text = _SourceDBPW;
                txtSourceTableNM.Text = _SourceTableNM;
                txtSourceYearDB.Text = _SourceYearDB;
                txtSourceMarkField.Text = _SourceMarkField;
                txtSourceSelectCondition.Text = _SourceSelectCondition;



                if (_CheckTrustDBServer == "1")
                    checkTrustServer.Checked = true;
                else
                    checkTrustServer.Checked = false;

                // PathInfo
                txtI360HttpFullPathField.Text = _I360HttpFullPathField;
                txtI360IISPath.Text = _I360IISPath;
                txtI360NetBiosPath.Text = _I360NetBiosPath;
                txtAudiologPath.Text = _AudiologPath;
                txtAudiologPathAddField.Text = _AudiologPathAddField;
                txtTargetPath.Text = _TargetPath;
                txtBackupPath.Text = _BackupPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[Error__] [Message] " + MethodBase.GetCurrentMethod().Name);
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private void WriteINI()
        {
            try
            {
                // WorkInfo
                _Ini.SetIniValue("WorkInfo", "Site", cboSite.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "Interval", txtInterval.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "StartTime", dtpStartTime.Value.TimeOfDay.ToString(), _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "EndTime", dtpEndTime.Value.TimeOfDay.ToString(), _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "WeekdayStartTime", dtpStartTime.Value.TimeOfDay.ToString(), _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "WeekdayEndTime", dtpEndTime.Value.TimeOfDay.ToString(), _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "WeekendStartTime", dtpWeekendStartTime.Value.TimeOfDay.ToString(), _Ini.IniFilePath);
                _Ini.SetIniValue("WorkInfo", "WeekendEndTime", dtpWeekendEndTime.Value.TimeOfDay.ToString(), _Ini.IniFilePath);
                if (chkRunAtStart.Checked)
                    _RunAutoStart = "1";
                else
                    _RunAutoStart = "0";

                if (chkEnableDefaultConnectionLimit.Checked)
                    _EnableDefaultConnectionLimit = "1";
                else
                    _EnableDefaultConnectionLimit = "0";

                _Ini.SetIniValue("General", "EnableDefaultConnectionLimit", _EnableDefaultConnectionLimit, _Ini.IniFilePath);
                _Ini.SetIniValue("General", "WorkerStatsSaveIntervalSec", _WorkerStatsSaveIntervalSec.ToString(), _Ini.IniFilePath);
                _Ini.SetIniValue("General", "WorkerLogFlushIntervalMs", _WorkerLogFlushIntervalMs.ToString(), _Ini.IniFilePath);

                if (checkTrustServer.Checked)
                    _Ini.SetIniValue("DBInfoSource", "Enable Trust DB Server", "1", _Ini.IniFilePath);
                else
                    _Ini.SetIniValue("DBInfoSource", "Enable Trust DB Server", "0", _Ini.IniFilePath);

                _Ini.SetIniValue("WorkInfo", "RunAutoStart", _RunAutoStart, _Ini.IniFilePath);
                // DBInfo - Source
                _Ini.SetIniValue("DBInfoSource", "DBIP", txtSourceDBIP.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "DBNM", txtSourceDBNM.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "DBID", txtSourceDBID.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "DBPW", _SqlAccount.EncodeSqlAccount(txtSourceDBPW.Text), _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "TableNM", txtSourceTableNM.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "YearDB", txtSourceYearDB.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "MarkField", txtSourceMarkField.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("DBInfoSource", "SelectCondition", txtSourceSelectCondition.Text, _Ini.IniFilePath);


                // PathInfo
                _Ini.SetIniValue("PathInfo", "I360HttpFullPathField", txtI360HttpFullPathField.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("PathInfo", "I360IISPath", txtI360IISPath.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("PathInfo", "I360NetBiosPath", txtI360NetBiosPath.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("PathInfo", "AudiologPath", txtAudiologPath.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("PathInfo", "AudiologPathAddField", txtAudiologPathAddField.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("PathInfo", "TargetPath", txtTargetPath.Text, _Ini.IniFilePath);
                _Ini.SetIniValue("PathInfo", "BackupPath", txtBackupPath.Text, _Ini.IniFilePath);
                WriteWorkerRowsToIni();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "[Error__] [Message] " + MethodBase.GetCurrentMethod().Name);
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        #endregion [ ini ]

        #region [ Log - lstLogText ]

        private void lstLogText(string text, bool err = false, bool writeFile = true)
        {
            try
            {
                if (writeFile)
                {
                    _Log.LogMessage(text);
                    if (err)
                        _LogErr.LogMessage(text);
                }
                if (lstLog.Items.Count < 100)
                {
                    lstLog.Items.Add(System.DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] : ") + text);
                    lstLog.SelectedIndex = lstLog.Items.Count - 1;
                }
                else
                {
                    lstLog.Items.RemoveAt(0);
                    lstLog.Items.Add(System.DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] : ") + text);
                    lstLog.SelectedIndex = lstLog.Items.Count - 1;
                }
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        #endregion [ Log ]

        #region [ Form & Control - frmMain, frmMain_Load, cboSFFolderType_TextChanged, cboSite_TextChanged, ToolStripControl, ControlEnable ]

        public frmMain()
        {
            InitializeComponent();



        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 닫기 버튼 비 활성화---------------------------------
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int menuItemCount = GetMenuItemCount(hMenu);
            RemoveMenu(hMenu, menuItemCount - 1, MF_BYPOSITION);
            // ----------------------------------------------------

            // 폼 기본 속성값
            this.StartPosition = FormStartPosition.CenterScreen;                        // 시작 위치
            this.Text = this.Text + " [ Ver. " + Application.ProductVersion + " ]";     // 타이틀바에 버전 표시

            // Tooltip Strip 초기화
            ToolStripControl("INIT");
            ApplyResizableLayout();

            // 컨트롤 Disable
            ControlEnable(false);

            _Ini.CreateIniFile();
            _Log.CreateLogFile();
            _LogErr.LogFileName = Process.GetCurrentProcess().ProcessName + "Err";
            _LogErr.CreateLogFile();

            // 설정값 읽기/컨트롤 표시
            ReadINI();
            ShowINI();
            ConfigureWorkerUiFlushTimer();

            if (_Title != "")
                this.Text = this.Text + " - " + _Title;

            // Load 끝
            lstLog.Items.Clear();
            lstWorkerLog.Items.Clear();

            CreateDirectory(Directory.GetCurrentDirectory() + @"\temp");
            CreateWorkerManagerUi();

            // 자동 실행 옵션 체크
            if (chkRunAtStart.Checked)
            {
                if (HasCheckedWorkers())
                {
                    lstLogText("[Start__] [Program] Auto Start Option Enabled. Worker scheduler starting");
                    tsbStart.PerformClick();
                }
                else
                {
                    lstLogText("[Info___] [Program] Auto Start skipped. No checked worker");
                }
            }
            else
            {
                lstLogText("[Start__] [Program]");
            }
        }

        private void cboSite_TextChanged(object sender, EventArgs e)
        {
            switch (cboSite.Text)
            {
                case "SearchFiles":
                    lblSourceYearDB.Visible = false;
                    lblSourceSelectCondition.Visible = false;
                    lblSourceMarkField.Visible = false;
                    txtSourceYearDB.Visible = false;
                    txtSourceSelectCondition.Visible = false;
                    txtSourceMarkField.Visible = false;
                    grpConfPathI360.Visible = false;
                    grpConfPathAudiolog.Visible = false;
                    grpConfPathTarget.Visible = false;
                    break;
                default:
                    lblSourceYearDB.Visible = true;
                    lblSourceSelectCondition.Visible = true;
                    lblSourceMarkField.Visible = true;
                    txtSourceYearDB.Visible = true;
                    txtSourceSelectCondition.Visible = true;
                    txtSourceMarkField.Visible = true;
                    grpConfPathI360.Visible = true;
                    grpConfPathAudiolog.Visible = true;
                    grpConfPathTarget.Visible = true;
                    break;
            }
        }

        private void ToolStripControl(string flag)
        {
            switch (flag)
            {
                case "INIT":
                    tsbStart.Enabled = true;
                    tsbStop.Enabled = false;
                    tsbConfig.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbExit.Enabled = true;
                    lblStatus.Text = "Program Initialized...";
                    break;
                case "START":
                    tsbStart.Enabled = false;
                    tsbStop.Enabled = true;
                    tsbConfig.Enabled = false;
                    tsbSave.Enabled = false;
                    tsbExit.Enabled = false;
                    lblStatus.Text = "Worker scheduler started...";
                    break;
                case "STOP":
                    tsbStart.Enabled = true;
                    tsbStop.Enabled = false;
                    tsbConfig.Enabled = true;
                    tsbSave.Enabled = false;
                    tsbExit.Enabled = true;
                    lblStatus.Text = "All Workers Stopped...";
                    break;
                case "CONFIG":
                    tsbStart.Enabled = false;
                    tsbStop.Enabled = false;
                    tsbConfig.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbExit.Enabled = true;
                    lblStatus.Text = "Setting Config...";
                    break;
                case "SAVE":
                    tsbStart.Enabled = true;
                    tsbStop.Enabled = false;
                    tsbConfig.Enabled = true;
                    tsbSave.Enabled = true;
                    tsbExit.Enabled = true;
                    lblStatus.Text = "Save Done...";
                    break;
            }
        }

        private void ControlEnable(bool enable)
        {
            grpWork.Enabled = enable;
            grpConfDBSource.Enabled = enable;
            grpConfPathI360.Enabled = enable;
            grpConfPathAudiolog.Enabled = enable;
            grpConfPathTarget.Enabled = enable;
        }

        private void ApplyResizableLayout()
        {
            tableLayoutPanel.RowStyles[0].SizeType = SizeType.Percent;
            tableLayoutPanel.RowStyles[0].Height = 100;
            tableLayoutPanel.RowStyles[1].SizeType = SizeType.Absolute;
            tableLayoutPanel.RowStyles[1].Height = 18;

            tpConfigDB.AutoScroll = true;
            tmrBatch.Interval = 1000;

            tpConfigDB.Resize += delegate { ResizeConfigControls(); };

            ResizeConfigControls();
        }

        private void ResizeConfigControls()
        {
            if (tpConfigDB.ClientSize.Width <= 0)
                return;

            int width = Math.Max(559, tpConfigDB.ClientSize.Width - 24);
            grpWork.Width = width;
            grpConfDBSource.Width = width;
            grpConfPathI360.Width = width;
            grpConfPathAudiolog.Width = width;
            grpConfPathTarget.Width = width;

            grpConfDBSource.Top = grpWork.Bottom + 8;
            grpConfPathI360.Top = grpConfDBSource.Bottom + 8;
            grpConfPathAudiolog.Top = grpConfPathI360.Bottom + 8;
            grpConfPathTarget.Top = grpConfPathAudiolog.Bottom + 8;

            int rightLabelLeft = Math.Max(368, grpConfDBSource.Width - 238);
            int rightTextLeft = Math.Max(454, grpConfDBSource.Width - 152);

            lblSourceTableNM.Left = rightLabelLeft;
            txtSourceTableNM.Left = rightTextLeft;
            lblSourceYearDB.Left = rightLabelLeft;
            txtSourceYearDB.Left = rightTextLeft;
            lblSourceMarkField.Left = rightLabelLeft;
            txtSourceMarkField.Left = rightTextLeft;

            txtSourceSelectCondition.Width = Math.Max(120, rightLabelLeft - txtSourceSelectCondition.Left - 18);
            checkTrustServer.Left = Math.Min(rightLabelLeft + 2, grpConfDBSource.Width - checkTrustServer.Width - 12);

            txtI360HttpFullPathField.Width = Math.Max(124, grpConfPathI360.Width - txtI360HttpFullPathField.Left - 16);
            txtI360NetBiosPath.Width = Math.Max(124, grpConfPathI360.Width - txtI360NetBiosPath.Left - 16);
            txtAudiologPath.Width = Math.Max(180, grpConfPathAudiolog.Width / 2 - txtAudiologPath.Left - 16);
            lblAudiologPathAddField.Left = Math.Max(321, grpConfPathAudiolog.Width / 2 + 16);
            txtAudiologPathAddField.Left = lblAudiologPathAddField.Left + 96;
            txtAudiologPathAddField.Width = Math.Max(124, grpConfPathAudiolog.Width - txtAudiologPathAddField.Left - 16);
            txtTargetPath.Width = Math.Max(180, grpConfPathTarget.Width / 2 - txtTargetPath.Left - 16);
            lblBackupPath.Left = Math.Max(287, grpConfPathTarget.Width / 2 + 16);
            txtBackupPath.Left = lblBackupPath.Left + 78;
            txtBackupPath.Width = Math.Max(124, grpConfPathTarget.Width - txtBackupPath.Left - 16);
        }

        #region [ Worker UI ]

        private class WorkerRowControls
        {
            public int WorkerId;
            public Panel Panel;
            public CheckBox SelectCheckBox;
            public TextBox ConditionTextBox;
            public TextBox TopCountTextBox;
            public TextBox IntervalTextBox;
            public TextBox FromDateTextBox;
            public TextBox ToDateTextBox;
            public TextBox MarkFieldTextBox;
            public TextBox MarkValueTextBox;
            public Button StartButton;
            public Button StopButton;
            public Button ResetButton;
            public Label CurrentDateLabel;
            public Label StatusLabel;
            public Label CountLabel;
            public ProgressBar ProgressBar;
            public RadioButton LogRadioButton;
            public List<string> WorkerLogItems = new List<string>();
            public List<string> PendingWorkerLogItems = new List<string>();
            public MigrationWorkerProgressEventArgs PendingProgress;
            public bool HasPendingProgress;
            public long ProcessedTotal;
            public long SuccessTotal;
            public long FailureTotal;
            public long RunStartProcessedTotal;
            public long RunStartSuccessTotal;
            public long RunStartFailureTotal;
            public DateTime LastStatsSavedAt = DateTime.MinValue;
            public bool StatsSavePending;
            public CancellationTokenSource CancelSource;
            public Task<MigrationWorkerSummary> WorkerTask;
        }

        private void ConfigureWorkerUiFlushTimer()
        {
            if (_WorkerUiFlushTimer == null)
            {
                _WorkerUiFlushTimer = new System.Windows.Forms.Timer();
                _WorkerUiFlushTimer.Tick += WorkerUiFlushTimer_Tick;
            }

            _WorkerUiFlushTimer.Interval = Math.Max(100, _WorkerLogFlushIntervalMs);
            _WorkerUiFlushTimer.Enabled = true;
        }

        private void WorkerUiFlushTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                FlushWorkerUiUpdates(false);
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private void FlushWorkerUiUpdates(bool forceStatsSave)
        {
            foreach (WorkerRowControls row in _WorkerRows.ToArray())
            {
                FlushWorkerUiUpdates(row, forceStatsSave);
            }
        }

        private void FlushWorkerUiUpdates(WorkerRowControls row, bool forceStatsSave)
        {
            MigrationWorkerProgressEventArgs progress = null;
            List<string> pendingLogs = null;

            lock (_WorkerEventLock)
            {
                if (row.HasPendingProgress)
                {
                    progress = row.PendingProgress;
                    row.PendingProgress = null;
                    row.HasPendingProgress = false;
                }

                if (row.PendingWorkerLogItems.Count > 0)
                {
                    pendingLogs = new List<string>(row.PendingWorkerLogItems);
                    row.PendingWorkerLogItems.Clear();
                }
            }

            AppendWorkerLogItems(row, pendingLogs);

            if (progress != null)
                ApplyWorkerProgress(row, progress);

            SaveWorkerStatsIfDue(row, forceStatsSave);
        }

        private void ApplyWorkerProgress(WorkerRowControls row, MigrationWorkerProgressEventArgs e)
        {
            UpdateWorkerCurrentDate(row, e.CurrentDate);
            row.StatusLabel.Text = BuildWorkerStatusText(e.BatchCount, e.StatusText);

            long previousProcessedTotal = row.ProcessedTotal;
            long previousSuccessTotal = row.SuccessTotal;
            long previousFailureTotal = row.FailureTotal;

            row.ProcessedTotal = row.RunStartProcessedTotal + e.ProcessedCount;
            row.SuccessTotal = row.RunStartSuccessTotal + e.SuccessCount;
            row.FailureTotal = row.RunStartFailureTotal + e.FailureCount;
            UpdateWorkerCountLabel(row);

            if (previousProcessedTotal != row.ProcessedTotal ||
                previousSuccessTotal != row.SuccessTotal ||
                previousFailureTotal != row.FailureTotal)
            {
                row.StatsSavePending = true;
            }
        }

        private void SaveWorkerStatsIfDue(WorkerRowControls row, bool force)
        {
            if (!row.StatsSavePending && !force)
                return;

            DateTime now = DateTime.Now;
            if (!force &&
                row.LastStatsSavedAt != DateTime.MinValue &&
                (now - row.LastStatsSavedAt).TotalSeconds < _WorkerStatsSaveIntervalSec)
            {
                return;
            }

            SaveWorkerRowToIni(row);
            row.LastStatsSavedAt = now;
            row.StatsSavePending = false;
        }

        private void CreateWorkerManagerUi()
        {
            if (_WorkerFlowPanel != null)
                return;

            _WorkerFlowPanel = flpWorkerRows;
            btnWorkerSelectAll.Click += delegate { SelectAllWorkers(); };
            btnWorkerAdd.Click += delegate { AddWorkerFromButton(); };
            btnWorkerDelete.Click += delegate { DeleteSelectedWorkers(); };
            btnWorkerResetTotals.Click += delegate { ResetWorkerTotals(); };
            flpWorkerRows.SizeChanged += delegate { ArrangeWorkerRows(); };

            bool loadedFromIni = true;
            int workerCount = LoadWorkerRowsFromIni();
            if (workerCount == 0)
            {
                loadedFromIni = false;
                workerCount = Environment.ProcessorCount;
                if (workerCount < 1)
                    workerCount = 1;

                for (int workerId = 1; workerId <= workerCount; workerId++)
                {
                    AddWorkerRow(workerId);
                }

                _NextWorkerId = workerCount + 1;
            }

            ArrangeWorkerRows();
            WriteWorkerRowsToIni();

            if (loadedFromIni)
                lstLogText("[Info___] [Worker] INI 기준 작업자 UI 생성 - " + workerCount + "개");
            else
                lstLogText("[Info___] [Worker] CPU 논리 프로세서 기준 작업자 UI 생성 - " + workerCount + "개");
        }

        private void AddWorkerFromButton()
        {
            AddWorkerRow(_NextWorkerId);
            _NextWorkerId++;
            ArrangeWorkerRows();
            WriteWorkerRowsToIni();
        }

        private void SelectAllWorkers()
        {
            foreach (WorkerRowControls row in _WorkerRows)
            {
                if (!IsWorkerRunning(row))
                    row.SelectCheckBox.Checked = true;
            }

            lstLogText("[Info___] [Worker] 전체 Worker 선택");
        }

        private void AddWorkerRow(int workerId)
        {
            WorkerRowControls row = CreateWorkerRow(workerId);
            _WorkerRows.Add(row);
            _WorkerFlowPanel.Controls.Add(row.Panel);
            AddWorkerLogSelector(row);
            UpdateWorkerCountLabel(row);
        }

        private WorkerRowControls CreateWorkerRow(int workerId)
        {
            WorkerRowControls row = new WorkerRowControls();
            row.WorkerId = workerId;

            row.Panel = new Panel();
            row.Panel.Width = WorkerPanelMinimumWidth;
            row.Panel.Height = 148;
            row.Panel.BorderStyle = BorderStyle.FixedSingle;
            row.Panel.Margin = new Padding(0, 0, 0, 8);

            row.SelectCheckBox = new CheckBox();
            row.SelectCheckBox.Left = 10;
            row.SelectCheckBox.Top = 10;
            row.SelectCheckBox.Width = 45;
            row.SelectCheckBox.Text = "W" + workerId;
            row.SelectCheckBox.Checked = false;
            row.Panel.Controls.Add(row.SelectCheckBox);

            AddWorkerLabel(row.Panel, "Top", 58, 13, 25);
            row.TopCountTextBox = new TextBox();
            row.TopCountTextBox.Left = 85;
            row.TopCountTextBox.Top = 8;
            row.TopCountTextBox.Width = 42;
            row.TopCountTextBox.Text = String.IsNullOrWhiteSpace(_TopCount) ? "5000" : _TopCount;
            row.Panel.Controls.Add(row.TopCountTextBox);

            AddWorkerLabel(row.Panel, "Interval", 132, 13, 48);
            row.IntervalTextBox = new TextBox();
            row.IntervalTextBox.Left = 181;
            row.IntervalTextBox.Top = 8;
            row.IntervalTextBox.Width = 36;
            row.IntervalTextBox.Text = _Interval <= 0 ? "0" : _Interval.ToString();
            row.Panel.Controls.Add(row.IntervalTextBox);

            AddWorkerLabel(row.Panel, "From", 222, 13, 34);
            row.FromDateTextBox = new TextBox();
            row.FromDateTextBox.Left = 260;
            row.FromDateTextBox.Top = 8;
            row.FromDateTextBox.Width = 80;
            row.FromDateTextBox.Text = _FromDate;
            row.Panel.Controls.Add(row.FromDateTextBox);

            AddWorkerLabel(row.Panel, "To", 346, 13, 24);
            row.ToDateTextBox = new TextBox();
            row.ToDateTextBox.Left = 374;
            row.ToDateTextBox.Top = 8;
            row.ToDateTextBox.Width = 80;
            row.ToDateTextBox.Text = _ToDate;
            row.Panel.Controls.Add(row.ToDateTextBox);

            AddWorkerLabel(row.Panel, "마킹", 10, 40, 36);
            row.MarkFieldTextBox = new TextBox();
            row.MarkFieldTextBox.Left = 50;
            row.MarkFieldTextBox.Top = 36;
            row.MarkFieldTextBox.Width = 100;
            row.MarkFieldTextBox.Text = _SourceMarkField;
            row.Panel.Controls.Add(row.MarkFieldTextBox);

            AddWorkerLabel(row.Panel, "값", 160, 40, 16);
            row.MarkValueTextBox = new TextBox();
            row.MarkValueTextBox.Left = 180;
            row.MarkValueTextBox.Top = 36;
            row.MarkValueTextBox.Width = 32;
            row.MarkValueTextBox.Text = "1";
            row.Panel.Controls.Add(row.MarkValueTextBox);

            row.StartButton = new Button();
            row.StartButton.Left = 510;
            row.StartButton.Top = 6;
            row.StartButton.Width = 42;
            row.StartButton.Height = 24;
            row.StartButton.Text = "시작";
            row.StartButton.Click += delegate { StartWorker(row); };
            row.Panel.Controls.Add(row.StartButton);

            row.StopButton = new Button();
            row.StopButton.Left = 556;
            row.StopButton.Top = 6;
            row.StopButton.Width = 42;
            row.StopButton.Height = 24;
            row.StopButton.Text = "중지";
            row.StopButton.Enabled = false;
            row.StopButton.Click += delegate { StopWorker(row); };
            row.Panel.Controls.Add(row.StopButton);

            row.ResetButton = new Button();
            row.ResetButton.Left = 590;
            row.ResetButton.Top = 116;
            row.ResetButton.Width = 58;
            row.ResetButton.Height = 24;
            row.ResetButton.Text = "초기화";
            row.ResetButton.Click += delegate { ResetWorkerTotal(row); };
            row.Panel.Controls.Add(row.ResetButton);

            AddWorkerLabel(row.Panel, "Where", 222, 40, 44);
            row.ConditionTextBox = new TextBox();
            row.ConditionTextBox.Left = 270;
            row.ConditionTextBox.Top = 36;
            row.ConditionTextBox.Width = 380;
            row.ConditionTextBox.Text = _SourceSelectCondition;
            row.Panel.Controls.Add(row.ConditionTextBox);

            row.CurrentDateLabel = new Label();
            row.CurrentDateLabel.AutoSize = false;
            row.CurrentDateLabel.Left = 10;
            row.CurrentDateLabel.Top = 66;
            row.CurrentDateLabel.Width = 170;
            row.CurrentDateLabel.Height = 18;
            row.CurrentDateLabel.Text = "처리일자 -";
            row.Panel.Controls.Add(row.CurrentDateLabel);

            row.StatusLabel = new Label();
            row.StatusLabel.AutoSize = false;
            row.StatusLabel.Left = 188;
            row.StatusLabel.Top = 66;
            row.StatusLabel.Width = 462;
            row.StatusLabel.Height = 18;
            row.StatusLabel.AutoEllipsis = true;
            row.StatusLabel.Text = "대기";
            row.Panel.Controls.Add(row.StatusLabel);

            row.CountLabel = new Label();
            row.CountLabel.AutoSize = false;
            row.CountLabel.Left = 10;
            row.CountLabel.Top = 120;
            row.CountLabel.Width = 570;
            row.CountLabel.Height = 18;
            row.CountLabel.Text = "처리 0 / 성공 0 / 예외 0";
            row.Panel.Controls.Add(row.CountLabel);

            row.ProgressBar = new ProgressBar();
            row.ProgressBar.Left = 10;
            row.ProgressBar.Top = 88;
            row.ProgressBar.Width = 640;
            row.ProgressBar.Height = 20;
            row.ProgressBar.Minimum = 0;
            row.ProgressBar.Maximum = 100;
            row.Panel.Controls.Add(row.ProgressBar);

            return row;
        }

        private void AddWorkerLabel(Control parent, string text, int left, int top, int width)
        {
            Label label = new Label();
            label.AutoSize = false;
            label.Left = left;
            label.Top = top;
            label.Width = width;
            label.Height = 20;
            label.Text = text;
            parent.Controls.Add(label);
        }

        private int LoadWorkerRowsFromIni()
        {
            List<int> workerIds = ReadWorkerIdsFromIni();
            if (workerIds.Count == 0)
                return 0;

            int maxWorkerId = 0;

            foreach (int workerId in workerIds)
            {
                AddWorkerRow(workerId);
                WorkerRowControls row = FindWorkerRow(workerId);
                if (row != null)
                    LoadWorkerRowFromIni(row);

                if (workerId > maxWorkerId)
                    maxWorkerId = workerId;
            }

            string nextWorkerIdText = _Ini.GetIniValue("Workers", "NextWorkerId", _Ini.IniFilePath);
            int nextWorkerId;
            if (Int32.TryParse(nextWorkerIdText, out nextWorkerId) && nextWorkerId > maxWorkerId)
                _NextWorkerId = nextWorkerId;
            else
                _NextWorkerId = maxWorkerId + 1;

            return workerIds.Count;
        }

        private List<int> ReadWorkerIdsFromIni()
        {
            List<int> workerIds = new List<int>();
            string workerIdsText = _Ini.GetIniValue("Workers", "WorkerIds", _Ini.IniFilePath);

            if (!String.IsNullOrWhiteSpace(workerIdsText))
            {
                string[] parts = workerIdsText.Split(',');
                foreach (string part in parts)
                {
                    int workerId;
                    if (Int32.TryParse(part.Trim(), out workerId) && workerId > 0 && !workerIds.Contains(workerId))
                        workerIds.Add(workerId);
                }
            }

            if (workerIds.Count > 0)
                return workerIds;

            string workerCountText = _Ini.GetIniValue("Workers", "Count", _Ini.IniFilePath);
            int workerCount;
            if (Int32.TryParse(workerCountText, out workerCount) && workerCount > 0)
            {
                for (int workerId = 1; workerId <= workerCount; workerId++)
                {
                    workerIds.Add(workerId);
                }
            }

            return workerIds;
        }

        private void LoadWorkerRowFromIni(WorkerRowControls row)
        {
            string section = GetWorkerSection(row.WorkerId);
            string value;

            value = _Ini.GetIniValue(section, "TopCount", _Ini.IniFilePath);
            if (!String.IsNullOrWhiteSpace(value))
                row.TopCountTextBox.Text = value;

            value = _Ini.GetIniValue(section, "IntervalSec", _Ini.IniFilePath);
            if (!String.IsNullOrWhiteSpace(value))
                row.IntervalTextBox.Text = value;

            value = _Ini.GetIniValue(section, "FromDate", _Ini.IniFilePath);
            if (!String.IsNullOrWhiteSpace(value))
                row.FromDateTextBox.Text = value;

            value = _Ini.GetIniValue(section, "ToDate", _Ini.IniFilePath);
            if (!String.IsNullOrWhiteSpace(value))
                row.ToDateTextBox.Text = value;

            value = _Ini.GetIniValue(section, "Selected", _Ini.IniFilePath);
            row.SelectCheckBox.Checked = value == "1";

            value = _Ini.GetIniValue(section, "MarkField", _Ini.IniFilePath);
            if (!String.IsNullOrWhiteSpace(value))
                row.MarkFieldTextBox.Text = value;

            value = _Ini.GetIniValue(section, "MarkValue", _Ini.IniFilePath);
            if (!String.IsNullOrWhiteSpace(value))
                row.MarkValueTextBox.Text = value;

            value = _Ini.GetIniValue(section, "SelectCondition", _Ini.IniFilePath);
            row.ConditionTextBox.Text = value;

            row.ProcessedTotal = ReadIniLong(section, "ProcessedCount");
            row.SuccessTotal = ReadIniLong(section, "SuccessCount");
            row.FailureTotal = ReadIniLong(section, "FailureCount");
            UpdateWorkerCountLabel(row);
        }

        private long ReadIniLong(string section, string key)
        {
            long value;
            string text = _Ini.GetIniValue(section, key, _Ini.IniFilePath);

            if (Int64.TryParse(text, out value) && value >= 0)
                return value;

            return 0;
        }

        private string GetWorkerSection(int workerId)
        {
            return "Worker_" + workerId;
        }

        private void WriteWorkerRowsToIni()
        {
            List<int> oldWorkerIds = ReadWorkerIdsFromIni();
            List<string> currentWorkerIds = new List<string>();

            foreach (WorkerRowControls row in _WorkerRows)
            {
                currentWorkerIds.Add(row.WorkerId.ToString());
                SaveWorkerRowToIni(row);
            }

            foreach (int oldWorkerId in oldWorkerIds)
            {
                if (FindWorkerRow(oldWorkerId) == null)
                    _Ini.DeleteSection(GetWorkerSection(oldWorkerId), _Ini.IniFilePath);
            }

            _Ini.SetIniValue("Workers", "Count", _WorkerRows.Count.ToString(), _Ini.IniFilePath);
            _Ini.SetIniValue("Workers", "WorkerIds", String.Join(",", currentWorkerIds.ToArray()), _Ini.IniFilePath);
            _Ini.SetIniValue("Workers", "NextWorkerId", _NextWorkerId.ToString(), _Ini.IniFilePath);
        }

        private void SaveWorkerRowToIni(WorkerRowControls row)
        {
            string section = GetWorkerSection(row.WorkerId);

            _Ini.SetIniValue(section, "TopCount", row.TopCountTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "IntervalSec", row.IntervalTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "FromDate", row.FromDateTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "ToDate", row.ToDateTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "Selected", row.SelectCheckBox.Checked ? "1" : "0", _Ini.IniFilePath);
            _Ini.SetIniValue(section, "MarkField", row.MarkFieldTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "MarkValue", row.MarkValueTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "SelectCondition", row.ConditionTextBox.Text.Trim(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "ProcessedCount", row.ProcessedTotal.ToString(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "SuccessCount", row.SuccessTotal.ToString(), _Ini.IniFilePath);
            _Ini.SetIniValue(section, "FailureCount", row.FailureTotal.ToString(), _Ini.IniFilePath);
        }

        private void AddWorkerLogSelector(WorkerRowControls row)
        {
            RadioButton radioButton = new RadioButton();
            radioButton.AutoSize = true;
            radioButton.Margin = new Padding(6, 6, 4, 0);
            radioButton.Text = "W" + row.WorkerId;
            radioButton.Tag = row;
            radioButton.CheckedChanged += delegate
            {
                if (radioButton.Checked)
                    RefreshWorkerLogList(row);
            };

            row.LogRadioButton = radioButton;
            flpWorkerLogSelectors.Controls.Add(radioButton);

            if (flpWorkerLogSelectors.Controls.Count == 1)
                radioButton.Checked = true;
        }

        private void RemoveWorkerLogSelector(WorkerRowControls row)
        {
            bool wasChecked = row.LogRadioButton != null && row.LogRadioButton.Checked;

            if (row.LogRadioButton != null)
            {
                flpWorkerLogSelectors.Controls.Remove(row.LogRadioButton);
                row.LogRadioButton.Dispose();
                row.LogRadioButton = null;
            }

            if (wasChecked && flpWorkerLogSelectors.Controls.Count > 0)
            {
                RadioButton firstRadioButton = flpWorkerLogSelectors.Controls[0] as RadioButton;
                if (firstRadioButton != null)
                    firstRadioButton.Checked = true;
            }

            if (flpWorkerLogSelectors.Controls.Count == 0)
                lstWorkerLog.Items.Clear();
        }

        private void RefreshWorkerLogList(WorkerRowControls row)
        {
            AddWorkerLogItemsToMemory(row, TakePendingWorkerLogItems(row));

            lstWorkerLog.BeginUpdate();
            lstWorkerLog.Items.Clear();

            foreach (string logItem in row.WorkerLogItems)
            {
                lstWorkerLog.Items.Add(logItem);
            }

            if (lstWorkerLog.Items.Count > 0)
                lstWorkerLog.SelectedIndex = lstWorkerLog.Items.Count - 1;

            lstWorkerLog.EndUpdate();
        }

        private void QueueWorkerLog(int workerId, string message)
        {
            WorkerRowControls row = FindWorkerRow(workerId);
            if (row == null)
                return;

            string logItem = DateTime.Now.ToString("[yyyy-MM-dd HH:mm:ss.fff] : ") + message;
            lock (_WorkerEventLock)
            {
                row.PendingWorkerLogItems.Add(logItem);

                if (row.PendingWorkerLogItems.Count > WorkerLogMaxItems)
                    row.PendingWorkerLogItems.RemoveRange(0, row.PendingWorkerLogItems.Count - WorkerLogMaxItems);
            }
        }

        private List<string> TakePendingWorkerLogItems(WorkerRowControls row)
        {
            lock (_WorkerEventLock)
            {
                if (row.PendingWorkerLogItems.Count == 0)
                    return null;

                List<string> logItems = new List<string>(row.PendingWorkerLogItems);
                row.PendingWorkerLogItems.Clear();
                return logItems;
            }
        }

        private void AppendWorkerLogItems(WorkerRowControls row, List<string> logItems)
        {
            if (logItems == null || logItems.Count == 0)
                return;

            AddWorkerLogItemsToMemory(row, logItems);

            if (row.LogRadioButton == null || !row.LogRadioButton.Checked)
                return;

            int displayStartIndex = Math.Max(0, logItems.Count - WorkerLogFlushMaxItems);

            lstWorkerLog.BeginUpdate();
            for (int index = displayStartIndex; index < logItems.Count; index++)
            {
                if (lstWorkerLog.Items.Count >= WorkerLogMaxItems)
                    lstWorkerLog.Items.RemoveAt(0);

                lstWorkerLog.Items.Add(logItems[index]);
            }

            if (lstWorkerLog.Items.Count > 0)
                lstWorkerLog.SelectedIndex = lstWorkerLog.Items.Count - 1;

            lstWorkerLog.EndUpdate();
        }

        private void AddWorkerLogItemsToMemory(WorkerRowControls row, List<string> logItems)
        {
            if (logItems == null || logItems.Count == 0)
                return;

            row.WorkerLogItems.AddRange(logItems);

            if (row.WorkerLogItems.Count > WorkerLogMaxItems)
                row.WorkerLogItems.RemoveRange(0, row.WorkerLogItems.Count - WorkerLogMaxItems);
        }

        private void ArrangeWorkerRows()
        {
            if (_WorkerFlowPanel == null)
                return;

            int availableWidth = _WorkerFlowPanel.ClientSize.Width - _WorkerFlowPanel.Padding.Left - _WorkerFlowPanel.Padding.Right - 24;
            if (availableWidth <= 0)
                return;

            int columnCount = availableWidth >= WorkerPanelTwoColumnWidth ? 2 : 1;
            int panelWidth = Math.Max(WorkerPanelMinimumWidth, (availableWidth / columnCount) - 8);

            _WorkerFlowPanel.SuspendLayout();
            foreach (WorkerRowControls row in _WorkerRows)
            {
                ResizeWorkerRow(row, panelWidth);
            }
            _WorkerFlowPanel.ResumeLayout();
        }

        private void ResizeWorkerRow(WorkerRowControls row, int panelWidth)
        {
            row.Panel.Width = panelWidth;

            int rightButtonLeft = row.Panel.Width - 104;
            row.StartButton.Left = rightButtonLeft;
            row.StopButton.Left = rightButtonLeft + 46;
            row.ResetButton.Left = row.Panel.Width - row.ResetButton.Width - 12;

            row.ConditionTextBox.Width = Math.Max(120, row.Panel.Width - row.ConditionTextBox.Left - 10);
            row.StatusLabel.Width = Math.Max(120, row.Panel.Width - row.StatusLabel.Left - 10);
            row.ProgressBar.Width = Math.Max(120, row.Panel.Width - 20);
            row.CountLabel.Width = Math.Max(120, row.ResetButton.Left - row.CountLabel.Left - 8);
        }

        private void UpdateWorkerCountLabel(WorkerRowControls row)
        {
            row.CountLabel.Text = "처리 " + row.ProcessedTotal.ToString("#,##0") +
                                  " / 성공 " + row.SuccessTotal.ToString("#,##0") +
                                  " / 예외 " + row.FailureTotal.ToString("#,##0");
        }

        private void ResetWorkerTotals()
        {
            if (HasRunningWorkers())
            {
                MessageBox.Show("실행 중에는 누적 결과를 초기화할 수 없습니다.", "누적 초기화", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("모든 Worker의 누적 처리 결과를 초기화하시겠습니까?", "누적 초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (WorkerRowControls row in _WorkerRows)
            {
                ClearWorkerTotal(row);
            }

            lstLogText("[Info___] [Worker] 누적 처리 결과 초기화");
        }

        private void ResetWorkerTotal(WorkerRowControls row)
        {
            if (IsWorkerRunning(row))
            {
                MessageBox.Show("실행 중인 Worker는 누적 결과를 초기화할 수 없습니다.", "누적 초기화", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("Worker " + row.WorkerId + "의 누적 처리 결과를 초기화하시겠습니까?", "누적 초기화", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            ClearWorkerTotal(row);
            lstLogText("[Info___] [Worker] Worker " + row.WorkerId + " 누적 처리 결과 초기화");
        }

        private void ClearWorkerTotal(WorkerRowControls row)
        {
            row.ProcessedTotal = 0;
            row.SuccessTotal = 0;
            row.FailureTotal = 0;
            row.RunStartProcessedTotal = 0;
            row.RunStartSuccessTotal = 0;
            row.RunStartFailureTotal = 0;
            UpdateWorkerCountLabel(row);
            SaveWorkerRowToIni(row);
        }

        private void DeleteSelectedWorkers()
        {
            List<WorkerRowControls> deleteRows = new List<WorkerRowControls>();
            List<string> deleteWorkerNames = new List<string>();
            List<string> runningWorkerNames = new List<string>();

            foreach (WorkerRowControls row in _WorkerRows)
            {
                if (!row.SelectCheckBox.Checked)
                    continue;

                if (IsWorkerRunning(row))
                    runningWorkerNames.Add("W" + row.WorkerId);
                else
                {
                    deleteRows.Add(row);
                    deleteWorkerNames.Add("W" + row.WorkerId);
                }
            }

            if (deleteRows.Count == 0 && runningWorkerNames.Count == 0)
            {
                MessageBox.Show("삭제할 작업자를 체크하십시오.", "작업자 삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (runningWorkerNames.Count > 0)
            {
                MessageBox.Show("실행 중인 작업자는 삭제할 수 없습니다.\r\n대상: " + String.Join(", ", runningWorkerNames.ToArray()),
                    "작업자 삭제", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string message = "다음 작업자를 삭제하시겠습니까?\r\n\r\n" + String.Join(", ", deleteWorkerNames.ToArray());
            if (MessageBox.Show(message, "작업자 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            foreach (WorkerRowControls row in deleteRows)
            {
                RemoveWorkerRow(row);
            }

            ArrangeWorkerRows();
            WriteWorkerRowsToIni();
            lstLogText("[Info___] [Worker] Worker 삭제 - " + String.Join(", ", deleteWorkerNames.ToArray()));
        }

        private void RemoveWorkerRow(WorkerRowControls row)
        {
            _WorkerRows.Remove(row);
            _WorkerFlowPanel.Controls.Remove(row.Panel);
            RemoveWorkerLogSelector(row);
            row.Panel.Dispose();
        }

        private int StartAllWorkers(bool showMessage)
        {
            int startedCount = 0;

            foreach (WorkerRowControls row in _WorkerRows)
            {
                if (row.SelectCheckBox.Checked && !IsWorkerRunning(row))
                {
                    if (StartWorker(row))
                        startedCount++;
                }
            }

            if (startedCount == 0 && showMessage)
                MessageBox.Show("시작할 체크된 대기 작업자가 없습니다.", "전체 작업자 시작", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return startedCount;
        }

        private bool StartWorker(WorkerRowControls row)
        {
            if (IsWorkerRunning(row))
                return false;

            MigrationWorkerSettings settings;
            try
            {
                settings = BuildWorkerSettings(row);
                ValidateWorkerSettings(settings);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "작업자 설정 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            row.CancelSource = new CancellationTokenSource();
            row.RunStartProcessedTotal = row.ProcessedTotal;
            row.RunStartSuccessTotal = row.SuccessTotal;
            row.RunStartFailureTotal = row.FailureTotal;
            SaveWorkerRowToIni(row);
            row.LastStatsSavedAt = DateTime.Now;
            row.StatsSavePending = false;
            SetWorkerRunning(row, true);

            // DB와 파일 I/O가 UI 스레드를 막지 않도록 작업자 처리는 백그라운드에서 실행합니다.
            MigrationWorker worker = new MigrationWorker();
            worker.LogCreated += Worker_LogCreated;
            worker.ProgressChanged += Worker_ProgressChanged;

            row.WorkerTask = Task.Factory.StartNew<MigrationWorkerSummary>(
                delegate { return worker.Run(settings, row.CancelSource.Token); },
                row.CancelSource.Token,
                TaskCreationOptions.LongRunning,
                TaskScheduler.Default);

            row.WorkerTask.ContinueWith(delegate(Task<MigrationWorkerSummary> task)
            {
                RunOnUiThread(delegate
                {
                    FinishWorker(row, task);
                });
            });

            lstLogText("[Start__] [Worker] Worker " + row.WorkerId + " 시작");
            return true;
        }

        private void StopWorker(WorkerRowControls row)
        {
            if (row.CancelSource != null)
            {
                row.CancelSource.Cancel();
                row.StatusLabel.Text = "중지 요청";
                lstLogText("[Stop___] [Worker] Worker " + row.WorkerId + " 중지 요청");
            }
        }

        private void StopAllWorkers()
        {
            foreach (WorkerRowControls row in _WorkerRows)
            {
                StopWorker(row);
            }
        }

        private MigrationWorkerSettings BuildWorkerSettings(WorkerRowControls row)
        {
            MigrationWorkerSettings settings = new MigrationWorkerSettings();

            settings.WorkerId = row.WorkerId;
            settings.SelectCondition = row.ConditionTextBox.Text.Trim();
            settings.TopCount = row.TopCountTextBox.Text.Trim();
            settings.BatchIntervalSeconds = row.IntervalTextBox.Text.Trim();
            settings.SuccessMarkValue = row.MarkValueTextBox.Text.Trim();
            settings.WeekdayStartTime = _WeekdayStartTime.TimeOfDay;
            settings.WeekdayEndTime = _WeekdayEndTime.TimeOfDay;
            settings.WeekendStartTime = _WeekendStartTime.TimeOfDay;
            settings.WeekendEndTime = _WeekendEndTime.TimeOfDay;

            settings.SourceDBIP = _SourceDBIP;
            settings.SourceDBNM = _SourceDBNM;
            settings.SourceDBID = _SourceDBID;
            settings.SourceDBPW = _SourceDBPW;
            settings.SourceTableName = _SourceTableNM;
            settings.SourceMarkTableName = String.IsNullOrWhiteSpace(_SourceMarkTableNM) ? _SourceTableNM : _SourceMarkTableNM;
            settings.SourceYearDB = _SourceYearDB;
            settings.SourceMarkField = String.IsNullOrWhiteSpace(row.MarkFieldTextBox.Text) ? _SourceMarkField : row.MarkFieldTextBox.Text.Trim();
            settings.FromDate = row.FromDateTextBox.Text.Trim();
            settings.ToDate = row.ToDateTextBox.Text.Trim();
            settings.CheckTrustDBServer = _CheckTrustDBServer;

            settings.I360HttpFullPathField = _I360HttpFullPathField;
            settings.I360IISPath = _I360IISPath;
            settings.I360NetBiosPath = _I360NetBiosPath;
            settings.AudiologPath = _AudiologPath;
            settings.AudiologPathAddField = _AudiologPathAddField;
            settings.TargetPath = _TargetPath;
            settings.BackupPath = _BackupPath;
            settings.TempRootPath = Directory.GetCurrentDirectory() + @"\temp";

            settings.KMSServerIP = _KMSServerIP;
            settings.KMSDomain = _KMSDomain;
            settings.KMSServerID = _KMSServerID;
            settings.KMSServerPW = _KMSServerPW;
            settings.KMSAuthIP = _KMSAuthIP;
            settings.KMSAuthPort = _KMSAuthPort;
            settings.KMSKeyValue = _KMSKeyValue;
            settings.KMSFileSize = _KMSFileSize;

            settings.CheckTelNoEncrypt = _CheckTelNoEncrypt;

            return settings;
        }

        private void ValidateWorkerSettings(MigrationWorkerSettings settings)
        {
            int topCount;
            int batchIntervalSeconds;
            DateTime tempDate;

            if (String.IsNullOrWhiteSpace(settings.SourceDBIP) || String.IsNullOrWhiteSpace(settings.SourceDBNM))
                throw new Exception("Source DB 설정을 확인하십시오.");

            if (String.IsNullOrWhiteSpace(settings.SourceTableName))
                throw new Exception("Source 테이블명이 비어 있습니다.");

            if (String.IsNullOrWhiteSpace(settings.SourceMarkField))
                throw new Exception("마킹 컬럼명이 비어 있습니다.");

            if (!Int32.TryParse(settings.TopCount, out topCount) || topCount <= 0)
                throw new Exception("Top Count는 1 이상의 숫자로 입력하십시오.");

            if (!Int32.TryParse(settings.BatchIntervalSeconds, out batchIntervalSeconds) || batchIntervalSeconds < 0)
                throw new Exception("Interval은 0 이상의 숫자로 입력하십시오.");

            if (!DateTime.TryParseExact(settings.FromDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
                throw new Exception("FromDate 형식은 yyyy-MM-dd 이어야 합니다.");

            if (!DateTime.TryParseExact(settings.ToDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDate))
                throw new Exception("ToDate 형식은 yyyy-MM-dd 이어야 합니다.");

            if (String.IsNullOrWhiteSpace(settings.TargetPath))
                throw new Exception("TargetPath 설정을 확인하십시오.");
        }

        private void SetWorkerRunning(WorkerRowControls row, bool running)
        {
            row.SelectCheckBox.Enabled = !running;
            row.ConditionTextBox.ReadOnly = running;
            row.TopCountTextBox.ReadOnly = running;
            row.IntervalTextBox.ReadOnly = running;
            row.FromDateTextBox.ReadOnly = running;
            row.ToDateTextBox.ReadOnly = running;
            row.MarkFieldTextBox.ReadOnly = running;
            row.MarkValueTextBox.ReadOnly = running;
            row.StartButton.Enabled = !running;
            row.StopButton.Enabled = running;
            row.ResetButton.Enabled = !running;

            if (running)
            {
                row.ProgressBar.Style = ProgressBarStyle.Marquee;
                row.ProgressBar.MarqueeAnimationSpeed = 20;
                row.StatusLabel.Text = "작업 시작";
            }
            else
            {
                row.ProgressBar.MarqueeAnimationSpeed = 0;
                row.ProgressBar.Style = ProgressBarStyle.Continuous;
                row.ProgressBar.Value = 0;
            }
        }

        private bool IsWorkerRunning(WorkerRowControls row)
        {
            return row.WorkerTask != null && !row.WorkerTask.IsCompleted;
        }

        private void FinishWorker(WorkerRowControls row, Task<MigrationWorkerSummary> task)
        {
            FlushWorkerUiUpdates(row, true);
            SetWorkerRunning(row, false);

            if (row.CancelSource != null)
            {
                row.CancelSource.Dispose();
                row.CancelSource = null;
            }

            if (task.Exception != null)
            {
                row.FailureTotal++;
                row.StatusLabel.Text = "오류 / " + task.Exception.GetBaseException().Message;
                UpdateWorkerCountLabel(row);
                SaveWorkerRowToIni(row);
                row.LastStatsSavedAt = DateTime.Now;
                row.StatsSavePending = false;
                lstLogText("[Error__] [Worker] Worker " + row.WorkerId + " - " + task.Exception.GetBaseException().Message, true);
            }
            else if (task.IsCanceled)
            {
                row.StatusLabel.Text = "중지됨";
                SaveWorkerRowToIni(row);
                row.LastStatsSavedAt = DateTime.Now;
                row.StatsSavePending = false;
            }
            else
            {
                MigrationWorkerSummary summary = task.Result;
                row.ProcessedTotal = row.RunStartProcessedTotal + summary.ProcessedCount;
                row.SuccessTotal = row.RunStartSuccessTotal + summary.SuccessCount;
                row.FailureTotal = row.RunStartFailureTotal + summary.FailureCount + summary.MissingFileCount + summary.SmallFileCount + summary.AlreadyEncryptedCount;
                row.StatusLabel.Text = summary.Message;
                UpdateWorkerCountLabel(row);
                SaveWorkerRowToIni(row);
                row.LastStatsSavedAt = DateTime.Now;
                row.StatsSavePending = false;
            }

            row.WorkerTask = null;

            if (!HasRunningWorkers() && !_Work)
                ToolStripControl("STOP");
            else if (!HasRunningWorkers())
                lblStatus.Text = "Worker scheduler waiting...";
        }

        private bool HasRunningWorkers()
        {
            foreach (WorkerRowControls row in _WorkerRows)
            {
                if (IsWorkerRunning(row))
                    return true;
            }

            return false;
        }

        private bool HasCheckedWorkers()
        {
            foreach (WorkerRowControls row in _WorkerRows)
            {
                if (row.SelectCheckBox.Checked)
                    return true;
            }

            return false;
        }

        private WorkerRowControls FindWorkerRow(int workerId)
        {
            foreach (WorkerRowControls row in _WorkerRows)
            {
                if (row.WorkerId == workerId)
                    return row;
            }

            return null;
        }

        private void Worker_LogCreated(object sender, MigrationWorkerLogEventArgs e)
        {
            QueueWorkerLog(e.WorkerId, e.Message);
        }

        private void Worker_ProgressChanged(object sender, MigrationWorkerProgressEventArgs e)
        {
            WorkerRowControls row = FindWorkerRow(e.WorkerId);
            if (row == null)
                return;

            lock (_WorkerEventLock)
            {
                row.PendingProgress = e;
                row.HasPendingProgress = true;
            }

            QueueWorkerLog(e.WorkerId, "[Status_] " + e.StatusText);
        }

        private void UpdateWorkerCurrentDate(WorkerRowControls row, string currentDate)
        {
            if (String.IsNullOrWhiteSpace(currentDate))
                return;

            row.CurrentDateLabel.Text = "처리일자 " + currentDate;
        }

        private string BuildWorkerStatusText(int batchCount, string statusText)
        {
            List<string> parts = new List<string>();

            if (batchCount > 0 && (String.IsNullOrWhiteSpace(statusText) || !statusText.Contains("건 조회")))
                parts.Add("조회 " + batchCount.ToString("#,##0") + "건");

            if (!String.IsNullOrWhiteSpace(statusText))
                parts.Add(statusText);

            if (parts.Count == 0)
                return "대기";

            return String.Join(" / ", parts.ToArray());
        }

        private void RunOnUiThread(Action action)
        {
            if (IsDisposed || !IsHandleCreated)
                return;

            if (InvokeRequired)
                BeginInvoke(action);
            else
                action();
        }

        #endregion [ Worker UI ]

        #endregion [ Form & Control ]

        #region [ Button - tsbStart_Click, tsbStop_Click, tsbConfig_Click, tsbSave_Click, tsbExit_Click, btnSFINUMRangesAdd_Click, btnSFINUMRangesDel_Click, btnSFReprocessing_Click ]

        private void tsbStart_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 0;
            ReadINI();

            if (!HasCheckedWorkers())
            {
                MessageBox.Show("스케줄로 실행할 작업자를 체크하십시오.", "Worker Scheduler", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            ToolStripControl("START");
            ControlEnable(false);
            _Work = true;
            _Wait = 0;
            _CurrentCycle = 0;
            tmrBatch.Enabled = true;

            lstLogText("[Start__] [Scheduler] Worker scheduler started");
        }
        
        private void tsbStop_Click(object sender, EventArgs e)
        {
            ToolStripControl("STOP");
            tmrBatch.Enabled = false;
            _Work = false;
            StopAllWorkers();
            lstLogText("[Stop___] [BatJob_]");
        }

        private void tsbConfig_Click(object sender, EventArgs e)
        {
            tabControl.SelectedIndex = 2;
            ToolStripControl("CONFIG");
            ControlEnable(true);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            ToolStripControl("SAVE");
            ControlEnable(false);
            WriteINI();
            lstLogText("[Save___] [Config_]");
        }

        private void tsbExit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Terminate program?", "User confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        #endregion [ Button ]

        #region [ Batch - tmrBatch_Tick ]
        
        private void tmrBatch_Tick(object sender, EventArgs e)
        {
            try
            {
                int scheduleInterval = _Interval <= 0 ? 1 : _Interval;

                _Wait++;
                lblStatus.Text = _Wait + " / " + scheduleInterval + " Sec. wait for scheduled worker start...";

                if (_Wait >= scheduleInterval)
                {
                    _Wait = 0;

                    // 로그 파일 생성
                    CreateLogFile();

                    if (IsCurrentTimeInSchedule())
                    {
                        tmrBatch.Enabled = false;

                        if (_CurrentCycle < _RetryCycle || _RetryCycle == 0)
                        {
                            _RetryWork = false;
                            _CurrentCycle++;
                        }
                        else
                        {
                            _RetryWork = true;
                            _CurrentCycle = 0;
                        }

                        switch (_Site)
                        {                           
                            default:
                                int startedCount = StartAllWorkers(false);
                                if (startedCount > 0)
                                    lstLogText("[Start__] [Scheduler] Scheduled worker start - " + startedCount + " worker(s)");
                                else if (HasRunningWorkers())
                                    lblStatus.Text = "Worker already running. Scheduler waiting...";
                                else
                                    lblStatus.Text = "No checked idle worker. Scheduler waiting...";
                                break;
                        }

                        // 작업 flag가 True이면, 작업 계속
                        if (_Work == true)
                            tmrBatch.Enabled = true;
                    }
                    else
                    {
                        lblStatus.Text = "Out of job schedule..";
                    }
                }
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private bool IsCurrentTimeInSchedule()
        {
            TimeSpan startTime;
            TimeSpan endTime;

            GetRuntimeForDate(DateTime.Now, out startTime, out endTime);
            return IsTimeInRuntime(DateTime.Now.TimeOfDay, startTime, endTime);
        }

        private void GetRuntimeForDate(DateTime date, out TimeSpan startTime, out TimeSpan endTime)
        {
            if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
            {
                startTime = _WeekendStartTime.TimeOfDay;
                endTime = _WeekendEndTime.TimeOfDay;
            }
            else
            {
                startTime = _WeekdayStartTime.TimeOfDay;
                endTime = _WeekdayEndTime.TimeOfDay;
            }
        }

        private bool IsTimeInRuntime(TimeSpan currentTime, TimeSpan startTime, TimeSpan endTime)
        {
            // [00:00 ~ 00:00]
            if (startTime == endTime)
                return true;

            // [18:00 ~ 19:00]
            if (startTime < endTime)
                return currentTime >= startTime && currentTime < endTime;

            // [22:00 ~ 04:00]
            if (currentTime >= startTime)
                return true;

            return currentTime < endTime;
        }

        #endregion [ Batch ]

        #region [미사용 기능-- KMS - KMSInit, KMSEncryption, KMSDecryption, KMSSizeCheck, KMSEncCheck, KMSEncryptionbySearchFiles ]

        private bool KMSInit(string KMSServerIP, string KMSDomain, string KMSServerID, string KMSServerPW, string KMSAuthIP, string KMSAuthPort)
        {
            try
            {
                if (_KMS == null)
                {
                    lstLogText("[Info___] [KMS____] MediaParser connection disabled");
                    return false;
                }

                int ret = _KMS.KMSInit(KMSServerIP, KMSDomain, KMSServerID, KMSServerPW, KMSAuthIP, KMSAuthPort);
                if (ret != 1)
                {
                    lstLogText("[Error__] [Message] KMSInit Failed, KMS Error Code - " + ret.ToString());
                    return false;
                }

                lstLogText("[Info___] [BatJob_] KMSInit Success");
                return true;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private bool KMSEncryption(string SourcePath, string BackupPath, string TargetPath, string KMSKeyValue)
        {
            FileInfo fi = new FileInfo(SourcePath);
            string TempPath = BackupPath;
            string EncTempPath = Directory.GetCurrentDirectory() + @"\temp\enc_" + fi.Name;

            try
            {
                if (_KMS == null)
                {
                    lstLogText("[Info___] [KMS____] MediaParser connection disabled");
                    return false;
                }

                if (File.Exists(TargetPath))
                {
                    if (KMSEncCheck(TargetPath))
                        return true;
                }

                isReadOnly(SourcePath);
                if (!FileCopy(SourcePath, TempPath))
                    return false;

                if (File.Exists(TempPath))
                {
                    int ret = 0;
                    ret = _KMS.KMSEncryptFile(TempPath, EncTempPath, KMSKeyValue);
                    if (ret != 1)
                    {
                        lstLogText("[Error__] [Message] KMSEncrypt Failed, KMS Encryption Error Code - " + ret.ToString());
                        return false;
                    }
                }
                else
                    return false;

                if (!FileCopy(EncTempPath, TargetPath))
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private bool KMSSizeCheck(string FilePath)
        {
            try
            {
                FileInfo fi = new FileInfo(FilePath);
                if (fi.Length <= _KMSFileSize)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private bool KMSEncCheck(string FilePath)
        {
            try
            {
                // KMS 암호화 체크
                char[] buffer = new char[37];
                using (StreamReader sr = new StreamReader(FilePath))
                {
                    sr.Read(buffer, 0, 37);
                }
                string sContents = new string(buffer);
                if (sContents.IndexOf("AES", 34) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }
                
        #endregion [ KMS ]

        #region [ Function - TableMarking, InsertResult, FileDelete, FileMove, FileCopy, CreateDirectory, isReadOnly, CreateLogFile, ClassDispose ]

        private void TableMarking(DBManager dbManager, DataRow dr, string MarkValue, string DialedNumber, string CallerNumber)
        {
            try
            {
                string SqlUpdateQuery;
                int Result;

                string FileName;
                string ServerName;
                string RecDate;
                string Year;

                FileName = dr["FileName"].ToString();
                ServerName = dr["ServerName"].ToString();
                RecDate = Convert.ToDateTime(dr["Date"]).ToString("yyyy-MM-dd");
                Year = RecDate.Substring(0, 4);

                SqlUpdateQuery = "";
                if (_SourceYearDB == "")
                    SqlUpdateQuery += "Update " + _SourceDBNM + ".dbo." + _SourceMarkTableNM;
                else
                    SqlUpdateQuery += "Update " + _SourceYearDB + Year + ".dbo." + _SourceMarkTableNM;

                SqlUpdateQuery += " Set ";
                SqlUpdateQuery += _SourceMarkField + " = '" + MarkValue + "'";
                SqlUpdateQuery += ", ETL_DT = GETDATE()";

                if (_CheckTelNoEncrypt == "1")
                {
                    SqlUpdateQuery += ", DialedNumber = '" + _SqlAccount.AES256ENC(DialedNumber) + "'";
                    SqlUpdateQuery += ", CallerNumber = '" + _SqlAccount.AES256ENC(CallerNumber) + "'";
                }

                SqlUpdateQuery += " Where FileName = '" + FileName + "' And ServerName = '" + ServerName + "'";

                Result = dbManager.UpdateSql(SqlUpdateQuery);
                if (Result == 1)
                {
                    lstLogText("[Success] [Marking] " + FileName + " / " + ServerName);
                }
                else
                {
                    lstLogText("[Failure] [Marking] " + SqlUpdateQuery, true);
                }
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private bool FileDelete(string WavFile)
        {
            try
            {
                //string XmlFile = WavFile.ToUpper().Replace(".WAV", ".XML");
                //File.Delete(XmlFile);
                isReadOnly(WavFile);
                File.Delete(WavFile);
                return true;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private bool FileMove(string SourceFile, string TargetFile)
        {
            try
            {
                File.Move(SourceFile, TargetFile);
                return true;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private bool FileCopy(string SourceFile, string TargetFile)
        {
            try
            {
                lstLogText("[Info___] [Message] " + "FileCopy : " + SourceFile + " >> " + TargetFile, true);

                File.Copy(SourceFile, TargetFile, true);
                return true;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private bool CreateDirectory(string TargetFolder)
        {
            try
            {
                if (!Directory.Exists(TargetFolder))
                    Directory.CreateDirectory(TargetFolder);
                return true;
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
                return false;
            }
        }

        private void isReadOnly(string FilePath)
        {
            try
            {
                if (File.Exists(FilePath))
                {
                    FileAttributes fas = File.GetAttributes(FilePath);
                    if ((fas & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                        File.SetAttributes(FilePath, FileAttributes.Normal);
                }
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private void CreateLogFile()
        {
            try
            {
                if (DateTime.Now.Date.ToString("yyyy-MM-dd") != _LogDate)
                {
                    _Log.DeleteLogFile();
                    _Log.CreateLogFile();
                    _LogErr.CreateLogFile();
                    _LogDate = DateTime.Now.Date.ToString("yyyy-MM-dd");
                    _Ini.SetIniValue("General", "LogDate", DateTime.Now.Date.ToString("yyyy-MM-dd"), _Ini.IniFilePath);
                }
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        private void ClassDispose(DataSet dsSource = null, DBManager conSourceDB = null, DBManager conTargetDB = null, DBManager conTargetDB2 = null)
        {
            try
            {
                if (dsSource != null)
                    dsSource.Dispose();
                if (conSourceDB != null)
                    conSourceDB.DisConnectDB();
                if (conTargetDB != null)
                    conTargetDB.DisConnectDB();
                if (conTargetDB2 != null)
                    conTargetDB2.DisConnectDB();
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

        #endregion [ Function ]


        /// <summary>
        /// 미사용 (현황 상세 파악 후 삭제 예정)
        /// </summary>
        private void KMSMigrationBatch()
        {
            try
            {
                #region [ 변수 선언 ]

                string FileName;
                string ServerName;
                string RecDate;
                string Year;
                string Started;

                string strDialedNumber;
                string strCallerNumber;


                string SourceFile;               
                string TargetFile;
                string AudiologPathAdd;

                string TargetFolder;

                string BackupFile;
                string BackupFolder;

                string SqlSelectQuery;

                

                DBManager conSourceDB = new DBManager();
                DataSet dsSource = new DataSet();

                #endregion [ 변수 선언 ]

                lstLogText("[Start__] [BatJob_]");

                foreach (string file in Directory.GetFiles(Directory.GetCurrentDirectory() + @"\temp", "*", SearchOption.TopDirectoryOnly))
                    FileDelete(file);

                #region [ SourceDB 연결 ]

                // SourceDB 연결
                if (conSourceDB.MssqlConnect(_SourceDBIP, _SourceDBNM, _SourceDBID, _SourceDBPW, _CheckTrustDBServer))
                    lstLogText("[Success] [DBCon__] Source - DBIP : " + _SourceDBIP + ", DBNM : " + _SourceDBNM);
                else
                {
                    lstLogText("[Failure] [DBCon__] Source - DBIP : " + _SourceDBIP + ", DBNM : " + _SourceDBNM, true);
                    return;
                }

                #endregion [ SourceDB 연결 ]







                // 우선 작업을 시작 할 때 현재 쿼리를 해야 할 시작 날짜를 읽어 온다.
                _JobCurrenWorkingtDate = _Ini.GetIniValue("DBInfoSource", "The current working date", _Ini.IniFilePath);

                if (_JobCurrenWorkingtDate == "")
                {
                    _JobCurrenWorkingtDate = _FromDate;
                    _Ini.SetIniValue("DBInfoSource", "The current working date", _JobCurrenWorkingtDate, _Ini.IniFilePath);
                }

                /*만약 지정된 최종 날짜보다 작업 하고자 하는 날짜가 크면 끝*/
                //설정된 MAX 일자
                DateTime cToDate = DateTime.ParseExact(_ToDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                DateTime cTime1 = DateTime.ParseExact(_JobCurrenWorkingtDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);

                if(cTime1 > cToDate)
                {
                    //lstLogText("[Success] 작업 설정 일자 만료 : " + _ToDate, true);
                    lstLogText("[Success] [BatJob_] 작업 설정 만료 일자까지 작업이 진행 되었습니다.", true);


                    dsSource.Dispose();
                    conSourceDB.DisConnectDB();


                    lstLogText("[Success] [DBDisco] Source - DBIP : " + _SourceDBIP + ", DBNM : " + _SourceDBNM);

                    return;
                }


                // 조회
                if (!_RetryWork)
                    if (_SourceSelectCondition == "")
                        SqlSelectQuery = "Select Top " + _TopCount + " FileName, ServerName, Date, Started, DialedNumber, CallerNumber, " + _I360HttpFullPathField + " From " + _SourceTableNM + " with (nolock)  Where Date = '" + _JobCurrenWorkingtDate + "' and ( " + _SourceMarkField + " is null or " + _SourceMarkField + " = '')";
                    else
                        SqlSelectQuery = "Select Top " + _TopCount + " FileName, ServerName, Date, Started, DialedNumber, CallerNumber, " + _I360HttpFullPathField + " From " + _SourceTableNM + " with (nolock)  Where Date = '" + _JobCurrenWorkingtDate + "' and " + _SourceSelectCondition + " and ( " + _SourceMarkField + " is null or " + _SourceMarkField + " = '')";
                else
                    if(_RetrySelectCondition == "")
                        SqlSelectQuery = "Select Top " + _TopCount + " FileName, ServerName, Date, Started, DialedNumber, CallerNumber, " + _I360HttpFullPathField + " From " + _SourceTableNM + " with (nolock)  Where Date = '" + _JobCurrenWorkingtDate + "'" + "' and ( " + _SourceMarkField + " is null or " + _SourceMarkField + " = '')";
                else
                    SqlSelectQuery = "Select Top " + _TopCount + " FileName, ServerName, Date, Started, DialedNumber, CallerNumber, " + _I360HttpFullPathField + " From " + _SourceTableNM + " with (nolock)  Where Date = '" + _JobCurrenWorkingtDate + "' and " + _RetrySelectCondition + " and ( " + _SourceMarkField + " is null or " + _SourceMarkField + " = '')";


                lstLogText("[Info___] [BatJob_] Query - " + SqlSelectQuery);
                dsSource.Clear();
                if (!conSourceDB.SelectSqlDataSet(dsSource, "Source", SqlSelectQuery))
                {
                    lstLogText("[Failure] [Conditi] Query - " + SqlSelectQuery, true);
                    dsSource.Dispose();
                    conSourceDB.DisConnectDB();

                    lstLogText("[Success] [DBDisco] Source - DBIP : " + _SourceDBIP + ", DBNM : " + _SourceDBNM);
                    return;
                }

                DataTable dtSource = dsSource.Tables["Source"];
                DataRowCollection rowsSource = dtSource.Rows;

                lstLogText("[Info___] [BatJob_] Query Count - " + rowsSource.Count + " 건");






                foreach (DataRow drSource in rowsSource)
                {
                    Application.DoEvents();

                    // 중지
                    if (!_Work)
                    {
                        dsSource.Dispose();
                        conSourceDB.DisConnectDB();

                        lstLogText("[Success] [DBDisco] Source - DBIP : " + _SourceDBIP + ", DBNM : " + _SourceDBNM);
                        return;
                    }

                    FileName = drSource["FileName"].ToString();
                    ServerName = drSource["ServerName"].ToString();
                    RecDate = Convert.ToDateTime(drSource["Date"]).ToString("yyyy-MM-dd");
                    Year = RecDate.Substring(0, 4);
                    Started = Convert.ToDateTime(drSource["Started"]).ToString("yyyy-MM-dd HH:mm:ss");
                    _LastTime = Started;

                    strDialedNumber = drSource["DialedNumber"].ToString();
                    strCallerNumber = drSource["CallerNumber"].ToString();

 //                   _Ini.SetIniValue("WorkInfo", "LastTime", _LastTime, _Ini.IniFilePath);

                    AudiologPathAdd = "";
                    if (_AudiologPathAddField != "")
                        AudiologPathAdd = drSource[_AudiologPathAddField].ToString().Replace(@"\", "").Trim();

                    // Impact360
                    if (_I360HttpFullPathField != "")
                    {
                        SourceFile = drSource[_I360HttpFullPathField].ToString().Trim();
                        SourceFile = SourceFile.Replace(_I360IISPath, _I360NetBiosPath).Replace("/", @"\");
                        TargetFile = SourceFile.Replace(_I360NetBiosPath, _TargetPath);
                        TargetFolder = Path.GetDirectoryName(TargetFile);
                        BackupFile = SourceFile.Replace(_I360NetBiosPath, _BackupPath);
                        BackupFolder = Path.GetDirectoryName(BackupFile);
                    }
                    // Audiolog
                    else
                    {
                        if (AudiologPathAdd != "")
                            SourceFile = _AudiologPath + @"\" + AudiologPathAdd + @"\" + ServerName.Replace(@"\", "") + @"\" + FileName.Substring(11, 5) + FileName.Substring(8, 3) + @"\" + RecDate.Replace("-", "") + @"\" + FileName;
                        else
                            SourceFile = _AudiologPath + @"\" + ServerName.Replace(@"\", "") + @"\" + FileName.Substring(11, 5) + FileName.Substring(8, 3) + @"\" + RecDate.Replace("-", "") + @"\" + FileName;                            
                        TargetFile = SourceFile.Replace(_AudiologPath, _TargetPath);
                        TargetFolder = Path.GetDirectoryName(TargetFile);
                        BackupFile = SourceFile.Replace(_AudiologPath, _BackupPath);
                        BackupFolder = Path.GetDirectoryName(BackupFile);
                    }

                    // MarkValue : 2 - 녹취 파일 없음
                    if (!File.Exists(SourceFile))
                    {
                        lstLogText("[Failure] [Exists_] 녹취 파일 없음(2) - " + FileName + " / " + SourceFile, true);
                        TableMarking(conSourceDB, drSource, "2", strDialedNumber, strCallerNumber);
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(SourceFile);

                    // **Length** 속성은 파일 크기를 **long 타입의 바이트**로 반환합니다.
                    long fileSizeInBytes = fileInfo.Length;

                    // KB로 변환
                    double fileSizeInKB = (double)fileSizeInBytes / 1024;
                    Console.WriteLine($"파일 크기 (KB): {fileSizeInKB:F2} KB");

                    if(fileSizeInKB<=1)
                    {
                        lstLogText($"[Failure] 파일 크기 (KB): {fileSizeInKB:F2} KB", true);
                        TableMarking(conSourceDB, drSource, "6", strDialedNumber, strCallerNumber);
                        continue;
                    }

                    // 대상 폴더 생성
                    if (!CreateDirectory(TargetFolder))
                    {
                        lstLogText("[Failure] [Folder_] 복사 폴더 생성 실패 - " + FileName + " / " + TargetFolder, true);
                        return;
                    }

                    // 대상 폴더 생성
                    if (!CreateDirectory(BackupFolder))
                    {
                        lstLogText("[Failure] [Folder_] 복사 폴더 생성 실패 - " + FileName + " / " + BackupFolder, true);
                        return;
                    }

                    // MarkValue : 3 - 녹취 파일 KMS 암호화 제외 파일 크기 17 Byte 미만 제외
                    FileInfo fi = new FileInfo(SourceFile);
                    if (fi.Length < _KMSFileSize)
                    {
                        lstLogText("[Success] [KMSEnc_] 녹취 파일 KMS 암호화 제외, 0초 파일 크기 " + fi.Length + "Byte(3) - " + SourceFile);
                        TableMarking(conSourceDB, drSource, "3", strDialedNumber, strCallerNumber);
                        continue;


                    }

                    if (KMSEncCheck(SourceFile))
                    {
                        lstLogText("[Success] [KMSEnc_] 녹취 파일 KMS 암호화 제외, 이미 암호화된 파일(4) " + SourceFile);
                        TableMarking(conSourceDB, drSource, "4", strDialedNumber, strCallerNumber);
                        continue;

                    }

                    // MarkValue : 5 - 녹취 파일 KMS 암호화 실패
                    if (!KMSEncryption(SourceFile, BackupFile, TargetFile, _KMSKeyValue))
                    {
                        lstLogText("[Failure] [KMSEnc_] 녹취 파일 KMS 암호화 실패 - " + SourceFile + " >>> " + TargetFile, true);
                        //TableMarking(conSourceDB, drSource, "5", strDialedNumber, strCallerNumber);
                        return;
                    }

                    // MarkValue : 1 - 녹취 파일 KMS 암호화 성공
                    lstLogText("[Success] [KMSEnc_] 녹취 파일 KMS 암호화 성공(1) - " + SourceFile + " >>> " + TargetFile);

                    /*
                     임시 폴더에 암호화가 되었을 경우
                       
                      1. 해당 파일을 다시 원본 파일 경로로 복사를 하여 덮어쓰기를 한다.
                      2. 복사가 완료가 된 경우에
                         - 임시 폴더의 암호화된 파일을 삭제 한다.
                         - 임시 폴더의 원본 파일을 삭제 한다.
                      3. 그리고 업데이트를 수행 한다.
                     */

                    if( FileCopy(TargetFile, SourceFile))
                    {
                        FileDelete(TargetFile);
                        FileDelete(BackupFile);


                        TableMarking(conSourceDB, drSource, "1", strDialedNumber, strCallerNumber);
                    }
                    else
                    {

                    }


                    
                  
                    _Ini.SetIniValue("WorkInfo", "LastTime", _LastTime, _Ini.IniFilePath);
                }



                if (rowsSource.Count == 0)
                {
                    //작업을 할 대상 날짜가 더이상 존재 하지 않을 경우 하루를 증가하고 해당 날짜를 기록한다.
                    DateTime currentDate = DateTime.ParseExact(_JobCurrenWorkingtDate, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    currentDate = currentDate.AddDays(1);
                    _JobCurrenWorkingtDate = currentDate.ToString("yyyy-MM-dd");
                    _Ini.SetIniValue("DBInfoSource", "The current working date", _JobCurrenWorkingtDate, _Ini.IniFilePath);


                    lstLogText("[Success] [BatJob_] " + _JobCurrenWorkingtDate + " 작업일자로 증가 합니다.");

                }

                dsSource.Dispose();
                conSourceDB.DisConnectDB();

                lstLogText("[Success] [DBDisco] Source - DBIP : " + _SourceDBIP + ", DBNM : " + _SourceDBNM);

                lstLogText("[End____] [BatJob_]");
            }
            catch (Exception ex)
            {
                if (_LogLevel > 0)
                    lstLogText("[Error__] [Message] " + MethodBase.GetCurrentMethod().Name + " - " + ex.Message, true);
            }
        }

    }
}
