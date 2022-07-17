namespace SelfServiceCheckout.Interfaces.Repositories
{
    public interface IUnitOfWork
    {
        IStockRepository StockRepository { get; }
        Task<bool> Commit();
        bool HasChanges();
    }
}
