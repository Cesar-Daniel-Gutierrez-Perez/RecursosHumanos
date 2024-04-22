using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Excusas
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long Cedula_e { get; set; }

        [Required]
        public DateTime Inicio { get; set; }

        [Required]
        public DateTime Finalizacion { get; set; }

        [Required]
        public String Motivo { get; set; }

        [Required]
        public String Estado { get; set; }
    }
}
