using System;
using System.Threading.Tasks;
using MovieDomain.Common.Extensions;
using TaskService.Domain;
using TaskService.Domain.ServiceInterface;
using Microsoft.Extensions.DependencyInjection;

namespace TaskService.ConsoleClient
{
    public class Program
    {
        //----------------------------------------------------------------//

        static void Main(string[] args)
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            TaskServiceConfigure configuration = new TaskServiceConfigure(serviceCollection);
            IServiceProvider provider = configuration.Provider;
            try
            {
                ICinemaTaskService taskService = provider.GetRequiredService<ICinemaTaskService>();
                Task<string> task = taskService.RunTasks().ContinueWith(c => c.GetExceptionLog());
                task.Wait();
                Console.WriteLine(task.Result);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //----------------------------------------------------------------//
    }
}
