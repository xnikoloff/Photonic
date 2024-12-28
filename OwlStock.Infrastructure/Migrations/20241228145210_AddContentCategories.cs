using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddContentCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("0045beb5-9555-467b-bd33-dd23ebb24e10"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("16488732-bfd2-402c-a389-74df37c7c051"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("8f8091af-598d-4569-aaa8-0fb7b7d9a95d"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("b039a7f4-0d74-4548-8b3d-f9bdd8531c8a"));

            migrationBuilder.CreateTable(
                name: "DynamicContentCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DynamicContentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DynamicContentCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DynamicContentCategories_AspNetUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_DynamicContentCategories_DynamicContents_DynamicContentId",
                        column: x => x.DynamicContentId,
                        principalTable: "DynamicContents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("5c5419db-b4d0-47df-9c8b-adf65ed15a7c"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("5f09d4e0-ff57-4c4a-bbcb-f08af79b2767"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("735995e7-3c80-46d1-84ca-7db318ec997f"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("9474d771-3549-4530-af2a-2b44609994a1"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DynamicContentCategories_CreatedById",
                table: "DynamicContentCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_DynamicContentCategories_DynamicContentId",
                table: "DynamicContentCategories",
                column: "DynamicContentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DynamicContentCategories");

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("5c5419db-b4d0-47df-9c8b-adf65ed15a7c"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("5f09d4e0-ff57-4c4a-bbcb-f08af79b2767"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("735995e7-3c80-46d1-84ca-7db318ec997f"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("9474d771-3549-4530-af2a-2b44609994a1"));

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("0045beb5-9555-467b-bd33-dd23ebb24e10"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("16488732-bfd2-402c-a389-74df37c7c051"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("8f8091af-598d-4569-aaa8-0fb7b7d9a95d"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("b039a7f4-0d74-4548-8b3d-f9bdd8531c8a"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null }
                });
        }
    }
}
