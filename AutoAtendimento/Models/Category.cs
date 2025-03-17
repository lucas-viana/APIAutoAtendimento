using AutoAtendimento.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace AutoAtendimento.Models
{
    [Table("Category")]
    public class Category : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 60, ErrorMessage = "Enter a value with a maximum of 60 characters")]
        public string Name { get; set; }
        [JsonIgnore]
        public ICollection<Product> Products { get; set; }
    }
}
