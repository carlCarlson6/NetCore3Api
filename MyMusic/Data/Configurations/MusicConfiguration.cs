using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Configurations
{
    public class MusicConfiguration : IEntityTypeConfiguration<Music>
    {
        public void Configure(EntityTypeBuilder<Music> builder)
        {
            builder.HasKey(music => music.Id);
            builder.Property(music => music.Id).UseIdentityColumn();
            
            builder.Property(music => music.Name).IsRequired().HasMaxLength(50);

            builder.HasOne(music => music.Artist).WithMany(artist => artist.Musics).HasForeignKey(music => music.ArtistId);

            builder.ToTable("Musics");
        }
    }
}