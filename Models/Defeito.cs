using System;

namespace aspcore_api.Models
{
    public class Defeito
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
    }
}