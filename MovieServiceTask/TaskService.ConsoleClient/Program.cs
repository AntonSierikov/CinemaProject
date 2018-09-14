using System;
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
                taskService.RunTasks();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //----------------------------------------------------------------//
    }
}
