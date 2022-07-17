namespace SelfServiceCheckout.Interfaces.Services
{
    public interface IStockService
    {
        public Task<Dictionary<string, int>> PostStock(Dictionary<string, int> stock);
        public Task<Dictionary<string, int>> GetStocks();
    }
}
