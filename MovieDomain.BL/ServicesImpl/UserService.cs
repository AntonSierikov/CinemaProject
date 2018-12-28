using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using MovieDomain.AuthEntities;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.IQueries;
using MovieDomain.BL.ValidationMessages;
using MovieDomain.BL.ServicesInterface;
using MovieDomain.BL.ServicesInterface.ValidateServices;

namespace MovieDomain.BL.ServicesImpl
{
    internal class UserService : BaseService, IUserService
    {

        //----------------------------------------------------------------//

        public UserService(IServiceProvider provider) : base(provider)
        {}

        //----------------------------------------------------------------//

        public async Task<User> GetUser(int userId)
        {
            using(IDbConnection connection = OpenConnection())
            {
                return await queryFactory.CreateQuery<IUserQuery>(connection).GetItem(userId);
            }
        }

        //----------------------------------------------------------------//

        public async Task<string> UpdateUser(User user)
        {
            using (IDbConnection connection = OpenConnection())
            {
                return await CreateUpdateUser(user, connection, async (u) => await commandFactory.CreateCommand<IUserCommand>(connection)
                                                                                                 .UpdateAsync(u));
            }
        }

        //----------------------------------------------------------------//

        public async Task<string> CreateUser(User user)
        {
            using(IDbConnection connection = OpenConnection())
            {
                return await CreateUpdateUser(user, connection, async (u) => await commandFactory.CreateCommand<IUserCommand>(connection)
                                                                                                 .InsertAsync(u) != default(int));
            }
        }

        //----------------------------------------------------------------//

        public async Task<string> CreateUpdateUser(User user, IDbConnection connection, Func<User, Task<bool>> dbOperation)
        {
            string errorMsg = await provider.GetRequiredService<IUserValidateService>().CreateUpdateValidate(connection, user);
            if (string.IsNullOrEmpty(errorMsg))
            {
                return await dbOperation(user) ? String.Empty : UserValidationMessage.UserNotAdded;
            }
            else
            {
                return errorMsg;
            }
        }

        //----------------------------------------------------------------//
    }
}
