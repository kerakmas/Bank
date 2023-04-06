using Bank.Data.Contexts;
using Bank.Data.IRepositores;
using Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext appDbContext = new AppDbContext();
        public async Task<bool> DeleteAsync(int id)
        {
            User entity = await appDbContext.Users.FirstOrDefaultAsync(user => user.Id == id);
            if (entity is null)
            {
                return false;
            }
            this.appDbContext.Remove(entity);
            await this.appDbContext.SaveChangesAsync();
            return true;
        }

        public IQueryable<User> GetAllAsync(Predicate<User> predicate = null)
        {
            if (predicate is null)
            {
                return appDbContext.Users;
            }
            return this.appDbContext.Users.AsEnumerable().Where(user => predicate(user)).AsQueryable();

        }

        public async Task<User> GetByAsync(Predicate<User> predicate)
        {
            var products = await appDbContext.Users.ToListAsync();
            return products.FirstOrDefault(user => predicate(user));
        }

        public async Task<User> InsertAsync(User user)
        {

                var res = await appDbContext.AddAsync(user);
                await appDbContext.SaveChangesAsync();
                return user;

        }

        public async Task<User> UpdateAsync(User user)
        {
            EntityEntry<User> entity = this.appDbContext.Users.Update(user);
            await appDbContext.SaveChangesAsync();
            return entity.Entity;
        }
    }
}
