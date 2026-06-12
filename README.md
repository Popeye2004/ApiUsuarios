## Extensión - Práctica 7: Modelo ampliado con agregaciones

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
![Estadísticas](screenshots/estadisticas.png)
![Productos por categoría](screenshots/productos_categoria.png)
![Productos por proveedor](screenshots/productos_proveedor.png)
![Cantidad total](screenshots/cantidad.png)
(Las capturas de CRUD se mantienen de la práctica anterior más las nuevas)
