# Personal Task List Vision

## Product Summary

Personal Task List is a minimal REST API that allows a user to manage a simple personal task list.

## Challenge Goal

The main goal of this challenge is to practice **Spec-Driven Development (SDD)**.

The expected workflow is:

1. Define the Api Project behavior in a documentation.
2. Define the data model.
3. Define the API contract in OpenAPI.
4. Implement the API according to the contract.
5. Add tests that prove the implementation follows the specification.

## Target User

The target user is a person who needs a simple way to track personal tasks through an API.

## Core Capabilities

The API must allow the user to:

- View all tasks in the personal task list.
- Create a task with a required title and optional description.

## Proposed API Scope

The first version should expose exactly five endpoints:

| Method | Endpoint | Purpose |
| --- | --- | --- |
| `GET` | `/api/tasks` | Return the full task list. |
| `POST` | `/api/tasks` | Create a new task. |