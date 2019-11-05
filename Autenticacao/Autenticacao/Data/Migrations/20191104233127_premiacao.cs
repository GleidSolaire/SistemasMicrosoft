using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Autenticacao.Data.Migrations
{
    public partial class premiacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Dono",
                table: "Torneio",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Premiacao",
                table: "Torneio",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Premiacao",
                table: "Torneio");

            migrationBuilder.AlterColumn<string>(
                name: "Dono",
                table: "Torneio",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
