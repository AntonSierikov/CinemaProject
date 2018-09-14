using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;
using MovieDomain.Common.Services;
using MovieDomain.BL.PageDto;
using MovieDomain.BL.Dto;
using MovieDomain.DAL.IQueries;
using Microsoft.Extensions.DependencyInjection;

namespace MovieDomain.BL.ServicesImpl
{
    internal class MovieService
    {

        //----------------------------------------------------------------//

        public MovieService() {}

        //----------------------------------------------------------------//

        public MovieMainPageDto GetMovieInfo(int movieId)
        {
            IMovieQuery query = ServiceLocator.ServiceProvider.GetService<IMovieQuery>();
            Movie movie = query.GetItem(movieId);

            MovieMainPageDto movieMainPageDto = new MovieMainPageDto();
        }

        //----------------------------------------------------------------//


    }
}
