using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Identifiers
{
    public class MovieCountryId
    {

        //----------------------------------------------------------------//

        public int MovieId { get; set; }

        public int CountryId { get; set; }

        //----------------------------------------------------------------//

        public MovieCountryId(int movieId, int countryId)
        {
            MovieId = movieId;
            CountryId = countryId;
        }

        //----------------------------------------------------------------//

        public override bool Equals(object obj)
        {
            MovieCountryId movieCountry = obj as MovieCountryId;
            if(obj != null)
            {
                return movieCountry.MovieId.Equals(MovieId) && movieCountry.CountryId.Equals(CountryId);
            }

            return false;
        }

        //----------------------------------------------------------------//

        public override int GetHashCode()
        {
            return CountryId.GetHashCode() ^ MovieId.GetHashCode();
        }

        //----------------------------------------------------------------//

    }
}
