using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNET.Data.Migrations
{
    public partial class RenameImageURLToImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Books",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "Authors",
                newName: "ImagePath");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Books",
                newName: "ImageURL");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Authors",
                newName: "ImageURL");
        }
    }
}
