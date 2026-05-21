# Personal Task List User Stories

## Story Map

These stories define the work we need to complete for the Personal Task List challenge using Spec-Driven Development.

## Story 1: Define The API Vision And Scope

As a developer i need to understand the requirements, vison and scope of the project

Create a /docs/vision.md file with that information

### Acceptance criteria
Have a clear documentation of the spectation of the first challenge.

### Definition Of Done

- `docs/vision.md` exists.


## Story 2: Define The Task Data Model

As a developer i need to know the task data model

Create a /docs/data-model.md with the `Task` entity, what each field does, validations rules

### Acceptance Criteria
Have the data model well designed and documented

### Definition Of Done

- `docs/data-model.md` exists.


## Story 3: Define The OpenAPI Contract

As a developer we need to know clearly the contracts of each endpoint and error response scenarios

Create a /docs/openapi.yaml file with the description of the endpoints, request bodies, response bodies, status code and validation errors

### Acceptance Criteria
Have all crud endpoints well documented

### Definition Of Done

- `docs/openapi.yaml` exists.


## Story 4: Create The ASP.NET Core Web API Solution

Create the ASP.NET webapi project and solution

Create the initial .NET solution with one Web API project.

### Acceptance Criteria
webapi running with the initial setup

```bash
Scenario: API project starts successfully
  Given the Web API project exists
  When I run the API locally
  Then the application starts without runtime errors
```

### Definition Of Done

- Solution file exists.
- API project exists.

## Story 5: Configure SQLite Persistence With EF Core

As a developer i want to test the functionalities with persistance, so as an initial start lets add SQLite for storing data

Add as well Entity framework libraries, configure SQLite, as the Task entity, and create the DbContext and add the initial migration

### Acceptance Criteria

Database context is configured
Initial migration creates tasks table

```bash
Scenario: Database context is configured
  Given the API project exists
  When the application starts
  Then it configures an Entity Framework Core DbContext
  And the DbContext uses SQLite
```

```bash
Scenario: Initial migration creates tasks table
  Given EF Core migration is configured
  When the initial migration is applied
  Then the database contains a tasks table
  And the table contains the fields defined in docs/data-model.md
```

### Definition Of Done

- EF Core packages are installed.
- SQLite provider is configured.
- `Task` entity exists.
- DbContext exists.
- Initial migration exists.

## Story 6: Create A Task

Create a task endpoint

As a user i want to create a task that will help us track our task

### API Contract

`POST /api/tasks`

### Request Body

```json
{
  "title": "Buy groceries",
  "description": "Milk, eggs, bread"
}
```

### Acceptance Criteria

```bash
Scenario: Create task with valid data
  Given the API is running
  When I send a POST request to /api/tasks with a valid title and optional description
  Then the API returns 201 Created
  And the response contains the created task
  And the task has a generated id
  And isCompleted is false
  And createdAt is set
  And updatedAt is set
  And completedAt is null
```

```bash
Scenario: Create task without title
  Given the API is running
  When I send a POST request to /api/tasks without a title or with a blank empty title
  Then the API returns 400 Bad Request
  And no task is created
```

### Definition Of Done

- Endpoint is implemented according to `docs/openapi.yaml`.
- Invalid create requests return `400 Bad Request`.

## Story 7: View The Task List

View the task list

As a user i want to view all my task list

### API Contract

`GET /api/tasks`

### Acceptance Criteria

```bash
Scenario: View existing task list
  Given a task list exist in the database
  When I send a GET request to /api/tasks
  Then the API returns 200 OK
  And the response body contains the existing tasks
```

### Definition Of Done

- Endpoint is implemented according to `docs/openapi.yaml`.
- The endpoint returns all stored tasks.

## Story 8: Edit A Task

Edit a task

As a user i want to edit a task, so i can update its details.

### API Contract

`PUT /api/tasks/{id}`

### Request Body

```json
{
  "title": "Buy groceries and coffee",
  "description": "Milk, eggs, bread, coffee",
  "isComplete": true
}
```

### Acceptance Criteria

```bash
Scenario: Edit existing task
  Given an existing task id
  When I send a PUT request to /api/tasks/{id} with a valid title, description ans isComplete
  Then the API returns 200 OK
  And the response contains the updated task
  And the title, description and isComplete are updated
  And updatedAt is changed
```

```bash
Scenario: Edit non existing task
  Given an non exisiting id of a task
  When I send a PUT request to /api/tasks/{id}
  Then the API returns 404 Not Found
```

```bash
Scenario: Edit task with invalid title
  Given an existing task
  When I send a PUT request to /api/tasks/{id} with a blank title
  Then the API returns 400 Bad Request
  And the task is not updated
```

### Definition Of Done

- Endpoint is implemented according to `docs/openapi.yaml`.
- Existing tasks can be updated.
- Missing tasks return `404 Not Found`.
- Invalid input returns `400 Bad Request`.

## Story 9: Mark A Task As Completed

Mark a task as completed

As a user i want to mark as completed a task to which task i have completed.

### API Contract

`PATCH /api/tasks/{id}/complete`

### Acceptance Criteria

```bash
Scenario: Complete existing task
  Given an incomplete task exists
  When I send a PATCH request to /api/tasks/{id}/complete
  Then the API returns 200 OK
  And the response contains the completed task
  And isCompleted is true
  And completedAt is set
  And updatedAt is changed
```

```bash
Scenario: Complete missing task
  Given a non existing task id
  When I send a PATCH request to /api/tasks/{id}/complete
  Then the API returns 404 Not Found
```

### Definition Of Done

- Endpoint is implemented according to `docs/openapi.yaml`.
- Missing tasks return `404 Not Found`.

## Story 10: Delete A Task

Delete a task

As a user i want to delete a task

### API Contract

`DELETE /api/tasks/{id}`

### Acceptance Criteria

```bash
Scenario: Delete existing task
  Given an existing task
  When I send a DELETE request to /api/tasks/{id}
  Then the API returns 204 No Content
  And the task is removed from the database
```

```bash
Scenario: Delete missing task
  Given a non existing task id
  When I send a DELETE request to /api/tasks/{id}
  Then the API returns 404 Not Found
```

### Definition Of Done

- Endpoint is implemented according to `docs/openapi.yaml`.
- Existing tasks can be deleted.
- Missing tasks return `404 Not Found`.

## Story 11: Verify Implementation Against The Specification

Verify implementation against the specification

AS a developer i want to veryfy tge api behavior

### Acceptance Criteria

```bash
Scenario: Implementation matches contract
  Given docs/openapi.yaml defines the API contract
  When I compare the implementation to the contract
  Then every documented endpoint is implemented
  And no unsupported endpoints are added
```

### Definition Of Done

- API behavior matches `docs/openapi.yaml`.

## Sprint 12: Add test for all endpoints

Add tests for all scenarios of all endpoint

```bash
Scenario: Tests cover documented behavior
  Given the API implementation exists
  When I run the test suite
  Then tests verify task creation
  And tests verify task listing
  And tests verify task editing
  And tests verify task completion
  And tests verify task deletion
```

```bash
Scenario: Tests cover documented errors
  Given the API implementation exists
  When I run the test suite
  Then tests verify validation failures return 400 Bad Request
  And tests verify missing task operations return 404 Not Found
```

### Definition Of Done

- Validate all test pass successfully
