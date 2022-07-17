namespace SelfServiceCheckout.Interfaces.Services
{
    public interface ICheckoutService
    {
        public Task<Dictionary<string, int>> PostCheckout(Checkout checkout);
    }
}
