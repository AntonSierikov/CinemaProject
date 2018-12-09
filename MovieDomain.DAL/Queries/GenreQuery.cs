using System.Data;
using System.Threading.Tasks;
using MovieDomain.Entities;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.IQueries;
using Dapper;

namespace MovieDomain.DAL.Queries
{
    internal class GenreQuery : BaseQuery<Genre, int>, IGenreQuery
    {

        //----------------------------------------------------------------//

        public GenreQuery(IDbConnection connection) : base(connection)
        {}

        //----------------------------------------------------------------//

        public GenreQuery(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        public Genre GetGenre(string genre)
        {
            string getGenre = $"SELECT TOP 1 * FROM {TableName} WHERE genre = @{nameof(genre)}";
            return _connection.QueryFirstOrDefault<Genre>(getGenre, new { genre }, _transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Genre item) => $" WHERE genre = @{nameof(item.genre)}";

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Genre genre)
        {
            string getGenre = $"SELECT Id FROM {TableName} {GetUniqueConditionByItem(genre)}";
            return _connection.QueryFirstOrDefaultAsync<int>(getGenre, genre, _transaction);
        }

        //----------------------------------------------------------------//

    }
}
