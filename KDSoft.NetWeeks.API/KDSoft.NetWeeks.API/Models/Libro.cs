using System;
using System.ComponentModel.DataAnnotations;

namespace KDSoft.NetWeeks.API.Models
{
    public class Libro
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public DateTime? FechaEdicion { get; set; }

        public string Edicion { get; set; }

        public bool? EnStock { get; set; }

        [Required]
        public int? Id_Categoria { get; set; }

        public Categoria Categoria { get; set; }
    }
}
