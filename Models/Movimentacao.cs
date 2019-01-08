using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace aspcore_api.Models
{
    public class Movimentacao
    {
        public Movimentacao(){
            //Itens = new List<ItemMovimentacao>();
        }
        public long Id { get; set; }
        [JsonIgnore]
        public long? LocalId { get; set; }
        public Local Local { get; set; }
        public DateTime Saida { get; set; }
        public DateTime Retorno { get; set; }
        public int Tipo { get; set; }
        [JsonIgnore]
        public long? FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public enumStatus Status { get; set; }
        public enumMotivo Motivo { get; set; }
        public List<ItemMovimentacao> Itens { get; set; }
    }
}