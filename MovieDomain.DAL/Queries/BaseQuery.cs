using System.Threading.Tasks;
using System.Data;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Helpers;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal abstract class BaseQuery<T, TKey> : BaseDBOperation<T> where T: class
    {
    
        //----------------------------------------------------------------//

        public BaseQuery(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        public abstract string GetUniqueConditionByItem(T item);

        //----------------------------------------------------------------//

        public Task<int> Count()
        {
            string count = $"SELECT Count(*) FROM {TableName}";
            return _session.Connection.ExecuteScalarAsync<int>(count, null, _session.Transaction, _session.Connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public virtual Task<T> GetItem(TKey key)
        {
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key));
            string getItem = $"SELECT TOP 1 * FROM {TableName} WHERE {condition}";
            return _session.Connection.QueryFirstOrDefaultAsync<T>(getItem, key, _session.Transaction, _session.Connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public async virtual Task<bool> IsItemExist(TKey key)
        {
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key));
            string itemExist = $"SELECT COUNT(*) FROM {TableName} WHERE {condition}";
            return await _session.Connection.QueryFirstOrDefaultAsync<int>(itemExist, key, _session.Transaction, _session.Connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

        public async virtual Task<bool> IsExist(T item)
        {
            string isExist =  $"SELECT COUNT(*) FROM {TableName} {GetUniqueConditionByItem(item)}";
            return await _session.Connection.ExecuteScalarAsync<int>(isExist, item, _session.Transaction, _session.Connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//
    }
}
