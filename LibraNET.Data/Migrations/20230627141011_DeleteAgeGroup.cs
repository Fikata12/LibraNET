using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNET.Data.Migrations
{
    public partial class DeleteAgeGroup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeGroup",
                table: "Books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AgeGroup",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
