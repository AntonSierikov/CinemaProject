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
        public EntityKeyQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public async override Task<bool> IsExist(T item)
        {
            string isExist = $"SELECT COUNT(*) FROM {TableName} {GetUniqueConditionByItem(item)}";
            return await _session.Connection.ExecuteScalarAsync<int>(isExist, item.Id, _session.Transaction, _session.Connection.ConnectionTimeout) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
