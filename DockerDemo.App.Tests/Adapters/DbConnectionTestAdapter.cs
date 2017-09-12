using System;
using System.Data;

namespace DockerDemo.App
{
    public class DbConnectionTestAdapter<T> : IDbConnection
        where T:IDbConnection, new()
    {
        public string ConnectionString {get; set;}
        public int ConnectionTimeout {get {return _dbConnection.ConnectionTimeout;}}
        public string Database {get {return _dbConnection.Database;}}
        public ConnectionState State {get {return _dbConnection.State;}}

        private readonly T _dbConnection;
        public DbConnectionTestAdapter(){
            _dbConnection = new T();
        }

        public IDbTransaction BeginTransaction(){
           return _dbConnection.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il){
           return _dbConnection.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName) {
            _dbConnection.ChangeDatabase(databaseName);
        }

        public void Close(){
            _dbConnection.Close();
        }

        public IDbCommand CreateCommand(){
            return _dbConnection.CreateCommand();
        }

        public void Open(){
            _dbConnection.Open();
        }
        public void Dispose(){
            _dbConnection.Dispose();
        }
    }
}