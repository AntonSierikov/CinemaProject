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
            AddSessionOperation<ICountryCommand>(s => new ProductionCountryCommand(s));
            AddSessionOperation<IPeopleCommand>(s => new PeopleCommand(s));
            AddSessionOperation<ICastCommand>(s => new CastCommand(s));
            AddSessionOperation<ICrewCommand>(s => new CrewCommand(s));
            AddSessionOperation<IMovieGenreCommand>(s => new MovieGenreCommand(s));
            AddSessionOperation<IMovieCompanyCommand>(s => new MovieCompanyCommand(s));
            AddSessionOperation<IMovieCountryCommand>(s => new MovieCountryCommand(s));
            AddSessionOperation<IJobCommand>(s => new JobCommand(s));
            AddSessionOperation<IDepartmentCommand>(s => new DepartmentCommand(s));
            AddSessionOperation<ITaskInfoCommand>(s => new TaskInfoCommand(s));
        }

        //----------------------------------------------------------------//
    }
}
