using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OwlStock.Domain.Entities;

namespace OwlStock.Infrastructure.Configuration
{
    public class DynamicContentCateogyConfiguration : ConfigurationBase<DynamicContentCategory>
    {
        public override void Configure(EntityTypeBuilder<DynamicContentCategory> builder)
        {
            builder.HasData(
                new DynamicContentCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Технологии",
                    CreatedOn = DateTime.UtcNow,
                },

                new DynamicContentCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Фототехника",
                    CreatedOn = DateTime.UtcNow,
                },

                new DynamicContentCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Образователни",
                    CreatedOn = DateTime.UtcNow,
                }
            );
        }
    }
}
