using Microsoft.EntityFrameworkCore.Migrations;

namespace Lite_Berry_Pi.Migrations
{
  public partial class test : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Design_UserDesign_UserDesignUserId_UserDesignDesignId",
          table: "Design");

      migrationBuilder.DropIndex(
          name: "IX_Design_UserDesignUserId_UserDesignDesignId",
          table: "Design");

      migrationBuilder.DropColumn(
          name: "UserDesignDesignId",
          table: "Design");

      migrationBuilder.DropColumn(
          name: "UserDesignUserId",
          table: "Design");

      migrationBuilder.CreateIndex(
          name: "IX_UserDesign_DesignId",
          table: "UserDesign",
          column: "DesignId",
          unique: true);

      migrationBuilder.AddForeignKey(
          name: "FK_UserDesign_Design_DesignId",
          table: "UserDesign",
          column: "DesignId",
          principalTable: "Design",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_UserDesign_Design_DesignId",
          table: "UserDesign");

      migrationBuilder.DropIndex(
          name: "IX_UserDesign_DesignId",
          table: "UserDesign");

      migrationBuilder.AddColumn<int>(
          name: "UserDesignDesignId",
          table: "Design",
          type: "int",
          nullable: true);

      migrationBuilder.AddColumn<int>(
          name: "UserDesignUserId",
          table: "Design",
          type: "int",
          nullable: true);

      migrationBuilder.CreateIndex(
          name: "IX_Design_UserDesignUserId_UserDesignDesignId",
          table: "Design",
          columns: new[] { "UserDesignUserId", "UserDesignDesignId" });

      migrationBuilder.AddForeignKey(
          name: "FK_Design_UserDesign_UserDesignUserId_UserDesignDesignId",
          table: "Design",
          columns: new[] { "UserDesignUserId", "UserDesignDesignId" },
          principalTable: "UserDesign",
          principalColumns: new[] { "UserId", "DesignId" },
          onDelete: ReferentialAction.Restrict);
    }
  }
}
