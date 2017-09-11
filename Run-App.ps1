# Pull the mssql-server image
docker pull microsoft/mssql-server-linux

# Start an SQL Server instance
docker run --name mssql-dev -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Passw0rd" -e "MSSQL_PID=Developer" --cap-add SYS_PTRACE -p 1433:1433 microsoft/mssql-server-linux

# Connect to the SQL Server instance
sqlcmd -S localhost -U sa -PPassword! -Q "SELECT @@VERSION"

# Create the test fixtures
sqlcmd -S localhost -i .\createTestFixtures.sql

# Run app
dotnet run ./DockerDemo.App

# Stop the SQL server instance
docker stop mssql-dev

# Delete the container
docker rm mssql-dev