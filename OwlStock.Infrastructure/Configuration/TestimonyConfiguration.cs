using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwlStock.Domain.Entities;

namespace OwlStock.Infrastructure.Configuration
{
    internal class TestimonyConfiguration : ConfigurationBase<Testimony>
    {
        public override void Configure(EntityTypeBuilder<Testimony> builder)
        {
            builder.HasData(
                new Testimony
                {
                    Id = Guid.NewGuid(),
                    PersonFirstName = "Павел",
                    PersonLastName = "Здравков",
                    Stars = 5,
                    Content = "Изключителен професионализъм и невероятни резултати! Снимките, които получихме, надминаха всичките ни очаквания. Фотографът беше много търпелив и внимателен към всеки детайл, което направи целия процес изключително приятен. Благодарим за прекрасните спомени, които ще останат завинаги с нас! Горещо препоръчвам на всеки, който търси качествена фотография!",
                    IsApproved = true,
                    IsHidden = false,
                    CreatedOn = DateTime.UtcNow,
                    ApprovedOn = DateTime.UtcNow,
                    IdentityUserId = "2374faef-58dc-44fd-a6bd-e6773c61eb7d"
                },

                new Testimony
                {
                    Id = Guid.NewGuid(),
                    PersonFirstName = "Катя",
                    PersonLastName = "Виденова",
                    Stars = 1,
                    Content = "За съжаление, услугата не отговори на очакванията ни. Комуникацията беше трудна, а снимките не изглеждаха професионално обработени. Не бих препоръчал на приятели.",
                    IsApproved = true,
                    IsHidden = false,
                    CreatedOn = DateTime.UtcNow,
                    ApprovedOn = DateTime.UtcNow,
                    IdentityUserId = "2374faef-58dc-44fd-a6bd-e6773c61eb7d"
                },

                new Testimony
                {
                    Id = Guid.NewGuid(),
                    PersonFirstName = "Миро Ганчев",
                    PersonLastName = "Виденова",
                    Stars = 3,
                    Content = "Цената беше приемлива, но очаквахме малко повече внимание към детайлите. Ако търсите нещо средно като качество, това може да е подходяща опция.",
                    IsApproved = false,
                    IsHidden = true,
                    CreatedOn = DateTime.UtcNow,
                    HiddenOn = DateTime.UtcNow,
                    IdentityUserId = "2374faef-58dc-44fd-a6bd-e6773c61eb7d"
                },

                new Testimony
                {
                    Id = Guid.NewGuid(),
                    PersonFirstName = "Силвена",
                    PersonLastName = "Сивкова",
                    Stars = 5,
                    Content = "Фотографът надмина всичките ни очаквания! Снимките са зашеметяващи – отлично качество и усет към детайла. Процесът беше лесен и приятен, а крайният резултат – повече от невероятен. Препоръчвам услугата на всеки, който иска да запази специалните си моменти по най-добрия начин!",
                    IsApproved = true,
                    IsHidden = false,
                    CreatedOn = DateTime.UtcNow,
                    ApprovedOn = DateTime.UtcNow,
                    IdentityUserId = "2374faef-58dc-44fd-a6bd-e6773c61eb7d"
                },
                
                new Testimony
                {
                    Id = Guid.NewGuid(),
                    PersonFirstName = "Валери",
                    PersonLastName = "Грънчарски",
                    Stars = 4,
                    Content = "Много сме доволни от услугата! Снимките са с високо качество и фотографът успя да улови красиви моменти. Единствено бихме искали малко по-бърза обработка на снимките. Като цяло, чудесно изживяване и бихме използвали услугата отново!",
                    IsApproved = true,
                    IsHidden = false,
                    CreatedOn = DateTime.UtcNow,
                    ApprovedOn = DateTime.UtcNow,
                    IdentityUserId = "2374faef-58dc-44fd-a6bd-e6773c61eb7d"
                }
            );
        }
    }
}
