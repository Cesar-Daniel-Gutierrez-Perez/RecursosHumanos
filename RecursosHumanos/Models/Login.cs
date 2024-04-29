using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Login
    {
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Clave { get; set; }
        public bool MantenerSesion { get; set; }
    }
}
