using System.Data;

namespace MovieDomain.DAL.Abstract
{
    public interface ISessionFactory
    {
        ISession CreateSession(IsolationLevel level = IsolationLevel.ReadCommitted);
    }
}
