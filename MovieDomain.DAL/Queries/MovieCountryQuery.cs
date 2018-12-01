using Dapper;
using System.Threading.Tasks;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class MovieCountryQuery : EntityKeyQuery<MovieCountry, MovieCountryId>, IMovieCountryQuery
    {

        //----------------------------------------------------------------//

        public MovieCountryQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(MovieCountry item)
        {
            return $"WHERE MovieId = @{nameof(item.Id.MovieId)} AND CountryId = @{nameof(item.Id.CountryId)}"
;        }

        //----------------------------------------------------------------//

        public Task<MovieCountryId> GetIdByItem(MovieCountry item)
        {
            string getById = $@"SELECT MovieId, CountryId FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _session.Connection.QueryFirstOrDefaultAsync<MovieCountryId>(getById, item, _session.Transaction);
        }

        //----------------------------------------------------------------//

    }
}
