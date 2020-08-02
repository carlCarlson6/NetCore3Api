using Core;
using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class ArtistService : IArtistService
    {
        private readonly IUnitOfWork unitOfWork;

        public ArtistService(IUnitOfWork unitOfWork) => this.unitOfWork = unitOfWork;

        #region IArtistServiceImplementation
        public async Task<Artist> CreateArtist(Artist newArtist)
        {
            await this.unitOfWork.Artist.AddAsync(newArtist);
            await this.unitOfWork.CommitAsync();

            return newArtist;
        }

        public async Task DeleteArtist(Artist artist)
        {
            this.unitOfWork.Artist.Remove(artist);
            await this.unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Artist>> GetAllArtist()
        {
            return await this.unitOfWork.Artist.GetAllAsync();
        }

        public async Task<Artist> GetArtistById(int id)
        {
            return await this.unitOfWork.Artist.GetByIdAsync(id);
        }

        public async Task UpdateArtist(Artist artistToBeUpdated, Artist artist)
        {
            artistToBeUpdated.Name = artist.Name;

            await this.unitOfWork.CommitAsync();
        }
        #endregion
    }
}
