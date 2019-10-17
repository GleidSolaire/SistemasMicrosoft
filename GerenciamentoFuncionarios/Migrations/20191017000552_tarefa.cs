using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciamentoFuncionarios.Migrations
{
    public partial class tarefa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Tarefa_TarefaId",
                table: "Departamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Tarefa_TarefaId",
                table: "Funcionario");

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
                name: "TarefaId",
                table: "Departamento");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fim",
                table: "Tarefa",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Tarefa",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ExecutorId",
                table: "Tarefa",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_DepartamentosId",
                table: "Tarefa",
                column: "DepartamentosId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefa_ExecutorId",
                table: "Tarefa",
                column: "ExecutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Departamento_DepartamentosId",
                table: "Tarefa",
                column: "DepartamentosId",
                principalTable: "Departamento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Funcionario_ExecutorId",
                table: "Tarefa",
                column: "ExecutorId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Departamento_DepartamentosId",
                table: "Tarefa");

            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Funcionario_ExecutorId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_DepartamentosId",
                table: "Tarefa");

            migrationBuilder.DropIndex(
                name: "IX_Tarefa_ExecutorId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Tarefa");

            migrationBuilder.DropColumn(
                name: "ExecutorId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fim",
                table: "Tarefa",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarefaId",
                table: "Funcionario",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TarefaId",
                table: "Departamento",
                nullable: true);

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
    }
}
