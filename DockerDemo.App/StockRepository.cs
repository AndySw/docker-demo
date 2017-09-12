using System.Data.SqlClient;
using System.Collections.Generic;
using System.Data;

namespace DockerDemo.App
{

    public interface IStockRepository<TConnection, TCommand>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new(){
        IEnumerable<string> GetData();
    }

    public class StockRepository<TConnection, TCommand> : IStockRepository<TConnection, TCommand>
        where TConnection : IDbConnection, new()
        where TCommand : IDbCommand, new()
    {
        public const string COMMAND_TEXT = "SELECT * FROM Stock";
        private readonly IConnectionFactory<TConnection> _connectionFactory;
        private readonly ICommandFactory<TCommand> _commandFactory;
        private readonly ILogger _logger;

        public StockRepository(IConnectionFactory<TConnection> connectionFactory, ICommandFactory<TCommand> commandFactory, ILogger logger)
        {
            _connectionFactory = connectionFactory;
            _commandFactory = commandFactory;
            _logger = logger;
        }

        public IEnumerable<string> GetData()
        {
            try
            {
                return TryGetData();
            }
            catch (System.Exception ex)
            {
                _logger.Error(ex);
                return new List<string>();
            }
        }

        private IEnumerable<string> TryGetData()
        {
            var data = new List<string>();

            using (var dbConnection = _connectionFactory.GetConnection())
            {
                dbConnection.Open();
                using (var dbCommand = _commandFactory.GetCommand(COMMAND_TEXT))
                {
                    dbCommand.Connection = dbConnection;
                    using(var dataReader = dbCommand.ExecuteReader(CommandBehavior.CloseConnection)){
                        while(dataReader.Read()){
                            data.Add(dataReader["ItemText"].ToString());
                        }
                    }
                }
            }
            return data;
        }
    }
}