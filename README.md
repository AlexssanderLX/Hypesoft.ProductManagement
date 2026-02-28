# Hypesoft Product Management

Technical challenge developed for Hypesoft.

## Overview

Full-stack Product Management System built with modern architecture principles and security best practices.

## Tech Stack

### Backend
- .NET 9
- Clean Architecture + DDD
- CQRS + MediatR
- MongoDB
- FluentValidation
- AutoMapper
- Serilog
- Keycloak (OAuth2 / OpenID Connect)

### Frontend
- Next.js 14 (App Router)
- React 18
- TypeScript
- TailwindCSS

### Infrastructure
- Docker + Docker Compose
- Nginx (Reverse Proxy)

## Security Considerations

During dependency auditing (`npm audit`), known advisories were identified affecting:

- Next.js 14.x (DoS-related advisories involving Image Optimizer and React Server Components deserialization)
- `glob` dependency used by ESLint (development-only advisory)

### Decision

The project intentionally remains on Next.js 14 to comply with the technical challenge requirements.

### Production Mitigation Strategy

In a real production scenario:

- Upgrade to the latest secure Next.js LTS version
- Restrict image optimization configuration
- Apply rate limiting via Nginx
- Enforce strict API validation
- Automate dependency audits in CI pipelines
