using Core.Repositories;
using System;
using System.Threading.Tasks;

namespace Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artist { get; }
        Task<int> CommitAsync();
    }
}
