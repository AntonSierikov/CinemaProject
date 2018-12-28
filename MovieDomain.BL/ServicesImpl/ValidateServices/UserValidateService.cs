using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.AuthEntities;
using MovieDomain.DAL.IQueries;
using MovieDomain.BL.ServicesInterface.ValidateServices;
using MovieDomain.BL.ValidationMessages;

namespace MovieDomain.BL.ServicesImpl.ValidateServices
{
    internal class UserValidateService : BaseService, IUserValidateService
    {
        public UserValidateService(IServiceProvider provider) : base(provider)
        {}


        //----------------------------------------------------------------//
        public async Task<string> CreateUpdateValidate(IDbConnection connection, User user)
        {
            bool emailExist = await queryFactory.CreateQuery<IUserQuery>(connection).EmailExist(user.Email);

            if (emailExist)
            {
                return UserValidationMessage.EmailExist(user.Email);
            }
            else
            {
                return String.Empty;
            }
        }

        //----------------------------------------------------------------//

    }
}
