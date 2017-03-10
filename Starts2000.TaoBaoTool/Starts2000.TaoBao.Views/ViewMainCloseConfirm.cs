using System.Windows.Forms;
using CCWin;
using Starts2000.TaoBao.Views.Utils;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewMainCloseConfirm : ViewBaseEx
    {
        readonly IGlobalApplicationData _applicationData;

        public ViewMainCloseConfirm(IGlobalApplicationData applicationData)
        {
            InitializeComponent();

            _applicationData = applicationData;
            RemoveErrorOnControlFocused(
                stbPassword, stbPassword.SkinTxt, errorProvider);
            sbtnOk.Click += (sender, e) =>
            {
                if(!CheckControlTextNullOrEmpty(stbPassword, stbPassword.SkinTxt, 
                    errorProvider, "密码不能为空"))
                {
                    return;
                }

                var user = _applicationData.ApplicationData.User;
                if(_applicationData.ApplicationData.User != null)
                {
                    if(string.Equals(user.Password, MD5Encrypt.GetMD5(
                        stbPassword.SkinTxt.Text.Trim())))
                    {
                        DialogResult = DialogResult.OK;
                        Close();
                    }
                    else
                    {
                        MessageBoxEx.Show(this, "输入密码错误，请重新输入。", "退出程序",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        stbPassword.SkinTxt.Focus();
                        stbPassword.SkinTxt.SelectAll();
                    }
                }
            };
        }
    }
}