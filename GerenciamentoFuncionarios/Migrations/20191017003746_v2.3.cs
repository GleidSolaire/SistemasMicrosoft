using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciamentoFuncionarios.Migrations
{
    public partial class v23 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Funcionario_ExecutorId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Tarefa",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Funcionario_ExecutorId",
                table: "Tarefa",
                column: "ExecutorId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tarefa_Funcionario_ExecutorId",
                table: "Tarefa");

            migrationBuilder.AlterColumn<int>(
                name: "ExecutorId",
                table: "Tarefa",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Tarefa_Funcionario_ExecutorId",
                table: "Tarefa",
                column: "ExecutorId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
