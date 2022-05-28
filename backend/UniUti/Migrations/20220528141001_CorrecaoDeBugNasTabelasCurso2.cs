using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Migrations
{
    public partial class CorrecaoDeBugNasTabelasCurso2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_cursos_CursoId",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_instituicoes_InstituicaoId",
                table: "usuarios");

            migrationBuilder.AlterColumn<long>(
                name: "InstituicaoId",
                table: "usuarios",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "CursoId",
                table: "usuarios",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_cursos_CursoId",
                table: "usuarios",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_instituicoes_InstituicaoId",
                table: "usuarios",
                column: "InstituicaoId",
                principalTable: "instituicoes",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_cursos_CursoId",
                table: "usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_usuarios_instituicoes_InstituicaoId",
                table: "usuarios");

            migrationBuilder.AlterColumn<long>(
                name: "InstituicaoId",
                table: "usuarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "CursoId",
                table: "usuarios",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_cursos_CursoId",
                table: "usuarios",
                column: "CursoId",
                principalTable: "cursos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_usuarios_instituicoes_InstituicaoId",
                table: "usuarios",
                column: "InstituicaoId",
                principalTable: "instituicoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
