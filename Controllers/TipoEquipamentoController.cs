using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;
// using aspcore_api.Services;
using Microsoft.EntityFrameworkCore;

namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoEquipamentoController : ControllerBase
    {
        private readonly TodoContext _context;
        public TipoEquipamentoController(TodoContext context){
            _context = context;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<List<TipoEquipamento>> GetAll()
        {            
            //return _context.TipoEquipamento.ToList();
            var lista  = _context.TipoEquipamento.ToList();

            foreach(var tipoequipamento in lista)
            {
                tipoequipamento.Modelos = _context.Modelo.Where(t => t.TipoEquipamentoId == tipoequipamento.Id).ToList();
            }

            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetTipoEquipamento")]
        public ActionResult<TipoEquipamento> Get(long id)
        {
            var item = _context.TipoEquipamento.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody] TipoEquipamento item)
        {
            _context.TipoEquipamento.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetTipoEquipamento", new { id = item.Id }, item);
        }

        // PUT api/values/5
        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, TipoEquipamento item)
        {
            var tipoequipamento = _context.TipoEquipamento.Find(id);
            if (tipoequipamento == null)
            {
                return NotFound();
            }

            //todo.Nome = item.Nome;
            tipoequipamento.Nome = item.Nome;
            tipoequipamento.Modelos = item.Modelos;
            tipoequipamento.dataModificacao = DateTime.Now;


            _context.TipoEquipamento.Update(tipoequipamento);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion

        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.TipoEquipamento.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.TipoEquipamento.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}
