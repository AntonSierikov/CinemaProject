using Dapper;
using System.Threading.Tasks;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Queries
{
    internal class MovieCompanyQuery : EntityKeyQuery<MovieCompany, MovieCompanyId>, IMovieCompanyQuery
    {

        //----------------------------------------------------------------//

        public MovieCompanyQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(MovieCompany item)
        {
            return $"WHERE MovieId = @{nameof(item.Id.MovieId)} AND CompanyId = @{nameof(item.Id.CompanyId)}";
        }

        //----------------------------------------------------------------//

        public Task<MovieCompanyId> GetIdByItem(MovieCompany item)
        {
            string isExist = $@"SELECT MovieId, CompanyId FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _session.Connection.QueryFirstOrDefaultAsync<MovieCompanyId>(isExist, item.Id, _session.Transaction);
        }

        //----------------------------------------------------------------//


    }
}
