using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyBotBackend.Migrations
{
    public partial class addUserIdToMoney : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Moneys",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Moneys",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Moneys",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateTime",
                table: "Moneys",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Moneys_Users_UserId",
                table: "Moneys",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
