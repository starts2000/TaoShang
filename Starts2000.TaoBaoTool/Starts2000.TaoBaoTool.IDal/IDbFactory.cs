using System.Data;

namespace Starts2000.TaoBaoTool.IDal
{
    internal interface IDbFactory
    {
        IDbConnection CreateConnection(bool open = true);
    }
}