﻿using InformationSystems.Server.Data;
using InformationSystems.Server.DTO.Stock;
using InformationSystems.Server.Interfaces;
using InformationSystems.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace InformationSystems.Server.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Stock> CreateAsync(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<Stock?> DeleteAsync(int id)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();
            return stock;
        }

        public async Task<List<Stock>> GetAllAsync()
        {
            return await _context.Stocks.Include(x => x.Comments).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
            return await _context.Stocks.Include(x => x.Comments).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stocks.AnyAsync(x => x.Id == id);
        }

        public async Task<Stock?> UpdateAsync(int id, UpdateStockRequest request)
        {
            var stock = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
            if (stock == null)
            {
                return null;
            }
            stock.Symbol = request.Symbol;
            stock.CompanyName = request.CompanyName;
            stock.Purchase = request.Purchase;
            stock.LastDiv = request.LastDiv;
            stock.Industry = request.Industry;
            stock.MarketCap = request.MarketCap;
            await _context.SaveChangesAsync();
            return stock;
        }
    }
}
