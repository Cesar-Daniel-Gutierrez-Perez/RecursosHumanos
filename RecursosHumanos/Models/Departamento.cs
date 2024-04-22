using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Departamento
    {
        [Key]
        public long Id { get; set; }
        [Required]
        public String Nombre { get; set; }
    }
}
