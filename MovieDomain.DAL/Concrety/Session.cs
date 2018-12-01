using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MovieDomain.DAL.Abstract;
using MovieDomain.DAL.Infrastructure;
using Dapper;

namespace MovieDomain.DAL.Concrety
{
    public class Session : ISession
    {
        private Boolean _isCommited;

        private IDbConnection _connection;

        private IDbTransaction _dbTransaction;

        //----------------------------------------------------------------//

        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }

        //----------------------------------------------------------------//

        public IDbTransaction Transaction
        {
            get
            {
                return _dbTransaction;
            }
        }

        //----------------------------------------------------------------//

        public Session(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _connection = new SqlConnection(ConfigurationFactory.MainDb);
            _connection.Open();
            _dbTransaction = _connection.BeginTransaction(isolationLevel);
        }

        //----------------------------------------------------------------//
            
        public Session(IDbConnection connection, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _connection = connection;
            _dbTransaction = _connection.BeginTransaction(isolationLevel);
        }

        //----------------------------------------------------------------//

        public void SaveChanges()
        {
            Transaction.Commit();
            _isCommited = true;
        } 

        //----------------------------------------------------------------//

        public void Dispose()
        {
            try
            {
                if (!_isCommited)
                {
                    _dbTransaction.Rollback();
                }
            }
            finally
            {
                _connection?.Close();
                _connection?.Dispose();
            }
        }

        //----------------------------------------------------------------//

    }
}
