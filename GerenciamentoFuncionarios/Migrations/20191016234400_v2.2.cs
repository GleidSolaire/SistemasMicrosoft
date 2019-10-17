using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciamentoFuncionarios.Migrations
{
    public partial class v22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TarefaId",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Departamento",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "TarefaId",
                table: "Departamento",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Tarefa",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    Fim = table.Column<DateTime>(nullable: false),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Titulo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefa", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_TarefaId",
                table: "Funcionario",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_TarefaId",
                table: "Departamento",
                column: "TarefaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Tarefa_TarefaId",
                table: "Departamento",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Tarefa_TarefaId",
                table: "Funcionario",
                column: "TarefaId",
                principalTable: "Tarefa",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Tarefa_TarefaId",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Tarefa_TarefaId",
                table: "Funcionario");

            migrationBuilder.DropTable(
                name: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_TarefaId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_TarefaId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "TarefaId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "TarefaId",
                table: "Departamento");
        }
    }
}
