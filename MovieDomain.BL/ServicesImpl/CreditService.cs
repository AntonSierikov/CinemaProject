using System;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.DAL.IQueries;
using MovieDomain.BL.ServicesInterface;
using MovieDomain.BL.Model;
using MovieDomain.Entities;

namespace MovieDomain.BL.ServicesImpl
{
    internal class CreditService : BaseService, ICreditService
    {

        //----------------------------------------------------------------//
        public CreditService(IServiceProvider provider) : base(provider)
        {}

        //----------------------------------------------------------------//

        public async Task<BLCredits> GetCredits(int movieId)
        {
            using (IDbConnection connection = OpenConnection())
            {
                return new BLCredits(await GetCastsByMovieId(connection, movieId),
                                     await GetCrewsByMovieId(connection, movieId));
            }
        }

        //----------------------------------------------------------------//

        private async Task<IEnumerable<Cast>> GetCastsByMovieId(IDbConnection connection, int movieId)
        {
            return await queryFactory.CreateQuery<ICastQuery>(connection).GetCastsWithShortPeopleInfo(movieId);
        }

        //----------------------------------------------------------------//

        private async Task<IEnumerable<Crew>> GetCrewsByMovieId(IDbConnection connection, int movieId)
        {
            return await queryFactory.CreateQuery<ICrewQuery>(connection).GetCrewsWithShortPeopleInfo(movieId);
        }

        //----------------------------------------------------------------//

    }
}
