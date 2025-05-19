using AutoMapper;
using calendar_server.Data;
using calendar_server.Dtos;
using calendar_server.Models;
using Microsoft.EntityFrameworkCore;

namespace calendar_server.Repositories
{
    public class BaseRepository<T, U> : IBaseRepository<U> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> _dbSet;
        protected readonly IMapper _mapper;

        public BaseRepository(ApplicationDbContext context, DbSet<T> dbSet, IMapper mapper)
        {
            _context = context;
            _dbSet = dbSet;
            _mapper = mapper;
        }

        public async Task<IEnumerable<U>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<U>>(entities);
        }

        public async Task<U?> GetByIdAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            return entity == null ? default : _mapper.Map<U>(entity);
        }

        public async Task<U> AddAsync(U dto)
        {
            IModel<T> entity = (IModel<T>) _mapper.Map<T>(dto);
            entity.Id = 0; // to have id autoincremented and prevent ids sent from client
            _dbSet.Add((T) entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<U>(entity);
        }

        public async Task UpdateAsync(IDto dto)
        {
            var entity = await _dbSet.FindAsync(dto.Id);
            if (entity != null)
            {
                _mapper.Map(dto, entity);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}
