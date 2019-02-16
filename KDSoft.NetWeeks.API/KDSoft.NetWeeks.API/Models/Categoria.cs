using System.ComponentModel.DataAnnotations;

namespace KDSoft.NetWeeks.API.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }
    }
}
