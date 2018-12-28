using System.Linq;
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
                fullMovieInfoDto.Companies = movie.ProductionCompanies.Select(c => new CompanyDto(c.Id, c.Name)).ToList();
                fullMovieInfoDto.Countries = movie.ProductionCountries.Select(c => new CountryDto(c.Name, c.iso_3166_1)).ToList();
                fullMovieInfoDto.Genres = movie.Genres.Select(g => new GenreDto(g.Id, g.genre)).ToList();
            }

            return fullMovieInfoDto;
        }

        //----------------------------------------------------------------//

    }
}
