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

        public bool IsExist(Genre genre)
        {
            string getGenre = $"SELECT COUNT(*) FROM {TableName} WHERE genre = @{nameof(genre.genre)}";
            return _session.Connection.ExecuteScalar<int>(getGenre, genre, _session.Transaction) > default(int);
        }

        //----------------------------------------------------------------//

    }
}
