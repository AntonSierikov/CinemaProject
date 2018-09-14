using MovieDomain.DAL.ICommands;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class CrewCommand : BaseCommand<Crew, int>, ICrewCommand
    {
        //----------------------------------------------------------------//

        public CrewCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Crew entity)
        {
            return $@"INSERT INTO {TableName} VALUES OUTPUT Inserted.Id
                      (DEFAULT, @{nameof(entity.PeopleId)}, @{nameof(entity.MovieId)}, @{nameof(entity.JobId)}";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Crew entity)
        {
            return  $@"UPDATE {TableName} SET
                       PeopleId = @{nameof(entity.PeopleId)},
                       MovieId  = @{nameof(entity.MovieId)},
                       JobId = @{nameof(entity.JobId)}
                       WHERE CrewId = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//


    }
}
