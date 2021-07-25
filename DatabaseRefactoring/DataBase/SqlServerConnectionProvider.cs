using Microsoft.Data.SqlClient;

namespace DatabaseRefactoring.DataBase
{
    public class SqlServerConnectionProvider : IDatabaseConnectionProvider<SqlConnection>
    {
        private readonly string connectionString;

        public SqlServerConnectionProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
