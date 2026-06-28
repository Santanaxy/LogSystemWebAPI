
namespace WebAPi_Logistica.Models;

public class ServiceResponse<T>
{
    //services e parametros de resposta, ele vai ser usado para padronizar as respostas da API, e vai ser usado em todos os serviços da API
    public T? Dados { get; set; }

    public string Mensagem { get; set; } =string.Empty;

    public bool Sucesso { get; set; } = true;

}
