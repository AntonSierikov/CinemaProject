using MovieDomain.Entities;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;
using Dapper;
using System.Data;

namespace MovieDomain.DAL.Commands
{
    internal class GenreCommand : BaseCommand<Genre, int>, IGenreCommand
    {
        //----------------------------------------------------------------//

        public GenreCommand(IDbConnection connection) : base(connection) {}

        //----------------------------------------------------------------//


        public GenreCommand(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        protected override string GenerateInsertQuery(Genre entity)
        {
            return $@"INSERT INTO {TableName} OUTPUT INSERTED.Id VALUES (@{nameof(entity.genre)})";
        }

        //----------------------------------------------------------------//

        protected override string GenerateUpdateQuery(Genre entity)
        {
            return $@"UPDATE {TableName} SET
                       genre = @{nameof(entity.genre)}
                       WHERE Id = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//
    }
}
