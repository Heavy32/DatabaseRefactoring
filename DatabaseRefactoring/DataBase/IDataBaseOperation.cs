using System.Data;

namespace DatabaseRefactoring.DataBase
{
    public interface IDataBaseOperation<out TResult, in TInputParameters, in TConnection> 
        where TConnection : IDbConnection
    {
        public TResult Execute(TInputParameters parameters, TConnection connection);
    }
}
