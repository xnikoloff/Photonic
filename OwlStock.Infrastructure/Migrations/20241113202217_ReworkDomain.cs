using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ReworkDomain : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("00df8866-d3d4-42be-844e-7a069208dd43"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("53588c7a-11a1-46fb-b569-3f604392b885"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("d68f71b8-8d48-4605-a0cd-4c337960a81e"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("fff29379-08f2-4f74-89b4-264968e9bd9d"));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Tags",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Tags",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Places",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Places",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EditedById",
                table: "Places",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EditedOn",
                table: "Places",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PhotosCategories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PhotosCategories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PhotosBase",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PhotosBase",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "Gear",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Gear",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("355ec71b-68ce-4951-9d76-096e7af2b51f"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("497f7521-2dde-493a-9be2-f7a8c4b6b4b4"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("7204383e-7614-4c34-83d8-c40e6eea53c6"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("e6bf43d9-ec2d-4066-809b-7465e5b9c45e"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_CreatedById",
                table: "Tags",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Places_CreatedById",
                table: "Places",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Places_EditedById",
                table: "Places",
                column: "EditedById");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosCategories_CreatedById",
                table: "PhotosCategories",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_PhotosBase_CreatedById",
                table: "PhotosBase",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_Gear_CreatedById",
                table: "Gear",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Gear_AspNetUsers_CreatedById",
                table: "Gear",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosBase_AspNetUsers_CreatedById",
                table: "PhotosBase",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PhotosCategories_AspNetUsers_CreatedById",
                table: "PhotosCategories",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_AspNetUsers_CreatedById",
                table: "Places",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Places_AspNetUsers_EditedById",
                table: "Places",
                column: "EditedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_AspNetUsers_CreatedById",
                table: "Tags",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Gear_AspNetUsers_CreatedById",
                table: "Gear");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosBase_AspNetUsers_CreatedById",
                table: "PhotosBase");

            migrationBuilder.DropForeignKey(
                name: "FK_PhotosCategories_AspNetUsers_CreatedById",
                table: "PhotosCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_AspNetUsers_CreatedById",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Places_AspNetUsers_EditedById",
                table: "Places");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_AspNetUsers_CreatedById",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_CreatedById",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Places_CreatedById",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_Places_EditedById",
                table: "Places");

            migrationBuilder.DropIndex(
                name: "IX_PhotosCategories_CreatedById",
                table: "PhotosCategories");

            migrationBuilder.DropIndex(
                name: "IX_PhotosBase_CreatedById",
                table: "PhotosBase");

            migrationBuilder.DropIndex(
                name: "IX_Gear_CreatedById",
                table: "Gear");

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("355ec71b-68ce-4951-9d76-096e7af2b51f"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("497f7521-2dde-493a-9be2-f7a8c4b6b4b4"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("7204383e-7614-4c34-83d8-c40e6eea53c6"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("e6bf43d9-ec2d-4066-809b-7465e5b9c45e"));

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "EditedById",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "EditedOn",
                table: "Places");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PhotosCategories");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PhotosCategories");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PhotosBase");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PhotosBase");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Gear");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Gear");

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "Description", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("00df8866-d3d4-42be-844e-7a069208dd43"), 11545, "Царският Дворец в село Куртово Конаре", "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("53588c7a-11a1-46fb-b569-3f604392b885"), 8443, "Местност Метоха в Асеновград", "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("d68f71b8-8d48-4605-a0cd-4c337960a81e"), 8443, "Асеновата крепост в Асеновград", "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("fff29379-08f2-4f74-89b4-264968e9bd9d"), 12590, "Старият град на Пловдив", "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null }
                });
        }
    }
}
