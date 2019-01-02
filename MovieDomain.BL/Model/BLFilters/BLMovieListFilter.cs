using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Model.BLFilters
{
    public class BLMovieListFilter
    {
        public string Genre { get; private set; }
        public string Company { get; private set; }
        public string Country { get; private set; }
        public int Year { get; private set; }
        public int PageNumber { get; private set; }

        //----------------------------------------------------------------//

        public BLMovieListFilter(string _genre, string _company, string _country, int _year, int _pageNumber)
        {
            Genre = _genre;
            Company = _company;
            Country = _country;
            Year = _year;
            PageNumber = _pageNumber;
        }

        //----------------------------------------------------------------//

    }
}
