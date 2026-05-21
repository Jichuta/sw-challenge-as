# Xunit tests

### Command to create the project
```bash
dotnet new xunit -n swchallenge1test -o swchallenge1test
```

### Add Test project to the solution
```bash
dotnet sln .\swchallenge.sln add .\swchallenge1test\swchallenge1test.csproj
```

### Reference to the API project
```bash
dotnet add .\swchallenge1test\swchallenge1test.csproj reference .\swchallenge1\swchallenge1.csproj
```

### Install test libraries
```bash
dotnet add .\swchallenge1test.csproj package Microsoft.AspNetCore.Mvc.Testing -v 8

dotnet add .\swchallenge1test.csproj package Microsoft.EntityFrameworkCore.Sqlite -v 8

dotnet add .\swchallenge1test.csproj package Microsoft.NET.Test.Sdk -v 8

dotnet add .\swchallenge1test.csproj package xunit

dotnet add .\swchallenge1test.csproj package xunit.runner.visualstudio
```