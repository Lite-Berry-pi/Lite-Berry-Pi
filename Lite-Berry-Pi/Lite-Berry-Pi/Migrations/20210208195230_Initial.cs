using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Lite_Berry_Pi.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LoginTime = table.Column<DateTime>(nullable: false),
                    SendTime = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLog_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserDesign",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    DesignId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDesign", x => new { x.UserId, x.DesignId });
                    table.ForeignKey(
                        name: "FK_UserDesign_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Design",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    TimeStamp = table.Column<DateTime>(nullable: false),
                    DesignCoords = table.Column<string>(nullable: false),
                    UserDesignUserId = table.Column<int>(nullable: true),
                    UserDesignDesignId = table.Column<int>(nullable: true),
                    ActivityLogId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Design", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Design_ActivityLog_ActivityLogId",
                        column: x => x.ActivityLogId,
                        principalTable: "ActivityLog",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Design_UserDesign_UserDesignUserId_UserDesignDesignId",
                        columns: x => new { x.UserDesignUserId, x.UserDesignDesignId },
                        principalTable: "UserDesign",
                        principalColumns: new[] { "UserId", "DesignId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Design",
                columns: new[] { "Id", "ActivityLogId", "DesignCoords", "TimeStamp", "Title", "UserDesignDesignId", "UserDesignUserId" },
                values: new object[,]
                {
                    { 1, null, "000011111", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test1", null, null },
                    { 2, null, "10011001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test2", null, null },
                    { 3, null, "100010101", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Test3", null, null }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Bruno" },
                    { 2, "Elwood" },
                    { 3, "Jake" }
                });

            migrationBuilder.InsertData(
                table: "UserDesign",
                columns: new[] { "UserId", "DesignId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "UserDesign",
                columns: new[] { "UserId", "DesignId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "UserDesign",
                columns: new[] { "UserId", "DesignId" },
                values: new object[] { 3, 3 });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLog_UserId",
                table: "ActivityLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_ActivityLogId",
                table: "Design",
                column: "ActivityLogId");

            migrationBuilder.CreateIndex(
                name: "IX_Design_UserDesignUserId_UserDesignDesignId",
                table: "Design",
                columns: new[] { "UserDesignUserId", "UserDesignDesignId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Design");

            migrationBuilder.DropTable(
                name: "ActivityLog");

            migrationBuilder.DropTable(
                name: "UserDesign");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
