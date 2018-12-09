using System;
using System.Collections.Generic;
using System.Data;

namespace MovieDomain.DAL.Abstract
{
    public abstract class ConnectionOperationFactory
    {

        //----------------------------------------------------------------//

        private Dictionary<Type, Func<IDbConnection, object>> _connectionOperations;

        //----------------------------------------------------------------//

        public ConnectionOperationFactory()
        {
            _connectionOperations = new Dictionary<Type, Func<IDbConnection, object>>();
            InitConnectionOperations();
        }

        //----------------------------------------------------------------//

        protected abstract void InitConnectionOperations();

        //----------------------------------------------------------------//

        protected void AddConnectionOperation<TInterface>(Func<IDbConnection, object> func)
        {
            _connectionOperations.Add(typeof(TInterface), s => func(s));
        }

        //----------------------------------------------------------------//
        public T Create<T>(IDbConnection connection)
        {
            if (_connectionOperations.TryGetValue(typeof(T), out Func<IDbConnection, object> func))
            {
                return (T)func(connection);
            }

            throw new ArgumentException("Object not exist");
        }

        //----------------------------------------------------------------//

    }
}
