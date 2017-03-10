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
    public partial class FormAddUpdateInfo : Form
    {
        static readonly IList<ClientType> ClientTypes = new List<ClientType>
        {
            new ClientType { Id = 1, Name= "淘商助手操作端" },
            new ClientType { Id = 2, Name= "淘商助手挂机端" }
        };

        public FormAddUpdateInfo()
        {
            InitializeComponent();
            cbClientType.DisplayMember = "Name";
            cbClientType.DataSource = ClientTypes;
            btnAdd.Click += btnAdd_Click;
        }

        void btnAdd_Click(object sender, EventArgs e)
        {
            string url = string.Format("{0}/managerxx/updateinfo/add", Settings.Default.BaseAddress);
            try
            {
                var ret = WebApiHelper.Post<UpdateInfo, bool>(url, new UpdateInfo
                {
                    FileName = tbFileName.Text.Trim(),
                    Version = tbVersion.Text.Trim(),
                    DowloadUrl = tbDownloadUrl.Text.Trim(),
                    ClientType = (cbClientType.SelectedItem as ClientType).Id,
                    Description = tbDescription.Text.Trim(),
                    LastUpdateTime = DateTime.Now
                });
                ret.Wait();

                if (ret.Result)
                {
                    MessageBox.Show(this, "添加更新信息列表成功！",
                               "添加更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show(this, "添加更新信息列表失败！",
                                "添加更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message,
                                "添加更新信息列表", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
