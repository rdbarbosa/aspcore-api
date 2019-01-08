using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;

#region CategoriaController
namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly TodoContext _context;
        #endregion

        public CategoriaController(TodoContext context)
        {
            _context = context;

            if (_context.Categoria.Count() == 0)
            {
                _context.Categoria.Add(new Categoria { Nome = "Categoria 1" });
                _context.Categoria.Add(new Categoria { Nome = "Categoria 2" });
                _context.Categoria.Add(new Categoria { Nome = "Categoria 3" });
                _context.SaveChanges();
            }
        }
        #region snippet_GetAll
        [HttpGet]
        public ActionResult<List<Categoria>> GetAll()
        {
            return _context.Categoria.ToList();
        }
        #endregion
        #region snippet_GetByID
        [HttpGet("{id}", Name = "GetCategoria")]
        public ActionResult<Categoria> GetById(long id)
        {
            var item = _context.Categoria.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        #endregion
        #region snippet_Create
        [HttpPost]
        public IActionResult Create(Categoria item)
        {
            _context.Categoria.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetCategoria", new { id = item.Id }, item);
        }
        #endregion

        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, Categoria item)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            // todo.IsComplete = item.IsComplete;
            // todo.Name = item.Name;

            _context.Categoria.Update(categoria);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var categoria = _context.Categoria.Find(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categoria.Remove(categoria);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
