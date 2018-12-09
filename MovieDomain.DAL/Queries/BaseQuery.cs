using System.Threading.Tasks;
using System.Data;
using MovieDomain.Abstract;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Helpers;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal abstract class BaseQuery<T, TKey> : BaseDBOperation<T> where T: DbObject<TKey>
    {

        //----------------------------------------------------------------//

        public BaseQuery(IDbConnection connection)
            : base(connection, null)
        {}

        //----------------------------------------------------------------//

        public BaseQuery(ISession session)
            : base(session.Connection, session.Transaction)
        {}

        //----------------------------------------------------------------//

        public abstract string GetUniqueConditionByItem(T item);

        //----------------------------------------------------------------//

        public Task<int> Count()
        {
            string count = $"SELECT Count(*) FROM {TableName}";
            return _connection.ExecuteScalarAsync<int>(count, null, _transaction, _connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public virtual Task<T> GetItem(TKey key)
        {
            bool isClustered = SqlGenerateHelper.IsClustered<T>();
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key), isClustered);
            string getItem = $"SELECT TOP 1 * FROM {TableName} WHERE {condition}";
            return _connection.QueryFirstOrDefaultAsync<T>(getItem, SqlGenerateHelper.CreatePrimaryKeyParameter(key, isClustered), _transaction, _connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public async virtual Task<bool> IsItemExist(TKey key)
        {
            bool isClustered = SqlGenerateHelper.IsClustered<T>();
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key), isClustered);
            string itemExist = $"SELECT COUNT(*) FROM {TableName} WHERE {condition}";
            return await _connection.QueryFirstOrDefaultAsync<int>(itemExist, SqlGenerateHelper.CreatePrimaryKeyParameter(key, isClustered), _transaction, _connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

        public async virtual Task<bool> IsExist(T item)
        {
            string isExist =  $"SELECT COUNT(*) FROM {TableName} {GetUniqueConditionByItem(item)}";
            return await _connection.ExecuteScalarAsync<int>(isExist, item, _transaction, _connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//
    }
}
