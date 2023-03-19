using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;

namespace Wells_WebAPI.Data.Services.Interfaces
{
    public interface IDrillBlockPointsService : IBaseService<DrillBlockPoints, DrillBlockPointsDto>
    {
        Task AddAsync(DrillBlockPointsDto entitydDto, DrillBlock drillBlock);
        Task<DrillBlock> GetDrillBlock(int drillBlockId);

    }
}
