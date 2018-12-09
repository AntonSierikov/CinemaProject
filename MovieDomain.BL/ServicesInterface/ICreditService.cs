using System;
using System.Threading.Tasks;
using System.Text;
using MovieDomain.Entities;
using MovieDomain.BL.Model;

namespace MovieDomain.BL.ServicesInterface
{
    public interface ICreditService
    {
        Task<BLCredits> GetCredits(int movieId);
    }
}
