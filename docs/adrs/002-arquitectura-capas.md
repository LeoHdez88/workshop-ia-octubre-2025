# 2. Arquitectura por capas

Fecha: Octubre 3 de 2025

## Status

Aceptada.

## Contexto

Es necesario establecer una arquitectura clara que permita mantenibilidad y separación de responsabilidades.

## Decisión

Implementar arquitectura por capas:
Backend:
- Controllers (API endpoints)
- Services (lógica de negocio)
- Repositories (acceso a datos)

Frontend:
- Pages (vistas Blazor)
- Components (UI reutilizable)
- Services (comunicación con API)

## Consecuencias

- Mayor mantenibilidad y testabilidad
- Separación clara de responsabilidades
- Facilita desarrollo paralelo