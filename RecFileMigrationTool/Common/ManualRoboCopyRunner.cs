using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace Common
{
    public class ManualRoboCopySettings
    {
        public string RoboCopyPath { get; set; }
        public string SourcePath { get; set; }
        public string TargetPath { get; set; }
        public string FilePattern { get; set; }
        public string ExtraOptions { get; set; }
        public bool IncludeSubdirectories { get; set; }
        public bool DryRun { get; set; }
        public bool Mirror { get; set; }
        public bool NoProgress { get; set; }
        public bool NoFileList { get; set; }
        public bool NoDirectoryList { get; set; }
        public int RetryCount { get; set; }
        public int WaitSeconds { get; set; }
        public int ThreadCount { get; set; }
        public int TimeoutSeconds { get; set; }
        public int SuccessExitCodeMax { get; set; }
        public bool ReportEnabled { get; set; }
        public bool ReportAppend { get; set; }
        public bool ReportTee { get; set; }
        public bool OpenReportFolderAfterFinish { get; set; }
        public string ReportDirectory { get; set; }
        public string ReportFilePrefix { get; set; }
        public string ReportLogPath { get; set; }
        public string SummaryReportPath { get; set; }

        public string BuildArguments()
        {
            List<string> parts = new List<string>();

            parts.Add(Quote(SourcePath));
            parts.Add(Quote(TargetPath));

            List<string> patterns = SplitFilePatterns(FilePattern);
            foreach (string pattern in patterns)
            {
                parts.Add(Quote(pattern));
            }

            if (Mirror)
                parts.Add("/MIR");
            else if (IncludeSubdirectories)
                parts.Add("/E");

            if (DryRun)
                parts.Add("/L");

            parts.Add("/R:" + RetryCount);
            parts.Add("/W:" + WaitSeconds);

            if (ThreadCount > 0)
                parts.Add("/MT:" + ThreadCount);

            if (NoProgress)
                parts.Add("/NP");

            if (NoFileList)
                parts.Add("/NFL");

            if (NoDirectoryList)
                parts.Add("/NDL");

            if (ReportEnabled && !String.IsNullOrWhiteSpace(ReportLogPath))
            {
                if (ReportAppend)
                    parts.Add("/LOG+:" + Quote(ReportLogPath));
                else
                    parts.Add("/LOG:" + Quote(ReportLogPath));

                if (ReportTee)
                    parts.Add("/TEE");
            }

            if (!String.IsNullOrWhiteSpace(ExtraOptions))
                parts.Add(ExtraOptions.Trim());

            return String.Join(" ", parts.ToArray());
        }

        public string BuildDisplayCommand()
        {
            return Quote(RoboCopyPath) + " " + BuildArguments();
        }

        private static List<string> SplitFilePatterns(string filePattern)
        {
            List<string> patterns = new List<string>();

            if (String.IsNullOrWhiteSpace(filePattern))
            {
                patterns.Add("*.*");
                return patterns;
            }

            string[] parts = filePattern.Split(new char[] { ' ', ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string part in parts)
            {
                string value = part.Trim();
                if (value.Length > 0)
                    patterns.Add(value);
            }

            if (patterns.Count == 0)
                patterns.Add("*.*");

            return patterns;
        }

        private static string Quote(string value)
        {
            if (value == null)
                value = "";

            string escapedValue = value.Replace("\"", "\\\"");
            return "\"" + escapedValue + "\"";
        }
    }

    public class ManualRoboCopyResult
    {
        public int ExitCode { get; set; }
        public bool TimedOut { get; set; }
        public bool Cancelled { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public DateTime StartedAt { get; set; }
        public DateTime FinishedAt { get; set; }
    }

    public class ManualRoboCopyOutputEventArgs : EventArgs
    {
        public string Text { get; set; }
        public bool IsError { get; set; }
    }

    public class ManualRoboCopyRunner
    {
        private readonly object _processLock = new object();
        private Process _process;

        public event EventHandler<ManualRoboCopyOutputEventArgs> OutputReceived;

        public ManualRoboCopyResult Run(ManualRoboCopySettings settings, CancellationToken cancelToken)
        {
            ManualRoboCopyResult result = new ManualRoboCopyResult();
            result.ExitCode = -1;

            Process process = new Process();
            process.StartInfo = new ProcessStartInfo();
            process.StartInfo.FileName = settings.RoboCopyPath;
            process.StartInfo.Arguments = settings.BuildArguments();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.StandardOutputEncoding = Encoding.Default;
            process.StartInfo.StandardErrorEncoding = Encoding.Default;
            process.EnableRaisingEvents = true;
            process.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
            {
                if (e.Data != null)
                    RaiseOutput(e.Data, false);
            };
            process.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
            {
                if (e.Data != null)
                    RaiseOutput(e.Data, true);
            };

            try
            {
                lock (_processLock)
                {
                    _process = process;
                }

                result.StartedAt = DateTime.Now;
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();

                DateTime startedAt = result.StartedAt;
                while (!process.WaitForExit(500))
                {
                    if (cancelToken.IsCancellationRequested)
                    {
                        result.Cancelled = true;
                        KillProcess(process);
                        break;
                    }

                    if (settings.TimeoutSeconds > 0 && DateTime.Now.Subtract(startedAt).TotalSeconds > settings.TimeoutSeconds)
                    {
                        result.TimedOut = true;
                        KillProcess(process);
                        break;
                    }
                }

                try
                {
                    process.WaitForExit();
                }
                catch
                {
                }

                if (cancelToken.IsCancellationRequested && !result.TimedOut)
                    result.Cancelled = true;

                if (!result.Cancelled && !result.TimedOut)
                    result.ExitCode = process.ExitCode;

                result.Succeeded = !result.Cancelled && !result.TimedOut && result.ExitCode <= settings.SuccessExitCodeMax;

                if (result.Cancelled)
                    result.Message = "RoboCopy stopped by user.";
                else if (result.TimedOut)
                    result.Message = "RoboCopy timeout.";
                else if (result.Succeeded)
                    result.Message = "RoboCopy completed. ExitCode=" + result.ExitCode;
                else
                    result.Message = "RoboCopy failed. ExitCode=" + result.ExitCode;

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                RaiseOutput(ex.Message, true);
                return result;
            }
            finally
            {
                result.FinishedAt = DateTime.Now;

                lock (_processLock)
                {
                    if (_process == process)
                        _process = null;
                }

                process.Dispose();
            }
        }

        public void Cancel()
        {
            lock (_processLock)
            {
                if (_process != null)
                    KillProcess(_process);
            }
        }

        private void KillProcess(Process process)
        {
            try
            {
                if (process != null && !process.HasExited)
                    process.Kill();
            }
            catch
            {
            }
        }

        private void RaiseOutput(string text, bool isError)
        {
            EventHandler<ManualRoboCopyOutputEventArgs> handler = OutputReceived;
            if (handler == null)
                return;

            ManualRoboCopyOutputEventArgs args = new ManualRoboCopyOutputEventArgs();
            args.Text = text;
            args.IsError = isError;
            handler(this, args);
        }
    }
}
