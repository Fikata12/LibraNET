using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraNET.Data.Migrations
{
    public partial class FixSeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                columns: new[] { "AddedDate", "ImageId" },
                values: new object[] { new DateTime(2023, 7, 18, 21, 24, 28, 858, DateTimeKind.Local).AddTicks(525), new Guid("d0829ed0-e541-4cd3-94d4-703173069313") });

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

            migrationBuilder.InsertData(
                table: "BooksCategories",
                columns: new[] { "BookId", "CategoryId" },
                values: new object[] { new Guid("485c54bc-b294-420b-ba53-c4c219af644d"), new Guid("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BooksCategories",
                keyColumns: new[] { "BookId", "CategoryId" },
                keyValues: new object[] { new Guid("485c54bc-b294-420b-ba53-c4c219af644d"), new Guid("ebf52f81-9a9f-47cd-a9a5-be672bb85c4a") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("09aef649-020c-401b-aeb2-07c3101d2ec8"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3528));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("234e7f45-82e2-4951-b993-0e0360daff8c"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3374));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("485c54bc-b294-420b-ba53-c4c219af644d"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3539));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5d437d09-15fd-4969-856d-6694f1d75f5f"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3478));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("5f619a68-3e7f-448e-b352-717915da20e5"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3404));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("6166d03c-e89a-448e-9dbb-367a1e8453cf"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("98967e6a-9bf9-43fd-a2e1-e1de3d647817"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3426));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("be157e3e-161f-4764-a782-2bec929bcd94"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3438));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("c482f838-87c4-4443-b143-62637d4f97e7"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3518));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("cd6c5819-53e3-4024-9216-ae0f6502996d"),
                columns: new[] { "AddedDate", "ImageId" },
                values: new object[] { new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3414), new Guid("e97e05ae-a5ab-4096-b9b8-0c2a3d05d8a9") });

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("e5fb9d61-731e-42f2-a39a-ab13f9f26d25"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3500));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ed7abc74-4b8b-481d-9d43-ec14ada15dcc"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3549));

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: new Guid("ee5aea48-22b6-44bc-bfee-309290f19c35"),
                column: "AddedDate",
                value: new DateTime(2023, 7, 14, 23, 3, 2, 65, DateTimeKind.Local).AddTicks(3393));
        }
    }
}
