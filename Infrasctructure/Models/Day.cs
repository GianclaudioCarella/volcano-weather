using System;

namespace Infrasctructure.Models
{
    public class Day
    {
        public Guid DayId { get; set; }
        public string Name { get; set; }
        public Weather Weather { get; set; }
    }
}
