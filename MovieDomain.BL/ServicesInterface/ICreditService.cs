using System.Data;
using System.Threading.Tasks;
using System.Collections.Generic;
using MovieDomain.Entities;
using MovieDomain.BL.Model;

namespace MovieDomain.BL.ServicesInterface
{
    public interface ICreditService
    {
        Task<BLCredits> GetCredits(int movieId);
        Task<IEnumerable<Crew>> GetCrewsByMovieId(IDbConnection connection, int movieId);
        Task<IEnumerable<Cast>> GetCastsByMovieId(IDbConnection connection, int movieId);
    }
}
