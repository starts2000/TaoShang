using Starts2000.TaobaoPlatform.Models;
using Starts2000.TaoBaoTool.IBll;
using Starts2000.TaoBaoTool.IDal;

namespace Starts2000.TaoBao.Core.Bll
{
    class LoginCfgBll : ILoginCfgBll
    {
        readonly ILoginCfgDal _logincfgDal;

        public LoginCfgBll(ILoginCfgDal logincfgDal)
        {
            _logincfgDal = logincfgDal;
        }

        #region ILoginCfgBll 成员

        public LoginCfg Get()
        {
            return _logincfgDal.Get();
        }

        public bool AddOrUpdate(LoginCfg cfg)
        {
            if(_logincfgDal.Exits(cfg))
            {
                return _logincfgDal.Update(cfg);
            }

            return _logincfgDal.Add(cfg);
        }

        public bool UpdatePassword(string account, string password)
        {
            return _logincfgDal.UpdatePassword(account, password);
        }

        public bool Delete(LoginCfg cfg)
        {
            return _logincfgDal.Delete(cfg);
        }

        #endregion
    }
}
