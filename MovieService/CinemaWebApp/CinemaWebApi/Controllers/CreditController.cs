using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CinemaWebCore.Dto;
using CinemaWebCore.Mappers;
using MovieDomain.BL.ServicesInterface;

namespace CinemaWebApi.Controllers
{
    [Route("Credit")]
    [ApiController]
    public class CreditController : ControllerBase
    {
        private readonly ICreditService _creditsService;


        //----------------------------------------------------------------//

        public CreditController(ICreditService creditsService)
        {
            _creditsService = creditsService;
        }

        //----------------------------------------------------------------//

        [HttpGet]
        [Route("GetAllByMovieId/{movieId:int}")]
        public async Task<ActionResult> GetAllByMovieId(int movieId)
        {
            CreditsDto creditsDto = CreditMapper.MapToCreditsDto(await _creditsService.GetCredits(movieId));
            if (creditsDto != null)
            {
                return Ok(creditsDto);
            }

            return NotFound();
        }

        //----------------------------------------------------------------//

    }
}
