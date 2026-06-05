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

<img width="871" height="203" alt="Swagger UI - Google Chrome 05_06_2026 17_21_16" src="https://github.com/user-attachments/assets/8360842f-90a7-4961-aaa9-eb01986027c7" />

<img width="1920" height="213" alt="Swagger UI - Google Chrome 05_06_2026 17_24_43" src="https://github.com/user-attachments/assets/3990a151-6e38-4f74-94f9-c9040f5d424b" />

<img width="645" height="506" alt="Swagger UI - Google Chrome 05_06_2026 17_29_52" src="https://github.com/user-attachments/assets/bad52737-2840-40e5-983d-dff3d7de8605" />

<img width="1920" height="572" alt="Swagger UI - Google Chrome 05_06_2026 17_30_42" src="https://github.com/user-attachments/assets/d08af90a-c8ec-42db-ac92-ad4c81f3994b" />

<img width="1920" height="438" alt="Swagger UI - Google Chrome 05_06_2026 17_30_56" src="https://github.com/user-attachments/assets/1fb57f29-6470-4cdf-8698-8f58b3fda8bc" />

- Intento sin token → 401 Unauthorized.

  <img width="1920" height="227" alt="Swagger UI - Google Chrome 05_06_2026 17_32_08" src="https://github.com/user-attachments/assets/58f44dfc-c721-4e3b-9404-91ddbaaf2b95" />

- Refresh token.

  <img width="1920" height="165" alt="Swagger UI - Google Chrome 05_06_2026 17_36_18" src="https://github.com/user-attachments/assets/ade35649-0e84-495b-889f-0472a1ba746e" />


