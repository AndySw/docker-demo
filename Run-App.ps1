Get-Date -DisplayHint Time
Write-Host 'Pull the mssql-server image'
docker pull microsoft/mssql-server-linux

Get-Date -DisplayHint Time
Write-Host 'Start an SQL Server instance'
docker run --name mssql-dev -d -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Passw0rd" -e "MSSQL_PID=Developer" -p 1433:1433 microsoft/mssql-server-linux

Get-Date -DisplayHint Time
Write-Host 'Wait 10 seconds for the SQL Server instance to start'
Start-Sleep -s 10

Get-Date -DisplayHint Time
Write-Host 'Connect to the SQL Server instance'
sqlcmd -S localhost -U sa -PPassw0rd -Q "SELECT @@VERSION"

Get-Date -DisplayHint Time
Write-Host 'Create the test fixtures'
sqlcmd -S localhost -U sa -PPassw0rd -i .\sql\createAppDb.sql

Get-Date -DisplayHint Time
Write-Host 'Run app'
dotnet run --project .\DockerDemo.App

Get-Date -DisplayHint Time
Write-Host 'Stop the SQL server instance'
docker stop mssql-dev

Get-Date -DisplayHint Time
Write-Host 'Delete the container'
docker rm mssql-dev

Get-Date -DisplayHint Time