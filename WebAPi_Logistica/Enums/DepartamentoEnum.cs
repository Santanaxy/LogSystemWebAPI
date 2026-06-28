using System.Text.Json.Serialization;

namespace WebAPi_Logistica.Enums;
// esse JsonConverter vai me trazer os nomes do departamento como string. se eu quiser numero eu só tiro esse Json. 
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
