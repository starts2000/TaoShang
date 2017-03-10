using System;
using System.Threading;
using System.Windows.Forms;
using Ninject.Extensions.Logging;
using Starts2000.TaobaoPlatform.Core;

namespace Starts2000.TaobaoPlatform.Server
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
            try
            {
                Global.Init();
            }
            catch(Exception ex)
            {
                MessageBox.Show("程序初始化错误！错误信息为：\r\n\r\n" + ex.Message,
                    "程序初始化", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.ThreadException += ApplicationThreadException;
            Application.Run(new FormMain());
            Global.UnInit();
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
    }
}