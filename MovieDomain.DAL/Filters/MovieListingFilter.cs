using MovieDomain.Common.Constans;

namespace MovieDomain.DAL.Filters
{
    public class MovieListingFilter
    {
        public string Genre { get; private set; }
        public string Company { get; private set; }
        public string Country { get; private set; }
        public int Year { get; private set; }
        public int PageNumber { get; private set; }

        public string OrderBy { get; private set; }

        //----------------------------------------------------------------//

        public int Limit { get; private set; }

        public int Offset { get; private set; }

        //----------------------------------------------------------------//

        public MovieListingFilter(string _genre, string _company, string _country, int _year, int _pageNumber)
        {
            Genre = _genre;
            Company = _company;
            Country = _country;
            Year = _year;
            PageNumber = _pageNumber;
            Offset = (GeneralConstants.DEFAULT_LISTING_PAGE_SIZE - 1) * _pageNumber;
        }

        //----------------------------------------------------------------//

    }
}
