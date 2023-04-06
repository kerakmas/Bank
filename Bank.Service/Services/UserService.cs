using Bank.Data.IRepositores;
using Bank.Data.Repositories;
using Bank.Domain.Entities;
using Bank.Service.DTOs;
using Bank.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository = new UserRepository();
        public async Task<User> CreateAsync(UserCreationDTO userCreationDTO)
        {
            var newUser = new User
            {
                Ism = userCreationDTO.Ism,
                Familya = userCreationDTO.Familya,
                Yoshi = userCreationDTO.Yoshi,
                CreatedAt = DateTime.UtcNow
            };

            await userRepository.InsertAsync(newUser);


            return newUser;
        }

        public async Task<bool> DeleteAsync(Predicate<User> predicate)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            var userToDelete = users.FirstOrDefault(user => predicate(user));

            if (userToDelete == null)
                return false;

            await userRepository.DeleteAsync(userToDelete.Id);

            return true;
        }

        public async Task<List<User>> GetAllAsync(Predicate<User> predicate)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            return users.Where(user => predicate(user)).ToList();
        }

        public async Task<User> GetAsync(Predicate<User> predicate)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            return users.FirstOrDefault(p => predicate(p));
        }

        public async Task<User> UpdateAsync(Predicate<User> predicate, UserCreationDTO userCreationDTO)
        {
            var users = await userRepository.GetAllAsync().ToListAsync();

            var userToUpdate = users.FirstOrDefault(p => predicate(p));

            if (userToUpdate == null)
                return null;

            userToUpdate.Ism = userCreationDTO.Ism;
            userToUpdate.Familya = userCreationDTO.Familya;
            userToUpdate.Yoshi = userCreationDTO.Yoshi;
            userToUpdate.UpdatedAt = DateTime.UtcNow;

            await userRepository.UpdateAsync(userToUpdate);

            return userToUpdate;
        }
    }
}
