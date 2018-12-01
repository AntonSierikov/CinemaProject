using System;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Commands
{
    internal class MovieGenreCommand : BaseCommand<MovieGenre, MovieGenreId>, IMovieGenreCommand
    {
        public MovieGenreCommand(ISession session) : base(session)
        {}

        protected override string GenerateInsertQuery(MovieGenre item)
        {
            string insert = $@"INSERT INTO {TableName}(MovieId, GenreId)
                               OUTPUT INSERTED.MovieId, INSERTED.GenreId
                               VALUES(@{nameof(item.Id.MovieId)}, @{nameof(item.Id.GenreId)})";
            return insert;
        }

        protected override string GenerateUpdateQuery(MovieGenre item)
        {
            throw new NotImplementedException();
        }
    }
}
