using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using MovieDomain.AuthEntities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;

namespace MovieDomain.DAL.Queries
{
    internal class UserQuery : BaseQuery<User, int>, IUserQuery
    {

        //----------------------------------------------------------------//

        public UserQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//

        public UserQuery(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(User item)
        {
            return $"WHERE Email = @{nameof(item.Email)}";
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(User user)
        {
            string getId = $"SELECT Id FROM SystemUser {GetUniqueConditionByItem(user)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getId, user, _transaction);
        }

        //----------------------------------------------------------------//

        public async Task<bool> EmailExist(string email)
        {
            string getemail = $"SELECT Count(*) FROM SystemUser WHERE Email = @{nameof(email)}";
            return await _connection.ExecuteScalarAsync<int>(getemail, new { email }, _transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
