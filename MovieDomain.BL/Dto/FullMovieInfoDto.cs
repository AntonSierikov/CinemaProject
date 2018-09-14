using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Dto
{
    public class FullMovieInfoDto
    {
        public string Title;
        public int Budget;
        public string Overview;
        public string Poster_Path;
        public DateTime ReleaseDate;
        public int? Runtime;
        public string Status;
        public string Tagline;
        public double VoteAverage;
        public int VoteCount;
    }

}
