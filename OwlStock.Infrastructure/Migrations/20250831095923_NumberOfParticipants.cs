using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class NumberOfParticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("0fece7d9-08e3-4a65-bf85-fed85ce8dbce"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("3faeb494-6a23-4463-ba33-37e8f38489d5"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("8a75cd27-d931-46d9-a6f9-b75dc2633702"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("25e80bfa-b13f-4f31-9ffc-b7a0dd60f4b4"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("5b866177-7dbb-4d1e-b8ad-a7bc6a328006"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("bc9bb87e-bb3f-4b30-934f-7f5d995d8ca4"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("cd2bf986-92ae-4f58-9a24-dccf22fb7dcd"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("00cd2973-1e8d-40f4-a821-ffae5ff9499d"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("172810c7-f860-4623-bff1-15213530ae31"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("1cda485c-5f48-44ae-9d2b-d090fc25b6a8"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("2d4423fd-65c7-4ab9-b9b4-44d73602f087"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("641fb081-2429-4d8d-92c5-0b5048a25a99"));

            migrationBuilder.AddColumn<int>(
                name: "NumberOfParticipants",
                table: "PhotoShoots",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("07b4ca60-25b6-4498-bc65-570d0658b7aa"), null, new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5430), "Технологии" },
                    { new Guid("3dfb4bef-ea85-42f2-9064-2364d349ffa1"), null, new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5435), "Фототехника" },
                    { new Guid("d4b24ff1-563c-4c97-99f9-c43a2598f0fe"), null, new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5436), "Образователни" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("036abf2d-d907-4c36-9924-b7a9b201be05"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("11f17467-748c-4c48-9d32-fa36c2f49b95"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("1cd0d546-3f4a-4ef2-b425-88d53291048a"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("2442bc71-2f61-44b5-a470-8a6fd30e7f4b"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("04ef6cfa-3176-440e-aef9-413ebfce99f3"), null, "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5872), new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5873), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, null },
                    { new Guid("8a13f8d4-e63a-4cb4-b0e2-8ce9bf0cd62e"), new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5863), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5862), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, null },
                    { new Guid("8f990519-e450-475f-b995-5d0fe0ad7c9e"), new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5876), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5875), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, null },
                    { new Guid("ecf391b7-49ad-4e63-a7f7-1242d8ef8938"), new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5878), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5878), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, null },
                    { new Guid("f714954e-58ee-4ccd-8460-533a0f330288"), new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5870), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 8, 31, 9, 59, 23, 56, DateTimeKind.Utc).AddTicks(5869), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("07b4ca60-25b6-4498-bc65-570d0658b7aa"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("3dfb4bef-ea85-42f2-9064-2364d349ffa1"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("d4b24ff1-563c-4c97-99f9-c43a2598f0fe"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("036abf2d-d907-4c36-9924-b7a9b201be05"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("11f17467-748c-4c48-9d32-fa36c2f49b95"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("1cd0d546-3f4a-4ef2-b425-88d53291048a"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("2442bc71-2f61-44b5-a470-8a6fd30e7f4b"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("04ef6cfa-3176-440e-aef9-413ebfce99f3"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("8a13f8d4-e63a-4cb4-b0e2-8ce9bf0cd62e"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("8f990519-e450-475f-b995-5d0fe0ad7c9e"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("ecf391b7-49ad-4e63-a7f7-1242d8ef8938"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("f714954e-58ee-4ccd-8460-533a0f330288"));

            migrationBuilder.DropColumn(
                name: "NumberOfParticipants",
                table: "PhotoShoots");

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("0fece7d9-08e3-4a65-bf85-fed85ce8dbce"), null, new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2059), "Образователни" },
                    { new Guid("3faeb494-6a23-4463-ba33-37e8f38489d5"), null, new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2042), "Технологии" },
                    { new Guid("8a75cd27-d931-46d9-a6f9-b75dc2633702"), null, new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2048), "Фототехника" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("25e80bfa-b13f-4f31-9ffc-b7a0dd60f4b4"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("5b866177-7dbb-4d1e-b8ad-a7bc6a328006"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("bc9bb87e-bb3f-4b30-934f-7f5d995d8ca4"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("cd2bf986-92ae-4f58-9a24-dccf22fb7dcd"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("00cd2973-1e8d-40f4-a821-ffae5ff9499d"), null, "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2580), new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2581), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, null },
                    { new Guid("172810c7-f860-4623-bff1-15213530ae31"), new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2584), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2583), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, null },
                    { new Guid("1cda485c-5f48-44ae-9d2b-d090fc25b6a8"), new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2571), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2570), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, null },
                    { new Guid("2d4423fd-65c7-4ab9-b9b4-44d73602f087"), new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2587), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2586), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, null },
                    { new Guid("641fb081-2429-4d8d-92c5-0b5048a25a99"), new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2578), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 8, 2, 6, 33, 12, 393, DateTimeKind.Utc).AddTicks(2578), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, null }
                });
        }
    }
}
