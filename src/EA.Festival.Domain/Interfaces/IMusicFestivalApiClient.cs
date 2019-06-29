using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EA.Festival.ApplicationCore.DTOs;

namespace EA.Festival.Domain.Interfaces
{
    public interface IMusicFestivalApiClient
    {
        Task<IEnumerable<MusicFestivalDto>> GetMusicFestivals();
    }
}
