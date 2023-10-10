using LaptopLand.Data.DbContexts;
using LaptopLand.Data.IRepositories;
using LaptopLand.Domain.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaptopLand.Data.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace LaptopLand.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Audiotable
    {
        AppDbContext dbContext;
        DbSet<TEntity> dbSet;
    
        public Repository()
        {
            dbContext = new AppDbContext();
            dbSet = dbContext.Set<TEntity>();
        }

        public async Task<bool> DeleteAsync(long id)
        {
            var entity = await dbContext.FindAsync<TEntity>(id);
            dbSet.Remove(entity);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            await dbSet.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public IQueryable<TEntity> SelectAll() => this.dbSet;
        

        public async Task<TEntity> SelecttByIdAsync(long id) 
            => await dbSet.FirstOrDefaultAsync(dbSet => dbSet.Id == id);
        

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            var model = dbSet.Update(entity);
            await dbContext.SaveChangesAsync();
            return model.Entity;
        }
    }
}
