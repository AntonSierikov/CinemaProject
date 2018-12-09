using System;
using System.Collections.Generic;
using System.Linq;
using MovieDomain.Entities;
using MovieDomain.BL.Model;
using CinemaWebCore.Dto;

namespace CinemaWebCore.Mappers
{
    public static class CreditMapper
    {

        //----------------------------------------------------------------//

        public static CreditsDto MapToCreditsDto(IEnumerable<Cast> casts, IEnumerable<Crew> crews)
        {
            List<CastDto> castsDto = casts.Select(c => new CastDto(c.CharacterCast, c.People.Name)).ToList();
            List<CrewDto> crewsDto = crews.Select(c => new CrewDto(c.Job.job, c.Job.Department?.DepartmentName, c.People.Name)).ToList();
            return new CreditsDto(castsDto, crewsDto);
        }

        //----------------------------------------------------------------//

        public static CreditsDto MapToCreditsDto(BLCredits credits)
        {
            return MapToCreditsDto(credits.Casts, credits.Crews);
        }

        //----------------------------------------------------------------//

    }
}
