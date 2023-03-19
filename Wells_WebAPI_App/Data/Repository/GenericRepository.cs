﻿using Microsoft.EntityFrameworkCore;
using Wells_WebAPI.Data.Repository.Interfaces;
using Wells_WebAPI.Persistence.Database;

namespace Wells_WebAPI.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<TEntity> _dbSet = null;
        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
             await _dbSet.AddAsync(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }
    }
}
