using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FlyoutTest.Data_Access
{
    public interface IRepository<T> where T: IDatabaseItem, new()
    {
        Task<T> GetById(int id);
        Task<int> DeleteAsysnc(T item);
        Task<List<T>> GetAllAsync();
        Task<int> SaveAsync(T item);
    }
    
}
