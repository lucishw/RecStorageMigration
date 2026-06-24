using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using Common;

namespace KMSMigration
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplyDefaultConnectionLimitSetting();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }

        private static void ApplyDefaultConnectionLimitSetting()
        {
            try
            {
                IniManager iniManager = new IniManager();
                iniManager.CreateIniFile();

                string enabled = iniManager.GetIniValue("General", "EnableDefaultConnectionLimit", iniManager.IniFilePath);
                if (enabled == "" || enabled == "1")
                    ServicePointManager.DefaultConnectionLimit = 100;
            }
            catch
            {
                ServicePointManager.DefaultConnectionLimit = 100;
            }
        }
    }
}
