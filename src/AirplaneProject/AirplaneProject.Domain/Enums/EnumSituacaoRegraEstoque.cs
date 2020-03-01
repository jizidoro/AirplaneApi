using System.ComponentModel;

namespace AirplaneProject.Domain.Enums
{
    public enum EnumSituacaoRegraEstoque
    {
        [Description("#008000")]
        Excedente = 1,
        [Description("#FFFF00")]
        Alerta = 2,
        [Description("#FF0000")]
        Critico = 3
    }
}
