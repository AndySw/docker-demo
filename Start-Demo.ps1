# Pull the mssql-server image
docker pull microsoft/mssql-server-windows

# Start an SQL Server instance
docker run --name mssql -d -p 1433:1433 -e sa_password=12345 -e ACCEPT_EULA=Y microsoft/mssql-server-windows

# Connect to the SQL Server instance
sqlcmd -S localhost -Q "SELECT @@VERSION"

# Create the test fixtures
sqlcmd -S localhost -i .\createTestFixtures.sql



# Stop the SQL server instance
docker stop mssql

# Delete the container
docker rm mssql