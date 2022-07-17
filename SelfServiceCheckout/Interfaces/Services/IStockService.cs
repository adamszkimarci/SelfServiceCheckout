namespace SelfServiceCheckout.Interfaces.Services
{
    public interface IStockService
    {
        /// <summary>
        /// Responsible for inserting a stock into the database (machine);
        /// </summary>
        /// <param name="stock">KV pair where K is the denominator, and V is the amount</param>
        /// <returns>The inserted stock as dictionary</returns>
        public Task<Dictionary<string, int>> PostStock(Dictionary<string, int> stock);
        /// <summary>
        /// Return the stocks that are currently stored in the database.
        /// </summary>
        /// <returns>Currently stored stocks as dictionaries</returns>
        public Task<Dictionary<string, int>> GetStocks();
    }
}
