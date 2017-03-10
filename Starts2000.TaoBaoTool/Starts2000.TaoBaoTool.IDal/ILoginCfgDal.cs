using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IDal
{
    internal interface ILoginCfgDal
    {
        bool Exits(LoginCfg cfg);

        bool Add(LoginCfg cfg);

        bool Update(LoginCfg cfg);

        bool UpdatePassword(string account, string password);

        LoginCfg Get();

        bool Delete(LoginCfg cfg);
    }
}
