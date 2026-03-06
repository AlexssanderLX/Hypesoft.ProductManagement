# Hypesoft Product Management

Product management system developed as a technical challenge for Hypesoft.
The project implements a fullstack architecture with a structured backend following Clean Architecture principles and a React + TypeScript frontend.

The system allows management of products, categories, stock quantities and dashboard summaries through a RESTful API.

---

## Features

* Product CRUD (create, read, update, delete)
* Category management
* Product search
* Stock quantity control
* Dashboard summary
* REST API integration between frontend and backend
* Containerized backend using Docker

---

## Architecture

The backend follows a layered architecture inspired by Clean Architecture principles, separating responsibilities across different projects.

```
Domain
Application
Infrastructure
API
```

### Domain

Contains the core business entities and domain rules.

### Application

Contains commands, handlers and application services responsible for orchestrating business operations.

### Infrastructure

Responsible for data persistence, Entity Framework configuration and external services.

### API

Handles HTTP requests, controllers and dependency injection configuration.

---

## Tech Stack

Backend

* .NET
* ASP.NET Core Web API
* Entity Framework Core
* MySQL / SQL database
* Docker

Frontend

* React
* Next.js
* TypeScript
* TailwindCSS

Tools

* Git
* GitHub
* Swagger

---

## Project Structure

```
backend
 ├── Hypesoft.API
 ├── Hypesoft.Application
 ├── Hypesoft.Domain
 └── Hypesoft.Infrastructure

frontend
 └── React / Next.js application
```

---

## Running the Project

### Running with Docker

The backend API can be executed using Docker.

Build the container:

```
docker build -t hypesoft-product-management .
```

Run the container:

```
docker run -p 5000:5000 hypesoft-product-management
```

---

### Running the Backend Locally

Navigate to the backend directory:

```
cd backend
```

Restore dependencies:

```
dotnet restore
```

Run the API:

```
dotnet run
```

Swagger documentation will be available at:

```
/swagger
```

---

### Running the Frontend

Navigate to the frontend directory:

```
cd frontend
```

Install dependencies:

```
npm install
```

Run the development server:

```
npm run dev
```

The application will run on:

```
http://localhost:3000
```

---

## API Endpoints

Products

```
GET /api/products
POST /api/products
PUT /api/products/{id}
DELETE /api/products/{id}
```

Categories

```
GET /api/categories
POST /api/categories
```

Dashboard

```
GET /api/dashboard/summary
```

---

## Purpose

This project was developed to demonstrate knowledge in backend architecture, REST API development, frontend integration and containerization using Docker.

---

## Author

Alexssander Ferreira de Almeida

Computer Science student and software developer focused on backend architecture, security and scalable systems.
