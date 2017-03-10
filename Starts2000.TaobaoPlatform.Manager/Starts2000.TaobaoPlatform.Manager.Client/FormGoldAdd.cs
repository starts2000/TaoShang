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
    public partial class FormGoldAdd : Form
    {
        readonly ManagerDal _manager;
        readonly User _user;

        public FormGoldAdd(ManagerDal manager, User user)
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
            if (string.IsNullOrEmpty(tbGold.Text))
            {
                MessageBox.Show(this, "请先输入要添加的金币数量！",
                    "添加金币", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int gold;
            if (!int.TryParse(tbGold.Text, out gold))
            {
                MessageBox.Show(this, "请先输入正确的金币数量！",
                    "添加金币", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                bool ret = await _manager.AddGold(_user.Id, gold);
                string info = ret ? "添加金币成功！" : "添加金币失败！";

                MessageBox.Show(this, info, "添加金币",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (ret)
                {
                    Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, "添加金币失败，错误：" + ex.Message,
                    "添加金币", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
