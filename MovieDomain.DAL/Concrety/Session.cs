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
            _dbTransaction = _connection.BeginTransaction();
        }

        //----------------------------------------------------------------//

        public void Dispose()
        {
            try
            {
                _dbTransaction?.Commit();
            }
            catch
            {
                _dbTransaction.Rollback();
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
