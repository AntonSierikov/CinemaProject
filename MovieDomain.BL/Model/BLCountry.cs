using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Model
{
    public class BLCountry
    {
        public readonly string CompanyName;

        public readonly string iso_3166_1;


        //----------------------------------------------------------------//

        public BLCountry(string _companyName, string _iso_3166_1)
        {
            CompanyName = _companyName;
            iso_3166_1 = _iso_3166_1;
        }
    }
}
