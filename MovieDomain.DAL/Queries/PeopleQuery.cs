using System.Threading.Tasks;
using System.Data;
using Dapper;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.Entities;

namespace MovieDomain.DAL.Queries
{
    internal class PeopleQuery : BaseQuery<People, int>, IPeopleQuery
    {

        //----------------------------------------------------------------//

        public PeopleQuery(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public PeopleQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(People item)
        {
            return $@"WHERE Name = @{nameof(item.Name)} AND Birthday = @{nameof(item.Birthday)} AND
                            PlaceOfBirth = @{nameof(item.PlaceOfBirth)}";
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(People item)
        {
            string getById = $@"SELECT COUNT(*) FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getById, item, _transaction);
        }

        //----------------------------------------------------------------//

    }
}
