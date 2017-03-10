using Starts2000.TaoBao.Views;

namespace Starts2000.TaoBao.Core
{
    internal class ViewFactory : IViewFactory
    {

        static ViewFactory _instance = new ViewFactory();

        ViewFactory()
        {
        }

        public static ViewFactory Instance
        {
            get { return _instance; }
        }

        #region IViewFactory 成员

        public T GetView<T>() where T : ViewBase
        {
            return Global.Resolve<T>();
        }

        #endregion
    }
}
