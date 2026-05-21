# Install Entty framework

### Commands to install dependencies
```bash
dotnet add .\swchallenge1.csproj package  Microsoft.EntityFrameworkCore.Sqlite -v 8

dotnet add .\swchallenge1.csproj package  Microsoft.EntityFrameworkCore.Design -v 8
```

### Install EF CLI if you do not have it:
```bash
dotnet tool install --global dotnet-ef
```
If already installed:
```bash
dotnet tool update --global dotnet-ef
```

### Create Initial migration
```bash
dotnet ef migrations add InitialCreate --project .\swchallenge1.csproj --startup-project .\swchallenge1.csproj --output-dir Infrastructure\Persistance\Migrations
```
The word *InitialCreate* could be anything, this is the word to generate the migration, and then apply the next command so you can see the changes reflected.


### Apply migration / Create SQLite database
```bash
dotnet ef database update --project .\swchallenge1.csproj --startup-project .\swchallenge1.csproj
```






 Create migration if starting from zero:

  dotnet ef migrations add InitialCreate --project
  src\PersonalTaskList.Api --startup-project
  src\PersonalTaskList.Api

  Apply migration / create database:

  dotnet ef database update --project src\PersonalTaskList.Api
  --startup-project src\PersonalTaskList.Api

  Run API:

  dotnet run --project src\PersonalTaskList.Api

  Verify:

  dotnet test PersonalTaskList.sln

  In the current project, SQLite is already installed and
  configured. The main command you need normally is:

  dotnet ef database update --project src\PersonalTaskList.Api
  --startup-project src\PersonalTaskList.Api