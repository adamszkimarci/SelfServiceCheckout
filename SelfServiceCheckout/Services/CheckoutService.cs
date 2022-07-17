namespace SelfServiceCheckout.Services
{
    public class CheckoutService : ICheckoutService
    {
        private readonly IStockService _stockService;
        private readonly IUnitOfWork _unitOfWork;

        public CheckoutService(IStockService stockService, IUnitOfWork unitOfWork)
        {
            _stockService = stockService;
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, int>> PostCheckout(Checkout checkout)
        {
            //sum the KV pairs to get the paid amount
            int paidAmount = checkout.Inserted.ToList()
                .Select(s => s.Value * Convert.ToInt32(s.Key))
                .Sum();
            if (paidAmount < checkout.Price)
            {
                throw new InvalidOperationException("Paid amount must be greater than or equal to price.");
            }

            //round the price to the closest 5, because the smallest denominator in Hungary is 5.
            int roundedPrice = (int)Math.Round(checkout.Price / 5.0m) * 5;

            ICollection<Stock> stocksInMachine = await _unitOfWork.StockRepository.GetAll();
            ICollection<Stock> change = GetChange(stocksInMachine, paidAmount - roundedPrice);
            await _stockService.PostStock(checkout.Inserted);

            return change.ToDictionary(keySelector: c => c.Denomination.ToString(), elementSelector: c => c.Amount);
        }

        private ICollection<Stock> GetChange(ICollection<Stock> stocks, int change)
        {
            ICollection<Stock> changeInStocks = new List<Stock>();
    
            while(change > 0)
            {
                //since the repository is ordering the stocks in descending order the first find will be the largest
                var largestDenomination = stocks.FirstOrDefault(s => s.Denomination <= change && s.Amount > 0);
                if(largestDenomination != null)
                {
                    int amount = Math.Min((change / largestDenomination.Denomination), largestDenomination.Amount);
                    changeInStocks.Add(new Stock()
                    {
                        Denomination = largestDenomination.Denomination,
                        Amount = amount
                    });
                    largestDenomination.Amount -= amount;
                    if(largestDenomination.Amount == 0)
                    {
                        stocks.Remove(largestDenomination);
                    }
                    change -= amount * largestDenomination.Denomination;
                }else
                {
                    throw new InvalidOperationException("Checkout failed. Machine run out of change.");
                }
            }
            return changeInStocks;
        }
    }
}
