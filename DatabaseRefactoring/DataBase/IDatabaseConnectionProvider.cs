using System.Data;

namespace DatabaseRefactoring.DataBase
{
    public interface IDatabaseConnectionProvider<TConnection> where TConnection : IDbConnection
    {
        public TConnection CreateConnection();
    }
}
