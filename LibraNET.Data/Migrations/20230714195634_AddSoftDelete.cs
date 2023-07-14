using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNET.Data.Migrations
{
    public partial class AddSoftDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Comments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Authors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2068));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("485c54bc-b294-420b-ba53-c4c219af644d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2141));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f619a68-3e7f-448e-b352-717915da20e5"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2094));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2154));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("be157e3e-161f-4764-a782-2bec929bcd94"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2128));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c482f838-87c4-4443-b143-62637d4f97e7"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2181));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2104));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2166));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2213));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 22, 56, 34, 222, DateTimeKind.Local).AddTicks(2084));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Authors");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(2940));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("485c54bc-b294-420b-ba53-c4c219af644d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3064));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3011));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f619a68-3e7f-448e-b352-717915da20e5"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(2968));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3022));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(2989));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("be157e3e-161f-4764-a782-2bec929bcd94"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3001));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c482f838-87c4-4443-b143-62637d4f97e7"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3043));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(2978));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3032));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(3074));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 8, 14, 39, 34, 698, DateTimeKind.Local).AddTicks(2955));
        }
    }
}
