using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebApp.Core.Dto
{
    public class CreditsDto
    {
        public List<CastDto> Casts { get; private set; }

        public List<CrewDto> Crews { get; private set; }


        //----------------------------------------------------------------//

        public CreditsDto(List<CastDto> casts, List<CrewDto> crews)
        {
            Casts = casts;
            Crews = crews;
        }

        //----------------------------------------------------------------//


    }
}
