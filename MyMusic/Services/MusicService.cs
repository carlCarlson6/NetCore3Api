using Core;
using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class MusicService : IMusicService
    {
        private readonly IUnitOfWork unitOfWork;

        public MusicService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        #region IMusicServiceImplementation
        public async Task<Music> CreateMusic(Music newMusic)
        {
            await this.unitOfWork.Musics.AddAsync(newMusic);
            await this.unitOfWork.CommitAsync();
            return newMusic;
        }

        public async Task DeleteMusic(Music music)
        {
            this.unitOfWork.Musics.Remove(music);
            await this.unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Music>> GetAllWithArtist()
        {
            return await this.unitOfWork.Musics.GetAllWithArtistAsync();
        }

        public async Task<Music> GetMusicById(int id)
        {
            return await this.unitOfWork.Musics.GetWithArtistByIdAsync(id);
        }

        public async Task<IEnumerable<Music>> GetMusicsByArtistId(int artistId)
        {
            return await this.unitOfWork.Musics.GetAllWithArtistByArtistIdAsync(artistId);
        }

        public async Task UpdateMusic(Music musicToBeUpdated, Music music)
        {
            musicToBeUpdated.Name = music.Name;
            musicToBeUpdated.ArtistId = music.ArtistId;

            await this.unitOfWork.CommitAsync();
        }
        #endregion
    }
}
