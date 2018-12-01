using MovieDomain.Abstract;
using MovieDomain.Identifiers;

namespace MovieDomain.Entities
{
    public class MovieGenre : DbObject<MovieGenreId>
    {

        //----------------------------------------------------------------//

        public Movie Movie { get; set; }

        public Genre Genre { get; set; }

        //----------------------------------------------------------------//


        public MovieGenre(int movieId, int genreId)
        {
            Id = new MovieGenreId(movieId, genreId);
        }

        //----------------------------------------------------------------//

        public MovieGenre(Movie movie, Genre genre)
            : this(movie.Id, genre.Id)
        {
            Movie = movie;
            Genre = genre;
        }

        //----------------------------------------------------------------//

    }
}
