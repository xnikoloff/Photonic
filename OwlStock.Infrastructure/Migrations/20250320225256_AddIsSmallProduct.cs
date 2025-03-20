using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIsSmallProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("49ef13c5-ad48-41e8-843b-4549623d9702"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("dd72d869-ff3b-4ef3-ba70-f317b4233cbc"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("ddf7c206-33e7-46cb-92fa-8870de247689"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("965d6886-7aa6-4e7a-8d8c-9b5d87a50669"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("b7c732e3-c483-4537-8c9b-e0c6e1ce7132"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("eef09539-2a8d-435c-a9d6-d326db074548"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("f8a6152e-d543-4d1e-8fc7-c694068eea99"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("0df38219-4936-4343-9f66-2995de26791a"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("152c5d36-022a-48de-bf95-76626d0855c5"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("743c8592-4b44-48c8-91ad-c211231269f7"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("a3564b78-95f4-44c6-87ba-0e1e376d3a63"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("f0e3727d-a1b7-46eb-b900-71ab6aa1db92"));

            migrationBuilder.AlterColumn<string>(
                name: "PersonLastName",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonFirstName",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSmallProduct",
                table: "PhotoShoots",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("8b636cac-c02a-4b98-90a3-540420565222"), null, new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9422), "Образователни" },
                    { new Guid("9dc73201-fb60-404b-a526-ebdc26a827bc"), null, new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9409), "Фототехника" },
                    { new Guid("d6541066-46a5-4093-87d4-954726bc498b"), null, new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9405), "Технологии" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("1d2e725d-d524-40df-a28e-f0e1f894a604"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("9982b491-90e8-4dab-816a-09286f9ea436"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("aa923e9a-fca5-4685-8235-2ff24371a96d"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("c22d7919-b2ef-4347-af31-19d19255f24b"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("076d5a3c-aff6-4f7a-a3b2-ccf6a2285f2d"), new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9966), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9966), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, null },
                    { new Guid("381ff38f-9753-4cba-b60f-aebea1af83ac"), new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9973), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9972), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, null },
                    { new Guid("928e8dd5-891f-4928-b522-a9cf051b0bfb"), new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9960), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9959), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, null },
                    { new Guid("cf4b8737-416b-4d7b-8e75-1eac6cd8d4b2"), new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9976), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9975), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, null },
                    { new Guid("d2d44ca3-d862-4e4b-b3cd-69bb08250fbf"), null, "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9969), new DateTime(2025, 3, 20, 22, 52, 56, 482, DateTimeKind.Utc).AddTicks(9970), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("8b636cac-c02a-4b98-90a3-540420565222"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("9dc73201-fb60-404b-a526-ebdc26a827bc"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("d6541066-46a5-4093-87d4-954726bc498b"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("1d2e725d-d524-40df-a28e-f0e1f894a604"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("9982b491-90e8-4dab-816a-09286f9ea436"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("aa923e9a-fca5-4685-8235-2ff24371a96d"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("c22d7919-b2ef-4347-af31-19d19255f24b"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("076d5a3c-aff6-4f7a-a3b2-ccf6a2285f2d"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("381ff38f-9753-4cba-b60f-aebea1af83ac"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("928e8dd5-891f-4928-b522-a9cf051b0bfb"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("cf4b8737-416b-4d7b-8e75-1eac6cd8d4b2"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("d2d44ca3-d862-4e4b-b3cd-69bb08250fbf"));

            migrationBuilder.DropColumn(
                name: "IsSmallProduct",
                table: "PhotoShoots");

            migrationBuilder.AlterColumn<string>(
                name: "PersonLastName",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PersonFirstName",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Content",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("49ef13c5-ad48-41e8-843b-4549623d9702"), null, new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5563), "Фототехника" },
                    { new Guid("dd72d869-ff3b-4ef3-ba70-f317b4233cbc"), null, new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5564), "Образователни" },
                    { new Guid("ddf7c206-33e7-46cb-92fa-8870de247689"), null, new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5558), "Технологии" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("965d6886-7aa6-4e7a-8d8c-9b5d87a50669"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("b7c732e3-c483-4537-8c9b-e0c6e1ce7132"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("eef09539-2a8d-435c-a9d6-d326db074548"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("f8a6152e-d543-4d1e-8fc7-c694068eea99"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("0df38219-4936-4343-9f66-2995de26791a"), new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5940), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5940), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, null },
                    { new Guid("152c5d36-022a-48de-bf95-76626d0855c5"), null, "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5933), new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5934), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, null },
                    { new Guid("743c8592-4b44-48c8-91ad-c211231269f7"), new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5918), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5918), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, null },
                    { new Guid("a3564b78-95f4-44c6-87ba-0e1e376d3a63"), new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5937), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5936), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, null },
                    { new Guid("f0e3727d-a1b7-46eb-b900-71ab6aa1db92"), new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5931), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 2, 1, 8, 16, 5, 36, DateTimeKind.Utc).AddTicks(5930), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, null }
                });
        }
    }
}
