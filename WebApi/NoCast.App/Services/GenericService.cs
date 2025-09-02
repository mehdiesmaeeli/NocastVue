using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NoCast.App.Contract.Services;
using NoCast.App.Data;

namespace NoCast.App.Services
{
    public class GenericService<TEntity, TDto> : IGenericService<TEntity, TDto> where TEntity : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        public GenericService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
            _dbSet = context.Set<TEntity>();
        }


        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await _dbSet.ToListAsync();
            return _mapper.Map<IEnumerable<TDto>>(entities);
        }

        public virtual async Task<TDto> GetByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            try
            {
                var entity = _mapper.Map<TEntity>(dto);
                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<TDto>(entity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                return false;

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
