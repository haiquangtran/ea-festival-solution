using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EA.Festival.Domain.Models;

namespace EA.Festival.Domain.Interfaces
{
    public interface IFestivalDataService
    {
        Task<IEnumerable<MusicFestival>> GetMusicFestivals();
    }
}
