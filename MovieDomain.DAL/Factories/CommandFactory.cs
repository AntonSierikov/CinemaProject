using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Commands;

namespace MovieDomain.DAL.Factories
{
    public class CommandFactory : SessionOperationFactory, ICommandFactory
    {

        //----------------------------------------------------------------//

        public T CreateCommand<T>(ISession session)
        {
            return Create<T>(session);
        }

        //----------------------------------------------------------------//

        protected override void InitSessionOperations()
        {
            AddSessionOperation<IMovieCommand>(s => new MovieCommand(s));
            AddSessionOperation<IGenreCommand>(s => new GenreCommand(s));
            AddSessionOperation<ICompanyCommand>(s => new ProductionCompanyCommand(s));
            commands.Add(typeof(ICommand<ProductionCountry, int>), s => new ProductionCountryCommand(s));
            commands.Add(typeof(ICommand<People, int>), s => new PeopleCommand(s));
            commands.Add(typeof(ICommand<Cast, int>), s => new CastCommand(s));
            commands.Add(typeof(ICommand<Crew, int>), s => new CrewCommand(s));
        }

        //----------------------------------------------------------------//
    }
}
