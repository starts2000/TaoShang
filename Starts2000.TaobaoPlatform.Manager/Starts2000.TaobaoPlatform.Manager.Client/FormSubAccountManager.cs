using System;
using System.Windows.Forms;
using Starts2000.TaobaoPlatform.Manager.Models;
using System.Linq;
using Starts2000.TaobaoPlatform.Manager.Client.Utils;

namespace Starts2000.TaobaoPlatform.Manager.Client
{
    public partial class FormSubAccountManager : Form
    {
        readonly ManagerDal _manager;
        readonly User _user;

        public FormSubAccountManager(ManagerDal manager, User user)
        {
            InitializeComponent();
            _manager = manager;
            _user = user;
            tsmiAudit.Click += tsmiAudit_Click;
            tsmiCancelAudit.Click += tsmiCancelAudit_Click;
            tsmiDelete.Click += tsmiDelete_Click;
            base.Text = string.Format("{0} - 会员：{1}", base.Text, _user.Account);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadSubAccounts();
        }

        async void LoadSubAccounts()
        {
            try
            {
                var subAccounts = await _manager.GetSubAccounts(_user.Id);
                foreach (var item in subAccounts)
                {
                    item.Password = TripleDES.Decrypt3DES(item.Password);
                    item.PayPassword = TripleDES.Decrypt3DES(item.PayPassword);
                }
                dgvSubAccountList.DataSource = subAccounts;
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, "获取用户小号信息失败！错误：" + ex.Message,
                    "用户小号管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        void tsmiCancelAudit_Click(object sender, EventArgs e)
        {
            Audit(false);
        }

        void tsmiAudit_Click(object sender, EventArgs e)
        {
            Audit(true);
        }

        async void tsmiDelete_Click(object sender, EventArgs e)
        {
            if (dgvSubAccountList.SelectedRows == null || dgvSubAccountList.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请先选择需要删除的小号信息！",
                    "用户小号管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("请确认是否删除小号信息？", "用户小号管理",
                MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
            {
                var subAccount = dgvSubAccountList.SelectedRows[0].DataBoundItem as UserSubAccount;
                try
                {
                    var ret = await _manager.DeleteSubAccount(subAccount.Id);
                    string msg = ret ? "删除小号信息成功！" : "删除小号信息失败！";
                    MessageBox.Show(this, msg, "用户小号管理",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (ret)
                    {
                        LoadSubAccounts();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, "删除小号信息失败，错误信息：" + ex.Message,
                        "用户小号管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        async void Audit(bool audit)
        {
            if (dgvSubAccountList.SelectedRows == null || dgvSubAccountList.SelectedRows.Count == 0)
            {
                MessageBox.Show(this, "请先选择需要进行小号管理的帐户！",
                    "小号管理", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var subAccount = dgvSubAccountList.SelectedRows[0].DataBoundItem as UserSubAccount;
            try
            {
                var ret = await _manager.SubAccountAudit(subAccount.Id, audit);
                string info = ret ? "用户小号审核成功！" : "用户小号审核失败！";

                MessageBox.Show(this, string.Format("{0}{1}", !audit ? "取消" : string.Empty, info),
                    "用户小号审核", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ret)
                {
                    LoadSubAccounts();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, string.Format(
                    "{0}用户小号审核失败，错误：{1}", !audit ? "取消" : string.Empty, ex.Message),
                    "用户小号审核", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}