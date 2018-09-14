using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.Common;
using MovieDomain.Common.Constans;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Helpers;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.IQueries;
using MovieDomain.Entities;
using TaskService.Domain.ServiceInterface;

namespace TaskService.Domain.Managers
{
    internal class FeedManager
    {

        private readonly ISession _session;

        //----------------------------------------------------------------//

        private readonly ICommandFactory _commandFactory;
        private readonly IQueryFactory _queryFactory;

        //----------------------------------------------------------------//

        private readonly IMovieCommand _movieCommand;
        private readonly IGenreCommand _genreCommand;
        private readonly ICastCommand _castCommand;
        private readonly ICrewCommand _crewCommand;
        private readonly IPeopleCommand _peopleCommad;
        private readonly ICountryCommand _countryCommand;
        private readonly ICompanyCommand _companyCommand;

        private readonly IMovieGenreCommand _movieGenreCommand;
        private readonly IMovieCompanyCommand _movieCompanyCommand;
        private readonly IMovieCountryCommand _movieCountryCommand;

        //----------------------------------------------------------------//

        private readonly IMovieQuery _movieQuery;
        private readonly IGenreQuery _genreQuery;
        private readonly ICrewQuery _crewQuery;
        private readonly ICastQuery _castQuery;
        private readonly IPeopleQuery _peopleQuery;
        private readonly ICompanyQuery _companyQuery;
        private readonly ICountryQuery _countryQuery;
        private readonly IMovieCountryQuery _movieCountryQuery;
        private readonly IMovieCompanyQuery _movieCompanyQuery;

        //----------------------------------------------------------------//

        private readonly IFeedEntityService _feedEntityService;

        //----------------------------------------------------------------//

        public FeedManager(ISession session, IServiceProvider provider)
        {
            _commandFactory = provider.GetService<ICommandFactory>();
            _queryFactory = provider.GetService<IQueryFactory>();

            _genreCommand = _commandFactory.CreateCommand<IGenreCommand>(session);
            _companyCommand = _commandFactory.CreateCommand<ICompanyCommand>(session);
            _countryCommand = _commandFactory.CreateCommand<ICountryCommand>(session);
            _peopleCommad = _commandFactory.CreateCommand<IPeopleCommand>(session);
            _movieCommand = _commandFactory.CreateCommand<IMovieCommand>(session);
            _castCommand = _commandFactory.CreateCommand<ICastCommand>(session);
            _crewCommand = _commandFactory.CreateCommand<ICrewCommand>(session);

            _movieGenreCommand = _commandFactory.CreateCommand<IMovieGenreCommand>(session);
            _movieCompanyCommand = _commandFactory.CreateCommand<IMovieCompanyCommand>(session);
            _movieCountryCommand = _commandFactory.CreateCommand<IMovieCountryCommand>(session);

            _movieQuery = _queryFactory.CreateQuery<IMovieQuery>(session);
            _castQuery = _queryFactory.CreateQuery<ICastQuery>(session);
            _crewQuery = _queryFactory.CreateQuery<ICrewQuery>(session);
            _peopleQuery = _queryFactory.CreateQuery<IPeopleQuery>(session);

            _feedEntityService = provider.GetRequiredService<IFeedEntityService>();
        }

        //----------------------------------------------------------------//

        public async Task FeedMovie(Movie movie)
        {
            List<Task> tasks = new List<Task>();

            IEnumerable<Genre> genres = movie.Genres.Select(c => c.Genre);
            IEnumerable<ProductionCompany> companies = movie.ProductionCompanies.Select(p => p.Company);
            IEnumerable<ProductionCountry> countries = movie.ProductionCountries.Select(p => p.Country);

            tasks.Add(SaveGenres(genres));
            tasks.Add(SaveCompanies(companies));
            tasks.Add(SaveCountries(countries));

            await Task.WhenAll(tasks.ToArray());
            await SaveMovie(movie);



        }

        //----------------------------------------------------------------//

        public async Task SaveMovie(Movie movie)
        {
            await _movieCommand.SaveIfNotExist(_movieQuery, movie);
            Logger.Log.Info($"Movie with {movie.Id} was saved");
        }

        //----------------------------------------------------------------//

        public async Task SaveGenres(IEnumerable<Genre> genres)
        {
            await _genreCommand.SaveIfNotExistCollection(_genreQuery, genres);
            string s_genres = String.Join(StringConstants.COMA_SPACE, genres.Select(c => c.genre)); 
            Logger.Log.Info($"Genres ({s_genres}) were saved");
        }

        //----------------------------------------------------------------//

        public async Task<IEnumerable<ProductionCompany>> SaveCompanies(IEnumerable<ProductionCompany> companies)
        {
            companies = await _companyCommand.SaveIfNotExistCollection(_companyQuery, companies);
            string s_companies = String.Join(StringConstants.COMA_SPACE, companies.Select(c => c.Name));
            Logger.Log.Info($"Companies ({s_companies}) were saved");
            return companies;
        }

        //----------------------------------------------------------------//

        public async Task<IEnumerable<ProductionCountry>> SaveCountries(IEnumerable<ProductionCountry> countries)
        {
            countries = await _countryCommand.SaveIfNotExistCollection(_countryQuery, countries);
            string s_countries = String.Join(StringConstants.COMA_SPACE, countries.Select(c => c.Name));
            Logger.Log.Info($"Countries ({s_countries} were saved)");
            return countries;
        }

        //----------------------------------------------------------------//

        public async Task<MovieCountry> SaveMovieCountry(Movie movie, ProductionCountry country)
        {
            MovieCountry movieCountry = new MovieCountry(movie, country);
            movie.ProductionCountries.Add(country);
            country.Movies.Add(movieCountry);
            await _movieCountryCommand.SaveIfNotExist(_movieCountryQuery, movieCountry);
            return movieCountry;
        }

        //----------------------------------------------------------------//

        public async Task SaveMovieCompany(Movie movie, ProductionCompany company)
        {
            MovieCompany movieCompany = new MovieCompany(movie, company);
            movie.ProductionCompanies.Add(movieCompany);
            coun
        }

        //----------------------------------------------------------------//

    }
}
