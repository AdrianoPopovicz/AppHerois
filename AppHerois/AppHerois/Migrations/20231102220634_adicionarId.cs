using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHerois.Migrations
{
    /// <inheritdoc />
    public partial class adicionarId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "HeroisSuperpoderesModel",
                newName: "HeroisPoderes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Herois",
                type: "timestamp without time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "HeroisPoderes",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Id",
                table: "HeroisPoderes");

            migrationBuilder.RenameTable(
                name: "HeroisPoderes",
                newName: "HeroisSuperpoderesModel");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Herois",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }
    }
}
