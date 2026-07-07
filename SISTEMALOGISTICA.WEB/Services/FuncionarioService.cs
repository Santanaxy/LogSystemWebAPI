using SISTEMALOGISTICA.WEB.Models;
using System.Net.Http.Json;

namespace SISTEMALOGISTICA.WEB.Services
{
    public class FuncionarioService
    {
        private readonly HttpClient _httpClient;

        public FuncionarioService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<FuncionarioModel>> GetAllFuncionario()
        {
            return await _httpClient.GetFromJsonAsync<List<FuncionarioModel>>($"Api/funcionario");
        }



    }
}
