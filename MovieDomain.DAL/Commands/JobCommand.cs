using System.Data;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;
using MovieDomain.Entities;


namespace MovieDomain.DAL.Commands
{
    internal class JobCommand : BaseCommand<Job, int>, IJobCommand
    {

        //----------------------------------------------------------------//

        public JobCommand(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public JobCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Job entity)
        {
           return $"INSERT INTO {TableName} OUTPUT INSERTED.Id VALUES (@{nameof(entity.job)}, @{nameof(entity.DepartmentId)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Job entity)
        {
            return $@"UPDATE {TableName} SET
                      DepartmentId = @{nameof(entity.DepartmentId)},
                      job = @{nameof(entity.job)}
                      WHERE Id = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//


    }
}
