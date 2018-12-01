using System.Threading.Tasks;
using System.Data;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class CastQuery : BaseQuery<Cast, int>, ICastQuery
    {

        //----------------------------------------------------------------//

        public CastQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Cast item) => $"WHERE CharacterCast = @{nameof(item.CharacterCast)} AND PeopleId = @{nameof(item.PeopleId)}";

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Cast item)
        {
            string getId = $"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _session.Connection.QueryFirstOrDefaultAsync<int>(getId, item, _session.Transaction);
        }

        //----------------------------------------------------------------//

    }
}
