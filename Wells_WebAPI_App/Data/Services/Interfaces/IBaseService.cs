using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Models;

namespace Wells_WebAPI.Data.Services.Interfaces
{
    public interface IBaseService<TEntity, TMapEntity>
    {
        Task<IEnumerable<TMapEntity>> GetAllAsync();
        Task<TMapEntity> GetMapEntityByIdAsync(int id);
        Task<TEntity> GetEntityByIdAsync(int id);
        Task UpdateAsync(TMapEntity entityDto, TEntity entity);
        Task DeleteAsync(TEntity entity);
        TEntity MappingEntity(TMapEntity entityDto);
    }
}
