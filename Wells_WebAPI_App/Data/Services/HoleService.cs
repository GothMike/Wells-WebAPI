using AutoMapper;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;
using Wells_WebAPI.Persistence.UnitOfWork;

namespace Wells_WebAPI.Data.Services
{
    public class HoleService : IHoleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public HoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(HoleDto entitydDto, DrillBlock drillBlock)
        {
            var mappingEntity = MappingEntity(entitydDto);
            mappingEntity.DrillBlock = drillBlock;
            _unitOfWork.HoleRepository.AddAsync(mappingEntity);
            _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Hole entity)
        {
            _unitOfWork.HoleRepository.Delete(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<HoleDto>> GetAllAsync()
        {
            var entities = await _unitOfWork.HoleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<HoleDto>>(entities);
        }

        public async Task<DrillBlock> GetDrillBlock(int drillBlockId)
        {
            return await _unitOfWork.DrillBlockRepository.GetByIdAsync(drillBlockId);
        }

        public async Task<Hole> GetEntityByIdAsync(int id)
        {
            return await _unitOfWork.HoleRepository.GetByIdAsync(id);
        }

        public async Task<HoleDto> GetMapEntityByIdAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            return _mapper.Map<HoleDto>(entity);
        }

        public Hole MappingEntity(HoleDto entityDto)
        {
            return _mapper.Map<Hole>(entityDto);
        }

        public async Task UpdateAsync(HoleDto entityDto, Hole entity)
        {
            entity.Name = entityDto.Name;
            entity.Depth = entityDto.Depth;

                 _unitOfWork.HoleRepository.Update(entity);
           await _unitOfWork.SaveAsync();
        }
    }
}
