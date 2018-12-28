using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.AuthEntities;
using MovieDomain.Entities;
using MovieDomain.DAL.ICommands;
using System.Data;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Commands
{
    internal class UserCommand : BaseCommand<User, int>, IUserCommand
    {
        public UserCommand(IDbConnection connnection) : base(connnection)
        {
        }

        public UserCommand(ISession session) : base(session)
        {
        }

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(User item)
        {
            return $@"INSERT INTO {TableName} OUTPUT INSERTED.Id VALUES
                      (@{nameof(item.FirstName)}, @{nameof(item.SecondName)},
                       @{nameof(item.UserPassword)}, @{nameof(item.Country)}, @{nameof(item.City)}, 
                       @{nameof(item.Address)}, @{nameof(item.RoleId)}, @{nameof(item.IsOnline)}, @{nameof(item.Gender)},
                       @{nameof(item.UserStatus)}, @{nameof(item.PathOfPhoto)}, @{nameof(item.AddedDate)}, @{nameof(item.LastVisitDate)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(User item)
        {
            return $@"UPDATE {TableName} SET
                      FirstName = @{nameof(item.FirstName)},
                      SecondName = @{nameof(item.SecondName)},
                      UserPassword = @{nameof(item.UserPassword)},
                      Country = @{nameof(item.City)},
                      Address = @{nameof(item.Address)},
                      RoleId = @{nameof(item.RoleId)},
                      IsOnline = @{nameof(item.IsOnline)},
                      Gender = @{nameof(item.Gender)},
                      UserStatus = @{nameof(item.UserStatus)},
                      PathOfPhoto = @{nameof(item.PathOfPhoto)},
                      AddedDate = @{nameof(item.AddedDate)},
                      LastVisitDate = @{nameof(item.LastVisitDate)}
                      WHERE Id = @{nameof(item.Id)}";
        }

        //----------------------------------------------------------------//

    }
}
