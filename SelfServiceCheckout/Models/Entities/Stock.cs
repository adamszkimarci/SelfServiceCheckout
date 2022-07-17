namespace SelfServiceCheckout.Models.Entities
{
    public class Stock
    {
        public Guid Id { get; set; }
        public int Denomination { get; set; }
        public int Amount { get; set; }
    }
}
