using AutoMapper;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;
using Wells_WebAPI.Persistence.UnitOfWork;

namespace Wells_WebAPI.Data.Services
{
    public class HolePointsService : IHolePointsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HolePointsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(HolePointsDto entitydDto, Hole hole)
        {
            var mappingEntity = MappingEntity(entitydDto);
            mappingEntity.Hole = hole;
            _unitOfWork.HolePointsRepository.AddAsync(mappingEntity);
            _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(HolePoints entity)
        {
            _unitOfWork.HolePointsRepository.Delete(entity);
        await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<HolePointsDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.HolePointsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HolePointsDto>>(entities);
        }

        public async Task<HolePoints> GetEntityByIdAsync(int id)
        {
            return await _unitOfWork.HolePointsRepository.GetByIdAsync(id);
        }

        public async Task<Hole> GetHole(int holeId)
        {
            return await _unitOfWork.HoleRepository.GetByIdAsync(holeId);
        }

        public async Task<HolePointsDto> GetMapEntityByIdAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            return _mapper.Map<HolePointsDto>(entity);
        }

        public HolePoints MappingEntity(HolePointsDto entityDto)
        {
            return _mapper.Map<HolePoints>(entityDto);
        }

        public async Task UpdateAsync(HolePointsDto entityDto, HolePoints entity)
        {
            entity.X = entityDto.X;
            entity.Y = entityDto.Y;
            entity.Z = entityDto.Z;

            _unitOfWork.HolePointsRepository.Update(entity);
           await _unitOfWork.SaveAsync();
        }
    }
}
