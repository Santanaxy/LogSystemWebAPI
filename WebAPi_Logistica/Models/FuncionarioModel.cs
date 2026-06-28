using System.ComponentModel.DataAnnotations;
using WebAPi_Logistica.Enums;

namespace WebAPi_Logistica.Models;

public class FuncionarioModel
{
    //Minha model funcinario e os paramentros da minha API de funcionarios, ela vai ser usada para mapear os dados do banco de dados e para receber os dados da API, e vai ser usada no controller e no service
    //prop tab
    [Key]
    public int id { get; set; }

    public string Nome { get; set; }

    public string Sobrenome { get; set; }

    public DepartamentoEnum Departamento { get; set; }

    public bool Ativo { get; set; }

    public TurnoEnum Turno { get; set; }

    public DateTime DataCriação { get; set; } = DateTime.Now.ToLocalTime();

    public DateTime DataAlteração { get; set; } = DateTime.Now.ToLocalTime();

}

