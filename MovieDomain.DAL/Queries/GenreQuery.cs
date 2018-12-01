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

        public GenreQuery(ISession session)
            : base(session)
        {}

        //----------------------------------------------------------------//

        public Genre GetGenre(string genre)
        {
            string getGenre = $"SELECT TOP 1 * FROM {TableName} WHERE genre = @{nameof(genre)}";
            return _session.Connection.QueryFirstOrDefault<Genre>(getGenre, new { genre }, _session.Transaction);
        }

        //----------------------------------------------------------------//

        public override string GetUniqueConditionByItem(Genre item) => $" WHERE genre = @{nameof(item.genre)}";

        //----------------------------------------------------------------//

        public Task<int> GetIdByItem(Genre genre)
        {
            string getGenre = $"SELECT Id FROM {TableName} {GetUniqueConditionByItem(genre)}";
            return _session.Connection.QueryFirstOrDefaultAsync<int>(getGenre, genre, _session.Transaction);
        }

        //----------------------------------------------------------------//

    }
}
