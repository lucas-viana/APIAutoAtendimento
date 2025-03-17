using AutoAtendimento.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAtendimento.Models
{
    [Table("ClientUser")]
    public class ClientUser : IEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 10, ErrorMessage = "Enter a value with a maximum of 60 characters and minimum 10")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(maximumLength: 60, MinimumLength = 10, ErrorMessage = "Enter a value with a maximum of 60 characters and minimum 10")]
        public string LastName { get; set; } = string.Empty;
    }
}
