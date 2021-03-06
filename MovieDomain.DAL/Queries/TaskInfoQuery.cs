﻿using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal class TaskInfoQuery : BaseQuery<TaskInfo, int>, ITaskQuery
    {

        //----------------------------------------------------------------//

        public TaskInfoQuery(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public TaskInfoQuery(ISession session)
            :base(session)
        {}

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(TaskInfo item)
        {
            return $"WHERE Description = @{nameof(item.Description)} AND Interval = @{nameof(item.Interval)}";
        }

        //----------------------------------------------------------------//

        public IEnumerable<TaskInfo> GetTaskForRun()
        {
            string getTasks = $"SELECT * FROM {TableName} WHERE RunNow = 1 OR SYSDATETIME() > LastEndingDateTime + CAST(Interval as DATETIME)";
            return _connection.Query<TaskInfo>(getTasks, null, _transaction);
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(TaskInfo info)
        {
            string getById = $"SELECT Id FROM {TableName} {GetUniqueConditionByItem(info)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getById, info, _transaction);
        }

        //----------------------------------------------------------------//

    }
}
