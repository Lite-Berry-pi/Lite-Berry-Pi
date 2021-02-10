using Microsoft.EntityFrameworkCore.Migrations;

namespace Lite_Berry_Pi.Migrations
{
  public partial class seedingRoles : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "administrator", "00000000-0000-0000-0000-000000000000", "Administrator", "ADMINISTRATOR" });

      migrationBuilder.InsertData(
          table: "AspNetRoles",
          columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
          values: new object[] { "user", "00000000-0000-0000-0000-000000000000", "User", "USER" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "administrator");

      migrationBuilder.DeleteData(
          table: "AspNetRoles",
          keyColumn: "Id",
          keyValue: "user");
    }
  }
}
