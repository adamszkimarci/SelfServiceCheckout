namespace SelfServiceCheckout.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, int>> PostStock(Dictionary<string, int> stock)
        {
            ICollection<Stock> storedStocks = await _unitOfWork.StockRepository.GetAll();

            foreach (KeyValuePair<string, int> s in stock)
            {
                //If the denomination is not defined we throw an exception
                if(Enum.IsDefined(typeof(HufDenominations), Convert.ToInt32(s.Key)))
                {
                    await InsertStock(storedStocks, s);
                }
                else
                {
                    throw new InvalidOperationException($"There's no such denomination {s.Key}");
                }

            }

            if (_unitOfWork.HasChanges()) await _unitOfWork.Commit();

            return storedStocks.ToDictionary(keySelector: s => s.Denomination.ToString(), elementSelector: s => s.Amount);
        }

        public async Task<Dictionary<string, int>> GetStocks()
        {
            var stocks = await _unitOfWork.StockRepository.GetAll();
            return stocks.ToDictionary(keySelector: s => s.Denomination.ToString(), elementSelector: s => s.Amount);
        }

        private async Task InsertStock(ICollection<Stock> stocks, KeyValuePair<string, int> stock)
        {
            int denomination = Convert.ToInt32(stock.Key);
            Stock stockToUpdate = stocks.SingleOrDefault(s => s.Denomination == denomination);

            if(stockToUpdate == null)
            {
                stocks.Add(await CreateNewStock(denomination, stock.Value));
            }else
            {
                stockToUpdate.Amount += stock.Value;
            }
        }

        private async Task<Stock> CreateNewStock(int denomination, int amount)
        {
            Stock stockToCreate = new()
            {
                Denomination = denomination,
                Amount = amount
            };
            await _unitOfWork.StockRepository.CreateStock(stockToCreate);

            return stockToCreate;
        }
    }
}
