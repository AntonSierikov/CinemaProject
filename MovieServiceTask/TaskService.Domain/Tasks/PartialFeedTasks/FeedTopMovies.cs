using System;
using System.Collections.Generic;
using System.Linq;
using MovieDomain.Common;
using System.Threading.Tasks;
using MovieDomain.Common.Extensions;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.Abstract;
using TaskService.Domain.Mappers;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Helpers;
using TaskService.Domain.TaskBaseInfo;
using TaskService.Domain.ServiceInterface;
using TaskService.Domain.DTO.CinemaEntities;
using Microsoft.Extensions.DependencyInjection;

namespace TaskService.Domain.Tasks.PartialFeedTasks
{
    public sealed class FeedTopMovies : TaskBase
    {

        //----------------------------------------------------------------//

        private readonly ILoadDataService _loadDataService;
        private readonly IFeedEntityService _feedEntityService;
        private readonly ISessionFactory _sessionFactory;
        private readonly IQueryFactory _queryFactory;
        private readonly ICommandFactory _commandFactory;

        //----------------------------------------------------------------//

        public FeedTopMovies(TaskInfo info, IServiceProvider provider)
            : base(info)
        {
            _loadDataService = provider.GetRequiredService<ILoadDataService>();
            _feedEntityService = provider.GetRequiredService<IFeedEntityService>();
            _queryFactory = provider.GetRequiredService<IQueryFactory>();
            _commandFactory = provider.GetRequiredService<ICommandFactory>();
        }

        //----------------------------------------------------------------//

        public override void Execute()
        {
            List<int> movieIds = null;

            while (movieIds?.Count != 0)
            {
                movieIds = SaveTopMoviePage(++option.LastPage);
                Logger.Log.Info($"Page {option.LastPage} was loaded");
            }
        }

        //----------------------------------------------------------------//

        private async Task<List<int>> SaveTopMoviePage(int pageNumber)
        {
            Task<List<int>> t_LoadTopMovieIds = _loadDataService.LoadTopMovieIdsByPage(pageNumber);
            t_LoadTopMovieIds.Wait();

            foreach (int movieId in t_LoadTopMovieIds.Result)
            {
                await SaveEntities(movieId);
                Logger.Log.Info($"Entities for movie with id {movieId} was loaded");
            }
            return t_LoadTopMovieIds.Result;
        }

        //----------------------------------------------------------------//

        private async Task SaveEntities(int movieId)
        {
            Task<MovieDto> t_movie = _loadDataService.LoadMovie(movieId.ToString());
            Movie movie = CinemaDtoMapper.MapMovie(t_movie.Result);
            Logger.Log.Info($"Movie with {movieId} was loaded");

            IEnumerable<Genre> genres = movie.Genres.Select(c => c.Genre);
            IEnumerable<ProductionCompany> companies = movie.ProductionCompanies.Select(p => p.Company);
            IEnumerable<ProductionCountry> countries = movie.ProductionCountries.Select(p => p.Country);

            using (ISession session = _sessionFactory.CreateSession())
            {              
                IGenreCommand genreCommand = _commandFactory.CreateCommand<IGenreCommand>(session);
                ICompanyCommand companyCommand = _commandFactory.CreateCommand<ICompanyCommand>(session);
                ICountryCommand countryCommand = _commandFactory.CreateCommand<ICountryCommand>(session);
                IMovieGenreCommand movieGenreCommand = _commandFactory.CreateCommand<IMovieGenreCommand>(session);
                IMovieCompanyCommand movieCompany = _commandFactory.CreateCommand<IMovieCompanyCommand>(session);
                IMovieCountryCommand movieCountry = _commandFactory.CreateCommand<IMovieCountryCommand>(session);

                Task<Movie> t_saveMovie = MovieSave(session, movie);

                //-genres--companies--countries
                Task<IEnumerable<Genre>> t_saveGenre = genreCommand.SaveOrUpdateCollectionAsync(genres);
                Task<IEnumerable<ProductionCompany>> t_saveCompanies = companyCommand.SaveOrUpdateCollectionAsync(companies);
                Task<IEnumerable<ProductionCountry>> t_saveCountries = countryCommand.SaveOrUpdateCollectionAsync(countries);

                movie = await t_saveMovie;
                Logger.Log.Info($"Movie with {movie.Id} was saved");

                //-genres--companies--countries
                 
            }



            //-genres--companies--countries
            genres = _feedEntityService.SaveCollection(genres);
            Logger.Log.Info($"Genres for movie with {movie.Id} were saved");

            companies = _feedEntityService.SaveCollection(companies);
            Logger.Log.Info($"Companies for movie with {movie.Id} were saved");

            countries = _feedEntityService.SaveCollection(countries);
            Logger.Log.Info($"Countries for movie with {movie.Id} were saved");

            //--many-to-many-subentities
            genres.ForEach(g => _feedEntityService.SaveMovieGenre(movie, g));
            Logger.Log.Info($"Binded genres with movie");

            companies.ForEach(c => _feedEntityService.SaveMovieCompany(movie, c));
            Logger.Log.Info($"Binded companies with movie");

            countries.ForEach(c => _feedEntityService.SaveMovieCountry(movie, c));
            Logger.Log.Info($"Binded countries with movie");

            //--credits
            _feedEntityService.SaveMovieCreditsByMovie(movie);
            Logger.Log.Info($"Credits for movie with {movie.Id} were saved");
        }

        //----------------------------------------------------------------//

        private async Task<Movie> MovieSave(ISession session, Movie movie)
        {
            IMovieCommand movieCommand = _commandFactory.CreateCommand<IMovieCommand>(session);
            IMovieQuery movieQuery = _queryFactory.CreateQuery<IMovieQuery>(session);
            return await movieCommand.SaveIfNotExist(movieQuery, movie);
        }

        //----------------------------------------------------------------//

    }
}
