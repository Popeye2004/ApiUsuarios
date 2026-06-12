using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ApiUsuarios.Models
{
    public class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre de la categoría es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; }

        public ICollection<Producto> Productos { get; set; }
    }
}