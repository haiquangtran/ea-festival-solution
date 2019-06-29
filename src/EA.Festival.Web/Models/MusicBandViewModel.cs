using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EA.Festival.Web.Models
{
    public class MusicBandViewModel
    {
        public string Name { get; set; }

        public IEnumerable<MusicFestivalViewModel> AttendedMusicFestivals { get; set; }
    }
}
