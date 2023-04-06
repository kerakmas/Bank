using Bank.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.IRepositores
{
    public interface IUserRepository
    {
        Task<User> InsertAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User> GetByAsync(Predicate<User> predicate = null);

        IQueryable<User> GetAllAsync(Predicate<User> predicate = null);
    }
}
