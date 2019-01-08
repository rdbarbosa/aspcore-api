using System;
using System.ComponentModel;
using Newtonsoft.Json;

namespace aspcore_api.Models
{
    
    public class Equipamento
    {
        public Equipamento()
        {
            // TipoEquipamento = new TipoEquipamento();
            // Modelo = new Modelo();
            // Categoria = new Categoria();
            // unopResponsavel = new Local();
            // Localizacao = new Local();
        }
        public long Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public long? TipoEquipamentoId { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }
        [JsonIgnore]
        public long? ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public string numeroSerie { get; set; }
        public string numeroPatrimonio { get; set; }
        [JsonIgnore]
        public long? CategoriaId { get; set; }
        public Categoria Categoria { get; set; }
        public string Especie { get; set; }
        public enumSituacao Situacao { get; set; }
        [JsonIgnore]
        public long? unopResponsavelId { get; set; }
        public Local unopResponsavel { get; set; }
        [JsonIgnore]
        public long? LocalizacaoId { get; set; }
        public Local Localizacao { get; set; }
        public Decimal valorEstimado { get; set; }
        public DateTime dataAquisicao { get; set; }
        public Boolean Liberado { get; set; }
        public Boolean Fora { get; set; }        
        public DateTime DataCadastro { get; set; }
        public DateTime dataModificacao { get; set; }
        
    }
}