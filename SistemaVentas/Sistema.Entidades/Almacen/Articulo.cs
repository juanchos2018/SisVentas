﻿

using System.ComponentModel.DataAnnotations;

namespace Sistema.Entidades.Almacen
{
  public  class Articulo
    {
        public int idarticulo { get; set; }
        public int idcategoria { get; set; }
        public string codigo { get; set; }

        [Required]
        public string nombre { get; set; }
        public decimal precio_venta { get; set; }
        public int stock { get; set; }
        public string descripcion { get; set; }
        public bool? condicion { get; set; }

        public Categoria categoria { get; set; }
    }
}
