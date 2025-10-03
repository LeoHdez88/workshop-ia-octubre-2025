# Plan de tareas: Dashboard SaaS para inversionistas

## 1. Diseño y arquitectura

### 1.1 ADRs
- [ ] ADR-001: Selección de stack tecnológico (Blazor WASM, ASP.NET Core, Azure SQL)
- [ ] ADR-002: Implementación de arquitectura por capas en backend y frontend
- [ ] ADR-003: Estrategia de autenticación y autorización para futuras versiones
- [ ] ADR-004: Integración y configuración con Azure SQL

### 1.2 Diagramas de arquitectura C4
- [ ] Generar diagrama de contexto incluyendo actores (inversionistas) y sistemas externos
- [ ] Generar diagrama de contenedores mostrando frontend, backend y base de datos
- [ ] Documentar diagramas en `/docs/architecture/diagrams.md` usando Mermaid

### 1.3 Diseño de base de datos
- [ ] Revisar script existente `01-top-saas-db-creation.sql`
- [ ] Validar modelo de datos, relaciones y tipos de datos
- [ ] Generar diagrama entidad-relación usando Mermaid
- [ ] Documentar modelo en `/docs/database/database-model.md`

## 2. Backend

### 2.1 Configuración inicial
- [ ] Configurar conexión a Azure SQL
- [ ] Implementar estructura de capas (Controllers, Services, Repositories)
- [ ] Configurar inyección de dependencias

### 2.2 Modelos y DTOs
- [ ] Crear modelos de dominio (Company, Industry, Location)
- [ ] Crear DTOs para respuestas de API
- [ ] Implementar mapeos entre modelos y DTOs

### 2.3 Endpoints
- [ ] Implementar HealthCheck endpoint
- [ ] Implementar endpoint de listado de empresas con filtros
- [ ] Implementar endpoint de industrias
- [ ] Implementar endpoint de ubicaciones

### 2.4 Pruebas unitarias
- [ ] Pruebas unitarias para servicios de empresas
- [ ] Pruebas unitarias para servicios de industrias
- [ ] Pruebas unitarias para servicios de ubicaciones
- [ ] Pruebas unitarias para controladores

## 3. Frontend

### 3.1 Configuración inicial
- [ ] Configurar estructura de componentes
- [ ] Configurar servicios HTTP
- [ ] Implementar interfaces y DTOs

### 3.2 Componentes
- [ ] Crear componente de filtros (industria y ubicación)
- [ ] Crear componente de listado de empresas
- [ ] Crear componente de paginación
- [ ] Implementar ordenamiento en el listado

### 3.3 Servicios
- [ ] Implementar servicio de empresas
- [ ] Implementar servicio de industrias
- [ ] Implementar servicio de ubicaciones

## 4. Integración y pruebas

### 4.1 Integración
- [ ] Integrar frontend con backend
- [ ] Verificar paginación y filtros
- [ ] Verificar ordenamiento

### 4.2 Pruebas finales
- [ ] Pruebas de integración backend-base de datos
- [ ] Pruebas end-to-end de funcionalidades principales
- [ ] Verificación de rendimiento con dataset completo

## 5. Documentación

### 5.1 Documentación técnica
- [ ] Documentar estructura del proyecto
- [ ] Documentar endpoints de API
- [ ] Documentar componentes principales

### 5.2 Documentación de usuario
- [ ] Guía de instalación y configuración
- [ ] Manual de usuario del dashboard

## Notas adicionales

- Priorizar la revisión del modelo de datos antes de comenzar el desarrollo
- Seguir las convenciones de código establecidas en el repositorio
- Mantener la documentación actualizada en cada fase
- Realizar commits frecuentes y descriptivos

## Dependencias

1. Los ADRs deben completarse antes de comenzar el desarrollo
2. El diseño de base de datos debe validarse antes de implementar los endpoints
3. Los endpoints del backend deben estar listos antes de implementar los servicios del frontend
4. Las pruebas unitarias deben implementarse junto con el desarrollo de cada componente