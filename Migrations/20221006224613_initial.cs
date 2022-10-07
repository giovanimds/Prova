using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProva.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.FuncionarioId);
                });

            migrationBuilder.CreateTable(
                name: "Folha",
                columns: table => new
                {
                    FolhaId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ValorHora = table.Column<double>(type: "REAL", nullable: false),
                    QuantidadeDeHoras = table.Column<double>(type: "REAL", nullable: false),
                    SalarioBruto = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoDeRenda = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoInss = table.Column<double>(type: "REAL", nullable: false),
                    ImpostoFgts = table.Column<double>(type: "REAL", nullable: false),
                    SalarioLiquido = table.Column<double>(type: "REAL", nullable: false),
                    FuncionarioId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folha", x => x.FolhaId);
                    table.ForeignKey(
                        name: "FK_Folha_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Folha_FuncionarioId",
                table: "Folha",
                column: "FuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Folha");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
