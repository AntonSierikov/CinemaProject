using System.Threading.Tasks;
using System.Collections.Generic;
using MovieDomain.Entities;

namespace MovieDomain.DAL.IQueries
{
    public interface ICastQuery : IQuery<Cast, int>
    {
        Task<IEnumerable<Cast>> GetCastsWithShortPeopleInfo(int movieId);

        Task<IEnumerable<Cast>> GetCastsWithShortPeopleInfo(params int[] movieIds);
    }
}
