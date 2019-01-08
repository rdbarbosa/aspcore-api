using System.ComponentModel;

namespace aspcore_api.Models
{
    public enum enumMotivo : int
    {
        [Description("")]Indefinido = 0,
        [Description("Serviço")]Servico = 1,
        [Description("Manutenção")]Manutencao = 2,
        [Description("Calibração")]Calibracao = 3,

 
    }
}