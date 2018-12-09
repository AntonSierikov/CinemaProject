using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;
using CinemaWebCore.Dto;


namespace CinemaWebCore.Mappers
{
    public static class MovieMapper
    {

        //----------------------------------------------------------------//

        public static FullMovieInfoDto MovieToMovieInfoDto(Movie movie)
        {
            FullMovieInfoDto fullMovieInfoDto = null;
            if(movie != null)
            {
                fullMovieInfoDto = new FullMovieInfoDto(movie.Title, movie.Budget, movie.Overview, movie.Poster_path, 
                                                        movie.ReleaseDate, movie.Runtime, movie.Status, movie.Tagline);
            }

            return fullMovieInfoDto;
        }

        //----------------------------------------------------------------//

    }
}
