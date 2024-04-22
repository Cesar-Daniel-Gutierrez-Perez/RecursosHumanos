using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Usuario
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public String Nombre { get; set; }
        [Required]
        public String Clave { get; set; }
    }
}
