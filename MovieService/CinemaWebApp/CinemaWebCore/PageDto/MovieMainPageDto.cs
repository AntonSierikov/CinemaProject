using System;
using System.Collections.Generic;
using System.Text;
using CinemaWebCore.Dto;

namespace CinemaWebCore.PageDto
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
