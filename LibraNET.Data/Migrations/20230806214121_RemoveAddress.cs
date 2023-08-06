using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNET.Data.Migrations
{
    public partial class RemoveAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AddColumn<string>(
                name: "PostCode",
                table: "Orders",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Town",
                table: "Orders",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("485c54bc-b294-420b-ba53-c4c219af644d"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f619a68-3e7f-448e-b352-717915da20e5"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1493));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1516));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("be157e3e-161f-4764-a782-2bec929bcd94"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1528));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c482f838-87c4-4443-b143-62637d4f97e7"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1571));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1560));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1630));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"),
                column: "AddedDate",
                value: new DateTime(2023, 8, 7, 0, 41, 21, 349, DateTimeKind.Local).AddTicks(1483));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostCode",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Town",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostCode = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Town = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(639));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("485c54bc-b294-420b-ba53-c4c219af644d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(563));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f619a68-3e7f-448e-b352-717915da20e5"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(515));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(605));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(539));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("be157e3e-161f-4764-a782-2bec929bcd94"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(550));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c482f838-87c4-4443-b143-62637d4f97e7"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(629));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(525));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(618));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(505));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId");
        }
    }
}
