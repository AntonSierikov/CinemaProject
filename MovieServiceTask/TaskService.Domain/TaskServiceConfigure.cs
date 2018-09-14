using System;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Concrety;
using MovieDomain.DAL.Factories;
using TaskService.Domain.Service;
using TaskService.Domain.ServiceInterface;

namespace TaskService.Domain
{
    public class TaskServiceConfigure 
    {
        private readonly IServiceCollection _serviceCollection;

        //----------------------------------------------------------------//

        public IServiceProvider Provider
        {
            get { return _serviceCollection.BuildServiceProvider(); }
        }

        //----------------------------------------------------------------//

        public TaskServiceConfigure(IServiceCollection serviceCollection)
        {
            _serviceCollection = serviceCollection;
        }

        //----------------------------------------------------------------//

        public void ConfigureDependencies()
        {

            _serviceCollection.AddSingleton<ISessionFactory, SessionFactory>();
            _serviceCollection.AddSingleton<IQueryFactory, QueryFactory>();
            _serviceCollection.AddSingleton<ICommandFactory, CommandFactory>();

            _serviceCollection.AddSingleton<ILoadDataService, LoadDataServiceTmdb>();
            _serviceCollection.AddSingleton<ICinemaTaskService, CinemaTaskService>();
            _serviceCollection.AddSingleton<IFeedEntityService, FeedEntityService>();
        }

        //----------------------------------------------------------------//



    }
}
