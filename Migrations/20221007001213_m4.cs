using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAppProva.Migrations
{
    /// <inheritdoc />
    public partial class m4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId1",
                table: "Folhas",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Folhas_FuncionarioId1",
                table: "Folhas",
                column: "FuncionarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId1",
                table: "Folhas",
                column: "FuncionarioId1",
                principalTable: "Funcionarios",
                principalColumn: "FuncionarioId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Folhas_Funcionarios_FuncionarioId1",
                table: "Folhas");

            migrationBuilder.DropIndex(
                name: "IX_Folhas_FuncionarioId1",
                table: "Folhas");

            migrationBuilder.DropColumn(
                name: "FuncionarioId1",
                table: "Folhas");
        }
    }
}
