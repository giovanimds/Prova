using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProva.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folha_Funcionario_FuncionarioId",
                table: "Folha");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folha",
                table: "Folha");

            migrationBuilder.RenameTable(
                name: "Funcionario",
                newName: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Folha",
                newName: "Folhas");

            migrationBuilder.RenameIndex(
                name: "IX_Folha_FuncionarioId",
                table: "Folhas",
                newName: "IX_Folhas_FuncionarioId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Folhas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "FuncionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folhas",
                table: "Folhas",
                column: "FolhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId",
                table: "Folhas",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId",
                table: "Folhas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Folhas",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Folhas");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Funcionario");

            migrationBuilder.RenameTable(
                name: "Folhas",
                newName: "Folha");

            migrationBuilder.RenameIndex(
                name: "IX_Folhas_FuncionarioId",
                table: "Folha",
                newName: "IX_Folha_FuncionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario",
                column: "FuncionarioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Folha",
                table: "Folha",
                column: "FolhaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Folha_Funcionario_FuncionarioId",
                table: "Folha",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
