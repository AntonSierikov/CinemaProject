using System;
using System.Collections.Generic;
using System.Text;
using CinemaWebCore.Dto;

namespace CinemaWebCore.PageDto
{
    public class MovieMainPageDto
    {
        public ShortMovieInfoDto FullMovieInfo { get; private set; }

        public CreditsDto Credits { get; private set; }

        //----------------------------------------------------------------//

        public MovieMainPageDto(ShortMovieInfoDto _fullMovieInfo, CreditsDto creditsDto)
        {
            FullMovieInfo = _fullMovieInfo;
            Credits = creditsDto;
        }

        //----------------------------------------------------------------//

    }
}
