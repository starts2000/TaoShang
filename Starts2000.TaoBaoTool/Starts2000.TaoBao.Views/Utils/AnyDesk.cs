using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Threading;

namespace Starts2000.TaoBao.Views.Utils
{
    internal sealed class AnyDesk
    {
        [DllImport("user32.dll")]
        extern static IntPtr FindWindow(string classname, string captionName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        extern static IntPtr FindWindowEx(IntPtr parent, IntPtr child, string classname, string captionName);

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int length);

        [DllImport("user32.dll")]
        static extern bool DestroyWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        static extern bool SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        const uint WM_CLOSE = 0x0010;
        const uint WM_SYSCOMMAND = 0x0112;
        const uint SC_CLOSE = 0xF060;
        static string _installPath;
        static readonly string[] Commands = {
             "--install", "--start-with-win﻿", ﻿"--create-shortcuts", "--create-desktop-icon", 
             "--silent", "--uninstall", "--control", "--start-service", "--with-password", 
             "--set-password", "--get-alias", "--get-id", "--get-status", "--register-licence", "--remove-first"};

        internal static bool IsAnyDeskServiceExisted(out ServiceController anyDeskService)
        {
            ServiceController[] services = ServiceController.GetServices();
            foreach (var service in services)
            {
                if (service.ServiceName.ToUpper() == "ANYDESK")
                {
                    anyDeskService = service;
                    return true;
                }
            }

            anyDeskService = null;
            return false;
        }

        internal static string GetServiceFilePath(string svcName)
        {
            string path = "Win32_service";

            using (ManagementClass mClass = new ManagementClass(path))
            {
                using (ManagementObjectCollection moc = mClass.GetInstances())
                {
                    svcName = svcName.ToUpper();
                    foreach (ManagementObject mo in moc)
                    {
                        if (mo["Name"].ToString().Trim().ToUpper() == svcName)
                        {
                            return mo["PathName"].ToString();
                        }
                    }
                }
            }

            return null;
        }

        internal static AnyDeskServiceState CheckAnyDeskServiceState()
        {
            ServiceController anyDeskService;
            if (IsAnyDeskServiceExisted(out anyDeskService))
            {
                if (anyDeskService.Status == ServiceControllerStatus.Running)
                {
                    return AnyDeskServiceState.Running;
                }
                else
                {
                    if (anyDeskService.Status != ServiceControllerStatus.StartPending)
                    {
                        try
                        {
                            anyDeskService.Start();
                        }
                        catch
                        {
                            return AnyDeskServiceState.NotExisted;
                        }
                    }

                    for (int i = 0; i < 30; i++)
                    {
                        Thread.Sleep(1000);
                        anyDeskService.Refresh();
                        if (anyDeskService.Status == ServiceControllerStatus.Running)
                        {
                            return AnyDeskServiceState.Running;
                        }
                    }

                    return AnyDeskServiceState.StartFailed;
                }
            }

            return AnyDeskServiceState.NotExisted;
        }

