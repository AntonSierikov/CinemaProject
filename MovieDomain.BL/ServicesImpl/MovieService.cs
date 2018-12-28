using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.Entities;
using MovieDomain.DAL.IQueries;
using MovieDomain.BL.Model;
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


    }
}
