﻿namespace WebSystem.Mvc.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid id);
        Task SaveAsync(T entity);
        Task UpdateAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangeAsync();
    }
}