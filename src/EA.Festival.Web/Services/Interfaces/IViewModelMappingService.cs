using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EA.Festival.ApplicationCore.DTOs;
using EA.Festival.Web.Models;

namespace EA.Festival.Web.Services.Interfaces
{
    public interface IViewModelMappingService
    {
        IEnumerable<RecordLabelViewModel> MapToRecordLabelViewModel(IEnumerable<MusicFestivalDto> musicFestivals);
    }
}
