using System.Collections;
using System.Collections.Generic;

namespace GamedayTracker.Models
{
    public class Player
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Company { get; set; }
        public PlayerPicks? Picks { get; set; }
    }
}