using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPi_Logistica.Enums;
using WebAPi_Logistica.Models;
using WebAPi_Logistica.Service.FuncionarioService;

namespace WebAPi_Logistica.Controllers;

[Route("Api/[controller]")]
[ApiController]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioInterface _funcionarioInterface;
    public FuncionarioController(IFuncionarioInterface funcionarioInterface)
    {
        _funcionarioInterface = funcionarioInterface;
    }

    [HttpGet]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
    {
        return Ok(await _funcionarioInterface.GetFuncionarios());
    }

    [HttpGet("{Id}")]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionariosById(int Id)
    {
        //return Ok(await _funcionarioInterface.GetFuncionarioById(id));

        ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(Id);
        return Ok(serviceResponse);
    }

    //[HttpGet("ByDepartamento/{departamento}")]
    //public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionariosDepartamento(DepartamentoEnum departamento)
    //{
    //    //return Ok(await _funcionarioInterface.GetFuncionarioById(id));

    //    ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.GetFuncionariosDepartamento(departamento);
    //    return Ok(serviceResponse);
    //}

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel NovoFuncionario)
    {
        return Ok(await _funcionarioInterface.CreateFuncionario(NovoFuncionario));
    }

    [HttpPut("InativaFuncionario")]
    public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(int id)
    {
        ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativoFuncionario(id);

        return Ok(serviceResponse);
    }
    [HttpPut("AtualizarFuncionário")]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editandoFuncionario)
    {
        ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.UpdateFuncionario(editandoFuncionario);

        return Ok(serviceResponse);
    }
    [HttpDelete]
    public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> DeleteFuncionario(int id) 
    {
        ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);

        return Ok(serviceResponse);
    }
}
