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
    public class ItemMovimentacaoController : ControllerBase
    {
        private readonly TodoContext _context;

        public ItemMovimentacaoController(TodoContext context){
            _context = context;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<List<ItemMovimentacao>> GetAll()
        {
            //var lista = _context.ItemMovimentacao.ToList();
            var lista = _context.ItemMovimentacao.Include(e => e.Equipamento).ToList();
            // foreach (var item in lista)
            // {
            //     item.Equipamento = _context.Equipamento.Find(item.EquipamentoId);
            // }

            return lista;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
