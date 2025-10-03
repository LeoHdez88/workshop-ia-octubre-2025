# 4. Integración con Azure SQL

Fecha: Octubre 3 de 2025

## Status

Aceptada.

## Contexto

El sistema necesita una base de datos robusta y escalable para datos de empresas SaaS.

## Decisión

Usar Azure SQL con:
- Entity Framework Core como ORM
- Migrations para control de esquema
- Connection pooling para optimización
- Backups automatizados

## Consecuencias

- Alta disponibilidad y respaldo automático
- Rendimiento optimizado con pooling
- Control de versiones de esquema