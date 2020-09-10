
namespace Sistema.Web.Models.Almacen.Categoria
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public class CrearViewModel
    {
        
        [MaxLength(50)]
        [Required]
        public string nombre { get; set; }
        [MaxLength(256)]
        public string descripcion { get; set; }
    }
}
