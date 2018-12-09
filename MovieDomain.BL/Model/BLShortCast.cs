using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.BL.Model
{
    public class BLShortCast
    {

        //----------------------------------------------------------------//

        public readonly string CharacterCast;
        public readonly string Gender;
        public readonly int Order;
        public readonly string PeopleName;
        public readonly int Popularity;

        //----------------------------------------------------------------//

        public BLShortCast(string _characterCast, string _gender, int _order, 
                           string _peopleName, int _popularity)
        {
            CharacterCast = _characterCast;
            Gender = _gender;
            Order = _order;
            PeopleName = _peopleName;
            Popularity = _popularity;
        }

        //----------------------------------------------------------------//

    }
}
