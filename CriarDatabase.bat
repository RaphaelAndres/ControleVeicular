dotnet restore
dotnet build
dotnet ef --startup-project .\ControleVeicular.WebApi\ControleVeicular.WebApi.csproj database update
sqlcmd -E -S "(LocalDB)\MSSQLLOCALDB" -d ControleAutomotivo -i .\Sql\InserirDependencias.sql
pause