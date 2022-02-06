using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using OncoDiagnose.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OncoDiagnose.DataAccess.Repositories
{
    public class SP_Call : ISP_Call
    {
        private readonly OncoDbContext _db;
        private static string ConnectionString = "";

        public SP_Call(OncoDbContext db)
        {
            _db = db;
            ConnectionString = db.Database.GetDbConnection().ConnectionString;
        }
        public void Dispose()
        {
            _db.Dispose();
        }

        public T Single<T>(string procedureName, DynamicParameters parameters = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            return (T)Convert.ChangeType(sqlConnection.ExecuteScalar<T>(procedureName, parameters,
                commandType: System.Data.CommandType.StoredProcedure), typeof(T));
        }

        public void Execute(string procedureName, DynamicParameters parameters = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            sqlConnection.Execute(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public T OneRecord<T>(string procedureName, DynamicParameters parameters = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            var value = sqlConnection.Query<T>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
            return (T)Convert.ChangeType(value.FirstOrDefault(), typeof(T));
        }

        public IEnumerable<T> List<T>(string procedureName, DynamicParameters parameters = null)
        {
            using SqlConnection sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            return sqlConnection.Query<T>(procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters parameters = null)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                var result = SqlMapper.QueryMultiple(sqlConnection, procedureName, parameters, commandType: System.Data.CommandType.StoredProcedure);
                var item1 = result.Read<T1>().ToList();
                var item2 = result.Read<T2>().ToList();

                if (item1 != null && item2 != null)
                {
                    return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(item1, item2);
                }
            }

            return new Tuple<IEnumerable<T1>, IEnumerable<T2>>(new List<T1>(), new List<T2>());
        }
    }
}