using System;
using System.Linq;
using System.Threading.Tasks;
using ControleVeicular.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleVeicular.Repository
{
    public class ControleVeicularRepository : IControleVeicularRepository
    {
        private readonly DataContext DataContext;

        public ControleVeicularRepository(DataContext dataContext)
        {
            DataContext = dataContext;
            DataContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add<T>(T entity) where T: class
        {
            DataContext.Add(entity);
        }

        public void Update<T>(T entity) where T: class
        {
            DataContext.Update(entity);
        }

        public void Delete<T>(T entity) where T: class
        {
            DataContext.Remove(entity);
        }

        public async Task<T[]> GetAll<T>() where T: class
        {
            return await DataContext.Set<T>().ToArrayAsync();
        }

        public async Task<T> GetById<T>(Guid Id) where T: class
        {
            return await DataContext.Set<T>().FindAsync(Id);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await DataContext.SaveChangesAsync()) > 0;
        }
    }
}