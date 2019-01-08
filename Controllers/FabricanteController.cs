using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;

#region FabricanteController
namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly TodoContext _context;
        #endregion

        public FabricanteController(TodoContext context)
        {
            _context = context;
        }
        // GET api/values
        #region snippet_GetAll
        [HttpGet]
        public ActionResult<List<Fabricante>> GetAll()
        {
            return _context.Fabricante.ToList();
        }
        #endregion
        #region snippet_GetByID
        // GET api/values/5
        [HttpGet("{id}", Name = "GetFabricante")]
        public ActionResult<Fabricante> Get(int id)
        {
            var item = _context.Fabricante.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        #endregion
        #region snippet_Create
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Fabricante item)
        {
            _context.Fabricante.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetFabricante", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Fabricante item)
        {
            var fabricante = _context.Fabricante.Find(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            _context.Fabricante.Update(fabricante);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var fabricante = _context.Fabricante.Find(id);
            if (fabricante == null)
            {
                return NotFound();
            }

            _context.Fabricante.Remove(fabricante);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
