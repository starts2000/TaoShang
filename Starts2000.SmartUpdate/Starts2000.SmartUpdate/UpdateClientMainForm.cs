using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpWin;
using Starts2000.SmartUpdate.Dal;
using Starts2000.SmartUpdate.Models;
using Starts2000.SmartUpdate.Properties;

namespace Starts2000.SmartUpdate
{
    public partial class UpdateClientMainForm : DialogSkinForm
    {
        UpdateInfo _updateInfo;
        string _totalCountString;
        string _updateFileName;
        readonly UpdateInfoDal _updateInfoDal = new UpdateInfoDal();

        public UpdateClientMainForm(UpdateInfo updateInfo)
        {
            _updateInfo = updateInfo;
            InitializeComponent();
            Init();
        }

        void Init()
        {
            string title = Resources.UpdateFormTitle;
            if(!string.IsNullOrEmpty(title))
            {
                base.Text = title;
            }

            string logoFileName = Resources.LogoFileName;
            if(!string.IsNullOrEmpty(logoFileName))
            {
                picLogo.ImageLocation = logoFileName;
            }

            lbVersion.Text = _updateInfo.Version;
            rtbUpdateInfo.AppendText(_updateInfo.Description);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            DownLoad();
        }

        string CheckFolder()
        {
            string path = string.Format(@"{0}\update", Application.StartupPath);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return path;
        }

        string GetFileSizeString(long size)
        {
            if (size >= 0x100000L)
            {
                return string.Format("{0:f2}M", (double)size / 0x100000L);
            }

            if (size >= 0x400L)
            {
                return string.Format("{0:f2}KB", (double)size / 0x400L);
            }

            return string.Format("{0}B", size);
        }

        void DownLoad()
        {
            try
            {
                using (WebClient client = new WebClient())
                {
                    client.DownloadProgressChanged += DownloadProgressChanged;
                    _updateFileName = string.Format(@"{0}\{1}", CheckFolder(), _updateInfo.FileName);
                    client.DownloadFileAsync(new Uri(_updateInfo.DowloadUrl), _updateFileName);
                    client.DownloadFileCompleted += (sender, e) =>
                    {
                        if(e.Error != null)
                        {
                            MessageBoxEx.Show("下载更新程序失败！", Resources.UpdateFormTitle
                                , MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                            UpdateHelper.StartMainApp();
                            return;
                        }

                        if (File.Exists(_updateFileName))
                        {
                            if (UpdateHelper.KillProcess())
                            {
                                StartUpdateSetupApp(_updateFileName);
                            }
                            else
                            {
                                string processNmae = Resources.ClientProcessName;
                                MessageBoxEx.Show(string.Format("[{0}] 关闭失败，请手动关闭程序后再更新！",
                                    processNmae), Resources.UpdateFormTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                Close();
                            }
                        }
                        else
                        {
                            MessageBoxEx.Show("下载更新程序失败！", Resources.UpdateFormTitle,
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Close();
                            UpdateHelper.StartMainApp();
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBoxEx.Show(ex.Message, Resources.UpdateFormTitle,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                UpdateHelper.StartMainApp();
            }
        }

        void DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                pbDownload.Value = e.ProgressPercentage;

                if(_totalCountString == null)
                {
                    _totalCountString = GetFileSizeString(e.TotalBytesToReceive);
                }

                lbDownloadInfo.Text = string.Format("{0}/{1}",
                    GetFileSizeString(e.BytesReceived), _totalCountString);
            }));
        }

        void StartUpdateSetupApp(string fileName)
        {
            lbDownloadInfo.Text = "正在安装...";
            try
            {
                string path = new DirectoryInfo(Application.StartupPath).Parent.FullName;
                Process process = new Process();
                process.StartInfo = new ProcessStartInfo(fileName, string.Concat("/S /D=", path));
                process.EnableRaisingEvents = true;
                process.Exited += Exited;
                process.Start();

                _updateInfoDal.Add(_updateInfo);
            }
            catch (Exception exception)
            {
                MessageBoxEx.Show(exception.Message, "运行更新程序安装包", MessageBoxButtons.OK, MessageBoxIcon.Error);

                Close();
                UpdateHelper.StartMainApp();
            }
        }

        void Exited(object sender, EventArgs e)
        {
            BeginInvoke((Action)(() =>
            {
                int deleteCount = 0;
                while (File.Exists(_updateFileName) && deleteCount++ < 10)
                {
                    Thread.Sleep(3000);
                    try
                    {
                        File.Delete(_updateFileName);
                    }
                    catch (Exception)
                    {
                    }
                }

                Close();
                UpdateHelper.StartMainApp();
            }));
        }
    }
}