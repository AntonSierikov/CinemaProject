using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using MovieDomain.Common.Extensions;
using MovieDomain.Common.Constans;
using MovieDomain.Entities;
using MovieDomain.Abstract;
using MovieDomain.Filters;
using MovieDomain.DAL.IQueries;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;
using MovieDomain.DAL.Filters;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal class MovieQuery : BaseQuery<Movie, int>, IMovieQuery
    {

        //----------------------------------------------------------------//

        public MovieQuery(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public MovieQuery(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        public Movie GetMovie(string title)
        {
            string selectMovieByTitle = $"SELECT TOP 1 * FROM {TableConstans.MOVIE} WHERE Title = @{nameof(title)}";
            return _connection.QueryFirstOrDefault<Movie>(selectMovieByTitle, new { title }, _transaction);
        }

        //----------------------------------------------------------------//

        public IEnumerable<Cast> GetMovieCasts(int movieID)
        {
            string selectMovieCredits = $"SELECT * FROM {TableConstans.CAST} WHERE MovieId = @{nameof(movieID)}";
            return _connection.Query<Cast>(selectMovieCredits, new { movieID }, _transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Movie item)
        {
            return $"WHERE Title = @{nameof(item.Title)} AND Status = @{nameof(item.Status)} AND ReleaseDate = @{nameof(item.ReleaseDate)}";
        }

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Movie movie)
        {
            string getMovie = $@"SELECT Id FROM {TableName} {GetUniqueConditionByItem(movie)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getMovie, movie, _transaction);
        }

        //----------------------------------------------------------------//

        public async Task<Movie> GetMovie(int movieId)
        {
            Movie movie = await GetItem(movieId);
            if(movie != null)
            {
                string subQuery = $@"SELECT g.* FROM Genre g JOIN MovieGenre mg 
                                     ON g.Id = mg.GenreId WHERE mg.MovieId = @{nameof(movieId)};
                                     SELECT c.* FROM ProductionCompany c JOIN MovieCompany mc 
                                     ON c.Id = mc.CompanyId WHERE mc.MovieId = @{nameof(movieId)};
                                     SELECT c.* FROM ProductionCountry c JOIN MovieCountry mc
                                     ON c.Id = mc.CountryId WHERE mc.MovieId = @{nameof(movieId)};";

                using(SqlMapper.GridReader reader = await _connection.QueryMultipleAsync(subQuery, new { movieId }, _transaction))
                {
                    movie.Genres = new HashSet<Genre>(reader.Read<Genre>());
                    movie.ProductionCompanies = new HashSet<ProductionCompany>(reader.Read<ProductionCompany>());
                    movie.ProductionCountries = new HashSet<ProductionCountry>(reader.Read<ProductionCountry>());
                }
            }

            return movie;
        }

        //----------------------------------------------------------------//

        public async Task<MovieEntityFilters> GetFilters(MovieListingFilter filter)
        {
            StringBuilder queryBuilder = new StringBuilder();
            MovieEntityFilters filters = new MovieEntityFilters();

            queryBuilder.Append($"WITH available AS(");
            queryBuilder.Append($@"SELECT g.Id AS GenreId, com.Id AS CompanyId, coun.Id AS CountryId");
            MovieListFilterQuery(queryBuilder, filter);
            queryBuilder.Append(@")");

            queryBuilder.Append(@"SELECT g.*,  
                                  CASE WHEN (avail_genre.GenreId IS NOT NULL) THEN 1 ELSE 0 END AS IsAvailable
                                  FROM Genre g LEFT JOIN (SELECT DISTINCT available.GenreId FROM available) as avail_genre
                                  JOIN g.Id = available.GenreId;");

            queryBuilder.Append(@"SELECT c.*,  
                                  CASE WHEN (avail_company.CompanyId IS NOT NULL) THEN 1 ELSE 0 END AS IsAvailable
                                  FROM ProductionCompany c LEFT JOIN (SELECT DISTINCT available.CompanyId FROM available) as avail_company
                                  JOIN c.Id = available.CompanyId;");

            queryBuilder.Append(@"SELECT c.*,  
                                  CASE WHEN (avail_country.CountryId IS NOT NULL) THEN 1 ELSE 0 END AS IsAvailable
                                  FROM ProductionCountry c LEFT JOIN (SELECT DISTINCT available.CountryId FROM available) as avail_country
                                  JOIN g.Id = available.GenreId;");

            string query = queryBuilder.ToString();

            using (SqlMapper.GridReader reader = await _connection.QueryMultipleAsync(query, filter, _transaction))
            {
                filters.GenreFilters = reader.Read<EntityFilter<Genre>>().AsList();
                filters.CompanyFilters = reader.Read<EntityFilter<ProductionCompany>>().AsList();
                filters.CountryFilters = reader.Read<EntityFilter<ProductionCountry>>().AsList();
            }

            return filters;
        }

        
        //----------------------------------------------------------------//

        public Task<IEnumerable<Movie>> MovieList(MovieListingFilter filter)
        {
            StringBuilder queryBuilder = new StringBuilder();
            queryBuilder.Append($@"SELECT TOP {GeneralConstants.DEFAULT_LISTING_PAGE_SIZE}  
                                m.Id, m.Title, m.Poster_Path, m.ReleaseDate, m.Runtime, m.Status,
                                m.Tagline, m.VoteAverage, m.VoteCount, 
                                g.Id, g.genre, com.Id, com.Name, coun.Id, coun.Name "); 

            MovieListFilterQuery(queryBuilder, filter);
            queryBuilder.Append(" ORDER BY m.Popularity ");
            queryBuilder.AppendIfExist($"OFFSET {filter.Offset}", filter.Offset);

            HashSet<Movie> movieList = new HashSet<Movie>();
            string query = queryBuilder.ToString();
            
            return _connection.QueryAsync<Movie, Genre, ProductionCompany, ProductionCountry, Movie>(queryBuilder.ToString(),
            (movie, genre, company, country) =>
            {
                if(movieList.Add(movie))
                {
                    movie.Genres.Add(genre);
                    movie.ProductionCompanies.Add(company);
                    movie.ProductionCountries.Add(country);
                }

                return movie;
            },
            filter, _transaction, splitOn: "Id, Id, Id");
        }

        //----------------------------------------------------------------//

        private StringBuilder MovieListFilterQuery(StringBuilder queryBuilder, MovieListingFilter filter)
        {  
            queryBuilder.Append($@"
                                    FROM Movie m 
                                    JOIN MovieGenre mg ON mg.MovieId = m.Id
                                    JOIN Genre g ON g.Id = mg.GenreId
                                    JOIN MovieCompany mcom ON mcom.MovieId = m.Id
                                    JOIN ProductionCompany com ON com.id = mcom.CompanyId
                                    JOIN MovieCountry mcoun ON mcoun.MovieId = m.Id
                                    JOIN ProductionCountry coun ON coun.Id = mcoun.CountryId");

            if (!string.IsNullOrEmpty(filter.Genre) || !string.IsNullOrEmpty(filter.Company) || !string.IsNullOrEmpty(filter.Country))
            {
                queryBuilder.Append(" WHERE ");
            }

            queryBuilder.AppendIfExist($"g.genre = @{nameof(filter.Genre)}", filter.Genre);
            queryBuilder.AppendIfExist($" AND ", filter.Company);
            queryBuilder.AppendIfExist($"com.Name = @{nameof(filter.Company)}", filter.Company);
            queryBuilder.AppendIfExist($" AND ", filter.Country);
            queryBuilder.AppendIfExist($"coun.Name = @{nameof(filter.Country)}", filter.Country);

            return queryBuilder;
        }

        //----------------------------------------------------------------//

    }
}
