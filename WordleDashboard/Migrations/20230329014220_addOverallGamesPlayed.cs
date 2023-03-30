using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WordleDashboard.Migrations
{
    /// <inheritdoc />
    public partial class addOverallGamesPlayed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OverallGamesPlayed",
                table: "Players",
                type: "int",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OverallGamesPlayed",
                table: "Players");
        }
    }
}
