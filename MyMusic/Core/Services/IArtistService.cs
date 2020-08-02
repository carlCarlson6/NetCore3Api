using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IArtistService
    {
        Task<IEnumerable<Artist>> GetAllArtist();
        Task<Artist> GetArtistById(int id);
        Task<Artist> CreateArtist(Artist newArtist);
        Task UpdateArtist(Artist artistToBeUpdated, Artist artist);
        Task DeleteArtist(Artist artist);
    }
}
