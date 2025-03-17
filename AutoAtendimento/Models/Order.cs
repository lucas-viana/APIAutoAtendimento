using AutoAtendimento.Models.Enum;
using AutoAtendimento.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAtendimento.Models
{
    [Table("Order")]
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }
        public OrderStatus Status { get; private set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
        public ClientUser ClientUser { get; set; }
        public int ClientUserId { get; set; }
        private List<OrderItem> _orderItens = [];
        public IReadOnlyCollection<OrderItem> OrderItens => _orderItens;



        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (OrderItem orderItem in _orderItens)
            {
                total += orderItem.CalculateTotal();
            }
            return total;
        }
        public void AddOrderItem(Product product, int quantity)
        {
            _orderItens.Add(new OrderItem(product, quantity));
        }
        public void RemoveOrderItem(Product product)
        {
            _orderItens.Remove(_orderItens.Find(x => x.Product == product));
        }
    }
}
