using Azure;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using WebAPi_Logistica.DataContext;
using WebAPi_Logistica.Enums;
using WebAPi_Logistica.Models;

namespace WebAPi_Logistica.Service.FuncionarioService;



public class FuncionarioService : IFuncionarioInterface
{
    //service e a conexão com  o banco de dados  com a minha model FuncinarioModel(Parametros), que vai ser usada no controller(FACADE) para me trazer os dados do banco de dados e fazer operações de CRUD(Create, Read, Update, Delete) na tabela Funcionarios, e vai ser usada no controller para me trazer os dados do banco de dados e fazer operações de CRUD.
    private readonly AplicationDbContext _context;
    public FuncionarioService(AplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            serviceResponse.Dados = _context.Funcionarios.ToList();
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Funcionários obtidos com sucesso.";

            if (serviceResponse.Dados.Count == 0)
            {
                serviceResponse.Mensagem = "Nenhum Dado Encontrado!";
            }

        }
        catch (Exception ex)
        {
            serviceResponse.Sucesso = false;
            serviceResponse.Mensagem = ex.Message;
        }
        return serviceResponse;

    }
    public async Task<ServiceResponse<FuncionarioModel>> CreateFuncionario(FuncionarioModel novoFuncionario)
    {
        ServiceResponse<FuncionarioModel> response = new();

        try
        {
            if (novoFuncionario == null)
            {
                response.Sucesso = false;
                response.Mensagem = "Informe os dados.";

                return response;
            }

            await _context.Funcionarios.AddAsync(novoFuncionario);

            await _context.SaveChangesAsync();

            response.Dados = novoFuncionario;
            response.Mensagem = "Funcionário cadastrado com sucesso.";
        }
        catch (Exception ex)
        {
            response.Sucesso = false;
            response.Mensagem = ex.Message;
        }

        return response;
    }
    public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();
        try
        {

            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.id == id);

            serviceResponse.Dados = funcionario;
            if (funcionario == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Funcionário Não Encontrado.";
                serviceResponse.Sucesso = false;
            }


        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;

    }
    public async Task<ServiceResponse<FuncionarioModel>> UpdateFuncionario(FuncionarioModel editandoFuncionario)
    {

        ServiceResponse<FuncionarioModel> serviceResponse = new();

        try
        {
            var funcionario = await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(x => x.id == editandoFuncionario.id);

            if (funcionario == null)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Funcionário não encontrado.";

                return serviceResponse;
            }

            _context.Funcionarios.Update(editandoFuncionario);
            funcionario.DataAlteração = DateTime.Now;

            await _context.SaveChangesAsync();

            serviceResponse.Dados = funcionario;
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Funcionário atualizado com sucesso.";
        }
        catch (Exception ex)
        {
            serviceResponse.Sucesso = false;
            serviceResponse.Mensagem = ex.Message;
        }

        return serviceResponse;
    }


    public async Task<ServiceResponse<FuncionarioModel>> DeleteFuncionario(int id)
    {
     
        ServiceResponse<FuncionarioModel> serviceResponse = new();

        try
        {
            var funcionario = _context.Funcionarios.FirstOrDefault(x => x.id == id);

            if (funcionario == null)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Funcionário não encontrado.";

                return serviceResponse;
            }

            _context.Funcionarios.Remove(funcionario);

            await _context.SaveChangesAsync();

            serviceResponse.Dados = funcionario;
            serviceResponse.Mensagem = "Funcionário removido com sucesso.";
        }
        catch (Exception ex)
        {
            serviceResponse.Sucesso = false;
            serviceResponse.Mensagem = ex.Message;
        }

        return serviceResponse;
    }

    
    public async Task<ServiceResponse<List<FuncionarioModel>>> InativoFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {
            FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.id == id);

            if (funcionario == null)
            {
                serviceResponse.Sucesso = false;
                serviceResponse.Mensagem = "Funcionário não encontrado.";

                return serviceResponse;
            }

            funcionario.Ativo = false;
            funcionario.DataAlteração = DateTime.Now.ToLocalTime();
            _context.Funcionarios.Update(funcionario);
            await _context.SaveChangesAsync();
            serviceResponse.Dados = _context.Funcionarios.ToList();
            serviceResponse.Mensagem = "Funcionário inativado com sucesso.";
        }
        catch (Exception ex)
        {
            serviceResponse.Sucesso = false;
            serviceResponse.Mensagem = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionariosDepartamento(DepartamentoEnum departamento)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
        try
        {

            List<FuncionarioModel> funcionarios = await _context.Funcionarios.Where(x => x.Departamento == departamento).ToListAsync();

            if (funcionarios == null)
            {
                serviceResponse.Dados = null;
                serviceResponse.Mensagem = "Funcionário Não Encontrado.";
                serviceResponse.Sucesso = false;
            }
            serviceResponse.Sucesso = true;
            serviceResponse.Mensagem = "Funcionários Encontrado";
            

        }
        catch (Exception ex)
        {
            serviceResponse.Mensagem = ex.Message;
            serviceResponse.Sucesso = false;
        }
        return serviceResponse;
    }  

}
