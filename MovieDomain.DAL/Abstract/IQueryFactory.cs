using System.Data;

namespace MovieDomain.DAL.Abstract
{
    public interface IQueryFactory
    {
        T CreateQuery<T>(ISession session);

        T CreateQuery<T>(IDbConnection connection);
    }
}
