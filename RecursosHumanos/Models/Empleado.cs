using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecursosHumanos.Models
{
    public class Empleado
    {
        [Required]        
        public long Cedula { get; set; }

        [Required]
        public String Nombre { get; set; }

        [Required]
        public long Telefono { get; set; }

        [Required]
        public String Direccion { get; set; }

        [Required]
        public String Correo { get; set; }

        [Required]
        public String Estado { get; set; }

        [Required]
        public DateTime Fecha_Contratacion { get; set; }

        [Required]
        public long id_departamento { get; set; }

        [Required]
        public long id_rol { get; set; }

        [Required]
        public long id_usuario { get; set; }
    }
}
