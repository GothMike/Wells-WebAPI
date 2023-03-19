using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;

namespace Wells_WebAPI.Data.Services.Interfaces
{
    public interface IHolePointsService : IBaseService<HolePoints, HolePointsDto>
    {
        Task AddAsync(HolePointsDto entitydDto, Hole hole);
        Task<Hole> GetHole(int holeId);
    }
}
