using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewECommercePlatformSelect : ViewBaseEx
    {
        public ViewECommercePlatformSelect()
        {
            InitializeComponent();

            srbTaoBao.CheckedChanged += srbCheckedChanged;
            srb1688Ali.CheckedChanged += srbCheckedChanged;
            sbtnOk.Click += (sender, e) =>
            {
                Close();
            };
        }

        void srbCheckedChanged(object sender, EventArgs e)
        {
            if(object.Equals(sender, srbTaoBao) && srbTaoBao.Checked)
            {
                ECommercePlatform = ECommercePlatform.TaoBao;
                return;
            }

            if (object.Equals(sender, srb1688Ali) && srb1688Ali.Checked)
            {
                ECommercePlatform = ECommercePlatform.Ali1688;
            }
        }

        internal ECommercePlatform ECommercePlatform
        {
            private set;
            get;
        }
    }

    internal enum ECommercePlatform
    {
        TaoBao,
        Ali1688
    }
}
