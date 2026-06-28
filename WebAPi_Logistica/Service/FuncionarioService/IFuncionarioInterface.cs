using WebAPi_Logistica.Enums;
using WebAPi_Logistica.Models;

namespace WebAPi_Logistica.Service.FuncionarioService
{
    public interface IFuncionarioInterface
    {
        // Aqui define os métodos que serão implementados na classe FuncionarioService(DAL DE UM CRUD), CLASSE DE UM CRUD DE FUNCIONARIOS COM O BANCO DE DADOS.
        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios();

        Task<ServiceResponse<FuncionarioModel>> CreateFuncionario(FuncionarioModel NovoFuncionario);

        Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id);

        Task<ServiceResponse<FuncionarioModel>> UpdateFuncionario(FuncionarioModel FuncionarioAtualizado);

        Task<ServiceResponse<FuncionarioModel>> DeleteFuncionario(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> InativoFuncionario(int id);

        Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionariosDepartamento(DepartamentoEnum departamento);
    }
}
