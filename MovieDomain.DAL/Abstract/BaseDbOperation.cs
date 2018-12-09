using System.Data;
using MovieDomain.DAL.Factories;

namespace MovieDomain.DAL.Abstract
{
    internal abstract class BaseDBOperation<T> where T: class
    {

        protected readonly IDbConnection _connection;

        protected readonly IDbTransaction _transaction;

        protected readonly string TableName;

        //----------------------------------------------------------------//

        public BaseDBOperation(IDbConnection connection, IDbTransaction transaction)
        {
            _connection = connection;
            _transaction = transaction;
            TableName = TableFactory.GetNameTable<T>();
        }

        //----------------------------------------------------------------//

    }
}
