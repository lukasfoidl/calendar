using calendar_server.Dtos;

namespace calendar_server.Repositories
{
    public interface IBaseRepository<U>
    {
        Task<IEnumerable<U>> GetAllAsync();
        Task<U?> GetByIdAsync(int id);
        Task<U> AddAsync(U dto);
        Task UpdateAsync(IDto dto);
        Task DeleteAsync(int id);
    }
}
