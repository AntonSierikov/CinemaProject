using System.Data;
using System.Threading.Tasks;
using MovieDomain.Abstract;
using MovieDomain.DAL.Abstract;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal abstract class EntityKeyCommand<T, TKey> : BaseCommand<T, TKey> where T: DbObject<TKey>
    {

        //----------------------------------------------------------------//

        public EntityKeyCommand(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public EntityKeyCommand(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public override async Task<TKey> InsertAsync(T item)
        {
            string insertAsync = GenerateInsertQuery(item);
            return await _session.Connection.QueryFirstOrDefaultAsync<TKey>(insertAsync, item.Id, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public override async Task<bool> UpdateAsync(T item)
        {
            string updateAsync = GenerateUpdateQuery(item);
            return await _session.Connection.ExecuteAsync(updateAsync, item.Id, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

        public override TKey Insert(T item)
        {
            string insert = GenerateInsertQuery(item);
            return _session.Connection.QueryFirst<TKey>(insert, item.Id, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public override bool Update(T item)
        {
            string update = GenerateUpdateQuery(item);
            return _session.Connection.Execute(update, item.Id, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
