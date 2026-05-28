# API REST de Usuarios con ASP.NET Core

Desarrollé esta API REST como parte de la Tarea de Creación de una API REST. Utilicé ASP.NET Core 6, Entity Framework Core con enfoque Code First (en memoria) para gestionar usuarios, aplicando validaciones para evitar correos duplicados.

## Tecnologías utilizadas
- ASP.NET Core 6 Web API
- Entity Framework Core (InMemory)
- Swagger para documentación y pruebas
- C#

## Requisitos previos
- Use la version NET 6.0
- Visual Studio 2022 (o Visual Studio Code con extensión C#)

## Instrucciones para ejecutar la API

1. Clona este repositorio:
   ```bash
   git clone https://github.com/tuusuario/ApiUsuarios.git
   
# Pruebas con Swagger/Postman

## Obtener todos los usuarios (GET)

## Obtener usuario por ID (GET)

## Crear usuario exitoso (POST)
<img width="445" height="165" alt="Swagger UI - Google Chrome 28_05_2026 13_41_26" src="https://github.com/user-attachments/assets/3581927d-5e98-4a80-8c5f-24a748640b8b" />

## Intentar crear usuario con correo duplicado (POST - error 400)

## Actualizar usuario (PUT)

## Eliminar usuario (DELETE)
