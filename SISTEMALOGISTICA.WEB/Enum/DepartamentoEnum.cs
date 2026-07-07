using System.Text.Json.Serialization;

namespace SISTEMALOGISTICA.WEB.Enum
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum DepartamentoEnum
    {
        //Enum serve para definir padroes de departamentos usando sequencias de numeros ou nomes do departamento que vai ser usado na model, FuncionarioModel para definir o departamento do funcionario, e vai ser usado no service para filtrar os funcionarios por departamento
        RH,
        Financeiro,
        Operacional,
        Compras,
        Segurança,
        TI

    }
}
