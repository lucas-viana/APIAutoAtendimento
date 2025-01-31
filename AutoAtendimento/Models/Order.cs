using AutoAtendimento.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAtendimento.Models
{
    [Table("Order")]
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public OrderStatus Status{ get; private set; }
        public Table Table { get; set; }
        public int TableId { get; set; }
        private readonly List<OrderItem> OrderItens = [];

        public Order(Table table)
        {
            Table = table;
            Status = OrderStatus.OpenOrder;
        }

        public void ChangeStatus(OrderStatus status)
        {
            Status = status;
        }

        // CheckOrder() method is used to log the order details
        public String CheckOrder()
        {
            string order = $"Table: {Table.TableId} - Client: {Table.Client.FirstName} {Table.Client.LastName }";
            decimal total = 0;
            foreach (OrderItem orderItem in OrderItens)
            {
                order += orderItem.Product.Name + " - " + orderItem.Quantity + " - " + orderItem.CalculateTotal() + "\n";
                total += orderItem.CalculateTotal();
            }
            return order += "Total: " + total;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (OrderItem orderItem in OrderItens)
            {
                total += orderItem.CalculateTotal();
            }
            return total;
        }
        public void AddOrderItem(Product product, int quantity)
        {
            OrderItens.Add(new OrderItem(product, quantity));
        }
        public void RemoveOrderItem(Product product)
        {
            OrderItens.Remove(OrderItens.Find(x => x.Product == product));
        }
    }
}
