using System;
using System.Web;
using System.Windows.Forms;
using CSharpWin;
using Starts2000.SmartUpdate.Dal;
using Starts2000.SmartUpdate.Models;
using Starts2000.SmartUpdate.Properties;

namespace Starts2000.SmartUpdate
{
    internal class SmartUpdateContext : ApplicationContext
    {
        readonly UpdateInfoDal _updateInfoDal = new UpdateInfoDal();

        public SmartUpdateContext()
        {
            Init();
        }

        void Init()
        {
            try
            {
                var curUpdateInfo = _updateInfoDal.Get();
                var lastUpdateTime = curUpdateInfo == null ?
                    DateTime.MinValue : curUpdateInfo.LastUpdateTime;
                var updateInfo = WebApiHelper.GetJsonModel<UpdateInfo>(
                    string.Format("{0}/{1}/{2}", Resources.UpdateServer,
                    Resources.ClientType, HttpUtility.UrlPathEncode(lastUpdateTime.ToString("yyyy-MM-dd HH:mm:ss"))));
                updateInfo.Wait();

                if (updateInfo.Result.HasNewVersion)
                {
                    base.MainForm = new UpdateClientMainForm(updateInfo.Result);
                }
                else
                {
                    UpdateHelper.StartMainApp();
                }
            }
            catch(Exception ex)
            {
                MessageBoxEx.Show(ex.ToString(), Resources.UpdateFormTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateHelper.StartMainApp();
            }
        }
    }
}