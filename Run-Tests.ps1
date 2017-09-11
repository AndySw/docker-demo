# Pull the mssql-server image
docker pull microsoft/mssql-server-linux

# Start an SQL Server instance
docker run --name mssql-test -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Passw0rd" -e "MSSQL_PID=Developer" --cap-add SYS_PTRACE -p 1433:1433 microsoft/mssql-server-linux

# Connect to the SQL Server instance
sqlcmd -S localhost -U sa -P Passw0rd -Q "SELECT @@VERSION"

# Create the test fixtures
sqlcmd -S localhost -U sa -P Passw0rd -i .\sql\createTestFixtures.sql

# Execute tests
dotnet test ./DockerDemo.App.Tests

# Stop the SQL server instance
docker stop mssql-test

# Delete the container
docker rm mssql-test