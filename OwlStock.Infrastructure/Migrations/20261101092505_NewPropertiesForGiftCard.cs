using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NewPropertiesForGiftCard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "GiftCards",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedById",
                table: "GiftCards",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "GiftCards",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_GiftCards_UpdatedById",
                table: "GiftCards",
                column: "UpdatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_GiftCards_AspNetUsers_UpdatedById",
                table: "GiftCards",
                column: "UpdatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GiftCards_AspNetUsers_UpdatedById",
                table: "GiftCards");

            migrationBuilder.DropIndex(
                name: "IX_GiftCards_UpdatedById",
                table: "GiftCards");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "GiftCards");

            migrationBuilder.DropColumn(
                name: "UpdatedById",
                table: "GiftCards");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "GiftCards");
        }
    }
}
