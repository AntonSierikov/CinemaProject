using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Queries;

namespace MovieDomain.DAL.Factories
{
    public class QueryFactory : SessionOperationFactory, IQueryFactory
    {

        //----------------------------------------------------------------//

        public T CreateQuery<T>(ISession session)
        {
            return Create<T>(session);
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

    }
}
