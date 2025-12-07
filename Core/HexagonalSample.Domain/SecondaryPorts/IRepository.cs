using HexagonalSample.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HexagonalSample.Domain.SecondaryPorts
{
    public interface IRepository<T> where T : BaseEntity
    {

        //Read Operations
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();

        //Write Operations
        Task AddAsync(T entity);
        Task RemoveAsync(T entity); 
        Task UpdateAsync(T entity);
        Task<int> SaveAsync();
    }
}
