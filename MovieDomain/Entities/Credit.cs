using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public class Credit : DbObject<int>
    {
        public int? PeopleId { get; set; }

        public int MovieId { get; set; }

        public People People { get; set; }

        public Movie Movie { get; set; }
    }
}
