using System;
using System.ComponentModel.DataAnnotations;

namespace KDSoft.NetWeeks.API.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        public DateTime? FechaEdicion { get; set; }

        public string Edicion { get; set; }

        public bool? EnStock { get; set; }

        [Required(ErrorMessage = "Categoría es requerida")]
        public int? Id_Categoria { get; set; }

        public Categoria Categoria { get; set; }
    }
}
