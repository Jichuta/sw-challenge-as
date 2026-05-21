# Personal Task List User Stories

## Story Map

These stories define the work needed to complete the Personal Task List challenge using Spec-Driven Development.

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

### Definition Of Done

- Solution file exists.
- API project exists.

## Story 5: Configure SQLite Persistence With EF Core

As a developer i want to test the functionalities with persistance, so as an initial start lets add SQLite for storing data

Add as well Entity framework libraries, configure SQLite, ass the Task entity, and create the DbContext and add the initial migration

### Acceptance Criteria

Database context is configured
Initial migration creates tasks table

### Definition Of Done

- EF Core packages are installed.
- SQLite provider is configured.
- `Task` entity exists.
- DbContext exists.
- Initial migration exists.