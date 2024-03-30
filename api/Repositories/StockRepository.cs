using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class StockRepository : ISockRepository
    {
        private readonly ApplicationDBContext _context;

        public StockRepository(ApplicationDBContext context)
        {
            this._context = context;
        }

        public async Task<Stocks> CreateAsync(Stocks stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public Stocks? Delete(int id)
        {
            var stock = _context.Stocks.FirstOrDefault(s => s.Id == id);
            if (stock == null)
                return null;

            _context.Stocks.Remove(stock);
            _context.SaveChangesAsync();
            return stock;
        }


        public async Task<List<Stocks>> GetAllAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stocks?> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);

        }

        public async Task<Stocks?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(s => s.Id == id);

            if (stock == null)
                return null;

            stock.Symbol = stockDto.Symbol;
            stock.CompanyName = stockDto.CompanyName;
            stock.Purchase = stockDto.Purchase;
            stock.LastDiv = stockDto.LastDiv;
            stock.Industry = stockDto.Industry;
            stock.MarketCap = stockDto.MarketCap;

            await _context.SaveChangesAsync();

            return stock;
        }
    }
}