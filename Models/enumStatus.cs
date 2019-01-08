using System.ComponentModel;

namespace aspcore_api.Models
{
    public enum enumStatus : int
    {
        [Description("")]Indefinido = 0,
        [Description("Novo")]Novo = 1,
        [Description("Em Aberto")]EmAberto = 2,
        [Description("Em Processo")]EmProcesso = 3,
        [Description("Finalizado")]Finalizado = 4
 
    }
}