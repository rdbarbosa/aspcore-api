using System;
using Newtonsoft.Json;

namespace aspcore_api.Models
{
    public class ItemMovimentacao
    {
        public ItemMovimentacao(){

        }
        public long Id { get; set; }
        [JsonIgnore]
        public long? IdMovimentacao { get; set; }
        [JsonIgnore]
        public long? EquipamentoId { get; set; }
        public Equipamento Equipamento { get; set; }
        public bool Devolucao { get; set; }
        public DateTime? DataDeolucao { get; set; }
        public bool Defeituoso { get; set; }
        public Defeito Defeito { get; set; }
        public bool Calibrado { get; set; }
        public string NF { get; set; }
        //public Movimentacao Movimentacao { get; set; }
    }
}