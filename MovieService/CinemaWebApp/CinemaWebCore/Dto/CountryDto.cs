using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaWebCore.Dto
{
    public class CountryDto
    {

        //----------------------------------------------------------------//

        public readonly string CountryName;

        public readonly string ISO_3166_1;

        //----------------------------------------------------------------//

        public CountryDto(string countryName, string iso_3166)
        {
            CountryName = countryName;
            ISO_3166_1 = iso_3166;
        }

        //----------------------------------------------------------------//

    }
}
