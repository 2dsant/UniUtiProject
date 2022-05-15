using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Migrations
{
    public partial class MudancasModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplinas_Cursos_CursoId",
                table: "Disciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Usuarios_AutorId",
                table: "Monitorias");

            migrationBuilder.DropIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CursoId",
                table: "Disciplinas");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                table: "Monitorias",
                newName: "SolicitanteId");

            migrationBuilder.RenameIndex(
                name: "IX_Monitorias_AutorId",
                table: "Monitorias",
                newName: "IX_Monitorias_SolicitanteId");

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaHash",
                table: "Usuarios",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "SenhaSalt",
                table: "Usuarios",
                type: "longblob",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrestadorId",
                table: "Monitorias",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Disciplinas",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "CursoDisciplina",
                columns: table => new
                {
                    CursosId = table.Column<int>(type: "int", nullable: false),
                    DisciplinasId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoDisciplina", x => new { x.CursosId, x.DisciplinasId });
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Cursos_CursosId",
                        column: x => x.CursosId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CursoDisciplina_Disciplinas_DisciplinasId",
                        column: x => x.DisciplinasId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Monitorias_PrestadorId",
                table: "Monitorias",
                column: "PrestadorId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoDisciplina_DisciplinasId",
                table: "CursoDisciplina",
                column: "DisciplinasId");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Usuarios_PrestadorId",
                table: "Monitorias",
                column: "PrestadorId",
                principalTable: "Usuarios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Usuarios_SolicitanteId",
                table: "Monitorias",
                column: "SolicitanteId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Usuarios_PrestadorId",
                table: "Monitorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Usuarios_SolicitanteId",
                table: "Monitorias");

            migrationBuilder.DropTable(
                name: "CursoDisciplina");

            migrationBuilder.DropIndex(
                name: "IX_Monitorias_PrestadorId",
                table: "Monitorias");

            migrationBuilder.DropColumn(
                name: "SenhaHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SenhaSalt",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PrestadorId",
                table: "Monitorias");

            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Disciplinas");

            migrationBuilder.RenameColumn(
                name: "SolicitanteId",
                table: "Monitorias",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Monitorias_SolicitanteId",
                table: "Monitorias",
                newName: "IX_Monitorias_AutorId");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "CursoId",
                table: "Disciplinas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplinas_Cursos_CursoId",
                table: "Disciplinas",
                column: "CursoId",
                principalTable: "Cursos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Usuarios_AutorId",
                table: "Monitorias",
                column: "AutorId",
                principalTable: "Usuarios",
                principalColumn: "Id");
        }
    }
}
