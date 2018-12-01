using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public partial class Genre  : DbObject<int>
    { 
        public Genre()
        {
            Movies = new List<Movie>();
        }

        public string genre { get; set; }

        public IList<Movie> Movies { get; set; }

        public Genre(string genre) : this()
        {
            this.genre = genre;
        }

        //----------------------------------------------------------------//

    }
}
