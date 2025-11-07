using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BancoHistorico.Migrations
{
    public partial class ini : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Solucao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solucao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SolucaoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Projetos_Solucao_SolucaoId",
                        column: x => x.SolucaoId,
                        principalTable: "Solucao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tabelas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    area = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tableNameOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contador = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjetoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tabelas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tabelas_Projetos_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projetos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Colunas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TabelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroColuna = table.Column<int>(type: "int", nullable: false),
                    OwnsOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColumnNameOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    max_length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colunas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Colunas_Tabelas_TabelaId",
                        column: x => x.TabelaId,
                        principalTable: "Tabelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fk",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    referenced_object_id = table.Column<int>(type: "int", nullable: false),
                    referenced_column_id = table.Column<int>(type: "int", nullable: false),
                    FK_CONSTRAINT = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referenced_column = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    referenced_object = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_object = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    parent_column = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColunaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fk_Colunas_ColunaId",
                        column: x => x.ColunaId,
                        principalTable: "Colunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Indices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ColunaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    KeyNameOf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    is_unique = table.Column<bool>(type: "bit", nullable: false),
                    is_primary_key = table.Column<bool>(type: "bit", nullable: false),
                    filter_definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TabelaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Indices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Indices_Colunas_ColunaId",
                        column: x => x.ColunaId,
                        principalTable: "Colunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Indices_Tabelas_TabelaId",
                        column: x => x.TabelaId,
                        principalTable: "Tabelas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Restricoes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColunaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restricoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restricoes_Colunas_ColunaId",
                        column: x => x.ColunaId,
                        principalTable: "Colunas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Colunas_TabelaId",
                table: "Colunas",
                column: "TabelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Fk_ColunaId",
                table: "Fk",
                column: "ColunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Indices_ColunaId",
                table: "Indices",
                column: "ColunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Indices_TabelaId",
                table: "Indices",
                column: "TabelaId");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_SolucaoId",
                table: "Projetos",
                column: "SolucaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Restricoes_ColunaId",
                table: "Restricoes",
                column: "ColunaId");

            migrationBuilder.CreateIndex(
                name: "IX_Tabelas_ProjetoId",
                table: "Tabelas",
                column: "ProjetoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fk");

            migrationBuilder.DropTable(
                name: "Indices");

            migrationBuilder.DropTable(
                name: "Restricoes");

            migrationBuilder.DropTable(
                name: "Colunas");

            migrationBuilder.DropTable(
                name: "Tabelas");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Solucao");
        }
    }
}
