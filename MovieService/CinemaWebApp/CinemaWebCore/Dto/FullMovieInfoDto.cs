﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class FullMovieInfoDto
    {
        public readonly string Title;
        public readonly int Budget;
        public readonly string Overview;
        public readonly string Poster_Path;
        public readonly DateTime? ReleaseDate;
        public readonly int? Runtime;
        public readonly string Status;
        public readonly string Tagline;
        public readonly double VoteAverage;
        public readonly int VoteCount;

        //----------------------------------------------------------------//

        public List<string> Genres;

        public List<string> Companies;

        public List<CountryDto> Countries;

        //----------------------------------------------------------------//

        public FullMovieInfoDto(string _title, int _budget, string _overview, string _posterPath,
                                DateTime? _releaseDate, int? _runtime, string _status, string _tagline)
        {
            Title = _title;
            Budget = _budget;
            Overview = _overview;
            Poster_Path = _posterPath;
            ReleaseDate = _releaseDate;
            Runtime = _runtime;
            Status = _status;
            Tagline = _tagline;
        }

        //----------------------------------------------------------------//

    }

}
