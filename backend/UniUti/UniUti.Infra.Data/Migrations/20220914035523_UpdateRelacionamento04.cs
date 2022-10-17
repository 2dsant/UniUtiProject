using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniUti.Infra.Data.Migrations
{
    public partial class UpdateRelacionamento04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_Monitorias_Instituicoes_InstituicaoId",
                table: "Monitorias",
                column: "InstituicaoId",
                principalTable: "Instituicoes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
