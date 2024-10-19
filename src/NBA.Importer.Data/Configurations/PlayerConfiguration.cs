using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NBA.Importer.Data.Entities;

namespace NBA.Importer.Data.Configurations;

internal sealed class PlayerConfiguration : IEntityTypeConfiguration<Player>
{
    public void Configure(EntityTypeBuilder<Player> builder)
    {
        ArgumentNullException.ThrowIfNull(builder);

        builder.HasKey(player => player.Id);

        builder.Property(player => player.Id)
            .UseIdentityColumn();
    }
}
