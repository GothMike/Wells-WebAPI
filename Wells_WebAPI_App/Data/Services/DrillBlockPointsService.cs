using AutoMapper;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;
using Wells_WebAPI.Persistence.UnitOfWork;

namespace Wells_WebAPI.Data.Services
{
    public class DrillBlockPointsService : IDrillBlockPointsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DrillBlockPointsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(DrillBlockPointsDto entitydDto, DrillBlock drillBlock)
        {
            var mappingEntity = MappingEntity(entitydDto);
            mappingEntity.DrillBlock = drillBlock;
           await _unitOfWork.DrillBlockPointsRepository.AddAsync(mappingEntity);
           await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(DrillBlockPoints entity)
        {
            _unitOfWork.DrillBlockPointsRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DrillBlockPointsDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.DrillBlockPointsRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<DrillBlockPointsDto>>(entities);
        }

        public async Task<DrillBlock> GetDrillBlock(int drillBlockId)
        {
            return await _unitOfWork.DrillBlockRepository.GetByIdAsync(drillBlockId);
        }

        public async Task<DrillBlockPoints> GetEntityByIdAsync(int id)
        {
            return await _unitOfWork.DrillBlockPointsRepository.GetByIdAsync(id);
        }

        public async Task<DrillBlockPointsDto> GetMapEntityByIdAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            return _mapper.Map<DrillBlockPointsDto>(entity);
        }

        public DrillBlockPoints MappingEntity(DrillBlockPointsDto entityDto)
        {
            return _mapper.Map<DrillBlockPoints>(entityDto);
        }

        public async Task UpdateAsync(DrillBlockPointsDto entityDto, DrillBlockPoints entity)
        {
            entity.Sequence = entityDto.Sequence;
            entity.X = entityDto.X;
            entity.Y = entityDto.Y;
            entity.Z = entityDto.Z;

            _unitOfWork.DrillBlockPointsRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }
    }
}
