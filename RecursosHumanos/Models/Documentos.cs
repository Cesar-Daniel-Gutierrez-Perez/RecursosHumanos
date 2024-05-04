using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Documentos
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public long Cedula_E { get; set; }

        [Required]
        public String Cedula_img { get; set; }

        [Required]
        public String Contrato { get; set; }

        public String? Otro { get; set; }
    }
}
