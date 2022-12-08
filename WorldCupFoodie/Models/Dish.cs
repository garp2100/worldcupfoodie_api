using System;
using System.Collections.Generic;

namespace WorldCupFoodie.Models
{
    public partial class Dish
    {
        public int Id { get; set; }
        public int? MatchId { get; set; }
        public string? Dish1 { get; set; }
        public string? Description { get; set; }

        public virtual Match? Match { get; set; }
    }
}
