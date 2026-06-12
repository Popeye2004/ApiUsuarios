using ApiUsuarios.Data;
using ApiUsuarios.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProductosController(AppDbContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
        {
            return await _context.Productos
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            var producto = await _context.Productos
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (producto == null)
                return NotFound(new { message = "Producto no encontrado." });
            return producto;
        }

        [HttpPost]
        public async Task<ActionResult<Producto>> PostProducto(Producto producto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var proveedorExiste = await _context.Proveedores.AnyAsync(p => p.Id == producto.IdProveedor);
            var categoriaExiste = await _context.Categorias.AnyAsync(c => c.Id == producto.IdCategoria);
            if (!proveedorExiste || !categoriaExiste)
                return BadRequest(new { message = "Proveedor o categoría no válidos." });

            _context.Productos.Add(producto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProducto), new { id = producto.Id }, producto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducto(int id, Producto producto)
        {
            if (id != producto.Id)
                return BadRequest(new { message = "El ID no coincide." });

            _context.Entry(producto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducto(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                return NotFound(new { message = "Producto no encontrado." });

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        
        [HttpGet("estadisticas")]
        public async Task<IActionResult> GetEstadisticas()
        {
            var productos = await _context.Productos.ToListAsync();

            if (!productos.Any())
                return NotFound(new { message = "No hay productos registrados." });

            var masCaro = productos.OrderByDescending(p => p.Precio).First();
            var masBarato = productos.OrderBy(p => p.Precio).First();
            var sumaTotal = productos.Sum(p => p.Precio);
            var precioPromedio = productos.Average(p => p.Precio);

            return Ok(new
            {
                ProductoMasCaro = new { masCaro.Id, masCaro.Nombre, masCaro.Precio },
                ProductoMasBarato = new { masBarato.Id, masBarato.Nombre, masBarato.Precio },
                SumaTotalPrecios = sumaTotal,
                PrecioPromedio = precioPromedio
            });
        }

        
        [HttpGet("categoria/{categoriaId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosPorCategoria(int categoriaId)
        {
            var productos = await _context.Productos
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .Where(p => p.IdCategoria == categoriaId)
                .ToListAsync();

            if (!productos.Any())
                return NotFound(new { message = "No se encontraron productos para esta categoría." });
            return Ok(productos);
        }

       
        [HttpGet("proveedor/{proveedorId}")]
        public async Task<ActionResult<IEnumerable<Producto>>> GetProductosPorProveedor(int proveedorId)
        {
            var productos = await _context.Productos
                .Include(p => p.Proveedor)
                .Include(p => p.Categoria)
                .Where(p => p.IdProveedor == proveedorId)
                .ToListAsync();

            if (!productos.Any())
                return NotFound(new { message = "No se encontraron productos para este proveedor." });
            return Ok(productos);
        }

        
        [HttpGet("cantidad")]
        public async Task<IActionResult> GetCantidadProductos()
        {
            int cantidad = await _context.Productos.CountAsync();
            return Ok(new { TotalProductos = cantidad });
        }
    }
}