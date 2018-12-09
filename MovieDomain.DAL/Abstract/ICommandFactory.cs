using System.Data;

namespace MovieDomain.DAL.Abstract
{
    public interface ICommandFactory
    {
        T CreateCommand<T>(ISession session);

        T CreateCommand<T>(IDbConnection connection);
    }
}
