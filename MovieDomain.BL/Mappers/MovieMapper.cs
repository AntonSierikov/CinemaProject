using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;
using MovieDomain.BL.Dto;


namespace MovieDomain.BL.Mappers
{
    public static class MovieMapper
    {

        //----------------------------------------------------------------//

        public static FullMovieInfoDto MovieToMovieInfoDto(Movie movie)
        {
            FullMovieInfoDto fullMovieInfoDto = null;
            if(movie != null)
            {
                fullMovieInfoDto = new FullMovieInfoDto();
                fullMovieInfoDto.Runtime = movie.Runtime;
                fullMovieInfoDto.Title = movie.Title;
                fullMovieInfoDto.Budget = movie.Budget;
                fullMovieInfoDto.Overview = movie.Overview;
                fullMovieInfoDto.Poster_Path = movie.Poster_path;
                fullMovieInfoDto.ReleaseDate = movie.ReleaseDate;
                fullMovieInfoDto.Tagline = movie.Tagline;
                fullMovieInfoDto.VoteAverage = movie.VoteAverage;
                fullMovieInfoDto.VoteCount = movie.VoteCount;
            }

            return fullMovieInfoDto;
        }

        //----------------------------------------------------------------//

    }
}
