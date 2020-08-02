using Core;
using Core.Repositories;
using Data.Repositories;
using System.Threading.Tasks;

namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyMusicDbContext context;
        private MusicRepository musicRepository;
        private ArtistRepository artistRepository;

        #region IUnitOfWorkImplementation
        public IMusicRepository Musics
        {
            get { return this.musicRepository = this.musicRepository ?? new MusicRepository(this.context); }
        }
        public IArtistRepository Artist 
        {
            get { return this.artistRepository = this.artistRepository ?? new ArtistRepository(this.context); }
        } 

        public async Task<int> CommitAsync() => await this.context.SaveChangesAsync();
        #endregion

        #region IDisposeImplemetation
        public void Dispose() => this.context.Dispose();
        #endregion
    }
}
