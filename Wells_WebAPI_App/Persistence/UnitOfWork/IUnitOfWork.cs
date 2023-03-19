using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Repository.Interfaces;

namespace Wells_WebAPI.Persistence.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<DrillBlock> DrillBlockRepository { get; }
        IGenericRepository<Hole> HoleRepository { get; }
        IGenericRepository<DrillBlockPoints> DrillBlockPointsRepository { get; }
        IGenericRepository<HolePoints> HolePointsRepository { get; }
        Task SaveAsync();
    }
}
