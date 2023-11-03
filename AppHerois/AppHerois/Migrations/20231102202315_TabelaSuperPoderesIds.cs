using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHerois.Migrations
{
    /// <inheritdoc />
    public partial class TabelaSuperPoderesIds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Herois",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    NomeHeroi = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Altura = table.Column<double>(type: "double precision", nullable: false),
                    Peso = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Herois", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeroisSuperpoderesModel",
                columns: table => new
                {
                    HeroiId = table.Column<Guid>(type: "uuid", nullable: false),
                    SuperpoderId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SuperPoderes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SuperPoder = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPoderes", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Herois");

            migrationBuilder.DropTable(
                name: "HeroisSuperpoderesModel");

            migrationBuilder.DropTable(
                name: "SuperPoderes");
        }
    }
}
