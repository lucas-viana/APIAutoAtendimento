using AutoAtendimento.Models.Interfaces;

namespace AutoAtendimento.Models
{
    public class Stock : IEntity
    {
        public int Id { get; set; }
        public DateTime LastModified { get; set; }
        private List<StockItem> _stockItems = [];
        public IReadOnlyList<StockItem> StockItems => _stockItems;

        public Stock()
        {
            LastModified = DateTime.Now;
        }

        public void AddStockItem(StockItem stockItem)
        {
            _stockItems.Add(stockItem);
            LastModified = DateTime.Now;
        }
        public void RemoveStockItem(StockItem stockItem)
        {
            _stockItems.Remove(stockItem);
            LastModified = DateTime.Now;
        }

        public void UpdateStockItem(StockItem stockItem)
        {
            _stockItems[stockItem.Id] = stockItem;
        }
    }
}
