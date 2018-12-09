using MovieDomain.Attributes.Database;

namespace MovieDomain.Identifiers
{
    [ClusteredPrimaryKey]
    public class MovieGenreId
    {

        //----------------------------------------------------------------//

        public int MovieId { get; set; }

        public int GenreId { get; set; }

        //----------------------------------------------------------------//

        public MovieGenreId(int movieId, int genreId)
        {
            MovieId = movieId;
            GenreId = genreId;
        }

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
