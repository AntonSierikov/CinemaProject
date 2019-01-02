using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CinemaWebCore.Dto;
using CinemaWebCore.PageDto;
using CinemaWebCore.Mappers;
using CinemaWebApi.ParamDto;
using MovieDomain.BL.ServicesInterface;
using MovieDomain.BL.Model.BLFilters;

namespace CinemaWebApi.Controllers
{
    [Route("Movie")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        //----------------------------------------------------------------//

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        //----------------------------------------------------------------//

        [HttpGet]
        [Route("{movieId:int}")]
        public async Task<ActionResult<FullMovieInfoDto>> GetMovieInfo(int movieId)
        {
            FullMovieInfoDto movieDto = MovieMapper.MovieToMovieInfoDto(await _movieService.GetMovieInfo(movieId));
            if(movieDto != null)
            {
                return Ok(movieDto);
            }

            return NotFound();
        }

        //----------------------------------------------------------------//

        [HttpGet]
        [Route("MovieList")]
        public async Task<ActionResult<List<ShortMovieInfoDto>>> MovieList([FromQuery]MovieListFilterDto filter)
        {
            BLMovieListFilter blFIlter = new BLMovieListFilter(filter.Genre, filter.Company, filter.Country, filter.Year, filter.PageNumber);
            var data = await _movieService.GetListingPageMainData(blFIlter);
            List<ShortMovieInfoDto> l_shortMoveiInfo = data.Item1.Select(MovieMapper.MovieToShortMovieInfo).ToList();
            FiltersDto l_filters = FilterMapper.FiltersToDto(data.Item2); 
            return Ok(new ListingPageDto(l_shortMoveiInfo, l_filters));
        }

        //----------------------------------------------------------------//


    }
}