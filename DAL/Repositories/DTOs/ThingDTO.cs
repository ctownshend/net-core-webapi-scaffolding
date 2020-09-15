using System;
using System.Collections.Generic;

namespace DAL.Repositories.DTOs
{
    public class ThingDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
    }
}
