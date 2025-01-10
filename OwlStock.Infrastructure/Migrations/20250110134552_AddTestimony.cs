using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTestimony : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("355fe6fe-738d-48c1-9d71-b266931d851e"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("661598f4-ab6c-47d1-ac61-cea6a88f50bf"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("8157dd5f-40cd-4e6d-bf29-6cc22e0291ea"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("3f0ca70c-5f25-46aa-a314-823a9e8af2e6"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("4f988f68-5545-47a0-b917-d2dc84ef9a1d"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("f400e959-b9ae-40e2-8d0c-ff6beceffb94"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("fb470d32-41c1-4b1d-97e4-28a2da302bcf"));

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("1b218bb5-a294-4dda-a3a6-c1321ce6a3b8"), null, new DateTime(2025, 1, 10, 13, 45, 52, 229, DateTimeKind.Utc).AddTicks(2921), "Фототехника" },
                    { new Guid("7e0247b6-f81a-4723-9895-550c72bb700e"), null, new DateTime(2025, 1, 10, 13, 45, 52, 229, DateTimeKind.Utc).AddTicks(2915), "Технологии" },
                    { new Guid("abe168c0-f1d6-402f-a5fe-eea761b74ea8"), null, new DateTime(2025, 1, 10, 13, 45, 52, 229, DateTimeKind.Utc).AddTicks(2932), "Образователни" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("52ca820f-bf65-4ae5-8f8b-355d1ad125c1"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("6bf5f688-2981-4afb-a1ed-ccf661cd59de"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("9a359cfb-9099-4435-8473-90548d82ed3d"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("cc3d3548-c3a0-4f95-9cda-0cb6da7a1176"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("1b218bb5-a294-4dda-a3a6-c1321ce6a3b8"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("7e0247b6-f81a-4723-9895-550c72bb700e"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("abe168c0-f1d6-402f-a5fe-eea761b74ea8"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("52ca820f-bf65-4ae5-8f8b-355d1ad125c1"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("6bf5f688-2981-4afb-a1ed-ccf661cd59de"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("9a359cfb-9099-4435-8473-90548d82ed3d"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("cc3d3548-c3a0-4f95-9cda-0cb6da7a1176"));

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("355fe6fe-738d-48c1-9d71-b266931d851e"), null, new DateTime(2024, 12, 28, 15, 42, 14, 659, DateTimeKind.Utc).AddTicks(9801), "Фототехника" },
                    { new Guid("661598f4-ab6c-47d1-ac61-cea6a88f50bf"), null, new DateTime(2024, 12, 28, 15, 42, 14, 659, DateTimeKind.Utc).AddTicks(9812), "Образователни" },
                    { new Guid("8157dd5f-40cd-4e6d-bf29-6cc22e0291ea"), null, new DateTime(2024, 12, 28, 15, 42, 14, 659, DateTimeKind.Utc).AddTicks(9794), "Технологии" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("3f0ca70c-5f25-46aa-a314-823a9e8af2e6"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("4f988f68-5545-47a0-b917-d2dc84ef9a1d"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("f400e959-b9ae-40e2-8d0c-ff6beceffb94"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("fb470d32-41c1-4b1d-97e4-28a2da302bcf"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null }
                });
        }
    }
}
