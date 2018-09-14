using System.Threading.Tasks;
using MovieDomain.DAL.Abstract;
using TaskService.Domain.TaskBaseInfo;

namespace TaskService.Domain.ServiceInterface
{
    public interface ICinemaTaskService
    {

        //----------------------------------------------------------------//

        void RunTasks();

        Task RunTask(TaskBase taskBase, ISession session);

        //----------------------------------------------------------------//

    }
}
