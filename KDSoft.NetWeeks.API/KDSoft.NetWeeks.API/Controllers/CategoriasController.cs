using System.Linq;
using Microsoft.AspNetCore.Mvc;
using KDSoft.NetWeeks.API.Models;

namespace KDSoft.NetWeeks.API.Controllers
{
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly LibroContext _context;

        public CategoriasController(LibroContext context)
        {
            _context = context;
        }

        [HttpGet("ObtenerCategorias")]
        public IActionResult ObtenerCategorias()
        {
            var lista = _context.Categorias.ToList();
            return Ok(lista);
        }

        [HttpGet("ObtenerCategoriaXid/{id}")]
        public IActionResult ObtenerCategoriaxId(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.Id == id);

            if (categoria == null)
                return BadRequest("No se encontró la categoría");
            
            return Ok(categoria);
        }

        [HttpPost]
        public IActionResult CrearCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);

            var res = _context.SaveChanges();
            if (res > 0)
                return Ok(categoria);

            return BadRequest("No se pudo crear la categoría");
        }

        [HttpPut("{id}")]
        public IActionResult ModificarCategoria(int id, [FromBody] Categoria categoria)
        {
            var obj = _context.Categorias.FirstOrDefault(p => p.Id == categoria.Id);

            if (obj == null)
                return BadRequest("No se encontró la categoría");
         
            obj.Id = categoria.Id;
            obj.Nombre = categoria.Nombre;

            var res = _context.SaveChanges();
            if (res > 0)
                return Ok(obj);

            return BadRequest("No se pudo modificar la categoría");
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCategoria(int id)
        {
            var categoria = _context.Categorias.FirstOrDefault(p => p.Id == id);

            if (categoria == null)
                return BadRequest("No se encontró la categoría"); 

            _context.Categorias.Remove(categoria);

            var res = _context.SaveChanges();
            if (res > 0)
                return Ok(categoria);

            return BadRequest("No se pudo eliminar la categoría");
        }
    }
}