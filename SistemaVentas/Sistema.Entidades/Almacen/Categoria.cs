using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Sistema.Entidades.Almacen
{
   public class Categoria
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
        public bool? condicion { get; set; }


        public ICollection<Articulo> articulos { get; set; }


    }
}
