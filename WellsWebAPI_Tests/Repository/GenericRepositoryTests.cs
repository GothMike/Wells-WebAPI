using Microsoft.EntityFrameworkCore;
using Wells_WebAPI.Persistence.Database;
using Wells_WebAPI.Data.Repository;
using Wells_WebAPI.Data.Models;
using FluentAssertions;

namespace WellsWebAPI_Tests.Repository
{
    public class GenericRepositoryTests
    {
        private readonly ApplicationContext _context;
        private readonly GenericRepository<HolePoints> _repository;

        public GenericRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDb")
                .Options;
            _context = new ApplicationContext(options);
            _repository = new GenericRepository<HolePoints>(_context);
        }

        [Fact]
        public async Task GenericRepository_GetByIdAsync_ReturnEntity()
        {
            // Arrange
            var entity = new HolePoints { Hole = new Hole { Name = "Test" }, X = 1, Y = 1, Z = 1 };
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByIdAsync(entity.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HolePoints>();
        }

        [Fact]
        public async Task GenericRepository_GetAllAsync_ReturnEntities()
        {
            // Arrange
            var entity = new HolePoints { HoleId = 1, Hole = new Hole { Name = "Test" }, X = 1, Y = 1, Z = 1 };
            var entity2 = new HolePoints { HoleId = 1, Hole = new Hole { Name = "Test2" }, X = 2, Y = 2, Z = 2 };
            await _repository.AddAsync(entity);
            await _repository.AddAsync(entity2);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(c => c <= 2).And.OnlyHaveUniqueItems();
        }

        [Fact]
        public async Task GenericRepository_AddAsync_ReturnEntity()
        {
            // Arrange
            var entity = new HolePoints {  HoleId = 1, Hole = new Hole {  Name = "Test" }, X = 1, Y = 1, Z = 1 };
            var entity2 = new HolePoints { HoleId = 2, Hole = new Hole {  Name = "Test2" }, X = 2, Y = 2, Z = 2 };
            await _repository.AddAsync(entity);

            // Act
            await _repository.AddAsync(entity2);
            await _context.SaveChangesAsync();
            var result = await _repository.GetByIdAsync(entity2.Id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<HolePoints>();
        }

        [Fact]
        public async Task GenericRepository_Delete_ReturnNull()
        {
            // Arrange
           await _repository.AddAsync(new HolePoints { Hole = new Hole { Name = "Test" }, X = 1, Y = 1, Z = 1 });
           var entity = await _repository.GetByIdAsync(1);

            // Act
             _repository.Delete(entity);
            await _context.SaveChangesAsync();
            var deletedEntity = await _repository.GetByIdAsync(entity.Id);

            // Assert
            deletedEntity.Should().BeNull();
        }

        [Fact]
        public async Task GenericRepository_Update_ReturnNull()
        {
            // Arrange
            await _repository.AddAsync(new HolePoints { Hole = new Hole {  Name = "Test" }, X = 1, Y = 1, Z = 1 });
            var entity = await _repository.GetByIdAsync(1);
            await _context.SaveChangesAsync();

            // Act
            entity.X = 2;
            entity.Y = 2;
            entity.Z = 2;
             _repository.Update(entity);
            await _context.SaveChangesAsync();
            var updatedEntity = await _repository.GetByIdAsync(1);


            // Assert
            updatedEntity.X.Should().Be(2);
            updatedEntity.Y.Should().Be(2);
            updatedEntity.Z.Should().Be(2);
        }
    }
}
