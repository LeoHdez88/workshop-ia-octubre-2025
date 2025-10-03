# 3. Estrategia de autenticación y autorización

Fecha: Octubre 3 de 2025

## Status

Aceptada.

## Contexto

Se requiere planificar la seguridad para futuras versiones del dashboard.

## Decisión

Implementar:
- JWT para autenticación
- Roles basados en claims para autorización
- Azure AD B2C para gestión de identidad

## Consecuencias

- Seguridad robusta y escalable
- Integración nativa con Azure
- Soporte para múltiples proveedores de identidad