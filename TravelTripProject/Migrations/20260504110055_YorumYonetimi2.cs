using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTripProject.Migrations
{
    /// <inheritdoc />
    public partial class YorumYonetimi2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vize",
                table: "Blogs",
                newName: "BlogDurum");

            migrationBuilder.AddColumn<bool>(
                name: "Okundu",
                table: "Yorumlars",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Yayinlandi",
                table: "Yorumlars",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Okundu",
                table: "Yorumlars");

            migrationBuilder.DropColumn(
                name: "Yayinlandi",
                table: "Yorumlars");

            migrationBuilder.RenameColumn(
                name: "BlogDurum",
                table: "Blogs",
                newName: "Vize");
        }
    }
}
