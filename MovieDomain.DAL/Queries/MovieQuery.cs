using System.Threading.Tasks;
using System.Collections.Generic;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;
using MovieDomain.DAL.DbModels.CreditModels;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal class MovieQuery : BaseQuery<Movie, int>, IMovieQuery
    {

        //----------------------------------------------------------------//

        public MovieQuery(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        public Movie GetMovie(string title)
        {
            string selectMovieByTitle = $"SELECT TOP 1 * FROM {TableConstans.MOVIE} WHERE Title = @title";
            return _session.Connection.QueryFirstOrDefault<Movie>(selectMovieByTitle, new { title }, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public IEnumerable<CastsModel> GetMovieCasts(int movieID)
        {
            string selectMovieCredits = $"SELECT * FROM {TableConstans.CAST} WHERE MovieId = @{nameof(movieID)}";
            return _session.Connection.Query<CastsModel>(selectMovieCredits, new { movieID }, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Movie item)
        {
            return $"WHERE Title = @{nameof(item.Title)} AND Status = @{nameof(item.Status)} AND ReleaseDate = @{nameof(item.ReleaseDate)}";
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Movie movie)
        {
            string getMovie = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(movie)}";
            return _session.Connection.QueryFirstOrDefaultAsync<int>(getMovie, movie, _session.Transaction);
        }

        //----------------------------------------------------------------//

    }
}
