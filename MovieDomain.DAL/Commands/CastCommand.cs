using System;
using MovieDomain.DAL.ICommands;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class CastCommand : BaseCommand<Cast, int>, ICastCommand
    {
        //----------------------------------------------------------------//

        public CastCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Cast entity)
        {
            return  $@"INSERT INTO {TableConstans.CAST} VALUES OUTPUT Inserted.Id
                       (DEFAULT, @{nameof(entity.CharacterCast)}, 
                                 @{nameof(entity.Gender)},   @{nameof(entity.Order)},
                                 @{nameof(entity.PeopleId)}, @{nameof(entity.MovieId)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Cast entity)
        {
            return $@"UPDATE {TableConstans.CAST} SET 
                      CharacterCast = @{nameof(entity.CharacterCast)},
                      Gender = @{nameof(entity.Gender)}, Order = @{nameof(entity.Order)},
                      PeopleId = @{nameof(entity.PeopleId)}, MovieId = @{nameof(entity.MovieId)}";
        }

        //----------------------------------------------------------------//



    }
}
