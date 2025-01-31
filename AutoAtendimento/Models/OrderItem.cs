using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAtendimento.Models
{
    [Table("OrderItem")]
    public class OrderItem
    {
        [Key]
        public int OrderItemId { get; set; }
        [Required]
        public Product Product { get; set; }
        public int ProductId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [ForeignKey("Order")]
        public int OrderId { get; set; }
        public decimal PriceAtOrder { get; set; }

        public OrderItem(Product product, int quantity)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product cannot be null");
            }
            if (quantity <= 0)
            {
                throw new ArgumentException("Quantity must be greater than zero");
            }
            Product = product;
            Quantity = quantity;
        }

        public decimal CalculateTotal()
        {
            return Quantity * Product.Price;
        }
    }
}
