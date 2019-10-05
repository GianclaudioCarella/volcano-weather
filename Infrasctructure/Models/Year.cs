using System;
using System.Collections.Generic;

namespace Infrasctructure.Models
{
    public class Year
    {
        public Guid YearId { get; set; }
        public string Name { get; set; }
        public IList<Month> Month { get; set; }

    }
}
