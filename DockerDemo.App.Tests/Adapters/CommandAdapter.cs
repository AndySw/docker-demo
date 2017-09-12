using System.Data;

namespace DockerDemo.App
{
    public class CommandAdapter<T> : IDbCommand
        where T : IDbCommand, new()
    {
        public string CommandText
        {
            get { return _dbCommand.CommandText; }
            set { _dbCommand.CommandText = value; }
        }
        public int CommandTimeout
        {
            get { return _dbCommand.CommandTimeout; }
            set { _dbCommand.CommandTimeout = value; }
        }
        public CommandType CommandType
        {
            get { return _dbCommand.CommandType; }
            set { _dbCommand.CommandType = value; }
        }
        public IDbConnection Connection
        {
            get { return _dbCommand.Connection; }
            set { _dbCommand.Connection = value; }
        }
        public IDataParameterCollection Parameters { get; }
        public IDbTransaction Transaction
        {
            get { return _dbCommand.Transaction; }
            set { _dbCommand.Transaction = value; }
        }
        public UpdateRowSource UpdatedRowSource
        {
            get { return _dbCommand.UpdatedRowSource; }
            set { _dbCommand.UpdatedRowSource = value; }
        }

        private readonly T _dbCommand;

        public CommandAdapter()
        {
            _dbCommand = new T();
        }

        public void Cancel()
        {
            _dbCommand.Cancel();
        }
        public IDbDataParameter CreateParameter()
        {
            return _dbCommand.CreateParameter();
        }
        public int ExecuteNonQuery()
        {
            return _dbCommand.ExecuteNonQuery();
        }
        public virtual IDataReader ExecuteReader()
        {
            return _dbCommand.ExecuteReader();
        }
        public virtual IDataReader ExecuteReader(CommandBehavior behavior)
        {
            return _dbCommand.ExecuteReader(behavior);
        }
        public object ExecuteScalar()
        {
            return _dbCommand.ExecuteScalar();
        }
        public void Prepare()
        {
            _dbCommand.Prepare();
        }

        public void Dispose(){
            _dbCommand.Dispose();
        }
    }
}