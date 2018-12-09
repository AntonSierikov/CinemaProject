using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Model
{
    public class BLMovie
    {

        //----------------------------------------------------------------//

        public readonly string Title;
        public readonly int Budget;
        public readonly string Overview;
        public readonly string Poster_Path;
        public readonly DateTime ReleaseDate;
        public readonly int? Runtime;
        public readonly string Status;
        public readonly string Tagline;

        //----------------------------------------------------------------//
        //Should be recalculated

        public double VoteAverage;
        public int VoteCount;

        //----------------------------------------------------------------//
        //SubEntities
        
        public IEnumerable<BLShortCast> BLShortCasts { get; set; }
        public IEnumerable<string> Genres { get; set; } //need split object?
        public IEnumerable<string> ProductionCompanies { get; set; } //need split object?
        public IEnumerable<BLShortCrew> BLShortCrews { get; set; }
        public IEnumerable<BLCountry> BLCountries { get; set; }

        //----------------------------------------------------------------//

        public BLMovie(string _title, int _budget, string _overview, string _posterPath,
                       DateTime _releaseDate, int? _runtime, string _status, string _tagline)
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

    }
}
