using System;
using System.Data;
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
        protected readonly ISession _session;

        //----------------------------------------------------------------//

        public BaseCommand(IDbConnection connnection)
            : base(connnection, null)
        {}    

        //----------------------------------------------------------------//

        public BaseCommand(ISession session)
            :base(session.Connection, session.Transaction)
        {
            _session = session;
        }
        
        //----------------------------------------------------------------//

        protected abstract string GenerateInsertQuery(T item);

        protected abstract string GenerateUpdateQuery(T item);

        //----------------------------------------------------------------//

        public virtual bool Update(T item)
        {
            string updateQuery = GenerateUpdateQuery(item);
            return _connection.Execute(updateQuery, item, _transaction, _connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

        public virtual async Task<bool> UpdateAsync(T item)
        {
            string updateQuery = GenerateUpdateQuery(item);
            return await _connection.ExecuteAsync(updateQuery, item, _transaction, _connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

        public virtual TKey Insert(T item)
        {
            string insert = GenerateInsertQuery(item);
            return _connection.QueryFirstOrDefault<TKey>(insert, item, _transaction, _connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public virtual async Task<TKey> InsertAsync(T item)
        {
            string insertAsync = GenerateInsertQuery(item);
            return await _connection.QueryFirstOrDefaultAsync<TKey>(insertAsync, item, _transaction, _session.Connection.ConnectionTimeout);
        }

        //----------------------------------------------------------------//

        public bool Delete(TKey key)
        {
            bool isClustered = SqlGenerateHelper.IsClustered<T>();
            string condition = SqlGenerateHelper.GenerateUniqueCondition<T, TKey>(nameof(key), isClustered);
            string deleteEntity = $"DELETE {TableName} WHERE {condition}";
            return _connection.Execute(condition, SqlGenerateHelper.CreatePrimaryKeyParameter(key, isClustered)) > default(int);
        }

        //----------------------------------------------------------------//

        public Boolean Delete(T entity)
        {
            return Delete(entity.Id);
        }

        //----------------------------------------------------------------//

    }
}
