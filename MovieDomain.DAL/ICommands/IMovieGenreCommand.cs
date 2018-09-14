using MovieDomain.Entities;
using MovieDomain.Identifiers;

namespace MovieDomain.DAL.ICommands
{
    public interface IMovieGenreCommand : ICommand<MovieGenre, MovieGenreId>
    {
    }
}
