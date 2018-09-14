using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MovieDomain.Abstract;
using MovieDomain.Entities;
using TaskService.Domain.Mappers;
using TaskService.Domain.DTO.CinemaEntities;
using TaskService.Domain.ServiceInterface;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Helpers;

namespace TaskService.Domain.Service
{
    public class FeedEntityService : IFeedEntityService
    {
        private readonly ILoadDataService _loadDataService;
        private readonly ICommandFactory _commandFactory;
        private readonly IQueryFactory _queryFactory;


        //----------------------------------------------------------------//

        public FeedEntityService(IServiceProvider serviceProvider)
        {
            _loadDataService = serviceProvider.GetRequiredService<ILoadDataService>();
            _commandFactory = serviceProvider.GetRequiredService<ICommandFactory>();
            _queryFactory = serviceProvider.GetRequiredService<IQueryFactory>();
        }

        //----------------------------------------------------------------//
        //Load AND Save
        public async Task<Movie> LoadAndSaveMovieAsync(IMovieCommand command, IMovieQuery query, int movieId)
        {
            string s_movieID = movieId.ToString();
            MovieDto movieDto = await _loadDataService.LoadMovie(s_movieID);
            Movie movie = CinemaDtoMapper.MapMovie(movieDto);
            return await command.SaveIfNotExist(query, movie);
        }

        //----------------------------------------------------------------//

        public async Task<People> LoadAndSavePeopleAsync(IPeopleCommand command, IPeopleQuery query, int peopleId)
        {
            string s_peopleID = peopleId.ToString();
            PeopleDto people_dto = await _loadDataService.LoadPeople(s_peopleID);
            People people = CinemaDtoMapper.MapPeople(people_dto);
            return await command.SaveIfNotExist(query, people);
        }

        public async Task SaveMovieCreditsByMovieAsync(Movie movie)
        {
            CreditsDto creditsDto =  await _loadDataService.LoadCreditsByMovieId(movie.Tmdb_ID);
            creditsDto.Cast.ForEach(c => SaveMovieCast(c, movie));
            creditsDto.Crew.ForEach(c => SaveMovieCrew(c, movie));
        }

        //----------------------------------------------------------------//

        public IEnumerable<T> SaveCollection<T, TId>(ICommand<T, TId> command, IEnumerable<T> entities) where T: DbObject<TId>
        {
            return command.SaveOrUpdateCollection(entities);
        }

        //----------------------------------------------------------------//
        //Save entity

        public MovieGenre SaveMovieGenre(IMovieGenreCommand mgCommand, Movie movie, Genre genre)
        {
            MovieGenre movieGenre = new MovieGenre(movie, genre);
            movie.Genres.Add(movieGenre);
            genre.Movies.Add(movieGenre);
            mgCommand.SaveIfNotExist(movieGenre, );
            return movieGenre;
        }

        //----------------------------------------------------------------//

        public MovieCompany SaveMovieCompany(Movie movie, ProductionCompany company)
        {
            MovieCompany movieCompany = new MovieCompany(movie, company);
            movie.ProductionCompanies.Add(movieCompany);
            company.Movies.Add(movieCompany);
            _unitOfWork.GeneralRepository.AddIfNotExist(movieCompany, true);
            return movieCompany;
        }

        //----------------------------------------------------------------//

        public MovieCountry SaveMovieCountry(Movie movie, ProductionCountry country)
        {
            MovieCountry movieCountry = new MovieCountry(movie, country);
            movie.ProductionCountries.Add(movieCountry);
            country.Movies.Add(movieCountry);
            _unitOfWork.GeneralRepository.AddIfNotExist(movieCountry, true);
            return movieCountry;
        }

        //----------------------------------------------------------------//

        public Cast SaveMovieCast(CastDto castDto, Movie movie)
        {
            Cast cast = CinemaDtoMapper.MapCast(castDto);
            cast.Movie = movie;
            cast.MovieId = movie.Id;
            People people = SavePeople(castDto.Id);
            cast.People = people;
            cast.PeopleId = people.Id;
            _unitOfWork.GeneralRepository.AddIfNotExist(cast, true);
            return cast;
        }

        //----------------------------------------------------------------//

        public Crew SaveMovieCrew(CrewDto crewDto, Movie movie)
        {
            People people = SavePeople(crewDto.Id);
            Job job = _unitOfWork.JobRepository.GetJobByName(crewDto.job);
            if(job == null)
            {
                Department department = SaveDepartment(crewDto.department);
                job = SaveJob(crewDto.job, department);
            }
            Crew crew = new Crew()
            {
                Movie = movie,
                MovieId = movie.Id,
                People = people,
                PeopleId = people.Id,
                Job = job,
                JobId = job.Id
            };
            _unitOfWork.GeneralRepository.AddIfNotExist(crew, true);
            return crew;
        }

        //----------------------------------------------------------------//

        public void SaveDepartments()
        {
            Task<List<DepartmentDto>> t_departments = _loadDataService.LoadDepartments();
            t_departments.Wait();
            List<DepartmentDto> departments = t_departments.Result;
            departments.ForEach(d => SaveDepartment(d));
        }

        //----------------------------------------------------------------//

        public Department SaveDepartment(string s_department)
        {
            Department department = new Department()
            {
                DepartmentName = s_department
            };
            department = _unitOfWork.GeneralRepository.AddIfNotExist(department, true);   
            return department;
        }

        //----------------------------------------------------------------//

        public Department SaveDepartment(DepartmentDto departmentDto)
        {
            Department department = SaveDepartment(departmentDto.Department);
            department.Jobs = SaveJobs(departmentDto.Jobs, department);
            return department;
        }

        //----------------------------------------------------------------//

        public List<Job> SaveJobs(IEnumerable<string> jobs, Department department)
        {
            List<Job> savedJobs = new List<Job>();
            foreach(string job in jobs)
            {
                savedJobs.Add(SaveJob(job, department));
            }
            return savedJobs;
        }

        //----------------------------------------------------------------//

        public Job SaveJob(string s_job, Department department)
        {
            Job job = new Job()
            {
                job = s_job,
                Department = department,
                DepartmentId = department.Id
            };
            return job;
        }

        //----------------------------------------------------------------//
    }
}
