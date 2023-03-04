using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace LocacaoImoveis.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    cep = table.Column<string>(type: "text", nullable: true),
                    logradouro = table.Column<string>(type: "text", nullable: true),
                    bairro = table.Column<string>(type: "text", nullable: true),
                    localidade = table.Column<string>(type: "text", nullable: true),
                    uf = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECOS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CLIENTES",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    nome = table.Column<string>(type: "text", nullable: false),
                    cpfCnpj = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    telefone = table.Column<string>(type: "text", nullable: false),
                    numeroCasa = table.Column<long>(type: "bigint", nullable: false),
                    enderecoCep = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTES", x => x.id);
                    table.ForeignKey(
                        name: "FK_CLIENTES_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "IMOVEIS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    numeroCasa = table.Column<long>(type: "bigint", nullable: false),
                    locado = table.Column<bool>(type: "boolean", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    enderecoCep = table.Column<string>(type: "text", nullable: false),
                    EnderecoId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IMOVEIS", x => x.id);
                    table.ForeignKey(
                        name: "FK_IMOVEIS_ENDERECOS_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "ENDERECOS",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "CONTRATOS",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ValorLocacao = table.Column<double>(type: "double precision", nullable: false),
                    dataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    dataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ativo = table.Column<bool>(type: "boolean", nullable: false),
                    clienteId = table.Column<int>(type: "integer", nullable: false),
                    imovelId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTRATOS", x => x.id);
                    table.ForeignKey(
                        name: "FK_CONTRATOS_CLIENTES_clienteId",
                        column: x => x.clienteId,
                        principalTable: "CLIENTES",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CONTRATOS_IMOVEIS_imovelId",
                        column: x => x.imovelId,
                        principalTable: "IMOVEIS",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CLIENTES_EnderecoId",
                table: "CLIENTES",
                column: "EnderecoId");

            migrationBuilder.CreateIndex(
                name: "IX_CONTRATOS_clienteId",
                table: "CONTRATOS",
                column: "clienteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CONTRATOS_imovelId",
                table: "CONTRATOS",
                column: "imovelId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IMOVEIS_EnderecoId",
                table: "IMOVEIS",
                column: "EnderecoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CONTRATOS");

            migrationBuilder.DropTable(
                name: "CLIENTES");

            migrationBuilder.DropTable(
                name: "IMOVEIS");

            migrationBuilder.DropTable(
                name: "ENDERECOS");
        }
    }
}
