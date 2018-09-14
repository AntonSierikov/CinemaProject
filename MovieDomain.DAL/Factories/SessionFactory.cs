using System.Data;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Concrety;

namespace MovieDomain.DAL.Factories
{
    public class SessionFactory : ISessionFactory
    {
        public ISession CreateSession(IsolationLevel level) => new Session(level);
    }
}
