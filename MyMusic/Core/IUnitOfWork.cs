using Core.Repositories;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork
    {
        IMusicRepository Musics { get; set; }
        IArtistRepository Artist { get; set; }
        Task<int> CommitAsync();
    }
}
