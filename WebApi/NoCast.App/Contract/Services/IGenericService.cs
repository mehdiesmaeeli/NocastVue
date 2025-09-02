namespace NoCast.App.Contract.Services
{
    public interface IGenericService<TEntity, TDto> where TEntity : class
    {
        Task<IEnumerable<TDto>> GetAllAsync();
        Task<TDto> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TDto entity);
        Task<TDto> UpdateAsync(TDto entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
