using Dapper;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class MovieCompanyQuery : BaseQuery<MovieCompany, MovieCompanyId>, IMovieCompanyQuery
    {

        //----------------------------------------------------------------//

        public MovieCompanyQuery(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        public bool IsExist(MovieCompany item)
        {
            string isExist = $@"SELECT Count(*) FROM MovieCompany WHERE 
                                MovieId = @{nameof(item.Id.MovieId)} AND CompanyId = @{nameof(item.Id.CompanyId)}";
            return _session.Connection.ExecuteScalar<int>(isExist, item.Id, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//


    }
}
