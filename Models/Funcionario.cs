using System;

namespace aspcore_api.Models
{
    public class Funcionario
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
    }
}