using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EA.Festival.ApplicationCore.DTOs;
using EA.Festival.Web.Models;
using EA.Festival.Web.Services.Interfaces;

namespace EA.Festival.Web.Services
{
    public class ViewModelMappingService : IViewModelMappingService
    {
        public IEnumerable<RecordLabelViewModel> MapToRecordLabelViewModel(IEnumerable<MusicFestivalDto> musicFestivals)
        {
            IEnumerable<RecordLabelViewModel> recordLabels = musicFestivals?.SelectMany(festival => festival.Bands.Select(band => band.RecordLabel))
                .Distinct()
                .Select(recordLabelName =>
                {
                    // Bands belonging to the record label
                    IEnumerable<MusicBandViewModel> recordLabelBands = musicFestivals
                        .SelectMany(festival => festival.Bands.Where(band => band.RecordLabel == recordLabelName).Select(band => band.Name))
                        .Where(bandName => !string.IsNullOrEmpty(bandName))
                        .Select(bandName => new MusicBandViewModel()
                        {
                            Name = bandName,
                            // Music festivals the band has attended
                            AttendedMusicFestivals = musicFestivals
                                .Where(festival => !string.IsNullOrEmpty(festival.Name) && festival.Bands.Any(band => band.Name == bandName))
                                .Select(festival => new MusicFestivalViewModel() { Name = festival.Name })
                                .OrderBy(festival => festival.Name)
                        })
                        .OrderBy(band => band.Name);

                    return new RecordLabelViewModel()
                    {
                        Name = recordLabelName,
                        Bands = recordLabelBands
                    };
                })
                .OrderBy(recordLabel => recordLabel.Name);

            return recordLabels ?? Enumerable.Empty<RecordLabelViewModel>();
        }
    }
}
