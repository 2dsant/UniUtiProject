using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Migrations
{
    public partial class UpdateMonitoriaModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_monitorias_usuarios_PrestadorId",
                table: "monitorias");

            migrationBuilder.AlterColumn<long>(
                name: "PrestadorId",
                table: "monitorias",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_monitorias_usuarios_PrestadorId",
                table: "monitorias",
                column: "PrestadorId",
                principalTable: "usuarios",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_monitorias_usuarios_PrestadorId",
                table: "monitorias");

            migrationBuilder.AlterColumn<long>(
                name: "PrestadorId",
                table: "monitorias",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_monitorias_usuarios_PrestadorId",
                table: "monitorias",
                column: "PrestadorId",
                principalTable: "usuarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
