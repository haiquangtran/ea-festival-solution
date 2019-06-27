using System;
using System.Collections.Generic;
using System.Text;

namespace EA.Festival.ApplicationCore.DTOs
{
    public class MusicFestivalDto
    {
        public string Name { get; set; }

        public IEnumerable<BandDto> Bands { get; set; }
    }
}
