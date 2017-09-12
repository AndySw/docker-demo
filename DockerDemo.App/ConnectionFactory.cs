using System;
using System.Data;
using System.Data.Common;

namespace DockerDemo.App
{
    public interface IConnectionFactory<T> 
        where T:IDbConnection, new()
    {
        T GetConnection();
    }

    public class ConnectionFactory<T> : IConnectionFactory<T> 
        where T:IDbConnection, new()
    {
        private readonly string _connectionString;
        private ConnectionFactory() {throw new System.NotImplementedException();}
        public ConnectionFactory(string connectionString){
            _connectionString = connectionString;
        }

        public T GetConnection(){
            T connection = new T();
            connection.ConnectionString = _connectionString;
            return connection;
        }
    }
}