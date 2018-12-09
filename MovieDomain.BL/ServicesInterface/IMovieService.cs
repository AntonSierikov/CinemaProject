using System;
using System.Threading.Tasks;
using MovieDomain.Entities;

namespace MovieDomain.BL.ServicesInterface
{
    public interface IMovieService 
    {

        //----------------------------------------------------------------//

        Task<Movie> GetMovieInfo(int movieId);


        //----------------------------------------------------------------//

    }
}
