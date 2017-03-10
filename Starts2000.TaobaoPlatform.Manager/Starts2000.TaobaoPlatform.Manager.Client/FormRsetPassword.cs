using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormResetPasswod : Form
    {
        readonly ManagerDal _manager;
        readonly User _user;

        public FormResetPasswod(ManagerDal manager, User user)
        {
            InitializeComponent();
            _manager = manager;
            _user = user;
            tbAccount.Text = user.Account;
            Init();
        }

        void Init()
        {
            btnOk.Click += btnOk_Click;
        }

        async void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbPassword.Text))
            {
                MessageBox.Show(this, "请先输入重置密码！",
                    "重置用户密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool ret = await _manager.ResetPassword(_user.Id, tbPassword.Text.Trim(), _user.Salt);
                string info = ret ? "重置用户密码成功！" : "重置用户密码失败！";

                MessageBox.Show(this, info, "重置用户密码",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ret)
                {
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "重置用户密码失败，错误：" + ex.Message,
                    "重置用户密码", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
