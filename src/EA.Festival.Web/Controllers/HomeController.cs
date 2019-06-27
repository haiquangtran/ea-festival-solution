using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EA.Festival.Web.Models;
using EA.Festival.Domain.Interfaces;
using EA.Festival.ApplicationCore.DTOs;

namespace EA.Festival.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMusicFestivalDataService _festivalDataService;

        public HomeController(IMusicFestivalDataService festivalDataService)
        {
            _festivalDataService = festivalDataService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<MusicFestivalDto> musicFestivals = await _festivalDataService.GetMusicFestivals();

            return View();
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
