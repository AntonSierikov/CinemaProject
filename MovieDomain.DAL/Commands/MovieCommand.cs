using System.Data;
using MovieDomain.DAL.ICommands;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Constans;

namespace MovieDomain.DAL.Commands
{
    internal class MovieCommand :  BaseCommand<Movie, int>, IMovieCommand
    {

        //----------------------------------------------------------------//

        public MovieCommand(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public MovieCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Movie entity)
        {
            string addMovie = $@"INSERT INTO {TableConstans.MOVIE} OUTPUT Inserted.Id VALUES 
                              (@{nameof(entity.Adult)}, @{nameof(entity.Backdrop_path)}, @{nameof(entity.Budget)},
                               @{nameof(entity.BelongsToCollection)}, @{nameof(entity.Imdb_id)}, @{nameof(entity.Original_language)}, 
                               @{nameof(entity.Original_title)}, @{nameof(entity.Overview)}, @{nameof(entity.Popularity)},
                               @{nameof(entity.Poster_path)}, @{nameof(entity.ReleaseDate)}, @{nameof(entity.Revenue)}, 
                               @{nameof(entity.Runtime)}, @{nameof(entity.Status)}, @{nameof(entity.Tagline)}, 
                               @{nameof(entity.Title)}, @{nameof(entity.Video)}, @{nameof(entity.VoteAverage)}, @{nameof(entity.VoteCount)}, @{nameof(entity.Tmdb_ID)})";
            return addMovie;
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Movie entity)
        {
            string update = $@"UPDATE {TableConstans.MOVIE} SET
                               Adult = @{nameof(entity.Adult)}, Backdrop_path = @{nameof(entity.Backdrop_path)},
                               Budget = @{nameof(entity.Budget)}, BelongsToCollection = @{nameof(entity.BelongsToCollection)},
                               Imdb_id = @{nameof(entity.Imdb_id)}, Original_language = @{nameof(entity.Original_language)},
                               Original_title = @{nameof(entity.Original_title)}, Overview = @{nameof(entity.Overview)}, 
                               Popularity = @{nameof(entity.Popularity)}, Poster_path = @{nameof(entity.Poster_path)},
                               ReleaseDate = @{nameof(entity.ReleaseDate)}, Revenue = @{nameof(entity.Revenue)}, 
                               Runtime = @{nameof(entity.Runtime)}, Tagline = @{nameof(entity.Tagline)},
                               Status = @{nameof(entity.Status)}, Title = @{nameof(entity.Title)},
                               Video = @{nameof(entity.Video)}, VoteAverage = @{nameof(entity.VoteAverage)}, VoteCount = @{nameof(entity.VoteCount)}
                               WHERE Id = @{nameof(entity.Id)}";
            return update;
        }

        //----------------------------------------------------------------//

    }
}
