namespace SelfServiceCheckout.Data.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly DataContext _context;
        public StockRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Stock>> GetAll()
        {
            return await _context.Stocks
                .Where(s => s.Amount > 0)
                .OrderByDescending(s => s.Denomination)
                .ToListAsync();
        }
        public async Task CreateStock(Stock stock)
        {
            await _context.Stocks.AddAsync(stock);
        }
    }
}
