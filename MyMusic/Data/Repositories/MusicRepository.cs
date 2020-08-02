using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class MusicRepository : Repository<Music>, IMusicRepository
    {
        public MusicRepository(MyMusicDbContext context) : base(context) { }

        private MyMusicDbContext MyMusicDbContext
        {
            get { return this.Context as MyMusicDbContext; }
        }

        #region IMusicRepositoryImplementation
        public async Task<IEnumerable<Music>> GetAllWithArtistAsync()
        {
            return await this.MyMusicDbContext.Musics.Include(music => music.Artist).ToListAsync();
        }
        public async Task<IEnumerable<Music>> GetAllWithArtistByArtistIdAsync(int artistId)
        {
            return await this.MyMusicDbContext.Musics
                .Include(music => music.Artist)
                .Where(music => music.ArtistId == artistId).ToListAsync();
        }
        public async Task<Music> GetWithArtistByIdAsync(int id)
        {
            return await this.MyMusicDbContext.Musics
                .Include(music => music.Artist)
                .SingleOrDefaultAsync(music => music.Id == id);
        }
        #endregion
    }
}
