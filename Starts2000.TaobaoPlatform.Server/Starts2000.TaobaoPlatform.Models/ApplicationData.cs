namespace Starts2000.TaobaoPlatform.Models
{
    public class ApplicationData
    {
        bool _isClient;
        bool _userExit;
        UpdateInfo _updateInfo;
        User _user;
        readonly object _rootSync = new object();

        public bool UserExit
        {
            get
            {
                lock (_rootSync)
                {
                    return _userExit;
                }
            }
            set
            {
                lock (_rootSync)
                {
                    _userExit = value;
                }
            }
        }

        public bool IsClient
        {
            get
            {
                lock(_rootSync)
                {
                    return _isClient;
                }
            }
            set
            {
                lock(_rootSync)
                {
                    _isClient = value;
                }
            }
        }

        public User User
        {
            get
            {
                lock (_rootSync)
                {
                    return _user;
                }
            }
            set
            {
                lock (_rootSync)
                {
                    _user = value;
                }
            }
        }

        public UpdateInfo UpdateInfo
        {
            get
            {
                lock(_rootSync)
                {
                    return _updateInfo;
                }
            }
            set
            {
                lock(_rootSync)
                {
                    _updateInfo = value;
                }
            }
        }
    }
}
