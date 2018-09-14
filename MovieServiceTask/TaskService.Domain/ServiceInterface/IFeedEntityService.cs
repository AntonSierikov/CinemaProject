using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieDomain.Abstract;
using MovieDomain.Entities;
using MovieDomain.DAL.ICommands;
using TaskService.Domain.DTO.CinemaEntities;

namespace TaskService.Domain.ServiceInterface
{
    public interface IFeedEntityService
    {

        //----------------------------------------------------------------//

        IEnumerable<T> SaveCollection<T, TKey>(IEnumerable<T> enumerable, ICommand<T, TKey> command) where T : DbObject<TKey>;

        //----------------------------------------------------------------//

        Task<Movie> LoadAndSaveMovieAsync(int movieId);
        Task<People> LoadAndSavePeopleAsync(int peopleId);

        //----------------------------------------------------------------//


        Task<Movie> SaveMovieAsync(Movie movie);
        Task SaveMovieCreditsByMovieAsync(Movie movie);
        Task SaveDepartmentsAsync();
        Cast SaveMovieCastAsync(CastDto castDto, Movie movie);
        Crew SaveMovieCrewAsync(CrewDto crewDto, Movie movie);
        Department SaveDepartmentAsync(DepartmentDto departmentDto);
        Department SaveDepartmentAsync(string department);
        List<Job> SaveJobsAsync(IEnumerable<string> jobs, Department department);
        MovieGenre SaveMovieGenreAsync(Movie movie, Genre genre);
        MovieCompany SaveMovieCompanyAsync(Movie movie, ProductionCompany company);
        MovieCountry SaveMovieCountryAsync(Movie movie, ProductionCountry country);
        Job SaveJobAsync(string job, Department department);


        //----------------------------------------------------------------//


    }
}
