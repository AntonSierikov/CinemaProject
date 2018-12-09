using System.Data;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Queries;

namespace MovieDomain.DAL.Factories
{
    public class QueryFactory : DbOperationFactory, IQueryFactory
    {

        //----------------------------------------------------------------//

        public T CreateQuery<T>(ISession session)
        {
            return Create<T>(session);
        }

        //----------------------------------------------------------------//

        public T CreateQuery<T>(IDbConnection connection)
        {
            return Create<T>(connection);
        }

        //----------------------------------------------------------------//

        protected override void InitSessionOperations()
        {
            AddSessionOperation<IGenreQuery>(s => new GenreQuery(s));
            AddSessionOperation<IMovieQuery>(s => new MovieQuery(s));
            AddSessionOperation<ICastQuery>(s => new CastQuery(s));
            AddSessionOperation<ICrewQuery>(s => new CrewQuery(s));
            AddSessionOperation<IPeopleQuery>(s => new PeopleQuery(s));
            AddSessionOperation<IJobQuery>(s => new JobQuery(s));
            AddSessionOperation<ITaskQuery>(s => new TaskInfoQuery(s));
            AddSessionOperation<ICountryQuery>(s => new CountryQuery(s));
            AddSessionOperation<ICompanyQuery>(s => new CompanyQuery(s));
            AddSessionOperation<IMovieGenreQuery>(s => new MovieGenreQuery(s));
            AddSessionOperation<IMovieCompanyQuery>(s => new MovieCompanyQuery(s));
            AddSessionOperation<IMovieCountryQuery>(s => new MovieCountryQuery(s));
            AddSessionOperation<IDepartmentQuery>(s => new DepartmentQuery(s));
        }

        //----------------------------------------------------------------//

        protected override void InitConnectionOperations()
        {
            AddConnectionOperation<IGenreQuery>(c => new GenreQuery(c));
            AddConnectionOperation<IMovieQuery>(c => new MovieQuery(c));
            AddConnectionOperation<ICastQuery>(c => new CastQuery(c));
            AddConnectionOperation<ICrewQuery>(c => new CrewQuery(c));
            AddConnectionOperation<IPeopleQuery>(c => new PeopleQuery(c));
            AddConnectionOperation<IJobQuery>(c => new JobQuery(c));
            AddConnectionOperation<ITaskQuery>(c => new TaskInfoQuery(c));
            AddConnectionOperation<ICountryQuery>(c => new CountryQuery(c));
            AddConnectionOperation<IMovieGenreQuery>(c => new MovieGenreQuery(c));
            AddConnectionOperation<IMovieCompanyQuery>(c => new MovieGenreQuery(c));
            AddConnectionOperation<IMovieCountryQuery>(c => new MovieCountryQuery(c));
            AddConnectionOperation<IDepartmentQuery>(c => new DepartmentQuery(c));
        }
    }
}
