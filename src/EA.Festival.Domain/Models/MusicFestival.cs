using System;
using System.Collections.Generic;
using System.Text;

namespace EA.Festival.Domain.Models
{
    public class MusicFestival
    {
        public string Name { get; set; }

        public IEnumerable<Band> Bands { get; set; }
    }
}
