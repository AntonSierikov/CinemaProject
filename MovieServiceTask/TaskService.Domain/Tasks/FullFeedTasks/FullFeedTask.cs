using MovieDomain.Entities;
using TaskService.Domain.TaskBaseInfo;
using TaskService.Domain.ServiceInterface;


namespace TaskService.Domain.Tasks.FullFeedTasks
{
    class FullFeedTask : TaskBase
    {

        //----------------------------------------------------------------//

        public FullFeedTask(TaskInfo info)
            : base(info)
        {
        }

        //----------------------------------------------------------------//

        public override void Execute()
        {
        }

        //----------------------------------------------------------------//

    }
}
