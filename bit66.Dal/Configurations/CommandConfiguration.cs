using bit66.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bit66.Dal.Configurations;

public class CommandConfiguration: IEntityTypeConfiguration<Command>
{
    public void Configure(EntityTypeBuilder<Command> builder)
    {
        builder.Property(p => p.Name)
            .HasMaxLength(20)
            .IsRequired();
    }
}