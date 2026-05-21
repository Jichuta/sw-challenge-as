# Personal Task List API

API for managing personal task, we follow the spec-driven development. We understand the requirements, define the limitations and scope, define the data model, create the openapi contrats and then implemented the project.

## Teck stack

- ASP.NET Core 8
- EntityFramework
- SQLite
- xUnit test

## API Scope

The API exposes exactly the documented task endpoints:

| Method | Endpoint | Purpose |
| --- | --- | --- |
| `GET` | `/api/tasks` | Return all tasks. |
| `POST` | `/api/tasks` | Create a task. |
| `PUT` | `/api/tasks/{id}` | Edit a task. |
| `DELETE` | `/api/tasks/{id}` | Delete a task. |
| `PATCH` | `/api/tasks/{id}/complete` | Mark a task as completed. |


## Run locally

Make sure you have installed runtime and the sdks

```bash
cd swchallenge1
dotnet run
```

Run in watch mode
```bash
dotnet watch
```

## Run the test
```bash
cd swchallenge1test
dotnet test
```
## Swagger documentation
Go to this link http://localhost:5065/swagger/index.html