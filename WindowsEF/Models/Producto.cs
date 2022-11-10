using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsEF.Models
{
    [Table("Producto")]
    public class Producto
    {
        public int ProductoId { get; set; }

        [Required]//campo obligatorio - DB: NOT NULL
        [Column(TypeName = "varchar")]//tipo de datos de sql server
        [StringLength(50)]//longitud máxima de la cadena 
        public string Nombre { get; set; }
        [Column(TypeName = "money")]
        public decimal Precio { get; set; }

        public int IdCategoria { get; set; }

        #region Propiedades De Navegacion
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }
        #endregion

    }
}
