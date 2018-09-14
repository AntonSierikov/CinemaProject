using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebApp.Core.Dto
{
    public class FullMovieInfoDto
    {
        public string Title { get; private set; }
        public int Budget { get; private set; }
        public string Overview { get; private set; }
        public string Poster_Path { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public int Runtime { get; private set; }
        public string Status { get; private set; }
        public string Tagline { get; private set; }
        public string VoteAverage { get; private set; }
        public string VoteCountr { get; private set; }

    }

}
