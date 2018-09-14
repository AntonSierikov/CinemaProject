using MovieDomain.Entities;
using MovieDomain.DAL.ICommands;
using MovieDomain.DAL.Abstract;
using Dapper;

namespace MovieDomain.DAL.Commands
{
    internal class GenreCommand : BaseCommand<Genre, int>, IGenreCommand
    {
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
                       WHERE GenreId = @{nameof(entity.Id)}";
        }

        //----------------------------------------------------------------//
    }
}
