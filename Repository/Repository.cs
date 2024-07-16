using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById( int id );
        Task<IEnumerable<T>> Find( Expression<Func<T, bool>> predicate );
        Task Add( T entity );
        Task AddRange( IEnumerable<T> entities );
        Task Remove( T entity );
        Task RemoveRange( IEnumerable<T> entities );
    }

    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly EFContext _context;

        public Repository( EFContext context )
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById( int id )
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> Find( Expression<Func<T, bool>> predicate )
        {
            return await _context.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task Add( T entity )
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddRange( IEnumerable<T> entities )
        {
            await _context.Set<T>().AddRangeAsync(entities);
            await _context.SaveChangesAsync();
        }

        public async Task Remove( T entity )
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveRange( IEnumerable<T> entities )
        {
            _context.Set<T>().RemoveRange(entities);
            await _context.SaveChangesAsync();
        }
    }
}
