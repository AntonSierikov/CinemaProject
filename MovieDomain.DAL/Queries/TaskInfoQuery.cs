using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal class TaskInfoQuery : BaseQuery<TaskInfo, int>, ITaskQuery
    {

        //----------------------------------------------------------------//

        public TaskInfoQuery(ISession session)
            :base(session)
        {}

        //----------------------------------------------------------------//

        public IEnumerable<TaskInfo> GetTaskForRun()
        {
            string getTasks = $"SELECT * FROM {TableName} WHERE RunNow = 1 OR SYSDATETIME() > LastEndingDateTime + CAST(Interval as DATETIME)";
            return _session.Connection.Query<TaskInfo>(getTasks, null, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public bool IsExist(TaskInfo info)
        {
            string taskExist = $"SELECT COUNT(*) FROM {TableName} WHERE Id = @{nameof(info.Id)}";
            return _session.Connection.QueryFirstOrDefault(taskExist, info, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
