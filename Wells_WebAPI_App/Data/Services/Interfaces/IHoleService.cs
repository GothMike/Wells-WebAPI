using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;

namespace Wells_WebAPI.Data.Services.Interfaces
{
    public interface IHoleService : IBaseService<Hole,HoleDto>
    {
        Task AddAsync(HoleDto entitydDto, DrillBlock drillBlock);
        Task<DrillBlock> GetDrillBlock(int drillBlockId);
    }
}
