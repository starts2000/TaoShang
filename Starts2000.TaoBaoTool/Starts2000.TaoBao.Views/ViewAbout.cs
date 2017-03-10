using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Starts2000.TaoBao.Views.ViewResource;

namespace Starts2000.TaoBao.Views
{
    internal partial class ViewAbout : ViewBaseEx
    {
        public ViewAbout()
        {
            InitializeComponent();
            pbAbout.Image = ViewResources.About;
        }
    }
}
