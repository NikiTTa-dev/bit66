using bit66.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bit66.Dal.Configurations;

public class SoccerPlayerConfiguration : IEntityTypeConfiguration<SoccerPlayer>
{
    public void Configure(EntityTypeBuilder<SoccerPlayer> builder)
    {
        builder.Property(p => p.FirstName)
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(p => p.LastName)
            .HasMaxLength(30)
            .IsRequired();

        builder.HasOne(p => p.Command)
            .WithMany(p => p.Players)
            .IsRequired();

        builder.HasOne(p => p.Country)
            .WithMany(p => p.Players)
            .IsRequired();

        builder.Property(p => p.Gender)
            .HasMaxLength(10)
            .IsRequired();
        
        builder.Property(p => p.BirthDate)
            .IsRequired();
    }
}