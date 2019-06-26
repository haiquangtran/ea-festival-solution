using System;
using System.Collections.Generic;
using System.Text;
using EA.Festival.Domain.Interfaces;
using EA.Festival.Domain.Models;

namespace EA.Festival.Infra.Data.Services
{
    public class FestivalDataService : IFestivalDataService
    {
        public IEnumerable<MusicFestival> GetMusicFestivals()
        {
            throw new NotImplementedException();
        }
    }
}
