namespace AutoAtendimento.Models
{
    public class Stock
    {
        public int StockId { get; set; }
        private List<StockItem> StockItems { get; set; } = [];

        public void AddStockItem(StockItem stockItem)
        {
            StockItems.Add(stockItem);
        }
        public void RemoveStockItem(StockItem stockItem)
        {
            StockItems.Remove(stockItem);
        }

        public void UpdateStockItem(StockItem stockItem)
        {
            StockItems[StockItems.IndexOf(stockItem)] = stockItem;
        }
    }
}
