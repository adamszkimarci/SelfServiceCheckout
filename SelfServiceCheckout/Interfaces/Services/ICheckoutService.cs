namespace SelfServiceCheckout.Interfaces.Services
{
    public interface ICheckoutService
    {
        /// <summary>
        /// This method is responsible for executing the Checkout logic
        /// </summary>
        /// <param name="checkout">Checkout object which contains a Dictionary and the amount paid.</param>
        /// <returns>Returns the change as dictionary.</returns>
        public Task<Dictionary<string, int>> PostCheckout(Checkout checkout);
    }
}
