using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using CCWin;
using Ninject.Extensions.Logging;
using Starts2000.TaoBao.Core;
using Starts2000.TaoBao.Views.ViewResource;

namespace Starts2000.TaoBaoTool.Client
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (!CheckRun())
            {
                return;
            }

            try
            {
                Global.Init();
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show("程序初始化错误！错误信息为：\r\n\r\n" + ex.Message,
                    "程序初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Application.ThreadException += ApplicationThreadException;
            Application.Run(Global.Resolve<ApplicationContext>("Client"));
            Global.Uinit();
        }

        static void ApplicationThreadException(object sender, ThreadExceptionEventArgs e)
        {
            try
            {
                var logger = Global.Resolve<ILoggerFactory>().GetCurrentClassLogger();
                logger.FatalException("ApplicationThreadException", e.Exception);
            }
            catch
            {
            }
        }

        static bool CheckRun()
        {
            var instance = RunningInstance();
            if (instance == null)
            {
                if (CheckOperationClient())
                {
                    MessageBoxEx.Show("操作端已运行，挂机端与操作端不能运行在同一计算机上！",
                        "挂机端程序启动", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    Application.Exit();
                    return false;
                }
            }
            else
            {
                MessageBoxEx.Show("挂机端已运行，同一计算机不能同时运行两个挂机端程序！",
                    "挂机端程序启动", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                HandleRunningInstance(instance);
                Application.Exit();
                return false;
            }

            return true;
        }

        static Process RunningInstance()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);

            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }

            return null;
        }

        static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }

        static bool CheckOperationClient()
        {
            Process[] processes = Process.GetProcesses();
            foreach (var process in processes)
            {
                var title = process.MainWindowTitle;
                if (title.Equals(string.Concat(ViewResources.OptName, "登录")) ||
                    (title.StartsWith(string.Concat(ViewResources.OptName, " - 会员(")) && 
                    title.EndsWith(")")))
                {
                    return true;
                }
            }

            return false;
        }

        [DllImport("User32.dll")]
        static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        const int WS_SHOWNORMAL = 1;
    }
}
