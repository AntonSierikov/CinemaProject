using System.Data;
using System.Threading.Tasks;
using MovieDomain.AuthEntities;

namespace MovieDomain.BL.ServicesInterface.ValidateServices
{
    public interface IUserValidateService
    {
        Task<string> CreateUpdateValidate(IDbConnection connection, User user);
    }
}
