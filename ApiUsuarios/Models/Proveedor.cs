using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Models
{
    public class Proveedor
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre del proveedor es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El contacto es obligatorio")]
        [StringLength(200)]
        public string Contacto { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}