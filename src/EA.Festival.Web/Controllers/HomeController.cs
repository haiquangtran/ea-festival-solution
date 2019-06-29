using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EA.Festival.Web.Models;
using EA.Festival.Domain.Interfaces;
using EA.Festival.ApplicationCore.DTOs;
using AutoMapper;
using Microsoft.Extensions.Options;
using EA.Festival.ApplicationCore;
using EA.Festival.Web.Services.Interfaces;

namespace EA.Festival.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMusicFestivalApiClient _festivalDataService;
        private readonly IViewModelMappingService _mapper;

        public HomeController(IMusicFestivalApiClient festivalDataService, IViewModelMappingService mapper, IOptions<AppConfig> appSettings) : base(appSettings)
        {
            _festivalDataService = festivalDataService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<MusicFestivalDto> musicFestivals = await _festivalDataService.GetMusicFestivals();
            IEnumerable<RecordLabelViewModel> recordLabelViewModels = _mapper.MapToRecordLabelViewModel(musicFestivals);

            return View(recordLabelViewModels);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
