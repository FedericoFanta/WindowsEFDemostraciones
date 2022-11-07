using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        public int Id { get; set; }

        [Required] // campo obligatorio- en DB not null
        [Column(TypeName ="varchar")] // tipo de dato de slqserver
        [StringLength(50)]//longitud maxima de la cadena
        public string Nombre { get; set; }
    }
}
