using System;
using System.Configuration;
using System.ServiceProcess;
using Microsoft.Owin.Hosting;

namespace Starts2000.TaobaoPlatform.Manager.Server
{
    public partial class Service : ServiceBase
    {
        IDisposable _apiServer = null;

        public Service()
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
            if (_apiServer != null)
            {
                _apiServer.Dispose();
                _apiServer = null;
            }
        }
    }
}