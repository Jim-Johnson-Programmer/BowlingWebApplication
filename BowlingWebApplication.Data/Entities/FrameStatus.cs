using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace BowlingWebApplication.Data.Entities
{
    public class FrameStatus
    {
        [Key]
        public int Id { get; set; }
        public string Status { get; set; }
    }
}