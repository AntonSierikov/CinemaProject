using System;
using System.Collections.Generic;
using System.Data;

namespace MovieDomain.DAL.Abstract
{
    public abstract class DbOperationFactory
    {

        //----------------------------------------------------------------//

        private Dictionary<Type, Func<ISession, object>> _sessionOperations;

        private Dictionary<Type, Func<IDbConnection, object>> _connectionOperations;

        //----------------------------------------------------------------//

        public DbOperationFactory()
        {
            _sessionOperations = new Dictionary<Type, Func<ISession, object>>();
            _connectionOperations = new Dictionary<Type, Func<IDbConnection, object>>();
            InitConnectionOperations();
            InitSessionOperations();
        }

        //----------------------------------------------------------------//

        protected abstract void InitConnectionOperations();

        protected virtual void InitSessionOperations() {}

        //----------------------------------------------------------------//

        protected void AddSessionOperation<TInterface>(Func<ISession, object> func)
        {
            _sessionOperations.Add(typeof(TInterface), s => func(s));
        }

        protected void AddConnectionOperation<TInterface>(Func<IDbConnection, object> func)
        {
            _connectionOperations.Add(typeof(TInterface), s => func(s));
        }

        //----------------------------------------------------------------//
        public T Create<T>(ISession session)
        {
            if(_sessionOperations.TryGetValue(typeof(T), out Func<ISession, object> func))
            {
                return (T)func(session);
            }

            throw new ArgumentException("Object not exist");
        }

        //----------------------------------------------------------------//

        public T Create<T>(IDbConnection connection)
        {
            if(_connectionOperations.TryGetValue(typeof(T), out Func<IDbConnection, object> func))
            {
                return (T)func(connection);
            }

            throw new ArgumentException();
        }

        //----------------------------------------------------------------//

    }
}
