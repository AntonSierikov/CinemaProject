using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.Common;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using TaskService.Domain.TaskBaseInfo;
using TaskService.Domain.ServiceInterface;
using TaskService.Domain.Managers;

namespace TaskService.Domain.Tasks.PartialFeedTasks
{
    public sealed class FeedTopMovies : TaskBase
    {

        //----------------------------------------------------------------//

        private readonly ILoadDataService _loadDataService;
        private readonly ISessionFactory _sessionFactory;
        private readonly IServiceProvider _provider;

        //----------------------------------------------------------------//

        public FeedTopMovies(TaskInfo info, IServiceProvider provider)
            : base(info)
        {
            _provider = provider;
            _loadDataService = provider.GetRequiredService<ILoadDataService>();
            _sessionFactory = provider.GetRequiredService<ISessionFactory>();
        }

        //----------------------------------------------------------------//

        public async override Task Execute(ISession session)
        {
            List<int> movieIds = null;
            FeedManager feedManager = new FeedManager(session, _provider);
            List<Task> movieTasks = new List<Task>();
            while (movieIds?.Count != 0)
            {
                movieTasks.Add(SaveTopMoviePage(++option.LastPage, feedManager));
                Logger.Log.Info($"Page {option.LastPage} was loaded");
            }

            await Task.WhenAll(movieTasks);
        }

        //----------------------------------------------------------------//

        private async Task<List<int>> SaveTopMoviePage(int pageNumber, FeedManager feedManager)
        {
            List<int> loadTopMovieIds = await _loadDataService.LoadTopMovieIdsByPage(pageNumber);

            foreach (int movieId in loadTopMovieIds)
            {
                await feedManager.FeedMovieWithSubEntities(movieId);
                Logger.Log.Info($"Entities for movie with id {movieId} was loaded");
            }
            return loadTopMovieIds;
        }

        //----------------------------------------------------------------//

    }
}
