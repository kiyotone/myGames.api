using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace myGames.api.Data.Migrations
{
    /// <inheritdoc />
    public partial class genreUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 13, "Psychological Horror" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 13);
        }
    }
}
