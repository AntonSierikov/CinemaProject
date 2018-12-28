using System.Threading.Tasks;
using MovieDomain.Entities;

namespace MovieDomain.DAL.IQueries
{
    public interface IMovieQuery : IQuery<Movie, int>
    {

        //----------------------------------------------------------------//

        Movie GetMovie(string title);

        Task<Movie> GetMovie(int movieId);

        //----------------------------------------------------------------//

    }
}
