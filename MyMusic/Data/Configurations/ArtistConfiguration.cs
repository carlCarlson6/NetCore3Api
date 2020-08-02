using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.HasKey(artist => artist.Id);
            builder.Property(artist => artist.Id).UseIdentityColumn();

            builder.Property(artist => artist.Name).IsRequired().HasMaxLength(50);

            builder.ToTable("Musics");
        }
    }
}