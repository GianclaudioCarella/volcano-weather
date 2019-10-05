using System;
using System.Collections.Generic;

namespace Infrasctructure.Models
{
    public class Month
    {
        public Guid MonthId { get; set; }
        public string Name { get; set; }
        public IList<Day> Days { get; set; }
    }
}
