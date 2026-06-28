using Microsoft.EntityFrameworkCore;
using WebAPi_Logistica.Models;

namespace WebAPi_Logistica.DataContext
{
    public class AplicationDbContext : DbContext
    {
        //DataContext serve para eu criar um banco de dados e criar tabelas no banco de dados referente aos paramtros da minha model FuncionarioModel, e vai ser usado no controller e no service para acessar o banco de dados e fazer operações de CRUD(Create, Read, Update, Delete) na tabela Funcionarios
        //ctor tab
        //Conexão com o banco de dados Decorar esse codigo !!!!!
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
        {
        }

        // Ele vai criar uma tabela no banco de dados com o nome de Funcionarios e vai mapear a classe FuncionarioModel para essa tabela
        public DbSet<FuncionarioModel> Funcionarios { get; set; }


    
    }

}
