using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manager.Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    { 
        private readonly ManagerContext _context;
        public BaseRepository(ManagerContext context)
        {
            _context = context;
        }

        public virtual async Task<T> Create(T obj) 
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public virtual async Task<T> Update(T obj) 
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }

        public virtual async Task Remove(long id) 
        {
            var obj = await GetById(id);
            if(obj != null) 
            {
                _context.Remove(obj);
                await _context.SaveChangesAsync();
            }
        }

        public virtual async Task<T> GetById(long id) 
        {
            var obj = await _context.Set<T>()
                            .AsNoTracking()
                            .FirstOrDefaultAsync(o => o.Id == id);
            return obj;
        }


        public virtual async Task<IList<T>> Get() 
        {
            return await _context.Set<T>()
                        .AsNoTracking()
                        .ToListAsync();
        }
    }
}