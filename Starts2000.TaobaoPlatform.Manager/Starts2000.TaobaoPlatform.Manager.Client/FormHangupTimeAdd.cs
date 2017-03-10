using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormHangupTimeAdd : Form
    {
        readonly ManagerDal _manager;
        readonly User _user;

        public FormHangupTimeAdd(ManagerDal manager, User user)
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
            if (string.IsNullOrEmpty(tbHangupTime.Text))
            {
                MessageBox.Show(this, "请先输入要添加的挂机时间！",
                    "添加挂机时间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int minutes;
            if (!int.TryParse(tbHangupTime.Text, out minutes))
            {
                MessageBox.Show(this, "请先输入正确的挂机时间！",
                    "添加挂机时间", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool ret = await _manager.AddHangupTime(_user.Id, minutes);
                string info = ret ? "添加挂机时间成功！" : "添加挂机时间失败！";

                MessageBox.Show(this, info, "添加挂机时间",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ret)
                {
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "添加挂机时间失败，错误：" + ex.Message,
                    "添加挂机时间", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
