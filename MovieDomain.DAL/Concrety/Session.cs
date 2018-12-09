using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MovieDomain.DAL.Abstract;

namespace MovieDomain.DAL.Concrety
{
    public class Session : ISession
    {
        private Boolean _isCommited;

        private readonly Boolean _needDisposeConnection;

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

        public Session(String connectionString, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _dbTransaction = _connection.BeginTransaction(isolationLevel);
            _needDisposeConnection = true;
        }

        //----------------------------------------------------------------//
            
        public Session(IDbConnection connection, IsolationLevel isolationLevel = IsolationLevel.ReadCommitted)
        {
            _connection = connection;
            _needDisposeConnection = false;
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
                if (_needDisposeConnection)
                {
                    _connection?.Close();
                    _connection?.Dispose();
                }
            }
        }

        //----------------------------------------------------------------//

    }
}
