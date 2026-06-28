using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi_Logistica.Migrations
{
    /// <inheritdoc />
    public partial class firstmigration : Migration
    {
        /// <inheritdoc />
        /// Aqui ele vai criar a tabela Funcionarios no banco de dados com os campos id, Nome, Sobrenome, Departamento, Ativo, Turno, DataCriação e DataAlteração, e vai definir o id como chave primaria da tabela
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Departamento = table.Column<int>(type: "int", nullable: false),
                    Ativo = table.Column<bool>(type: "bit", nullable: false),
                    Turno = table.Column<int>(type: "int", nullable: false),
                    DataCriação = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataAlteração = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionarios", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Funcionarios");
        }
    }
}
