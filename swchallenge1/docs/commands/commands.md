# Commands
### dotnet command to create a project
```bash
dotnet new webapi -o swchallenge1 --use-program-main
dotnet new sln -n swchallenge
dotnet sln swchallenge.sln add swchallenge1\swchallenge1.csproj
cd .\swchallenge1\
dotnet run 
```

### Server listening
```link
http://localhost:5065/swagger/index.html
```