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
<img width="740" height="317" alt="Swagger UI - Google Chrome 28_05_2026 13_50_52" src="https://github.com/user-attachments/assets/8dd3a809-0807-494c-abef-e4e7045f1170" />

## Obtener usuario por ID (GET)
<img width="445" height="165" alt="Swagger UI - Google Chrome 28_05_2026 13_41_26" src="https://github.com/user-attachments/assets/b857776d-a7bb-4804-ad30-e01788367439" />

## Crear usuario exitoso (POST)
<img width="445" height="165" alt="Swagger UI - Google Chrome 28_05_2026 13_41_26" src="https://github.com/user-attachments/assets/3581927d-5e98-4a80-8c5f-24a748640b8b" />

## Intentar crear usuario con correo duplicado (POST - error 400)
<img width="635" height="247" alt="Swagger UI - Google Chrome 28_05_2026 13_43_32" src="https://github.com/user-attachments/assets/4ffcb870-c6d2-4ad7-ad17-565b849f93b4" />
## Actualizar usuario (PUT)


## Eliminar usuario (DELETE)
<img width="1726" height="397" alt="Swagger UI - Google Chrome 28_05_2026 13_52_20" src="https://github.com/user-attachments/assets/f3826680-effe-4d2c-82c0-9887d0772a0c" />
<img width="1766" height="336" alt="Swagger UI - Google Chrome 28_05_2026 13_53_04" src="https://github.com/user-attachments/assets/5d33203b-c35b-4f81-b032-9b5bdcdfe43f" />
