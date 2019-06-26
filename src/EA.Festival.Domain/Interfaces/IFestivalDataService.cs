using System;
using System.Collections.Generic;
using System.Text;
using EA.Festival.Domain.Models;

namespace EA.Festival.Domain.Interfaces
{
    public interface IFestivalDataService
    {
        IEnumerable<MusicFestival> GetMusicFestivals();
    }
}
