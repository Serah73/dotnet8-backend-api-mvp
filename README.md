# .NET 8 Backend API MVP

Este repositorio contiene un **MVP de API REST** desarrollado con **ASP.NET Core .NET 8**, diseñado para demostrar competencias requeridas en un contexto de **Backend Engineer**

---

## Objetivo del proyecto

Construir una API REST que demuestre:

- Arquitectura backend clara y razonada
- Seguridad realista basada en JWT, roles y claims
- Uso correcto de EF Core con SQL Server
- Validaciones, manejo de errores y logging estructurado
- Preparación para despliegue y operación básica

---

## Alcance del MVP

El MVP incluye:

- API REST versionada (`v1`)
- Autenticación mediante JWT
- Autorización por roles y policies (claims)
- Gestión de usuarios, roles y permisos en base de datos
- Dominio de negocio basado en gestión de pedidos
- EF Core con migraciones y control de concurrencia
- Validaciones explícitas por request
- Logging estructurado y correlation ID
- Health checks (liveness / readiness)
- Tests unitarios y de integración
- Docker Compose para ejecución local reproducible

---

## Fuera de alcance (intencionalmente)

Para evitar sobreingeniería, **no** se incluyen:

- Microservicios
- CQRS completo o Event Sourcing
- Message brokers o colas
- Frontend
- Observabilidad avanzada (tracing distribuido, métricas)

Estos aspectos se consideran evoluciones naturales, no requisitos del MVP.

---

## Estructura de la solución

```text
src/
  Api/              # Endpoints HTTP, autenticación, middleware
  Domain/           # Entidades y reglas de negocio
  Infrastructure/   # Persistencia, EF Core, SQL Server
tests/
  Domain.UnitTests/
  Api.IntegrationTests/
