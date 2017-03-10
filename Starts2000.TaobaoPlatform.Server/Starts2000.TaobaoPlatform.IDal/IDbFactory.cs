using System.Data;

namespace Starts2000.TaobaoPlatform.IDal
{
    public interface IDbFactory
    {
        IDbConnection CreateConnection(bool open = true);
    }
}