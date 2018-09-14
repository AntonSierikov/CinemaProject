using MovieDomain.Entities;

namespace MovieDomain.DAL.ICommands
{
    public interface IMovieCommand : ICommand<Movie, int>
    {
    }
}
