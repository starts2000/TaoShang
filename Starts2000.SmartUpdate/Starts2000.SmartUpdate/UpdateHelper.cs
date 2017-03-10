using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using CSharpWin;
using Starts2000.SmartUpdate.Properties;

namespace Starts2000.SmartUpdate
{
    internal class UpdateHelper
    {
        public static void StartMainApp()
        {
            try
            {
                string clientExcuteFileName = Resources.ClientExcuteFileName;
                if (!string.IsNullOrEmpty(clientExcuteFileName))
                {
                    Process.Start(Path.Combine(
                        new DirectoryInfo(Application.StartupPath).Parent.FullName,
                        clientExcuteFileName));
                }
            }
            catch (Exception exception)
            {
                MessageBoxEx.Show(exception.Message, 
                    string.Concat("启动", Resources.ClientProcessName) , 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Environment.Exit(0);
            }
        }

        public static bool KillProcess()
        {
            try
            {
                string processNmae = Resources.ClientProcessName;
                Process[] processesByName = Process.GetProcessesByName(processNmae);

                if (processesByName.Length > 0)
                {
                    if (MessageBoxEx.Show(string.Format(
                        "{0}正在运行，必须关闭才能更新，是否立即关闭程序？", processNmae), 
                        Resources.UpdateFormTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        foreach (Process process in processesByName)
                        {
                            process.Kill();
                        }

                        return true;
                    }

                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                MessageBoxEx.Show(string.Concat("程序更新失败:", Environment.NewLine , exception.Message)
                    , Resources.UpdateFormTitle, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return false;
            }
        }
    }
}