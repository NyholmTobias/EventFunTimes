using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projektarbete.Models;

namespace Projektarbete.Data.Configurations
{
    public class OpeningHoursConfiguration : IEntityTypeConfiguration<OpeningHours>
    {
        public void Configure(EntityTypeBuilder<OpeningHours> builder)
        {
            builder
                .HasKey(oh => oh.Id);

            builder
                .HasOne(oh => oh.Event)
                .WithMany(e => e.OpeningHours)
                .HasForeignKey(e => e.Id);
        }
    }
}
