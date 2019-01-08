using System;
using Newtonsoft.Json;

namespace aspcore_api.Models
{
    public class Modelo
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
        [JsonIgnore]
        public long TipoEquipamentoId { get; set; }
    }
}