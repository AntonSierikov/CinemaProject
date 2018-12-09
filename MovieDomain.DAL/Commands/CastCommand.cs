using System.Data;
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

        public CastCommand(IDbConnection connection)
            : base(connection)
        {}

        //----------------------------------------------------------------//

        public CastCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Cast entity)
        {
            return  $@"INSERT INTO {TableConstans.CAST} OUTPUT Inserted.Id VALUES 
                       (         @{nameof(entity.CharacterCast)}, 
                                 @{nameof(entity.Gender)},   @{nameof(entity.Sequence)},
                                 @{nameof(entity.PeopleId)}, @{nameof(entity.MovieId)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Cast entity)
        {
            return $@"UPDATE {TableConstans.CAST} SET 
                      CharacterCast = @{nameof(entity.CharacterCast)},
                      Gender = @{nameof(entity.Gender)}, Sequence = @{nameof(entity.Sequence)},
                      PeopleId = @{nameof(entity.PeopleId)}, MovieId = @{nameof(entity.MovieId)}
                      WHERE Id = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//



    }
}
