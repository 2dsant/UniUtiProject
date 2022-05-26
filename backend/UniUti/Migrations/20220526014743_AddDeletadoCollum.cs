using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Migrations
{
    public partial class AddDeletadoCollum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Usuarios",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Monitorias",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Instituicoes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Disciplinas",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Deletado",
                table: "Cursos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Monitorias");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Instituicoes");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "Deletado",
                table: "Cursos");
        }
    }
}
