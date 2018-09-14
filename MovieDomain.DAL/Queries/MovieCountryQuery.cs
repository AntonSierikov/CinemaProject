using Dapper;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class MovieCountryQuery : BaseQuery<MovieCountry, MovieCountryId>, IMovieCountryQuery
    {

        //----------------------------------------------------------------//

        public MovieCountryQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public bool IsExist(MovieCountry item)
        {
            string isExist = $@"SELECT Count(*) FROM {TableName} WHERE MovieId = @{nameof(item.Id.MovieId)} AND 
                                                                       CountryId = @{nameof(item.Id.CountryId)}";
            return _session.Connection.ExecuteScalar<int>(isExist, item, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
