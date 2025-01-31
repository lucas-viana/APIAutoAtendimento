using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAtendimento.Models
{
    [Table("Table")]
    public class Table
    {
        [Key]
        public int TableId { get; set; } 
        public Client Client { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }
        public bool IsOccupied { get; set; } = false;
    }
}
