using System;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;

namespace Starts2000.TaobaoPlatform.Core
{
    internal static class NinjectCommon
    {
        static IKernel _kernel;

        internal static void Start(Action<IBindingRoot> loadingAction)
        {
            ApplicationModule.Instance.Loading = loadingAction;
            CreateKernel();
        }

        internal static void Stop()
        {
            _kernel.Dispose();
        }

        internal static IKernel Kernel
        {
            get { return _kernel; }
        }

        internal static T Resolve<T>()
        {
            return _kernel.Get<T>();
        }

        internal static T Resolve<T>(string name)
        {
            return _kernel.Get<T>(name);
        }

        internal static void Inject(object t)
        {
            if (_kernel == null)
            {
                return;
            }

            _kernel.Inject(t);
        }

        static IKernel CreateKernel()
        {
            _kernel = new StandardKernel();
            try
            {
                //kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                //kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                //RegisterServices(kernel);
                //kernel.Bind<WebPluginManager>().ToConstant(_webPluginManager);
                _kernel.Load(ApplicationModule.Instance);
                return _kernel;
            }
            catch
            {
                _kernel.Dispose();
                throw;
            }
        }

        private sealed class ApplicationModule : NinjectModule
        {
            static readonly ApplicationModule _instance = new ApplicationModule();

            internal static ApplicationModule Instance
            {
                get { return _instance; }
            }

            internal Action<IBindingRoot> Loading
            {
                private get;
                set;
            }

            ApplicationModule()
            {
            }

            public override void Load()
            {
                if (Loading != null)
                {
                    Loading(this);
                }
            }
        }
    }
}