        internal static bool Start(string installPath, string sourcefile)
        {
            _installPath = installPath;
            var serviceState = CheckAnyDeskServiceState();
            switch (serviceState)
            {
                case AnyDeskServiceState.Running:
                    _installPath = GetServiceFilePath("AnyDesk").Split(
                        new string[] { " --" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    break;
                case AnyDeskServiceState.NotExisted:
                    ExecAnyDeskCommand(sourcefile, BuildArgs(Commands[0],
                        string.Format("\"{0}\"", installPath), Commands[14], Commands[1], Commands[4]));
                    Thread.Sleep(10000);
                    if (CheckAnyDeskServiceState() != AnyDeskServiceState.Running)
                    {
                        return false;
                    }
                    _installPath = GetServiceFilePath("AnyDesk").Split(
                       new string[] { " --" }, StringSplitOptions.RemoveEmptyEntries)[0];
                    break;
                case AnyDeskServiceState.StartFailed:
                    return false;
            }

            var status = GetStatus();
            for (int i = 0; i < 60; i++)
            {
                if (status != AnyDeskStatus.OnLine)
                {
                    Thread.Sleep(3000);
                    status = GetStatus();
                }
            }

            return status == AnyDeskStatus.OnLine;
        }

        internal static bool IsServerOpened()
        {
            IntPtr hAnyDeskHwnd = FindWindow("ad_win#4\n", null);
            if (hAnyDeskHwnd == IntPtr.Zero)
            {
                return false;
            }

            StringBuilder sbTitle = new StringBuilder(512);
            GetWindowText(hAnyDeskHwnd, sbTitle, 512);

            string title = sbTitle.ToString().ToUpper();
            if (title.StartsWith("ANYDESK (") && title.EndsWith(")"))
            {
                return true;
            }

            return false;
        }

        internal static bool IsClientOpened()
        {
            IntPtr hAnyDeskHwnd = FindWindow("ad_win#2\n", null);
            if (hAnyDeskHwnd == IntPtr.Zero)
            {
                return false;
            }

            StringBuilder sbTitle = new StringBuilder(512);
            GetWindowText(hAnyDeskHwnd, sbTitle, 512);

            string title = sbTitle.ToString().ToUpper();
            if (title.EndsWith(" - ANYDESK"))
            {
                return true;
            }

            return false;
        }

        internal static bool CloseServer()
        {
            IntPtr hAnyDeskHwnd = FindWindow("ad_win#4\n", null);

            if (hAnyDeskHwnd == IntPtr.Zero)
            {
                return false;
            }

            StringBuilder sbTitle = new StringBuilder(512);
            GetWindowText(hAnyDeskHwnd, sbTitle, 512);

            string title = sbTitle.ToString().ToUpper();
            if (title.StartsWith("ANYDESK (") && title.EndsWith(")"))
            {
                //return PostMessage(hAnyDeskHwnd, WM_CLOSE, 0, 0);
                return SendMessage(hAnyDeskHwnd, WM_SYSCOMMAND, SC_CLOSE, 0);
            }

            return false;
        }

        internal static bool CloseClient()
        {
            IntPtr hAnyDeskHwnd = FindWindow("ad_win#2\n", null);

            if (hAnyDeskHwnd == IntPtr.Zero)
            {
                return false;
            }

            StringBuilder sbTitle = new StringBuilder(512);
            GetWindowText(hAnyDeskHwnd, sbTitle, 512);

            string title = sbTitle.ToString().ToUpper();
            if (title.EndsWith(" - ANYDESK"))
            {
                return PostMessage(hAnyDeskHwnd, WM_CLOSE, 0, 0);
            }

            return false;
        }

        internal static AnyDeskStatus GetStatus()
        {
            string output = ExecAnyDeskCommand(_installPath, Commands[12]);
            switch (output)
            {
                case "offline":
                    return AnyDeskStatus.OffLine;
                case "SERVICE_NOT_RUNNING":
                    return AnyDeskStatus.ServiceNotRunning;
                case "online":
                    return AnyDeskStatus.OnLine;
                case "nofile":
                default:
                    return AnyDeskStatus.NotInstalled;
            }
        }

        internal static string GetId()
        {
            return ExecAnyDeskCommand(_installPath, Commands[11]);
        }

        internal static string GetAlias()
        {
            return ExecAnyDeskCommand(_installPath, Commands[10]);
        }

        internal static void SetPassword(string password)
        {
            ExecCmdCommand(string.Format("echo {0} | {1} {2}", password,
                string.Format("\"{0}\"", _installPath), Commands[9]));
        }

        internal static void Connect(string file, string id, string password)
        {
            //echo password | anydesk alias@ad --with-password
            ExecCmdCommand(string.Format("echo {0} | {1} {2} {3}", password,
                string.Format("\"{0}\"", file), id, Commands[8]));
        }

        internal static string ExecAnyDeskCommand(string file, string args)
        {
            if (File.Exists(file))
            {
                var info = new ProcessStartInfo(file, args);
                info.RedirectStandardOutput = true;
                info.UseShellExecute = false;
                var process = Process.Start(info);
                return process.StandardOutput.ReadToEnd();
            }

            return "nofile";
        }

        internal static void Stop()
        {
            //foreach (var process in Process.GetProcessesByName("AnyDesk"))
            //{
            //    process.Kill();
            //}

            ServiceController service;
            if (IsAnyDeskServiceExisted(out service))
            {
                if (service.CanStop)
                {
                    service.Stop();
                }
            }
        }

        internal static void ExecCmdCommand(string input)
        {
            var startInfo = new ProcessStartInfo("cmd.exe");
            startInfo.UseShellExecute = false;
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;
            startInfo.RedirectStandardError = true;
            startInfo.CreateNoWindow = true;

            var process = Process.Start(startInfo);
            process.StandardInput.WriteLine(input);
            process.StandardInput.Flush();
            process.Close();
        }

        static string BuildArgs(params string[] args)
        {
            StringBuilder argsBuilder = new StringBuilder();
            foreach (var arg in args)
            {
                argsBuilder.AppendFormat("{0} ", arg);
            }

            return argsBuilder.ToString();
        }

        internal enum AnyDeskServiceState
        {
            NotExisted,
            StartFailed,
            Running,
        }

        internal enum AnyDeskStatus
        {
            OnLine,
            OffLine,
            ServiceNotRunning,
            NotInstalled
        }
    }
}
