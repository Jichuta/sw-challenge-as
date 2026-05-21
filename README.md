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

## Validate each story
### Story 1: Define The API Vision And Scope
- `docs/vision.md` should exist [Link](https://github.com/Jichuta/sw-challenge-as/blob/main/swchallenge1/docs/vision.md).

### Story 2: Define The Task Data Model
- `docs/data-model.md` should exist [Link](https://github.com/Jichuta/sw-challenge-as/blob/main/swchallenge1/docs/data-model.md).

### Story 3: Define The OpenAPI Contract
- `docs/openapi.yaml` should exist [Link](https://github.com/Jichuta/sw-challenge-as/blob/main/swchallenge1/docs/openapi.yaml).

### Story 4: Create The ASP.NET Core Web API Solution
- Solution folder structure exists.
- API project exists.

### Story 5: Configure SQLite Persistence With EF Core
- EF Core packages are installed.
- SQLite provider is configured.
- `Task` entity should exist [Link](https://github.com/Jichuta/sw-challenge-as/blob/main/swchallenge1/Domain/Task/TaskItem.cs).
- DbContext exist [Link](https://github.com/Jichuta/sw-challenge-as/blob/main/swchallenge1/Infrastructure/Persistance/TaskDbContext.cs).
- Initial migration should exist [Link](https://github.com/Jichuta/sw-challenge-as/tree/main/swchallenge1/Infrastructure/Persistance/Migrations).

### Story 6: Create A Task
- POST endpoint is implemented according to `docs/openapi.yaml`.
- Invalid create requests return `400 Bad Request`.

### Story 7: View The Task List
- GET all task endpoint is implemented according to `docs/openapi.yaml`.
- The endpoint returns all stored tasks.

### Story 8: Edit A Task
- PUT update task endpoint is implemented according to `docs/openapi.yaml`.
- Existing tasks can be updated.
- Non existing task return `404 Not Found`.
- Invalid input returns `400 Bad Request`.

### Story 9: Mark A Task As Completed
- PATH endpoint is implemented according to `docs/openapi.yaml` to mask as completed a task.
- Missing tasks return `404 Not Found`.

### Story 10: Delete A Task
- DELETE task endpoint is implemented according to `docs/openapi.yaml`.
- Existing tasks can be deleted.
- Non existing task return `404 Not Found`.

### Story 11: Verify Implementation Against The Specification
- All APIs should match the behavior according to `docs/openapi.yaml`.

### Sprint 12: Add test for all endpoints
- All test should pass successfully