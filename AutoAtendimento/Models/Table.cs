using AutoAtendimento.Models.Enum;
using AutoAtendimento.Models.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoAtendimento.Models
{
    [Table("Table")]
    public class Table : IEntity
    {
        [Key]
        public int Id { get; set; } 
        public int SeatsFor { get; set; }
        public TableStatus Status { get; set; }
        public Table()
        {
            Status = TableStatus.Free;
        }
    }
}
