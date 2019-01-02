using System.Threading.Tasks;
using System.Collections.Generic;
using MovieDomain.Entities;
using MovieDomain.Filters;
using MovieDomain.DAL.Filters;

namespace MovieDomain.DAL.IQueries
{
    public interface IMovieQuery : IQuery<Movie, int>
    {

        //----------------------------------------------------------------//

        Movie GetMovie(string title);

        Task<Movie> GetMovie(int movieId);

        Task<IEnumerable<Movie>> MovieList(MovieListingFilter filter);

        Task<MovieEntityFilters> GetFilters(MovieListingFilter filter);

        //----------------------------------------------------------------//

    }
}
