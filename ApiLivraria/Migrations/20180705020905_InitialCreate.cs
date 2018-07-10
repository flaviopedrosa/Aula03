using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiLivraria.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autores",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Entregas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataRetirada = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    DataEntrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entregas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pedidos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataRetirada = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedidos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarrinhosCompras",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AutorId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarrinhosCompras", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarrinhosCompras_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    Isbn = table.Column<string>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Prefacio = table.Column<string>(nullable: false),
                    CarrinhoCompraId = table.Column<Guid>(nullable: true),
                    EntregaId = table.Column<Guid>(nullable: true),
                    PedidoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.Isbn);
                    table.ForeignKey(
                        name: "FK_Livros_CarrinhosCompras_CarrinhoCompraId",
                        column: x => x.CarrinhoCompraId,
                        principalTable: "CarrinhosCompras",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livros_Entregas_EntregaId",
                        column: x => x.EntregaId,
                        principalTable: "Entregas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Livros_Pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "Pedidos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutorId = table.Column<Guid>(nullable: false),
                    LivroId = table.Column<Guid>(nullable: false),
                    LivroIsbn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => new { x.AutorId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_AutorLivro_Autores_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Autores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutorLivro_Livros_LivroIsbn",
                        column: x => x.LivroIsbn,
                        principalTable: "Livros",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    LivroIsbn = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Livros_LivroIsbn",
                        column: x => x.LivroIsbn,
                        principalTable: "Livros",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivro_LivroIsbn",
                table: "AutorLivro",
                column: "LivroIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_CarrinhosCompras_AutorId",
                table: "CarrinhosCompras",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_LivroIsbn",
                table: "Comentarios",
                column: "LivroIsbn");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_CarrinhoCompraId",
                table: "Livros",
                column: "CarrinhoCompraId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_EntregaId",
                table: "Livros",
                column: "EntregaId");

            migrationBuilder.CreateIndex(
                name: "IX_Livros_PedidoId",
                table: "Livros",
                column: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivro");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Livros");

            migrationBuilder.DropTable(
                name: "CarrinhosCompras");

            migrationBuilder.DropTable(
                name: "Entregas");

            migrationBuilder.DropTable(
                name: "Pedidos");

            migrationBuilder.DropTable(
                name: "Autores");
        }
    }
}
