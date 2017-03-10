using Starts2000.TaobaoPlatform.Models;

namespace Starts2000.TaoBaoTool.IBll
{
    internal interface ILoginCfgBll
    {
        LoginCfg Get();

        bool AddOrUpdate(LoginCfg cfg);

        bool UpdatePassword(string account, string password);

        bool Delete(LoginCfg cfg);
    }
}