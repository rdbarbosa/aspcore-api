using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace aspcore_api.Models
{
    public class Local
    {
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Nome { get; set; }
        public bool unidade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
    }
}