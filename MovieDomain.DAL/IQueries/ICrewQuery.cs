using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.Entities; 

namespace MovieDomain.DAL.IQueries
{
    public interface ICrewQuery : IQuery<Crew, int>
    {
        Task<IEnumerable<Crew>> GetCrewsWithShortPeopleInfo(int movieId);
    }
}
