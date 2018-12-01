using System.Threading.Tasks;
using MovieDomain.DAL.Abstract;
using TaskService.Domain.TaskBaseInfo;

namespace TaskService.Domain.ServiceInterface
{
    public interface ICinemaTaskService
    {

        //----------------------------------------------------------------//

        Task RunTasks();

        Task RunTask(TaskBase taskBase, ISession session);

        //----------------------------------------------------------------//

    }
}
