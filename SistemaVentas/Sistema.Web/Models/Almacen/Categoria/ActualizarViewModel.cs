using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Models.Almacen.Categoria
{
    public class ActualizarViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int idcategoria { get; set; }
        [MaxLength(50)]
        [Required]
        public string nombre { get; set; }
        [MaxLength(256)]
        public string descripcion { get; set; }
        
    }
}
