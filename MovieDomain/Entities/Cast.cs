using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public class Cast : Credit
    {   
        public string CharacterCast { get; set; }

        public int Gender { get; set; }

        public int? Sequence { get; set; }

        //----------------------------------------------------------------//

        public Cast() { }

        //----------------------------------------------------------------//

        public Cast(string characterCast, int gender, int order)
        {
            CharacterCast = characterCast;
            Gender = gender;
            Sequence = order;
        }

        //----------------------------------------------------------------//

    }
}
