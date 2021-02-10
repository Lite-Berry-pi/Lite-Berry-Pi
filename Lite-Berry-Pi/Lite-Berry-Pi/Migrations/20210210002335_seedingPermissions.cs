using Microsoft.EntityFrameworkCore.Migrations;

namespace Lite_Berry_Pi.Migrations
{
  public partial class seedingPermissions : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.InsertData(
          table: "AspNetRoleClaims",
          columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
          values: new object[,]
          {
                    { 1, "permissions", "create", "administrator" },
                    { 2, "permissions", "update", "administrator" },
                    { 3, "permissions", "delete", "administrator" },
                    { 4, "permissions", "read", "user" },
                    { 5, "permissions", "send", "user" }
          });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DeleteData(
          table: "AspNetRoleClaims",
          keyColumn: "Id",
          keyValue: 1);

      migrationBuilder.DeleteData(
          table: "AspNetRoleClaims",
          keyColumn: "Id",
          keyValue: 2);

      migrationBuilder.DeleteData(
          table: "AspNetRoleClaims",
          keyColumn: "Id",
          keyValue: 3);

      migrationBuilder.DeleteData(
          table: "AspNetRoleClaims",
          keyColumn: "Id",
          keyValue: 4);

      migrationBuilder.DeleteData(
          table: "AspNetRoleClaims",
          keyColumn: "Id",
          keyValue: 5);
    }
  }
}
