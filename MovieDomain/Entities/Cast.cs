using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public partial class Cast : DbObject<int>
    {   
        public string CharacterCast { get; set; }

        public int Gender { get; set; }

        public int? Order { get; set; }

        public int? PeopleId { get; set; }

        public int MovieId { get; set; }
    
        public People People { get; set; }

        public Movie Movie { get; set; } 

        //----------------------------------------------------------------//

        public Cast() { }

        //----------------------------------------------------------------//

        public Cast(string characterCast, int gender, int order)
        {
            CharacterCast = characterCast;
            Gender = gender;
            Order = order;
        }

        //----------------------------------------------------------------//

    }
}
