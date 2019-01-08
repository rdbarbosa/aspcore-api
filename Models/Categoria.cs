using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore_api.Models
{
    public class Categoria
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
        
    }
}