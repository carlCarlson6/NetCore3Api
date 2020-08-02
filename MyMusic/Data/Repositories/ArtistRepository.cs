using Core.Models;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(MyMusicDbContext context) : base(context) { }

        private MyMusicDbContext MyMusicDbContext
        {
            get { return this.Context as MyMusicDbContext; }
        }

        #region IMusicRepositoryImplementation
        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await this.MyMusicDbContext.Artists
                .Include(artist => artist.Musics)
                .ToListAsync();
        }
        public async Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return await this.MyMusicDbContext.Artists
                .Include(artist => artist.Musics)
                .SingleOrDefaultAsync(artist => artist.Id == id);
        }
        #endregion
    }
}
