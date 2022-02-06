using Dapper;
using System;
using System.Collections.Generic;

namespace OncoDiagnose.DataAccess.Repositories.Interfaces
{
    public interface ISP_Call : IDisposable
    {
        T Single<T>(string procedureName, DynamicParameters parameters = null);
        void Execute(string procedureName, DynamicParameters parameters = null);
        T OneRecord<T>(string procedureName, DynamicParameters parameters = null);
        IEnumerable<T> List<T>(string procedureName, DynamicParameters parameters = null);
        Tuple<IEnumerable<T1>, IEnumerable<T2>> List<T1, T2>(string procedureName, DynamicParameters parameters = null);
    }
}