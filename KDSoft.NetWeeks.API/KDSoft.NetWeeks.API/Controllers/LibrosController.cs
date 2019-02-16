using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KDSoft.NetWeeks.API.Models;

namespace KDSoft.NetWeeks.API.Controllers
{
    [Route("api/Libros")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly LibroContext _context;

        public LibrosController(LibroContext context)
        {
            _context = context;
        }

        [HttpGet("ObtenerLibros")]
        public IActionResult ObtenerLibros()
        {
            var res = _context.Libros.ToList();
            return Ok(res);
        }

        [HttpGet("ObtenerLibroXid/{id}")]
        public IActionResult ObtenerLibroxId(int id)
        {
            var libro = _context.Libros.FirstOrDefault(q => q.Id == id);

            if (libro == null)
                return BadRequest("No se encontró el libro");
            
            return Ok(libro);
        }

        [HttpPost]
        public IActionResult CrearLibro(Libro libro)
        {
            _context.Libros.Add(libro);

            var res = _context.SaveChanges();
            if (res > 0)
                return Ok(libro);

            return BadRequest("No se pudo crear el libro");
        }
        
        [HttpPut]
        public IActionResult ModificarLibro(int id, [FromBody]Libro libro)
        {
            var libroModificado = _context.Libros.FirstOrDefault(p => p.Id == id);
            
            if (libro == null)
                return BadRequest("No se encontró el libro");

            libroModificado.Nombre = libro.Nombre;
            libroModificado.FechaEdicion = libro.FechaEdicion;
            libroModificado.Edicion = libro.Edicion;
            libroModificado.EnStock = libro.EnStock;
            libroModificado.Id_Categoria = libro.Id_Categoria;

            var res = _context.SaveChanges();

            if (res > 0)
                return Ok(libro);

            return BadRequest("No se pudo modificar el libro");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarLibro(int id)
        {
            var libro = _context.Libros.FirstOrDefault(q => q.Id == id);

            if (libro == null)
                return BadRequest("No se encontró el libro");

            _context.Libros.Remove(libro);

            var res = _context.SaveChanges();

            if (res > 0)
                return Ok("El libro se eliminó correctamente");

            return BadRequest("No se pudo eliminar el libro");
        }
    }
}