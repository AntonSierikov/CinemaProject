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
        }

        //----------------------------------------------------------------//

    }
}
