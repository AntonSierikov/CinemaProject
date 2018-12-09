using System.Data;
using System.Threading.Tasks;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.Identifiers;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal class MovieGenreQuery : EntityKeyQuery<MovieGenre, MovieGenreId>, IMovieGenreQuery
    {
        public MovieGenreQuery(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public MovieGenreQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(MovieGenre item)
        {
            return $"WHERE MovieId = @{nameof(item.Id.MovieId)} AND GenreId = @{nameof(item.Id.GenreId)}";
        }

        //----------------------------------------------------------------//

        public Task<MovieGenreId> GetIdByItem(MovieGenre item)
        {
            string getById = $@"SELECT MovieId, GenreId FROM {TableName} {GetUniqueConditionByItem(item)}";
            return _connection.QueryFirstOrDefaultAsync<MovieGenreId>(getById, item.Id, _transaction);
        }

        //----------------------------------------------------------------//

    }
}
