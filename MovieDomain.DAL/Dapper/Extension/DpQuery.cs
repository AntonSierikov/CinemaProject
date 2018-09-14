using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using MovieDomain.DAL.Infrastructure;

namespace MovieDomain.DAL.Dapper.Extension
{
    public static class DpQuery
    {
        private const string defaultSchema = "dbo";

        //----------------------------------------------------------------//

        public static int ExecuteAction(Func<IDbConnection, int> func)
        {
            int countRows = 0;
            using(IDbConnection connection = new SqlConnection(ConfigurationFactory.MainDb))
            {
                connection.Open();
                countRows = func(connection);
            }
            return countRows;
        }

        //----------------------------------------------------------------//

        public static int ExecSQLCommand(string sql, object param, IDbConnection conn = null, IDbTransaction transcation = null,
                                          int? timeout = null, CommandType? type = null)
        {
            int countRows = 0;
            using (IDbConnection connection = conn ?? new SqlConnection(ConfigurationFactory.MainDb))
            {
                connection.Open();
                using (IDbTransaction dbTransaction = transcation ?? connection.BeginTransaction())
                {
                    try
                    {
                        countRows = connection.Execute(sql, param, dbTransaction, timeout, type);
                        dbTransaction.Commit();
                    }
                    catch (Exception)
                    {
                        dbTransaction.Rollback();
                    }
                }
            }
            return countRows;
        }

        //----------------------------------------------------------------//

        public static T Single<T>(string sql, object param, IDbTransaction transcation = null,
                                   int? timeout = null, CommandType? type = null)
        {
            T obj;
            using (IDbConnection connection = new SqlConnection(ConfigurationFactory.MainDb))
            {
                obj = connection.QueryFirstOrDefault<T>(sql, param, transcation, timeout, type);
            }
            return obj;
        }

        //----------------------------------------------------------------//

        public static IEnumerable<T> Enumeration<T>(string sql, object param = null, IDbTransaction transcation = null,
                                                    bool buffered = true, int? timeout = null, CommandType? type = null)
        {
            IEnumerable<T> enumeration;
            using (IDbConnection connection = new SqlConnection(ConfigurationFactory.MainDb))
            {
                enumeration = connection.Query<T>(sql, param, transcation, buffered, timeout, type);
            }
            return enumeration;
        }

        //----------------------------------------------------------------//

        public static int ScalarInteger(string sql, object param = null, IDbTransaction transaction = null,
                                        int? timeout = null, CommandType? commandType = null)
        {
            int scalarValue;
            using (IDbConnection connection = new SqlConnection(ConfigurationFactory.MainDb))
            {
                scalarValue = connection.ExecuteScalar<int>(sql, param, transaction, timeout, commandType);
            }
            return scalarValue;
        }

        //----------------------------------------------------------------//



    }
}
