## Práctica 7: Modelo ampliado con agregaciones

He ampliado la API con nuevas entidades (`Producto`, `Proveedor`, `Categoría`) y sus CRUD completos. También agregué endpoints de consulta con LINQ para obtener estadísticas y filtros.

### Nuevas entidades y relaciones
- **Producto**: Id, Nombre, Precio, Stock, IdProveedor, IdCategoria.
- **Proveedor**: Id, Nombre, Contacto. Un proveedor tiene muchos productos.
- **Categoria**: Id, Nombre. Una categoría tiene muchos productos.
- Las relaciones están configuradas con Code First y se insertan datos de ejemplo al iniciar.

### Endpoints agregados
- CRUD completo para `api/categorias` y `api/proveedores`.
- CRUD completo para `api/productos`.
- `GET /api/productos/estadisticas` → Devuelve producto más caro, más barato, suma total y promedio de precios.
- `GET /api/productos/categoria/{id}` → Productos de una categoría.
- `GET /api/productos/proveedor/{id}` → Productos de un proveedor.
- `GET /api/productos/cantidad` → Total de productos registrados.

### Pruebas (capturas)
- Estadísticas
  <img width="1740" height="657" alt="Swagger UI - Google Chrome 12_06_2026 16_24_11" src="https://github.com/user-attachments/assets/8c5d6865-08e8-4199-a0eb-be9f0d4c3510" />

- Productos por categoría
  <img width="1790" height="865" alt="Swagger UI - Google Chrome 12_06_2026 17_22_04" src="https://github.com/user-attachments/assets/53fd2d01-4213-4001-b27e-5bde2d540139" />

- Productos por proveedor
  <img width="1920" height="541" alt="Swagger UI - Google Chrome 12_06_2026 17_31_04" src="https://github.com/user-attachments/assets/44899259-75e9-4d60-a2c4-58b2ca375271" />
  
- Cantidad total
  <img width="1920" height="490" alt="Swagger UI - Google Chrome 12_06_2026 17_32_55" src="https://github.com/user-attachments/assets/05709373-fecf-4509-a62e-9f9414b9042f" />
