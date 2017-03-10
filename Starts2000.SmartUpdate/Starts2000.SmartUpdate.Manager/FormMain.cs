using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Starts2000.SmartUpdate.Manager.Models;
using Starts2000.SmartUpdate.Manager.Properties;

namespace Starts2000.SmartUpdate.Manager
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            btnAdd.Click += btnAdd_Click;
            btnDelete.Click += btnDelete_Click;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadUpdateInfoList();
        }

        void LoadUpdateInfoList()
        {
            try
            {
                string url = string.Format("{0}/managerxx/updateinfo/list", Settings.Default.BaseAddress);
                var updateInfos = WebApiHelper.GetJsonModel<IList<UpdateInfo>>(url);
                updateInfos.Wait();
                dgvUpdateInfoList.DataSource = updateInfos.Result;
            }
            catch(Exception ex)
            {
                MessageBox.Show(this, ex.Message, "获取更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void btnDelete_Click(object sender, EventArgs e)
        {
            if(dgvUpdateInfoList.SelectedRows!= null && dgvUpdateInfoList.SelectedRows.Count > 0)
            {
                var updateInfo = dgvUpdateInfoList.SelectedRows[0].DataBoundItem as UpdateInfo;
                if(updateInfo != null)
                {
                    if(MessageBox.Show(this, "是否删除选中的自动更新信息？", "删除信息", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.Yes)
                    {
                        string url = string.Format("{0}/mamangerxx/updateinfo/delete/{1}", 
                            Settings.Default.BaseAddress, updateInfo.Id.ToString());
                        try
                        {
                            var ret = WebApiHelper.GetJsonModel<bool>(url);
                            ret.Wait();
                            if (ret.Result)
                            {
                                MessageBox.Show(this, "删除更新信息列表成功！",
                                    "删除更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadUpdateInfoList();
                            }
                            else
                            {
                                MessageBox.Show(this, "删除更新信息列表失败！", 
                                    "删除更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(this, ex.Message, 
                                "删除更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAddUpdateInfo();
            if(form.ShowDialog(this) == DialogResult.OK)
            {
                LoadUpdateInfoList();
            }
        }
    }
}
