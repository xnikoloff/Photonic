using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OwlStock.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAnnouncementEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("a0cf2d82-c4b7-460e-911d-43549cc3971e"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("ba7162db-f546-4a3c-9fdf-04e4251441c2"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("fd063a2f-c1c2-4bcd-8cba-2ef13e5656d0"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("01c162c7-3ecf-4a75-9d84-3f08437690f9"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("7ad43783-7e80-4065-992c-a69a795ab9ea"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("f7a9f666-131c-4488-81e1-1612d1f4fa66"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("fef338e0-44d4-42e1-8b2e-9c305021579d"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("2bd0f9c2-d525-461f-94e9-2375023bc39a"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("2de29827-29f1-4f2a-b5a3-45ab94d4a3b1"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("406bbaa3-7732-4030-b82b-4fa2e8bb77e0"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("463f8c62-0927-4496-8dce-dee82cf07dcf"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("b9fe698a-8081-4070-8c78-e82a4631e306"));

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("17373c65-20f7-4f86-8aa6-16b62531c064"), null, new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(1649), "Образователни" },
                    { new Guid("b05cf253-06c9-4620-8ae9-7aeaf8657b21"), null, new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(1632), "Технологии" },
                    { new Guid("ec522857-5fe7-4f39-9f7d-2eeb8fd49eaa"), null, new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(1637), "Фототехника" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("61f87f9c-eb57-44b8-b9b4-047cb2f8acfe"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("8fb84be5-421b-43ce-9b85-024f0d976a78"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("b5cc1ce7-02cf-45c4-8b09-9b0a1ab76421"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null },
                    { new Guid("d7c88ce1-fa08-434f-8211-575d6912614d"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("051bdfd5-26ae-442a-af4f-02cf8f65b1c3"), null, "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2050), new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2050), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, null },
                    { new Guid("4f3d1d58-6c95-4c8f-aa53-d1dd3857b99e"), new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2047), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2047), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, null },
                    { new Guid("c8bb265e-90ec-4a20-8830-a6c1eb0a6242"), new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2039), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2038), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, null },
                    { new Guid("e7fcf46a-eb6c-4d37-93c0-a6185fe8389d"), new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2053), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2053), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, null },
                    { new Guid("f628816c-a794-42fc-9c70-8cc4f0d6ee84"), new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2056), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 2, 1, 8, 14, 12, 147, DateTimeKind.Utc).AddTicks(2056), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("17373c65-20f7-4f86-8aa6-16b62531c064"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("b05cf253-06c9-4620-8ae9-7aeaf8657b21"));

            migrationBuilder.DeleteData(
                table: "DynamicContentCategories",
                keyColumn: "Id",
                keyValue: new Guid("ec522857-5fe7-4f39-9f7d-2eeb8fd49eaa"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("61f87f9c-eb57-44b8-b9b4-047cb2f8acfe"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("8fb84be5-421b-43ce-9b85-024f0d976a78"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("b5cc1ce7-02cf-45c4-8b09-9b0a1ab76421"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: new Guid("d7c88ce1-fa08-434f-8211-575d6912614d"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("051bdfd5-26ae-442a-af4f-02cf8f65b1c3"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("4f3d1d58-6c95-4c8f-aa53-d1dd3857b99e"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("c8bb265e-90ec-4a20-8830-a6c1eb0a6242"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("e7fcf46a-eb6c-4d37-93c0-a6185fe8389d"));

            migrationBuilder.DeleteData(
                table: "Testimonies",
                keyColumn: "Id",
                keyValue: new Guid("f628816c-a794-42fc-9c70-8cc4f0d6ee84"));

            migrationBuilder.InsertData(
                table: "DynamicContentCategories",
                columns: new[] { "Id", "CreatedById", "CreatedOn", "Name" },
                values: new object[,]
                {
                    { new Guid("a0cf2d82-c4b7-460e-911d-43549cc3971e"), null, new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1325), "Технологии" },
                    { new Guid("ba7162db-f546-4a3c-9fdf-04e4251441c2"), null, new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1329), "Фототехника" },
                    { new Guid("fd063a2f-c1c2-4bcd-8cba-2ef13e5656d0"), null, new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1331), "Образователни" }
                });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "CityId", "CreatedById", "CreatedOn", "Description", "EditedById", "EditedOn", "GoogleMapsURL", "ImagePath", "IsPopular", "Name", "PhotoBaseId" },
                values: new object[,]
                {
                    { new Guid("01c162c7-3ecf-4a75-9d84-3f08437690f9"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Асеновата крепост в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%90%D1%81%D0%B5%D0%BD%D0%BE%D0%B2%D0%B0+%D0%BA%D1%80%D0%B5%D0%BF%D0%BE%D1%81%D1%82/@41.9863671,24.8703,17z/data=!3m1!4b1!4m6!3m5!1s0x14acdf34198aa463:0xd61aeb51093571e1!8m2!3d41.9863671!4d24.8728749!16zL20vMGNfcXo3?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Асеновата крепост", null },
                    { new Guid("7ad43783-7e80-4065-992c-a69a795ab9ea"), 11545, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Царският Дворец в село Куртово Конаре", null, null, "https://www.google.bg/maps/place/%D0%A6%D0%B0%D1%80%D1%81%D0%BA%D0%B8+%D0%B4%D0%B2%D0%BE%D1%80%D0%B5%D1%86+%D0%9A%D1%80%D0%B8%D1%87%D0%B8%D0%BC/@42.0992886,24.5157877,17z/data=!3m1!4b1!4m6!3m5!1s0x14acc7810a3d0e1d:0x4f0a59b440e765c0!8m2!3d42.0992886!4d24.5183626!16s%2Fg%2F11gcxykv2k?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Дворец Кричим", null },
                    { new Guid("f7a9f666-131c-4488-81e1-1612d1f4fa66"), 12590, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Старият град на Пловдив", null, null, "https://www.google.bg/maps/place/%D0%A1%D1%82%D0%B0%D1%80%D0%B8%D1%8F+%D0%B3%D1%80%D0%B0%D0%B4%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2+%D0%A6%D0%B5%D0%BD%D1%82%D1%8A%D1%80,+4000+%D0%9F%D0%BB%D0%BE%D0%B2%D0%B4%D0%B8%D0%B2/@42.1490439,24.7463858,16z/data=!3m1!4b1!4m6!3m5!1s0x14acd1a2e85b2bf7:0xe7d9efa93577ca7e!8m2!3d42.1488072!4d24.7521373!16s%2Fg%2F11ys_h_xy?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Старият град на Пловдив", null },
                    { new Guid("fef338e0-44d4-42e1-8b2e-9c305021579d"), 8443, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Местност Метоха в Асеновград", null, null, "https://www.google.bg/maps/place/%D0%9C%D0%B5%D1%82%D0%BE%D1%85%D0%B0/@42.0009383,24.8695654,17z/data=!3m1!4b1!4m6!3m5!1s0x14acd8cf73ab2aaf:0xbcb985c2cfe76039!8m2!3d42.0009383!4d24.8721403!16s%2Fg%2F11g7nrn5qb?entry=ttu&g_ep=EgoyMDI0MDgyOC4wIKXMDSoASAFQAw%3D%3D", null, true, "Метоха", null }
                });

            migrationBuilder.InsertData(
                table: "Testimonies",
                columns: new[] { "Id", "ApprovedOn", "Content", "CreatedOn", "HiddenOn", "IdentityUserId", "IsApproved", "IsHidden", "PersonFirstName", "PersonLastName", "Stars", "UnhiddenOn" },
                values: new object[,]
                {
                    { new Guid("2bd0f9c2-d525-461f-94e9-2375023bc39a"), new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1768), "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!", new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1766), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Павел", "Здравков", 5, null },
                    { new Guid("2de29827-29f1-4f2a-b5a3-45ab94d4a3b1"), new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1787), "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!", new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1787), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Валери", "Грънчарски", 4, null },
                    { new Guid("406bbaa3-7732-4030-b82b-4fa2e8bb77e0"), null, "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.", new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1776), new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1777), "2374faef-58dc-44fd-a6bd-e6773c61eb7d", false, true, "Миро Ганчев", "Виденова", 3, null },
                    { new Guid("463f8c62-0927-4496-8dce-dee82cf07dcf"), new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1774), "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.", new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1773), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Катя", "Виденова", 1, null },
                    { new Guid("b9fe698a-8081-4070-8c78-e82a4631e306"), new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1779), "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!", new DateTime(2025, 1, 10, 14, 42, 25, 471, DateTimeKind.Utc).AddTicks(1779), null, "2374faef-58dc-44fd-a6bd-e6773c61eb7d", true, false, "Силвена", "Сивкова", 5, null }
                });
        }
    }
}
