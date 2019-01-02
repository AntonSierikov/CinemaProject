using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class ShortMovieInfoDto
    {
        public readonly string Title;
        public readonly int Budget;
        public readonly string Poster_Path;
        public readonly DateTime? ReleaseDate;
        public readonly int? Runtime;
        public readonly string Status;
        public readonly string Tagline;
        public readonly double VoteAverage;
        public readonly int VoteCount;

        //----------------------------------------------------------------//

        public List<GenreDto> Genres;

        public List<CompanyDto> Companies;

        public List<CountryDto> Countries;

        //----------------------------------------------------------------//

        public ShortMovieInfoDto(string _title, int _budget, string _posterPath,
                                DateTime? _releaseDate, int? _runtime, string _status, string _tagline)
        {
            Title = _title;
            Budget = _budget;
            Poster_Path = _posterPath;
            ReleaseDate = _releaseDate;
            Runtime = _runtime;
            Status = _status;
            Tagline = _tagline;
        }

        //----------------------------------------------------------------//

    }

}
