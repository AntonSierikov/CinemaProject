using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class FullMovieInfoDto : ShortMovieInfoDto
    {
        public readonly string Overview;

        public FullMovieInfoDto(string _title, int _budget, string _overview, string _posterPath,
                                DateTime? _releaseDate, int? _runtime, string _status, string _tagline)
            : base(_title, _budget, _posterPath, _releaseDate, _runtime, _status, _tagline)
        {
            Overview = _overview;
        }
    }
}
