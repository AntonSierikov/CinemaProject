using System.Data;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.ICommands;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class TaskInfoCommand : BaseCommand<TaskInfo, int>, ITaskInfoCommand
    {

        //----------------------------------------------------------------//

        public TaskInfoCommand(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public TaskInfoCommand(ISession session) 
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(TaskInfo entity)
        {
            return $@"INSERT INTO {TableName}  OUTPUT INSERTED.Id VALUES 
                      (DEFAULT, @{nameof(entity.RunNow)}, @{nameof(entity.Description)},
                       @{nameof(entity.Interval)}, @{nameof(entity.LastStartDateTime)},
                       @{nameof(entity.LastEndingDateTime)}, @{nameof(entity.LastSuccessStartDateTime)},
                       @{nameof(entity.LastSuccessEndDateTime)}, @{nameof(entity.Options)}, 
                       @{nameof(entity.IsActive)}, @{nameof(entity.IsRunning)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(TaskInfo item)
        {
            string updateInfo = $@"UPDATE [dbo].[TaskInfo] 
                                  SET Options = @{nameof(item.Options)}, LastStartDateTime = @{nameof(item.LastStartDateTime)},
                                  LastEndingDateTime = @{nameof(item.LastEndingDateTime)}, LastSuccessStartDateTime = @{nameof(item.LastSuccessStartDateTime)},
                                  LastSuccessEndDateTime = @{nameof(item.LastSuccessEndDateTime)}, 
                                  IsActive = @{nameof(item.IsActive)},
                                  IsRunning = @{nameof(item.IsRunning)}
                                  WHERE Id = @{nameof(item.Id)}";
            return updateInfo;
        }

        //----------------------------------------------------------------//



    }
}
