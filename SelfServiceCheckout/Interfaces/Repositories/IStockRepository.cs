namespace SelfServiceCheckout.Interfaces.Repositories
{
    public interface IStockRepository
    {
        public Task CreateStock(Stock stock);
        public Task<ICollection<Stock>> GetAll();
    }
}
