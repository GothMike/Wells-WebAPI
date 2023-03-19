using Microsoft.AspNetCore.Mvc;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;

namespace Wells_WebAPI.Data.Services.Interfaces
{
    public interface IDrillBlockService : IBaseService<DrillBlock, DrillBlockDto>
    {
        Task AddAsync(DrillBlockDto entitydDto);
    }
}
