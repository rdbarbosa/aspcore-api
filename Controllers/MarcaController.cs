using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspcore_api.Models;

namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly TodoContext _context;

        public MarcaController(TodoContext context){
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Marca>> GetAll()
        {
            var lista = _context.Marca.ToList();

            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetMarca")]
        public ActionResult<Marca> Get(int id)
        {
            var item = _context.Marca.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        #region snippet_Create
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Marca item)
        {
            _context.Marca.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMarca", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Marca item)
        {
            var marca = _context.Marca.Find(id);
            if (marca == null)
            {
                return NotFound();
            }

            _context.Marca.Update(marca);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fabricante = _context.Marca.Find(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            _context.Marca.Remove(fabricante);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
