using MovieDomain.DAL.ICommands;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using System.Data;

namespace MovieDomain.DAL.Commands
{
    internal class CrewCommand : BaseCommand<Crew, int>, ICrewCommand
    {
        //----------------------------------------------------------------//

        public CrewCommand(IDbConnection connection) : base(connection) {}
    
        //----------------------------------------------------------------//

        public CrewCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Crew entity)
        {
            return $@"INSERT INTO {TableName} OUTPUT Inserted.Id VALUES 
                      (@{nameof(entity.PeopleId)}, @{nameof(entity.MovieId)}, @{nameof(entity.JobId)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Crew entity)
        {
            return  $@"UPDATE {TableName} SET
                       PeopleId = @{nameof(entity.PeopleId)},
                       MovieId  = @{nameof(entity.MovieId)},
                       JobId = @{nameof(entity.JobId)}
                       WHERE Id = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//


    }
}
