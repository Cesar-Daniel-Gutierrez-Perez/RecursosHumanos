using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Asistencia
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long Cedula_e { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public String Estado { get; set; }

        
    }
}
