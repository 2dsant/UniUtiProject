using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Infra.Data.Migrations
{
    public partial class UpdateRelacionamento02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Instituicoes_InstituicaoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Disciplinas_DisciplinaId",
                table: "Monitorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstituicaoId",
                table: "Monitorias",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplinaId",
                table: "Monitorias",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstituicaoId",
                table: "Enderecos",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Instituicoes_InstituicaoId",
                table: "Enderecos",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Disciplinas_DisciplinaId",
                table: "Monitorias",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Instituicoes_InstituicaoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Disciplinas_DisciplinaId",
                table: "Monitorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstituicaoId",
                table: "Monitorias",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "DisciplinaId",
                table: "Monitorias",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "InstituicaoId",
                table: "Enderecos",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Instituicoes_InstituicaoId",
                table: "Enderecos",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Disciplinas_DisciplinaId",
                table: "Monitorias",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "id");
        }
    }
}
