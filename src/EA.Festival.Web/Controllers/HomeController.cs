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

namespace EA.Festival.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IMusicFestivalApiClient _festivalDataService;

        public HomeController(IMusicFestivalApiClient festivalDataService, 
            IMapper mapper, IOptions<AppConfig> appSettings) : base(mapper, appSettings)
        {
            _festivalDataService = festivalDataService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<MusicFestivalDto> musicFestivals = await _festivalDataService.GetMusicFestivals();
            IEnumerable<MusicFestivalViewModel> result = _mapper.Map<IEnumerable<MusicFestivalDto>, IEnumerable<MusicFestivalViewModel>>(musicFestivals);

            return View(result);
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
