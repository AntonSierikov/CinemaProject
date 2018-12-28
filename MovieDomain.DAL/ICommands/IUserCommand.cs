using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.AuthEntities;

namespace MovieDomain.DAL.ICommands
{
    public interface IUserCommand : ICommand<User, int>
    {
    }
}
