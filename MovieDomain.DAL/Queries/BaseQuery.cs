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

        public int Count()
        {
            string count = $"SELECT Count(*) FROM {TableName}";
            return _session.Connection.ExecuteScalar<int>(count, null, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public virtual T GetItem(TKey key)
        {
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key));
            string getItem = $"SELECT TOP 1 * FROM {TableName} WHERE {condition}";
            return _session.Connection.QueryFirstOrDefault<T>(getItem, key, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public virtual bool IsItemExist(TKey key)
        {
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key));
            string itemExist = $"SELECT COUNT(*) FROM {TableName} WHERE {condition}";
            return _session.Connection.QueryFirstOrDefault<int>(itemExist, key, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
