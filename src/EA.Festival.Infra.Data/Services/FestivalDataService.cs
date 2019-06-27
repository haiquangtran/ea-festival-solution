using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EA.Festival.ApplicationCore;
using EA.Festival.Domain.Interfaces;
using EA.Festival.Domain.Models;
using Microsoft.Extensions.Options;

namespace EA.Festival.Infrastructure.Services
{
    public class FestivalDataService : IFestivalDataService
    {
        private static readonly HttpClient _httpClient;
        private readonly AppConfig _appConfig;

        static FestivalDataService()
        {
            _httpClient = new HttpClient();
        }

        public FestivalDataService(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig.Value;
        }
        private void SetUpHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            _httpClient.BaseAddress = new Uri(_appConfig.FestivalDataServiceApiBaseAddress);
        }

        public async Task<IEnumerable<MusicFestival>> GetMusicFestivals()
        {
            throw new NotImplementedException();
        }
    }
}
