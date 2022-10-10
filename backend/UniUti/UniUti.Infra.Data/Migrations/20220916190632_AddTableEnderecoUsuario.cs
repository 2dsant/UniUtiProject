using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Infra.Data.Migrations
{
    public partial class AddTableEnderecoUsuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Monitorias",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_Monitorias_InstituicaoId",
                table: "Monitorias",
                column: "InstituicaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias");

            migrationBuilder.DropIndex(
                name: "IX_Monitorias_InstituicaoId",
                table: "Monitorias");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Monitorias");
        }
    }
}
