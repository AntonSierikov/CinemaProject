using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.Common.Extensions;
using MovieDomain.Entities;
using MovieDomain.Filters;
using MovieDomain.DAL.Filters;
using MovieDomain.DAL.IQueries;
using MovieDomain.BL.Model.BLFilters;
using MovieDomain.BL.ServicesInterface;

namespace MovieDomain.BL.ServicesImpl
{
    internal class MovieService : BaseService, IMovieService
    {
        //----------------------------------------------------------------//

        public MovieService(IServiceProvider provider)
            : base(provider)
        {}

        //----------------------------------------------------------------//

        public async Task<Movie> GetMovieInfo(int movieId)
        {
            Movie movie = null;
            using (IDbConnection connection = OpenConnection())
            {
                IMovieQuery query = queryFactory.CreateQuery<IMovieQuery>(connection);
                movie = await query.GetMovie(movieId);
            }

            return movie;
        }

        //----------------------------------------------------------------//

        public async Task<Tuple<IEnumerable<Movie>, MovieEntityFilters>> GetListingPageMainData(BLMovieListFilter filter)
        {
            IEnumerable<Movie> shortMovieInfo = null;
            Task<MovieEntityFilters> t_filters = null;
            using (IDbConnection connection = OpenConnection())
            {
                ICastQuery castQuery = queryFactory.CreateQuery<ICastQuery>(connection);
                ICrewQuery crewQuery = queryFactory.CreateQuery<ICrewQuery>(connection);
                IMovieQuery query = queryFactory.CreateQuery<IMovieQuery>(connection);

                MovieListingFilter currentFilter = new MovieListingFilter(filter.Genre, filter.Company, filter.Country, filter.Year, filter.PageNumber);

                t_filters = query.GetFilters(currentFilter);
                shortMovieInfo = await query.MovieList(currentFilter);

                int[] movieIds = shortMovieInfo.Select(m => m.Id).ToArray();
                IEnumerable<Cast> casts = await castQuery.GetCastsWithShortPeopleInfo(movieIds);
                IEnumerable<Crew> crews = await crewQuery.GetCrewsWithShortPeopleInfo(movieIds);

                var castsGroups = casts.GroupBy(c => c.MovieId, (key, c) => new { key, c });
                var crewsGroups = crews.GroupBy(c => c.MovieId, (key, c) => new { key, c });

                castsGroups.ForEach(m => shortMovieInfo.First(i => i.Id == m.key).Casts = new HashSet<Cast>(m.c));
                crewsGroups.ForEach(m => shortMovieInfo.First(i => i.Id == m.key).Crews = new HashSet<Crew>(m.c));
            }

            return new Tuple<IEnumerable<Movie>, MovieEntityFilters>(shortMovieInfo, await t_filters);
        }

        //----------------------------------------------------------------//

    }
}
