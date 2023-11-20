using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeNaturezaDeLancamento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "naturezadelancamento",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataInatividade = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_naturezadelancamento", x => x.Id);
                    table.ForeignKey(
                        name: "FK_naturezadelancamento_usuario_Id",
                        column: x => x.Id,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "naturezadelancamento");
        }
    }
}
