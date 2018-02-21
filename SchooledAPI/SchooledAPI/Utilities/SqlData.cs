using System;
using Dapper;
using System.Collections.Generic;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;
using System.Data;
using System.Linq;
using System.Data.SqlClient;

namespace SchooledAPI.Utilities
{
    public abstract class SqlData : IDisposable
    {
        protected SqlData()
        {
            SqlMapper.AddTypeMap(typeof(DateTime), DbType.DateTime2);
            var retryStrategy = new Incremental(3, TimeSpan.FromMilliseconds(500), TimeSpan.FromSeconds(1));
            RetryPolicy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(retryStrategy);
            SqlConnection = new SqlConnection(Settings.SchooledDatabaseConnection);
        }
        private RetryPolicy RetryPolicy { get; set; }
        public SqlConnection SqlConnection { get; set; }
        public void Dispose()
        {
            SqlConnection.Dispose();
        }
        public class Command : SqlData
        {
            public Action Action { get; set; }
            public void Execute(SqlProcedureData.Procedures proc, object parameters = null)
            {
                SqlConnection.Execute(proc.ToString(), commandType: CommandType.StoredProcedure, param: parameters, commandTimeout: 200);
            }
            public void Run()
            {
                RetryPolicy.ExecuteAction(Action);
            }
        }
        public class Scaler<T> : SqlData
        {
            public Func<T> Action { get; set; }
            public T Execute(SqlProcedureData.Procedures proc, object parameters = null)
            {
                return SqlConnection.ExecuteScalar<T>(proc.ToString(), commandType: CommandType.StoredProcedure, param: parameters);
            }
            public T Run()
            {
                return RetryPolicy.ExecuteAction(Action);
            }
        }
        public class Record<T> : SqlData
        {
            public Func<T> Action { get; set; }
            public T Execute(SqlProcedureData.Procedures proc, object parameters = null)
            {
                return SqlConnection.Query<T>(proc.ToString(), commandType: CommandType.StoredProcedure, param: parameters).SingleOrDefault();
            }
            public T Run()
            {
                return RetryPolicy.ExecuteAction(Action);
            }
        }
        public class Records<T> : SqlData
        {
            public Func<List<T>> Action { get; set; }
            public List<T> Execute(SqlProcedureData.Procedures proc, object parameters = null)
            {
                return SqlConnection.Query<T>(proc.ToString(), commandType: CommandType.StoredProcedure, param: parameters).ToList();
            }
            public List<T> Run()
            {
                return RetryPolicy.ExecuteAction(Action);
            }
        }
        public class ConnectionOnly : SqlData
        {
            public Action Action { get; set; }
            public void Run()
            {
                RetryPolicy.ExecuteAction(Action);
            }
        }
    }
}