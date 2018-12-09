using System.Data;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Concrety;

namespace MovieDomain.DAL.Factories
{
    public class SessionFactory : ISessionFactory
    {
        private string _connectionString;

        public SessionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ISession CreateSession(IsolationLevel level) => new Session(_connectionString, level);

        public ISession CreateSession(IDbConnection connection, IsolationLevel level) => new Session(connection, level);
    }
}
