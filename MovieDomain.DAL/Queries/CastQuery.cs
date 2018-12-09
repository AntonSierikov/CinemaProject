using System.Threading.Tasks;
using System.Data;
using System.Collections.Generic;
using Dapper;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Mappers;

namespace MovieDomain.DAL.Queries
{
    internal class CastQuery : BaseQuery<Cast, int>, ICastQuery
    {

        //----------------------------------------------------------------//

        public CastQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//

        public CastQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Cast item) => $"WHERE CharacterCast = @{nameof(item.CharacterCast)} AND PeopleId = @{nameof(item.PeopleId)}";

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Cast item)
        {
            string getId = $"SELECT Id FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getId, item, _transaction);
        }

        //----------------------------------------------------------------//

        public async Task<IEnumerable<Cast>> GetCastsWithShortPeopleInfo(int movieId)
        {
            string getCast = $@"SELECT c.CharacterCast,
                                       c.Gender, 
                                       c.Sequence,
                                       p.Name,
                                       p.Imdb_id,
                                       p.Popularity
                                FROM {TableName} c JOIN People p ON c.PeopleId = p.Id
                                WHERE c.MovieId = @{nameof(movieId)}";

            return await _connection.QueryAsync<Cast, People, Cast>(getCast, CreditMapFunc.CastQueryMap, new { movieId }, _transaction, splitOn: "Name");
        }

        //----------------------------------------------------------------//

    }
}
