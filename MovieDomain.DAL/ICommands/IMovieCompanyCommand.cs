using MovieDomain.Entities;
using MovieDomain.Identifiers;

namespace MovieDomain.DAL.ICommands
{
    public interface IMovieCompanyCommand : ICommand<MovieCompany, MovieCompanyId>
    {
    }
}
