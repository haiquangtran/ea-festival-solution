using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EA.Festival.Web.Models
{
    public class RecordLabelViewModel
    {
        public string Name { get; set; }

        public IEnumerable<MusicBandViewModel> Bands { get; set; }
    }
}
