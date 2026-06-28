using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGiftCardIdToGUID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftCards",
                table: "GiftCards");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "GiftCards");

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "GiftCards",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "GiftCardId",
                table: "GiftCards",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "GiftCardNumber",
                table: "GiftCards",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftCards",
                table: "GiftCards",
                column: "GiftCardId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GiftCards",
                table: "GiftCards");

            migrationBuilder.DropColumn(
                name: "GiftCardId",
                table: "GiftCards");

            migrationBuilder.DropColumn(
                name: "GiftCardNumber",
                table: "GiftCards");

            migrationBuilder.AlterColumn<string>(
                name: "Receiver",
                table: "GiftCards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "GiftCards",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GiftCards",
                table: "GiftCards",
                column: "Id");
        }
    }
}
