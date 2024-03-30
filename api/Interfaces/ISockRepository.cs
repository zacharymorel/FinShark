using api.Dtos.Stock;
using api.Models;

namespace api.Interfaces
{
    public interface ISockRepository
    {
        Task<List<Stocks>> GetAllAsync();
        Task<Stocks?> GetByIdAsync(int id); // "?" here because FirstOrDefault can return null
        Task<Stocks> CreateAsync(Stocks stock);
        Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Stocks Delete(int id);
    }
}