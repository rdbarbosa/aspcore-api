using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using aspcore_api.Models;
using Microsoft.EntityFrameworkCore;

#region EquipamentoController
namespace aspcore_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipamentoController : ControllerBase
    {
        private readonly TodoContext _context;
        #endregion

        public EquipamentoController(TodoContext context)
        {
            _context = context;

            if (_context.Equipamento.Count() == 0)
            
            {
                var item = new Equipamento(){
                    Nome = "Acelerômetro Digital",
                    TipoEquipamento = new TipoEquipamento(){Id = 1, Nome ="Acelerômetro Digital", DataCadastro = DateTime.Now, dataModificacao = DateTime.Now},
                    Modelo =  new Modelo(){ Id= 1, Nome = "VI-410", DataCadastro = DateTime.Now, dataModificacao = DateTime.Now},
                    numeroSerie =  "15025",
                    numeroPatrimonio = "247664",
                    Categoria = new Categoria(){Id=1, Nome="Equipamento", DataCadastro = DateTime.Now, dataModificacao = DateTime.Now },
                    Especie = "Medição",
                    Situacao = enumSituacao.Ativo,
                    unopResponsavel = new Local(){Id=1, Nome="Centro de Atividade Jacarepaguá", DataCadastro = DateTime.Now, dataModificacao = DateTime.Now},
                    Localizacao = new Local(){Id=1, Nome="Centro de Atividade Jacarepaguá", DataCadastro = DateTime.Now, dataModificacao = DateTime.Now},
                    valorEstimado = 65000,
                    dataAquisicao = DateTime.Now,
                    Liberado = true,
                    Fora = false,
                    DataCadastro = DateTime.Now,
                    dataModificacao = DateTime.Now
                };
                
                _context.Equipamento.Add(item);               
                _context.SaveChanges();
            }
        }
        
        #region snippet_GetAll
        [HttpGet]
        public ActionResult<List<Equipamento>> GetAll()
        {
            //return _context.Equipamento.Include(e => e.TipoEquipamento).ToList();
            //var lista  = _context.Equipamento.Include(TipoEquipamento => TipoEquipamento).ToList();
            var lista  = _context.Equipamento.ToList();
            foreach(var equipamento in lista)
            {
                //equipamento.TipoEquipamento = _context.TipoEquipamento.Find(equipamento.TipoEquipamentoId);
                equipamento.TipoEquipamento = _context.TipoEquipamento.Where(t => t.Id == equipamento.TipoEquipamentoId).FirstOrDefault();
                equipamento.Modelo = _context.Modelo.Where(m => m.TipoEquipamentoId == equipamento.TipoEquipamentoId).FirstOrDefault();
                equipamento.Categoria = _context.Categoria.Where(c => c.Id == equipamento.CategoriaId).FirstOrDefault();
                equipamento.unopResponsavel = _context.Local.Find(equipamento.unopResponsavelId);
                equipamento.Localizacao = _context.Local.Find(equipamento.LocalizacaoId);
            }

            return lista;
        }
        #endregion
        #region snippet_GetByID
        [HttpGet("{id}", Name = "GetEquipamento")]
        public ActionResult<Equipamento> GetById(long id)
        {
            var item = _context.Equipamento.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }
        #endregion
        #region snippet_Create
        [HttpPost]
        public IActionResult Create([FromBody] Equipamento item)
        {
            _context.Equipamento.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetEquipamento", new { id = item.Id }, item);
        }
        #endregion
        #region snippet_Update
        [HttpPut("{id}")]
        public IActionResult Update(long id, Equipamento item)
        {
            var equipamento = _context.Equipamento.Find(id);
            if (equipamento == null)
            {
                return NotFound();
            }

            //todo.Nome = item.Nome;
            equipamento = item;

            _context.Equipamento.Update(equipamento);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
        #region snippet_Delete
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var item = _context.Equipamento.Find(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.Equipamento.Remove(item);
            _context.SaveChanges();
            return NoContent();
        }
        #endregion
    }
}