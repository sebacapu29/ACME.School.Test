# ACME School Test

## Descripción
Este es un proyecto realizado con tecnologías .Net, con la finalidad de registrar estudiantes, registrar cursos y listar los cursos dentro de un rango de fechas.

## Estructura del Proyecto
- **ACME.School.Domain**: Contiene las entidades del dominio y las interfaces de los repositorios y servicios.
- **ACME.School.Application**: Contiene la lógica de la aplicación.
- **ACME.School.Infrastructure**: Contiene las conexiones a base de datos o sistemas externos.
- **ACME.School.Tests**: Contiene las pruebas unitarias.
- **ACME.School.API**: Aplicación Web API para probar la funcionalidad.

## Bibliotecas de Terceros
- **EntityFramework Core**: ORM para facilitar la lectura y escritura de los datos.
- **Moq**: Para la creación de mocks en las pruebas unitarias.
- **xUnit**: Framework de pruebas unitarias.

## Mejoras Futuras
- Implementar CQRS en caso de crecimiento de la aplicacion.
- Integrar una pasarela de pago real.

## Tiempo invertido
- Se tomo al rededor de 20 horas en realizar el proyecto completo

## Cosas Investigadas
Se reforzó en los siguientes puntos:
- Clean Architecture
- Framework xUnit
- Entity Framework Core
- Moq
- Configuration Service
