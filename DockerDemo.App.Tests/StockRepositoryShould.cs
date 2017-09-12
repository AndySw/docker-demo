using System;
using Xunit;
using Moq;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections.Generic;
using System.Data;

namespace DockerDemo.App.Tests
{
    public class StockRepositoryShould
    {


        public StockRepositoryShould()
        {

        }

        [Fact]
        public void GetData()
        {
            // arrange
            string commandText = StockRepository<ConnectionAdapter<SqlConnection>, CommandAdapter<SqlCommand>>.COMMAND_TEXT;
            var stubConnection = Mock.Of<ConnectionAdapter<SqlConnection>>();

            var dataReader = new Mock<IDataReader>();
            dataReader.Setup(m => m["ItemText"].ToString()).Returns("Hello");
            dataReader.SetupSequence(m => m.Read()).Returns(true).Returns(true).Returns(false);

            var stubCommand = Mock.Of<CommandAdapter<SqlCommand>>(m => m.ExecuteReader() == dataReader.Object);
            var mockConnectionFactory = Mock.Of<IConnectionFactory<ConnectionAdapter<SqlConnection>>>
                (m => m.GetConnection() == stubConnection);

            var mockCommandFactory = Mock.Of<ICommandFactory<CommandAdapter<SqlCommand>>>
             (m => m.GetCommand(commandText) == stubCommand);

            var mockLogger = Mock.Of<ILogger>();
            var unit = new StockRepository<ConnectionAdapter<SqlConnection>, CommandAdapter<SqlCommand>>(mockConnectionFactory, mockCommandFactory, mockLogger);

            var expected = new List<string>() {"Hello", "Hello"};

            // act
            var actual = unit.GetData();

            // assert
            Assert.Equal(expected, actual);
        }

        public void LogExceptions()
        {

        }

        // public void LogExceptions()
        // {

        // }
    }
}
