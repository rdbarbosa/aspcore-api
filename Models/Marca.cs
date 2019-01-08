using System;

namespace aspcore_api.Models
{
    public class Marca
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public Fabricante Fabricante { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
    }
}