using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore_api.Models
{
    public class TipoEquipamento
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; }
        public List<Modelo> Modelos { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
        // public ICollection<Equipamento> Equipamento { get; set; }
        
    }
}