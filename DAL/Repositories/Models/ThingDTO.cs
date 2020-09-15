using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
