using AutoMapper;
using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Models.Dto;
using Wells_WebAPI.Data.Services.Interfaces;
using Wells_WebAPI.Persistence.UnitOfWork;

namespace Wells_WebAPI.Data.Services
{
    public class DrillBlockService: IDrillBlockService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DrillBlockService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddAsync(DrillBlockDto entitydDto)
        {
            var mappingEntity = MappingEntity(entitydDto);
            await  _unitOfWork.DrillBlockRepository.AddAsync(mappingEntity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(DrillBlock entity)
        {
            _unitOfWork.DrillBlockRepository.Delete(entity);
           await _unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<DrillBlockDto>> GetAllAsync()
        {
           var entities = await _unitOfWork.DrillBlockRepository.GetAllAsync();
           return _mapper.Map<IEnumerable<DrillBlockDto>>(entities);
        }

        public async Task<DrillBlock> GetEntityByIdAsync(int id)
        {
           return await _unitOfWork.DrillBlockRepository.GetByIdAsync(id);
        }

        public async Task<DrillBlockDto> GetMapEntityByIdAsync(int id)
        {
            var entity = await GetEntityByIdAsync(id);
            return _mapper.Map<DrillBlockDto>(entity);
        }

        public DrillBlock MappingEntity(DrillBlockDto entityDto)
        {
            return _mapper.Map<DrillBlock>(entityDto);
        }

        public async Task UpdateAsync(DrillBlockDto entityDto, DrillBlock entity)
        {

            entity.Name = entityDto.Name;
            entity.UpdateTime = entityDto.UpdateTime;

            _unitOfWork.DrillBlockRepository.Update(entity);
           await _unitOfWork.SaveAsync();
        }


    }
}
