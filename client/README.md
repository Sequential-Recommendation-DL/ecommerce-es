## Clean Architecture - Monorepo

A modern e-commerce application built with **Clean Architecture** principles using **Next.js 16** and **Monorepo** structure.

## Getting Started

### Installation

```bash
yarn install
```

### Development

```bash
yarn dev
```

Open [http://localhost:3000](http://localhost:3000) with your browser to see the result.

### Build

```bash
yarn build
```

### Build Individual Packages

```bash
yarn build:core
yarn build:domain
yarn build:data
```

## Architecture Layers

### 1. **Domain Layer** (`@packages/domain`)

**Responsibility**: Business logic & rules

Contains:

- **Entities** - Core business objects (e.g., `PostDisplay`)
- **Repositories** - Interfaces defining data contracts
- **UseCases** - Business logic orchestration (e.g., `GetPostsUsecase`)

### 2. **Data Layer** (`@packages/data`)

**Responsibility**: Data access & API integration

Contains:

- **DataSources** - External API calls (JSONPlaceholder)
- **Models** - API response mapping
- **Repositories** - Implementations of domain interfaces

### 3. **Core Layer** (`@packages/core`)

**Responsibility**: Cross-cutting concerns & utilities

Contains:

- **Either Type** - Functional error handling (`Left<Error> | Right<Success>`)
- **Exceptions** - Domain exceptions (`NetworkException`, `DatabaseException`, etc.)
- **Failures** - Result failures (`NetworkFailure`, `ServerFailure`, etc.)
- **UseCases** - Common interface for use case pattern
- **Utilities** - Helper functions

### 4. **Presentation Layer** (`e-commerce-app`)

**Responsibility**: UI & user interaction

Contains:

- **Pages** - Next.js pages
- **API Routes** - Backend endpoints
- **Hooks** - React custom hooks
- **Components** - UI components

## Usage

### Access Posts with Pagination

Navigate to any of these URLs:

```
http://localhost:3000/posts/1      → Posts 1-10
http://localhost:3000/posts/2      → Posts 11-20
http://localhost:3000/posts/3      → Posts 21-30
```

## Project Structure

```
client/
├── packages/
│   ├── core/        # Utilities & Types
│   ├── domain/      # Business Logic
│   ├── data/        # Data Access
│   └── ...
├── e-commerce-app/  # Next.js App
├── package.json     # Monorepo config
└── README.md
```

**Exception Flow**:

```
API Error → Exception
  ↓
mapExceptionToFailure()
  ↓
Failure
  ↓
Response.json()
```

## Key Principles

- [x] Separation of Concerns – Each layer has a clear, single responsibility
- [x] Dependency Inversion – High-level modules depend on abstractions rather than concrete implementations
- [x] Reusability – Domain and Data layers are reusable across different parts of the application
- [x] Testability – Business logic is isolated from UI and external dependencies, making it easy to test
- [x] Maintainability – Clean structure with consistent naming improves readability and maintainability
- [x] Scalability – The architecture supports easy extension with new features and integrations

## Scripts

```bash
# Development
yarn dev                # Start dev

# Building
yarn build             # Build e-commerce-app
yarn build:core        # Build @packages/core
yarn build:domain      # Build @packages/domain
yarn build:data        # Build @packages/data

# Testing
yarn test              # Run tests
yarn test:ci           # Run tests in CI mode

# Linting
yarn lint              # Lint all packages
```
