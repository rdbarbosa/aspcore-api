using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;

#region FuncionarioController
namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly TodoContext _context;
        #endregion

        public FuncionarioController(TodoContext context){
            _context = context;
        }
        // GET api/values
        #region snippet_GetAll
        [HttpGet]
        public ActionResult<List<Funcionario>> GetAll()
        {
            return _context.Funcionario.ToList();
        }
        #endregion
        #region snippet_GetByID
        // GET api/values/5
        [HttpGet("{id}", Name = "GetFuncionario")]
        public ActionResult<Funcionario> Get(int id)
        {
            var item = _context.Funcionario.Find(id);
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
        public IActionResult Post([FromBody] Funcionario item)
        {
            _context.Funcionario.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetFuncionario", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Funcionario item)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Update(funcionario);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var funcionario = _context.Funcionario.Find(id);
            if (funcionario == null)
            {
                return NotFound();
            }

            _context.Funcionario.Remove(funcionario);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
