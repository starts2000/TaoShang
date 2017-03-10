using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormUserAudit : Form
    {
        readonly ManagerDal _manager;
        readonly User _user;

        public FormUserAudit(ManagerDal manager, User user)
        {
            InitializeComponent();
            _manager = manager;
            _user = user;
            BindUser();
            Init();
        }

        void BindUser()
        {
            tbAccount.Text = _user.Account;
            if(_user.ExpireDate.HasValue)
            {
                dtpExpireDate.Value = _user.ExpireDate.Value;
            }

            cbAudit.Checked = _user.IsAudit;
            cbLock.Checked = _user.Lock;
        }

        void Init()
        {
            btnOk.Click += btnOk_Click;
        }

        async void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                bool ret = await _manager.UserAudit(new User
                {
                    Id = _user.Id,
                    IsAudit = cbAudit.Checked,
                    Lock = cbLock.Checked,
                    ExpireDate = dtpExpireDate.Value
                });

                string info = ret ? "审核用户成功！" : "审核用户失败！";

                MessageBox.Show(this, info, "审核用户",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ret)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "审核用户失败，错误：" + ex.Message,
                    "审核用户", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
