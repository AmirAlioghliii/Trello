using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class UpdateTaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "873c65ce-87f7-41bf-8fac-3b0be0b0eeb5");

            migrationBuilder.AddColumn<DateTime>(
                name: "TaskTime",
                table: "UserTasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "9feb39f6-4436-43f0-8972-28073a13a41e", "6c545752-d4bc-47f2-ac28-9548ec669275", "ApplicationRole", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9feb39f6-4436-43f0-8972-28073a13a41e");

            migrationBuilder.DropColumn(
                name: "TaskTime",
                table: "UserTasks");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "873c65ce-87f7-41bf-8fac-3b0be0b0eeb5", "6f32ff32-4b8a-4176-8693-17b5f2313816", "ApplicationRole", "Admin", "ADMIN" });
        }
    }
}
