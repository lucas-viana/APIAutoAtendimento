namespace AutoAtendimento.Models
{
    public class StockItem
    {
        public int StockItemId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
