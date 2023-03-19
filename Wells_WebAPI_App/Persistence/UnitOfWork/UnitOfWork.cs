using Wells_WebAPI.Data.Models;
using Wells_WebAPI.Data.Repository;
using Wells_WebAPI.Data.Repository.Interfaces;
using Wells_WebAPI.Persistence.Database;

namespace Wells_WebAPI.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationContext _context;
        IGenericRepository<DrillBlock> _drillBlockRepository;
        IGenericRepository<Hole> _holeRepository;
        IGenericRepository<DrillBlockPoints> _drillBlockPointsRepository;
        IGenericRepository<HolePoints> _holePointsRepository;

        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }

        public IGenericRepository<DrillBlock> DrillBlockRepository
        {
            get
            {
                if (_drillBlockRepository == null)
                {
                    _drillBlockRepository = new GenericRepository<DrillBlock>(_context);
                }
                return _drillBlockRepository;
            }
        }

        public IGenericRepository<Hole> HoleRepository
        {
            get
            {
                if (_holeRepository == null)
                {
                    _holeRepository = new GenericRepository<Hole>(_context);
                }
                return _holeRepository;
            }
        }

        public IGenericRepository<DrillBlockPoints> DrillBlockPointsRepository
        {
            get
            {
                if (_drillBlockPointsRepository == null)
                {
                    _drillBlockPointsRepository = new GenericRepository<DrillBlockPoints>(_context);
                }
                return _drillBlockPointsRepository;
            }
        }

        public IGenericRepository<HolePoints> HolePointsRepository
        {
            get
            {
                if (_holePointsRepository == null)
                {
                    _holePointsRepository = new GenericRepository<HolePoints>(_context);
                }
                return _holePointsRepository;
            }
        }

        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        private bool disposed = false;
        protected virtual async void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                   await _context.DisposeAsync();
                }
            }
            disposed = true;
        }
    }
}
