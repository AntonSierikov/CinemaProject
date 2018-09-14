using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.ICommands;
using TaskService.Domain.TaskBaseInfo;
using TaskService.Domain.ServiceInterface;
using MovieTaskFactory = TaskService.Domain.Factories.TaskFactory;


namespace TaskService.Domain.Service
{
    public class CinemaTaskService : ICinemaTaskService
    {
        private readonly IQueryFactory _queryFactory;
        private readonly ICommandFactory _commandFactory;
        private readonly ISessionFactory _sessionFunc;

        //----------------------------------------------------------------//

        public CinemaTaskService(IServiceProvider provider)
        {
            _queryFactory = provider.GetRequiredService<IQueryFactory>();
            _commandFactory = provider.GetRequiredService<ICommandFactory>();
            _sessionFunc = provider.GetRequiredService<ISessionFactory>();
        }

        //----------------------------------------------------------------//

        public void RunTasks()
        {
            using (ISession session = _sessionFunc.CreateSession())
            {
                ITaskQuery taskQuery = _queryFactory.CreateQuery<ITaskQuery>(session);
                IEnumerable<TaskInfo> enumeration = taskQuery.GetTaskForRun();
                List<Task> tasks = new List<Task>();
                foreach (TaskInfo info in enumeration)
                {
                    TaskBase taskBase = MovieTaskFactory.CreateTask(info);
                    tasks.Add(RunTask(taskBase, session));
                }
                Task.WaitAll(tasks.ToArray());
            }
        }

        //----------------------------------------------------------------//

        public async Task RunTask(TaskBase taskBase, ISession session)
        {
            bool isSuccess = await Task.Run(() => taskBase.SafeExecute());
            if (isSuccess)
            {
                _commandFactory.CreateCommand<ITaskInfoCommand>(session)
                               .Update(taskBase.taskInfo);
            }
        }

        //----------------------------------------------------------------//

    }
}
