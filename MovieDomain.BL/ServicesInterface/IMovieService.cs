using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.Entities;
using MovieDomain.Filters;
using MovieDomain.BL.Model.BLFilters;

namespace MovieDomain.BL.ServicesInterface
{
    public interface IMovieService 
    {

        //----------------------------------------------------------------//

        Task<Movie> GetMovieInfo(int movieId);

        Task<Tuple<IEnumerable<Movie>, MovieEntityFilters>> GetListingPageMainData(BLMovieListFilter filter);

        //----------------------------------------------------------------//

    }
}
