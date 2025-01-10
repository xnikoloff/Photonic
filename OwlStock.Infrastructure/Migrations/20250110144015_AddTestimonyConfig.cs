using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddTestimonyConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("04be46d9-7364-4da0-a525-8e7463a7af72"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("8d1c2647-f1de-4af2-9de5-266a9cd771df"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("e12d0f83-c847-4f52-b5a3-022dac5a4e30"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("06cef800-5edf-4b0c-8a12-bb1fa8b52d98"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("07405399-2869-4821-8064-37c87d6031f2"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("b265307a-c458-4640-a1fc-1650f1afc5f4"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("bcdcf0d0-34b1-4840-8a1d-0fcb5aa78c60"));

            migrationBuilder.AddColumn<string>(
                name: "PersonFirstName",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonLastName",
                table: "Testimonies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("3b1ad5e0-cb34-4613-bd6d-3f9fda9b7b9b"), null, new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1359), "Образователни" },
                    { new Guid("5c9af887-bde7-4d92-867b-59f07c9bec68"), null, new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1357), "Фототехника" },
                    { new Guid("78dc502c-340a-4259-a828-3b13df42fae4"), null, new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1353), "Технологии" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("03f89d3f-3339-4922-b5f8-2501d0021ad6"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("1a25b09a-9076-45ba-90ba-844491f69bd0"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("9b01e0a8-c286-45ab-b91e-3276e29c8523"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("e7b19773-d3db-48cb-9ad7-d2c2d49153ba"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("0edf4da5-2afe-4398-ab45-63eeb0faf2d0"), new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1881), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1880), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("20608343-31bd-407b-91b7-3f9fce155e44"), new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1890), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1890), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("3ce27a08-0298-4eee-b2dc-9c84884288e7"), new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1895), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1895), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("79d8f11d-c860-4e26-867d-cf5c77544174"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1892), new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1893), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("e2e08eb9-568d-4c95-b178-fff46e5ea45e"), new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1899), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 1, 10, 14, 40, 15, 437, DateTimeKind.Utc).AddTicks(1898), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("3b1ad5e0-cb34-4613-bd6d-3f9fda9b7b9b"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("5c9af887-bde7-4d92-867b-59f07c9bec68"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("78dc502c-340a-4259-a828-3b13df42fae4"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("03f89d3f-3339-4922-b5f8-2501d0021ad6"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("1a25b09a-9076-45ba-90ba-844491f69bd0"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("9b01e0a8-c286-45ab-b91e-3276e29c8523"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("e7b19773-d3db-48cb-9ad7-d2c2d49153ba"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("0edf4da5-2afe-4398-ab45-63eeb0faf2d0"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("20608343-31bd-407b-91b7-3f9fce155e44"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("3ce27a08-0298-4eee-b2dc-9c84884288e7"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("79d8f11d-c860-4e26-867d-cf5c77544174"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("e2e08eb9-568d-4c95-b178-fff46e5ea45e"));

            migrationBuilder.DropColumn(
                name: "PersonFirstName",
                table: "Testimonies");

            migrationBuilder.DropColumn(
                name: "PersonLastName",
                table: "Testimonies");

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("04be46d9-7364-4da0-a525-8e7463a7af72"), null, new DateTime(2025, 1, 10, 14, 8, 26, 286, DateTimeKind.Utc).AddTicks(6846), "Фототехника" },
                    { new Guid("8d1c2647-f1de-4af2-9de5-266a9cd771df"), null, new DateTime(2025, 1, 10, 14, 8, 26, 286, DateTimeKind.Utc).AddTicks(6841), "Технологии" },
                    { new Guid("e12d0f83-c847-4f52-b5a3-022dac5a4e30"), null, new DateTime(2025, 1, 10, 14, 8, 26, 286, DateTimeKind.Utc).AddTicks(6848), "Образователни" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("06cef800-5edf-4b0c-8a12-bb1fa8b52d98"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("07405399-2869-4821-8064-37c87d6031f2"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("b265307a-c458-4640-a1fc-1650f1afc5f4"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("bcdcf0d0-34b1-4840-8a1d-0fcb5aa78c60"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null }
                });
        }
    }
}
