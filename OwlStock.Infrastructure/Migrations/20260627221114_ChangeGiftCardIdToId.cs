using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeGiftCardIdToId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GiftCardId",
                table: "GiftCards",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "GiftCards",
                newName: "GiftCardId");
        }
    }
}
