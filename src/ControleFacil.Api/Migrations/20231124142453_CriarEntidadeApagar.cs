using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ControleFacil.Api.Migrations
{
    /// <inheritdoc />
    public partial class CriarEntidadeApagar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_naturezadelancamento_usuario_Id",
                table: "naturezadelancamento");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "naturezadelancamento",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.CreateTable(
                name: "apagar",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdUsuario = table.Column<long>(type: "bigint", nullable: false),
                    IdNaturezaDeLancamento = table.Column<long>(type: "bigint", nullable: false),
                    Descricao = table.Column<string>(type: "VARCHAR", nullable: false),
                    ValorOriginal = table.Column<double>(type: "double precision", nullable: false),
                    ValorPago = table.Column<double>(type: "double precision", nullable: false),
                    Observacao = table.Column<string>(type: "VARCHAR", nullable: true),
                    DataCadastro = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataVencimento = table.Column<DateTime>(type: "timestamp", nullable: false),
                    DataInatividade = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataReferencia = table.Column<DateTime>(type: "timestamp", nullable: true),
                    DataPagamento = table.Column<DateTime>(type: "timestamp", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_apagar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_apagar_naturezadelancamento_IdNaturezaDeLancamento",
                        column: x => x.IdNaturezaDeLancamento,
                        principalTable: "naturezadelancamento",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_apagar_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_naturezadelancamento_IdUsuario",
                table: "naturezadelancamento",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_apagar_IdNaturezaDeLancamento",
                table: "apagar",
                column: "IdNaturezaDeLancamento");

            migrationBuilder.CreateIndex(
                name: "IX_apagar_IdUsuario",
                table: "apagar",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_naturezadelancamento_usuario_IdUsuario",
                table: "naturezadelancamento",
                column: "IdUsuario",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_naturezadelancamento_usuario_IdUsuario",
                table: "naturezadelancamento");

            migrationBuilder.DropTable(
                name: "apagar");

            migrationBuilder.DropIndex(
                name: "IX_naturezadelancamento_IdUsuario",
                table: "naturezadelancamento");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "naturezadelancamento",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddForeignKey(
                name: "FK_naturezadelancamento_usuario_Id",
                table: "naturezadelancamento",
                column: "Id",
                principalTable: "usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
