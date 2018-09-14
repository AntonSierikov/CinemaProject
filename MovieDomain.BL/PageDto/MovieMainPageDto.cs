using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.BL.Dto;

namespace MovieDomain.BL.PageDto
{
    public class MovieMainPageDto
    {
        public FullMovieInfoDto FullMovieInfo { get; private set; }

        public CreditsDto Credits { get; private set; }

        //----------------------------------------------------------------//

        public MovieMainPageDto(FullMovieInfoDto _fullMovieInfo, CreditsDto creditsDto)
        {
            FullMovieInfo = _fullMovieInfo;
            Credits = creditsDto;
        }

        //----------------------------------------------------------------//

    }
}
