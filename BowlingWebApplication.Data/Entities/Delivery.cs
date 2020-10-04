using System.ComponentModel.DataAnnotations;

namespace BowlingWebApplication.Data.Entities
{
    public class Delivery
    {
        [Key]
        public int Id { get; set; }
        public int PinsDown { get; set; }
        public string Status { get; set; }
    }
}