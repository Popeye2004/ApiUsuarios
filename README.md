# API REST con JWT - práctica 6

He extendido la API de usuarios creada anteriormente agregando autenticación mediante JSON Web Tokens (JWT). Ahora los endpoints CRUD están protegidos y solo son accesibles con un token válido.

## Nuevas funcionalidades

- **Login**: `POST /api/auth/login` – Envía `username` y `password` para obtener un token JWT.
- **Refresh token**: `POST /api/auth/refresh` – Renueva el token antes de que expire (requiere token válido).
- **Protección**: Todos los endpoints de `/api/usuarios` requieren el token JWT.
- **Validaciones**: Añadidas con DataAnnotations (`[Required]`, `[StringLength]`, `[EmailAddress]`, etc.) para los campos de usuario.

## Tecnologías utilizadas

- ASP.NET Core 6 Web API
- Entity Framework Core (InMemory)
- JWT (JSON Web Tokens)
- SHA-256 para hash de contraseñas
- Swagger para pruebas

## Instrucciones para ejecutar

1. Clona el repositorio:
   ```bash
   git clone https://github.com/tuusuario/ApiUsuarios.git

   ## Capturas de pantalla

- Login con éxito y token.
  
  <img width="1833" height="328" alt="Swagger UI - Google Chrome 05_06_2026 16_59_46" src="https://github.com/user-attachments/assets/06dd686b-d278-4cd1-a4bf-055356077854" />

- Uso del token en Swagger (Authorize).
  
  <img width="365" height="165" alt="Swagger UI - Google Chrome 05_06_2026 17_02_34" src="https://github.com/user-attachments/assets/9a1d4868-c7ce-457f-9637-902eb874c9df" />

- Solicitudes GET, POST, PUT, DELETE protegidas.
- Intento sin token → 401 Unauthorized.
- Refresh token.

