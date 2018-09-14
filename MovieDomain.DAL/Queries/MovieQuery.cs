using System.Data;
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

        public bool IsExist(Movie movie)
        {
            string getMovie = $@"SELECT COUNT(*) FROM {TableName} WHERE Title = @{nameof(movie.Title)} AND 
                                                                        Status = @{nameof(movie.Status)} AND 
                                                                        ReleaseDate = @{nameof(movie.ReleaseDate)}";
            return _session.Connection.QueryFirstOrDefault<int>(getMovie, movie, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
