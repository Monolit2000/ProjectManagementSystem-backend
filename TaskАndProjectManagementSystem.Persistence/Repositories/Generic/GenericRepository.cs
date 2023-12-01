using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskАndProjectManagementSystem.Application.Contracts.Persistence;

namespace TaskАndProjectManagementSystem.Persistence.Repositories.Generic
{
    public abstract class GenericRepository<T> : IRepository<T> where T: class
    {
        private ProgectMengmentApplicationDbContext _DBcontext;
        private DbSet<T> _entyntes;
        public GenericRepository(ProgectMengmentApplicationDbContext applicationDb)
        {
            _DBcontext = applicationDb; 
        }
        public DbSet<T> Entities
        {
            get
            {
                if (_entyntes == null)       
                    _entyntes = _DBcontext.Set<T>();
                
                return _entyntes;   
            }
        }
        public async Task<T> Add(T entity)
        {
            await Entities.AddAsync(entity);
            return entity;
        }

        public async Task Delete(T entity)
        {
            var test = Entities.Remove(entity);
        }

        public async Task<bool> Exists(int id)
        {
            var entity = await Get(id);
            return entity != null;
        }

        public async Task<T> Get(int id)
        {
            return await Entities.FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await Entities.ToListAsync();
        }

        public async Task Update(T entity)
        {
            _DBcontext.Entry(entity).State = EntityState.Modified;
        }
    }
}
