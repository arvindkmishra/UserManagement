# User Management API

## Overview

The User Management API is a .NET Core-based service designed to handle user management operations such as creation, update, and deactivation of users. The project follows Domain-Driven Design (DDD) and Command Query Responsibility Segregation (CQRS) principles, ensuring a scalable and maintainable architecture. It integrates with RabbitMQ for messaging and MongoDB for persistence.

## Architecture

### Domain-Driven Design (DDD)

The project is structured around the core domain, which includes:

- Entities: Core objects with identities that are tracked throughout their lifecycle.

- Repositories: Abstractions for data access, allowing the domain to be persistence-agnostic.
- Commands: Represent the intent to change the state of the system.

### Command Query Responsibility Segregation (CQRS)

CQRS is implemented to separate the write and read operations, enhancing scalability and maintainability:

- Commands: Represent the intent to change the state of the system.
- Command Handlers: Contain the business logic for handling commands.
- Queries: Read operations that return data without modifying the state.

### Technology Stack
- .NET Core: Framework for building the API.
- RabbitMQ: Message broker for handling user management events.
- MongoDB: NoSQL database for persisting user data.
- MediatR: Library for implementing CQRS pattern.
- Docker: Containerization of the application.

### Project Structure

#### UserManagement
- UserManagement.API           : API project
- UserManagement.Core     :  Application layer (CQRS implementation)
- UserManagement.Domain  : Domain layer (entities, repositories, etc.)
- UserManagement.Infrastructure : Infrastructure layer (database, messaging)
- UserManagement.Tests          : Unit tests

### Running the Project

#### Prerequisites

- Docker
- .NET Core SDK

#### License
This project is licensed under the MIT License. See the LICENSE file for details.