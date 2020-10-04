using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BowlingWebApplication.Data.Entities
{
    public class Frame
    {
        [Key]
        public int Id { get; set; }
        public int StatusCode { get; set; }
        public int CumulativeScore { get; set; }
        public int Delivery1Id { get; set; }
        public int Delivery2Id { get; set; }
        public int Delivery3Id { get; set; }
    }
}
