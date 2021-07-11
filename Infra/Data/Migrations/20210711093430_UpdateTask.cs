using Microsoft.EntityFrameworkCore.Migrations;

namespace Infra.Data.Migrations
{
    public partial class UpdateTask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9feb39f6-4436-43f0-8972-28073a13a41e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "192f282a-58f7-4d7f-a7ea-08c610eea14e", "60d70055-35c3-4599-8e01-b2f28d3a0e15", "ApplicationRole", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "192f282a-58f7-4d7f-a7ea-08c610eea14e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Discriminator", "Name", "NormalizedName" },
                values: new object[] { "9feb39f6-4436-43f0-8972-28073a13a41e", "6c545752-d4bc-47f2-ac28-9548ec669275", "ApplicationRole", "Admin", "ADMIN" });
        }
    }
}
