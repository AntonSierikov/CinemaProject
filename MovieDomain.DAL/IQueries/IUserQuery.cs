using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.AuthEntities;

namespace MovieDomain.DAL.IQueries
{
    public interface IUserQuery : IQuery<User, int>
    {
        Task<bool> EmailExist(string email);
    }
}
