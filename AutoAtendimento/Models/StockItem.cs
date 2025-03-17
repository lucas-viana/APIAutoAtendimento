using AutoAtendimento.Models.Interfaces;

namespace AutoAtendimento.Models
{
    public class StockItem : IEntity
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PriceAtPurchase { get; private set; } = decimal.Zero;
        public Stock Stock { get; set; }
        public int StockId { get; set; }


    }
}
