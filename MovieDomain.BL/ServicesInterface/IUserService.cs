using System.Threading.Tasks;
using MovieDomain.AuthEntities;

namespace MovieDomain.BL.ServicesInterface
{
    public interface IUserService
    {

        //----------------------------------------------------------------//

        Task<User> GetUser(int userId);

        Task<string> CreateUser(User user);

        Task<string> UpdateUser(User user);

        //----------------------------------------------------------------//

    }
}
