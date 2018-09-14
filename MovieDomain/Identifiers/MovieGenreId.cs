using System;
using System.Collections.Generic;
using System.Text;

namespace MovieDomain.Identifiers
{
    public class MovieGenreId
    {

        //----------------------------------------------------------------//

        public int MovieId { get; set; }

        public int GenreId { get; set; }


        //----------------------------------------------------------------//

        public override bool Equals(object obj)
        {
            MovieGenreId movieGenre = obj as MovieGenreId;
            if(movieGenre != null)
            {
                return movieGenre.MovieId == MovieId && movieGenre.GenreId == GenreId;
            }

            return false; 
        }

        //----------------------------------------------------------------//

        public override int GetHashCode()
        {
            return MovieId.GetHashCode() ^ GenreId.GetHashCode();
        }

        //----------------------------------------------------------------//

    }
}
