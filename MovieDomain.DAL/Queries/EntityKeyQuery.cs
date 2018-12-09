using System.Data;
using Dapper;
using System.Threading.Tasks;
using MovieDomain.Abstract;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    //good idea? Separate abstract query for table with only clustered primary key 
    internal abstract class EntityKeyQuery<T, TKey> : BaseQuery<T, TKey> where T : DbObject<TKey>
                                                                         where TKey : class
    {

        //----------------------------------------------------------------//

        public EntityKeyQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//
        public EntityKeyQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public async override Task<bool> IsExist(T item)
        {
            string isExist = $"SELECT COUNT(*) FROM {TableName} {GetUniqueConditionByItem(item)}";
            return await _connection.ExecuteScalarAsync<int>(isExist, item.Id, _transaction, _connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
