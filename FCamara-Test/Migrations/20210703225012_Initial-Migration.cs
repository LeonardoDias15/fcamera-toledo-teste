using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace FCamara_Test.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: false),
                    Cep = table.Column<string>(maxLength: 8, nullable: true),
                    Endereco = table.Column<string>(maxLength: 100, nullable: true),
                    Bairro = table.Column<string>(maxLength: 60, nullable: true),
                    Numero = table.Column<string>(maxLength: 20, nullable: true),
                    Complemento = table.Column<string>(maxLength: 40, nullable: true),
                    Estado = table.Column<string>(maxLength: 40, nullable: true),
                    Cidade = table.Column<string>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCadastro = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HistoricoAuditoria",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Funcionalidade = table.Column<string>(maxLength: 30, nullable: true),
                    Evento = table.Column<string>(maxLength: 20, nullable: true),
                    Dados = table.Column<string>(nullable: true),
                    IdentificadorFuncionalidade = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCadastro = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricoAuditoria", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DependenteFuncionario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(maxLength: 255, nullable: true),
                    CPF = table.Column<string>(maxLength: 11, nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<string>(nullable: true),
                    FuncionarioId = table.Column<Guid>(nullable: false),
                    Ativo = table.Column<bool>(nullable: false, defaultValue: true),
                    DataCadastro = table.Column<DateTime>(nullable: false, defaultValueSql: "getdate()"),
                    DataAtualizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DependenteFuncionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DependenteFuncionario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DependenteFuncionario_FuncionarioId",
                table: "DependenteFuncionario",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DependenteFuncionario");

            migrationBuilder.DropTable(
                name: "HistoricoAuditoria");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
