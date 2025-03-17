using AutoAtendimento.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AutoAtendimento.Models
{
    [Table("Product")]
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 10, ErrorMessage = "Enter a value with a maximum of 60 characters and minimum 10")]
        public string Name { get; set; }

        [Required]
        public decimal SalePrice { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        [JsonIgnore]
        public Category Category { get; set; }
    }
}
