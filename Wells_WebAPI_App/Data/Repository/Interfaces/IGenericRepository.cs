﻿using System.Diagnostics.Eventing.Reader;

namespace Wells_WebAPI.Data.Repository.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task AddAsync(TEntity entity);
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
