using System;
using System.Data;
using MovieDomain.Entities;
using MovieDomain.Identifiers;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Commands
{
    internal class MovieGenreCommand : EntityKeyCommand<MovieGenre, MovieGenreId>, IMovieGenreCommand
    {
        public MovieGenreCommand(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//

        public MovieGenreCommand(ISession session) : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(MovieGenre item)
        {
            string insert = $@"INSERT INTO {TableName}(MovieId, GenreId)
                               OUTPUT INSERTED.MovieId, INSERTED.GenreId
                               VALUES(@{nameof(item.Id.MovieId)}, @{nameof(item.Id.GenreId)})";
            return insert;
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(MovieGenre item)
        {
            throw new NotImplementedException();
        }

        //----------------------------------------------------------------//

    }
}
