using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;
using Microsoft.EntityFrameworkCore;

namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentacaoController : ControllerBase
    {
        private readonly TodoContext _context;

        public MovimentacaoController(TodoContext context){
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<Movimentacao>> GetAll()
        {
            // var lista = _context.Movimentacao.ToList();
            // foreach (var m in lista)
            // {
            //     m.Local = _context.Local.Find(m.LocalId);
            //     m.Funcionario = _context.Funcionario.Find(m.FuncionarioId);
            //     m.Itens = _context.ItemMovimentacao.ToList();
            // }

            var lista = _context.Movimentacao
                                    .Include(l => l.Local)
                                    .Include(f => f.Funcionario)
                                    .Include(i => i.Itens)
                                        .ThenInclude(e => e.Equipamento).ToList();

            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetMovimentacao")]
        public ActionResult<Movimentacao> Get(int id)
        {
            var item = _context.Movimentacao.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        #region snippet_Create
        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] Movimentacao item)
        {
            _context.Movimentacao.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetMovimentacao", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Movimentacao item)
        {
            var movimentacao = _context.Movimentacao.Find(id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            _context.Movimentacao.Update(movimentacao);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var movimentacao = _context.Movimentacao.Find(id);
            if (movimentacao == null)
            {
                return NotFound();
            }

            _context.Movimentacao.Remove(movimentacao);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
