## Práctica 8: Registro de logs de usuarios

He agregado un sistema de logging para la creación de usuarios. Cada vez que se registra un nuevo usuario, la información (excepto la contraseña) se guarda en un archivo JSON (`Logs/usuarios_log.json`). Además, se expone un endpoint para consultar el historial.

### Endpoint agregado
- `GET /api/usuarios/logs` → Devuelve todos los registros de log.

### Detalles técnicos
- Se creó un `LogService` que maneja la lectura/escritura asíncrona del archivo.
- El archivo se crea automáticamente en la carpeta `Logs` si no existe.
- Los registros incluyen la fecha UTC y los datos del usuario (sin información sensible).
- Se manejan errores de E/S y se integra con el controlador existente.
