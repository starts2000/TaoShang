namespace Starts2000.Net.Session.Dispatcher
{
    public class DispatcherFactory
    {
        static readonly IDispatcher _dispatcher = new DirectDispatcher();

        public static IDispatcher GetDispatcher()
        {
            return _dispatcher;
        }
    }
}
