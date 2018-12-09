using Dapper;
using System.Data;
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

        public MovieCompanyQuery(IDbConnection connection) : base(connection)
        {}

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
            return _connection.QueryFirstOrDefaultAsync<MovieCompanyId>(isExist, item.Id, _transaction);
        }

        //----------------------------------------------------------------//


    }
}
