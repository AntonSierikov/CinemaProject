using System.Collections.Generic;
using MovieDomain.Abstract;

namespace MovieDomain.Entities
{
    public class Genre: DbObject<int>
    { 
        public Genre()
        {
            Movies = new HashSet<Movie>();
        }

        public string genre { get; set; }

        public HashSet<Movie> Movies { get; set; }

        public Genre(string genre) : this()
        {
            this.genre = genre;
        }

        //----------------------------------------------------------------//

    }
}
