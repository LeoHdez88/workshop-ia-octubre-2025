# Plan de tareas: Dashboard SaaS para inversionistas

## 1. Diseño y arquitectura

### 1.1 ADRs
- [x] ADR-001: Selección de stack tecnológico (Blazor WASM, ASP.NET Core, Azure SQL)
- [x] ADR-002: Implementación de arquitectura por capas en backend y frontend
- [x] ADR-003: Estrategia de autenticación y autorización para futuras versiones
- [x] ADR-004: Integración y configuración con Azure SQL

### 1.2 Diagramas de arquitectura C4
- [x] Generar diagrama de contexto incluyendo actores (inversionistas) y sistemas externos
- [x] Generar diagrama de contenedores mostrando frontend, backend y base de datos
- [x] Documentar diagramas en `/docs/architecture/diagrams.md` usando Mermaid

### 1.3 Diseño de base de datos
- [x] Revisar script existente `01-top-saas-db-creation.sql`
- [x] Validar modelo de datos, relaciones y tipos de datos
- [x] Generar diagrama entidad-relación usando Mermaid
- [x] Documentar modelo en `/docs/database/database-model.md`

## 2. Backend

### 2.1 Configuración inicial
 - [x] Configurar conexión a Azure SQL
 - [x] Implementar estructura de capas (Controllers, Services, Repositories)
 - [x] Configurar inyección de dependencias

### 2.2 Modelos y DTOs
 [x] Crear DTOs para respuestas de API
 [x] Implementar mapeos entre modelos y DTOs
[x] Implementar endpoint de listado de empresas con filtros
 [x] Implementar endpoint de industrias
 [x] Implementar endpoint de ubicaciones
### 2.4 Pruebas unitarias
 - [x] Pruebas unitarias para servicios de empresas
 - [x] Pruebas unitarias para servicios de industrias
 - [x] Pruebas unitarias para servicios de ubicaciones
 - [x] Pruebas unitarias para controladores
## 3. Frontend

### 3.1 Configuración inicial
 [x] Configurar conexión a Azure SQL
 [x] Implementar estructura de capas (Controllers, Services, Repositories)
 [x] Configurar inyección de dependencias

### 3.3 Servicios
- [x] Implementar servicio de empresas
- [x] Implementar servicio de industrias
- [x] Implementar servicio de ubicaciones

## 4. Integración y pruebas

### 4.1 Integración
- [x] Integrar frontend con backend
- [x] Verificar paginación y filtros
- [x] Verificar ordenamiento

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