using System;
using System.Threading.Tasks;

namespace ControleVeicular.Repository
{
    public interface IControleVeicularRepository
    {
         void Add<T>(T entity) where T: class;
         void Update<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<T[]> GetAll<T>() where T: class;
         Task<T> GetById<T>(Guid Id) where T: class;
         Task<bool> SaveChangesAsync();
    }
}