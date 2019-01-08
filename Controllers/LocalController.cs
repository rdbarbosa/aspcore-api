using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;

namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalController : ControllerBase
    {
        private readonly TodoContext _context;

        public LocalController(TodoContext context){
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Local>> GetAll()
        {
            var lista = _context.Local.ToList();

            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetLocal")]
        public ActionResult<Local> Get(int id)
        {
            var item = _context.Local.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        #region snippet_Create
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Local item)
        {
            _context.Local.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetLocal", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Local item)
        {
            var local = _context.Local.Find(id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Local.Update(local);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var local = _context.Local.Find(id);
            if (local == null)
            {
                return NotFound();
            }

            _context.Local.Remove(local);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
