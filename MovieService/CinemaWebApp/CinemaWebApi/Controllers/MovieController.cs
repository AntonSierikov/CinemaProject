using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaWebCore.Dto;
using CinemaWebCore.Mappers;
using MovieDomain.BL.ServicesInterface;

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


    }
}