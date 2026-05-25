# Sistema de Parqueadero

Aplicación web desarrollada para la gestión de ingreso y salida de vehículos en un parqueadero, permitiendo el cálculo automático del valor a pagar según el tiempo de permanencia y el envío de notificaciones vía correo electrónico mediante una API externa.

# Tecnologías Utilizadas

## Frontend
- Angular
- Bootstrap
- SweetAlert2
- TypeScript

## Backend
- .NET 9 Web API
- Entity Framework Core
- Arquitectura por capas
- Repository Pattern

## Base de Datos
- MySQL

## Integraciones Externas
- API Email (JWT Authentication)

---

# Arquitectura

El proyecto fue desarrollado utilizando una arquitectura limpia basada en separación por capas:

PT_PARQUEADERO
│
├── PT_PARQUEADERO_BACKEND
│   │
│   ├── Parqueadero.API
│   │   └── Controllers
│   │
│   ├── Parqueadero.Aplicacion
│   │   ├── DTOs
│   │   ├── Interfaces
│   │   └── Servicios
│   │
│   ├── Parqueadero.Dominio
│   │   └── Entidades
│   │
│   └── Parqueadero.Infrastructura
│       ├── Persistencia
│       ├── Repositorios
│       └── ServiciosExternos
│
└── PT_PARQUEADERO_FRONTEND
    │
    └── src/app
        ├── models
        ├── services
        ├── app.ts
        ├── app.html
        └── app.css

# Funcionalidades
- Gestión de Vehículos
Registro de ingreso de vehículos
Registro de salida de vehículos
Validación de vehículos activos
Visualización de vehículos activos

- Cálculo de Tarifas
Cálculo automático del tiempo en minutos
Tarifa fija de $50 COP por minuto
Visualización del valor total pagado

- Integración Email
Consumo de API externa
Autenticación JWT
Envío automático de correo al registrar salida

- Interfaz Moderna
Diseño responsive
Alertas visuales con SweetAlert2
Loading spinner
Formato de moneda COP
Estilo corporativo personalizado

- Base de Datos
La base de datos utilizada es MySQL.

- El proyecto incluye:
Migraciones con Entity Framework Core
Script SQL manual (script.sql)

# Ejecución del proyecto

## BACKEND

Ubicarse en:

 -> PT_PARQUEADERO_BACKEND
        Ejecutar: dotnet run --project Parqueadero.API
        
        Swagger disponible en: http://localhost:5188/swagger

## FRONTEND
Ubicarse en:

 -> PT_PARQUEADERO_FRONTEND
        Instalar dependencias: npm install
        Ejecutar: ng serve

        Aplicación disponible en: http://localhost:4200

# Endpoints Principales
    Vehículos
    Método	Endpoint
    GET	/api/Vehiculo/activos
    POST	/api/Vehiculo/ingreso
    POST	/api/Vehiculo/salida/{placa}
    API Externa de Correo: Se implementó integración con API externa utilizando autenticación JWT para el envío automático de correos electrónicos.

# Principios Aplicados
    SOLID
    Clean Architecture
    Repository Pattern
    Separación de responsabilidades
    Código mantenible


Desarrollado por:
Ingeniero en Mecatronica
Juan Esteban Bolívar Rodriguez
3178532380
juanesbol09@gmail.com