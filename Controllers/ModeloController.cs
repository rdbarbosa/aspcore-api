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
    public class ModeloController : ControllerBase
    {
        private readonly TodoContext _context;

        public ModeloController(TodoContext context){
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Modelo>> GetAll()
        {
            var lista = _context.Modelo.ToList();

            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetModelo")]
        public ActionResult<Modelo> Get(int id)
        {
            var item = _context.Modelo.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        #region snippet_Create
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Modelo item)
        {
            _context.Modelo.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetModelo", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Modelo item)
        {
            var modelo = _context.Modelo.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelo.Update(modelo);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var modelo = _context.Modelo.Find(id);
            if (modelo == null)
            {
                return NotFound();
            }

            _context.Modelo.Remove(modelo);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
