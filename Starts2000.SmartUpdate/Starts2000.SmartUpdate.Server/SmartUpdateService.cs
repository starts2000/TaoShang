using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using Microsoft.Owin.Hosting;

namespace Starts2000.SmartUpdate.Server
{
    public partial class SmartUpdateService : ServiceBase
    {
        IDisposable _apiServer = null;

        public SmartUpdateService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var url = ConfigurationManager.AppSettings["BaseAddress"];
            _apiServer = WebApp.Start<Startup>(url); 
        }

        protected override void OnStop()
        {
            if(_apiServer != null)
            {
                _apiServer.Dispose();
                _apiServer = null;
            }
        }
    }
}
