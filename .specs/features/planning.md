# Plan de desarrollo: Dashboard SaaS para inversionistas

## 1. Descripción general

Aplicación compuesta por frontend (Blazor WebAssembly), backend (ASP.NET Core Web API) y base de datos (Azure SQL). El dashboard mostrará métricas de empresas SaaS relevantes para inversionistas, con datos provenientes de un dataset de Kaggle.

## 2. Objetivos y alcance

- Desplegar un dashboard con métricas clave de empresas SaaS.
- Permitir filtrado por industria y ubicación.
- Backend con endpoints RESTful para healthcheck, listado de empresas, industrias y ubicaciones.
- Base de datos normalizada en Azure SQL, alimentada por scripts y dataset.

## 3. Funcionalidades principales

### Backend
- Endpoint de healthcheck.
- Endpoint para obtener listado de empresas con filtros por industria y ubicación, paginación (20 por página) y ordenamiento por nombre, inversión o valoración.
- Endpoint para obtener industrias (para filtro).
- Endpoint para obtener ubicaciones (para filtro).

### Frontend
- Dashboard con listado de empresas y métricas:
  - Nombre empresa
  - Industria
  - Ubicación
  - Productos
  - Fecha de fundación
  - Total inversión
  - Ingresos anuales
  - Valoración
- Filtros de búsqueda por industria y ubicación.
- Paginación y ordenamiento en la vista de empresas.

## 4. Atributos de calidad

- **Factibilidad:** Arquitectura por capas, tecnologías conocidas, base de datos ya provisionada.
- **Mantenibilidad:** Separación clara de responsabilidades, modularidad, pruebas unitarias y de integración.

## 5. Patrón de arquitectura

- Arquitectura por capas en backend y frontend.
- Backend: Controllers → Services → Repositories → Data.
- Frontend: Pages/Components → Services → DTOs.

## 6. Stack tecnológico

- **Frontend:** Blazor WebAssembly (`src/frontend`)
- **Backend:** ASP.NET Core Web API (`src/backend`)
- **Base de datos:** Azure SQL (scripts en `scripts/database/`)

## 7. Consideraciones adicionales

- Seguridad: El dashboard y los endpoints serán públicos en la primera versión. Se agregará autenticación en futuras versiones.
- Pruebas: Se implementarán pruebas unitarias y de integración siguiendo las reglas del repositorio.
- Paginación: 20 empresas por página.
- Ordenamiento: Por nombre, inversión o valoración.

## 8. Preguntas clave y respuestas

1. **¿Qué métricas específicas y cálculos adicionales requieren los inversionistas en el dashboard, además de los campos listados?**
   - Solo los campos mencionados son suficientes para la primera versión.
2. **¿Qué nivel de paginación, ordenamiento y cantidad máxima de resultados se espera en los endpoints de empresas?**
   - Paginación estándar (20 por página), ordenamiento por nombre, inversión o valoración.
3. **¿Qué requisitos de seguridad y autenticación se deben considerar para el acceso al dashboard y a los endpoints?**
   - El dashboard será público y los endpoints no requerirán autenticación en la primera versión.

## 9. Siguientes pasos

- Definir modelos y DTOs para empresas, industrias y ubicaciones.
- Implementar endpoints en el backend.
- Crear componentes y páginas en el frontend.
- Configurar conexión a Azure SQL y cargar datos.
- Implementar pruebas unitarias y de integración.
