using Bank.Domain.Entities;
using Bank.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Interfaces
{
    public interface IUserService
    {
        Task<User> CreateAsync(UserCreationDTO userCreationDTO);
        Task<User> UpdateAsync(Predicate<User> predicate, UserCreationDTO userCreationDTO);
        Task<bool> DeleteAsync(Predicate<User> predicate);
        Task<User> GetAsync(Predicate<User> predicate);
        Task<List<User>> GetAllAsync(Predicate<User> predicate);
    }
}
