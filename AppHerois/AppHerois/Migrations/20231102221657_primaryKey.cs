using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppHerois.Migrations
{
    /// <inheritdoc />
    public partial class primaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddPrimaryKey(
                name: "PK_HeroisPoderes",
                table: "HeroisPoderes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_HeroisPoderes",
                table: "HeroisPoderes");
        }
    }
}
