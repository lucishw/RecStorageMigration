using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Common
{
    class IniManager
    {
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string section, string key, string val, string filePath);

        private string iniFileName;
        private string iniFilePath;

        /// <summary>Ini 파일 이름</summary>
        public string IniFileName
        {
            get { return iniFileName; }
            set { iniFileName = value; }
        }

        /// <summary>Ini 파일 경로</summary>
        public string IniFilePath
        {
            get { return iniFilePath; }
            set { iniFilePath = value; }
        }

        /// <summary>새로운 IniManager 개체 인스턴스를 초기화 합니다.</summary>
        public IniManager()
        {
            iniFileName = Process.GetCurrentProcess().ProcessName;
            iniFilePath = Directory.GetCurrentDirectory() + @"\ini";
        }

        /// <summary>ini파일을 생성합니다.</summary>
        public void CreateIniFile()
        {
            if (!Directory.Exists(iniFilePath))
            {
                Directory.CreateDirectory(iniFilePath);
            }

            iniFilePath = iniFilePath + @"\" + iniFileName + ".ini";
            if (!File.Exists(iniFilePath))
            {
                using(StreamWriter sw = File.CreateText(iniFilePath)) {}
            }
        }

        /// <summary>ini파일에서 설정값을 읽습니다.</summary>
        /// <param name="section">ini파일 Section 값</param>
        /// <param name="key">ini파일 Key 값</param>
        /// <param name="iniPath">ini파일 경로</param>
        public string GetIniValue(string section, string key, string iniPath)
        {
            StringBuilder temp = new StringBuilder(1024);
            int i = GetPrivateProfileString(section, key, "", temp, 1024, iniPath);
            return temp.ToString();
        }

        /// <summary>ini파일에 설정값을 씁니다.</summary>
        /// <param name="section">ini파일 Section 값</param>
        /// <param name="key">ini파일 Key 값</param>
        /// <param name="value">설정값</param>
        /// <param name="iniPath">ini파일 경로</param>
        public void SetIniValue(string section, string key, string value, string iniPath)
        {
            WritePrivateProfileString(section, key, value, iniPath);
        }

        public void DeleteSection(string section, string iniPath)
        {
            WritePrivateProfileString(section, null, null, iniPath);
        }
    }
}
