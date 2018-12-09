using System.Data;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Commands;

namespace MovieDomain.DAL.Factories
{
    public class CommandFactory : DbOperationFactory, ICommandFactory
    {

        //----------------------------------------------------------------//

        public T CreateCommand<T>(ISession session)
        {
            return Create<T>(session);
        }

        //----------------------------------------------------------------//

        public T CreateCommand<T>(IDbConnection connection)
        {
            return Create<T>(connection);
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

        protected override void InitConnectionOperations()
        {
            AddConnectionOperation<IMovieCommand>(c => new MovieCommand(c));
            AddConnectionOperation<IGenreCommand>(c => new GenreCommand(c));
            AddConnectionOperation<ICompanyCommand>(c => new ProductionCompanyCommand(c));
            AddConnectionOperation<ICountryCommand>(c => new ProductionCountryCommand(c));
            AddConnectionOperation<IPeopleCommand>(c => new PeopleCommand(c));
            AddConnectionOperation<ICastCommand>(c => new CastCommand(c));
            AddConnectionOperation<ICrewCommand>(c => new CrewCommand(c));
            AddConnectionOperation<IMovieGenreCommand>(c => new MovieGenreCommand(c));
            AddConnectionOperation<IMovieCompanyCommand>(c => new MovieCompanyCommand(c));
            AddConnectionOperation<IMovieCountryCommand>(c => new MovieCountryCommand(c));
            AddConnectionOperation<IJobCommand>(c => new JobCommand(c));
            AddConnectionOperation<IDepartmentCommand>(c => new DepartmentCommand(c));
            AddConnectionOperation<ITaskInfoCommand>(c => new TaskInfoCommand(c));
        }
    }
}
