using System;
using System.Data.SqlClient;
using System.Data;
using System.Linq;


namespace DockerDemo.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Program started.\r\n");
            ILogger logger = new Logger();
            ICommandFactory<SqlCommand> commandFactory = new CommandFactory<SqlCommand>();
            IConnectionFactory<SqlConnection> connectionFactory = new ConnectionFactory<SqlConnection>("Server=localhost;Database=AppDB;User Id=sa;Password=Passw0rd;");
            IStockRepository<SqlConnection, SqlCommand> repository = new StockRepository<SqlConnection, SqlCommand>(connectionFactory, commandFactory, logger);

            var data = repository.GetData();

            foreach(var item in data){Console.WriteLine($"\t - {item}");}

            Console.WriteLine("\r\nProgram complete.");
        }
    }
}