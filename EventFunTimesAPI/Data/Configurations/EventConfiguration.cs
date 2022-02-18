using EventFunTimesAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EventFunTimesAPI.Data.Configurations
{
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder
                .HasKey(e => e.Id);

            builder
                .HasMany(e => e.OpeningHours)
                .WithOne(oh => oh.Event)
                .HasForeignKey(oh => oh.Id);
        }
    }
}
