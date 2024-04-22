using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RecursosHumanos.Models
{
    public class Documentos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public long Cedula_E { get; set; }

        [MaxLength]
        [Required]
        public byte[] Cedula_img { get; set; }

        [MaxLength]
        [Required]
        public byte[] Contrato { get; set; }

        [MaxLength]        
        public byte[] Otro { get; set; }
    }
}
