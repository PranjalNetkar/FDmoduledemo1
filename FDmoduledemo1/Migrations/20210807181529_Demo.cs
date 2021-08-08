using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FDmoduledemo1.Migrations
{
    public partial class Demo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountNum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConfirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountType = table.Column<int>(type: "int", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sques = table.Column<int>(type: "int", nullable: false),
                    SAns = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DoB = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountUser", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "FDTable",
                columns: table => new
                {
                    FdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FdInvMon = table.Column<double>(type: "float", nullable: false),
                    Month = table.Column<double>(type: "float", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    n = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AccountUserUserId = table.Column<int>(type: "int", nullable: true),
                    FdMAmount = table.Column<double>(type: "float", nullable: false),
                    FdInMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FDTable", x => x.FdId);
                    table.ForeignKey(
                        name: "FK_FDTable_AccountUser_AccountUserUserId",
                        column: x => x.AccountUserUserId,
                        principalTable: "AccountUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RD",
                columns: table => new
                {
                    RdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RdInvMon = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<double>(type: "float", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    n = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AccountUserUserId = table.Column<int>(type: "int", nullable: true),
                    FdMAmount = table.Column<double>(type: "float", nullable: false),
                    FdInMoney = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RD", x => x.RdId);
                    table.ForeignKey(
                        name: "FK_RD_AccountUser_AccountUserUserId",
                        column: x => x.AccountUserUserId,
                        principalTable: "AccountUser",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FDTable_AccountUserUserId",
                table: "FDTable",
                column: "AccountUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_RD_AccountUserUserId",
                table: "RD",
                column: "AccountUserUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FDTable");

            migrationBuilder.DropTable(
                name: "RD");

            migrationBuilder.DropTable(
                name: "AccountUser");
        }
    }
}
