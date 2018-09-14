using System;
using System.Collections.Generic;
using System.Text;
using MovieDomain.Entities;

namespace MovieDomain.DAL.IQueries
{
    public interface ITaskQuery : IQuery<TaskInfo, int>
    {
        IEnumerable<TaskInfo> GetTaskForRun();

    }
}
