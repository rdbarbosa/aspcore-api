using System.ComponentModel;

namespace aspcore_api.Models
{
    public enum enumSituacao
    {
        [Description("")]Indefinido = 0,
        [Description("Ativo")]Ativo = 1,
        [Description("Manutenção")]Manutencao = 2,
        [Description("Calibração")]Calibracao = 3,
        [Description("Serviço")]Servico = 4,
        [Description("Inativo")]Inativo = 4,
        [Description("Com Defeito")]ComDefeito = 4,
        [Description("Em Espera")]EmEspera = 4,
        [Description("Museu")]Museu = 4,
        [Description("Não Localizado")]NaoLocalizado = 4
    }
}