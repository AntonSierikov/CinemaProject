using System;
using System.Threading.Tasks;
using MovieDomain.Abstract;
using MovieDomain.DAL.Helpers;
using MovieDomain.DAL.Abstract;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal abstract class BaseCommand<T, TKey> : BaseDBOperation<T> 
                                                   where T: DbObject<TKey>
    {

        //----------------------------------------------------------------//

        public BaseCommand(ISession session)
            :base(session)
        {}
        
        //----------------------------------------------------------------//

        protected abstract string GenerateInsertQuery(T item);

        protected abstract string GenerateUpdateQuery(T item);

        //----------------------------------------------------------------//

        public bool Update(T item)
        {
            string updateQuery = GenerateUpdateQuery(item);
            return _session.Connection.Execute(updateQuery, item, _session.Transaction, _session.Connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

        public async Task<bool> UpdateAsync(T item)
        {
            string updateQuery = GenerateUpdateQuery(item);
            return await _session.Connection.ExecuteAsync(updateQuery, item, _session.Transaction, _session.Connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

        public TKey Insert(T item)
        {
            string insert = GenerateInsertQuery(item);
            return _session.Connection.QueryFirstOrDefault<TKey>(insert, item, _session.Transaction, _session.Connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public async Task<TKey> InsertAsync(T item)
        {
            string insertAsync = GenerateInsertQuery(item);
            return await _session.Connection.QueryFirstOrDefaultAsync<TKey>(insertAsync, item, _session.Transaction, _session.Connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public bool Delete(TKey key)
        {
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key));
            string deleteEntity = $"DELETE {TableName} WHERE {condition}";
            return _session.Connection.Execute(condition) > default(int);
        }

        //----------------------------------------------------------------//

        public Boolean Delete(T entity)
        {
            return Delete(entity.Id);
        }

        //----------------------------------------------------------------//

    }
}
