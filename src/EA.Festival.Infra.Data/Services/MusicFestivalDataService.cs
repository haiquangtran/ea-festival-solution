using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using EA.Festival.ApplicationCore;
using EA.Festival.ApplicationCore.DTOs;
using EA.Festival.ApplicationCore.Exceptions;
using EA.Festival.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace EA.Festival.Infrastructure.Services
{
    public class MusicFestivalDataService : IMusicFestivalDataService
    {
        private static readonly HttpClient _httpClient;
        private readonly AppConfig _appConfig;

        static MusicFestivalDataService()
        {
            _httpClient = new HttpClient();
        }

        public MusicFestivalDataService(IOptions<AppConfig> appConfig)
        {
            _appConfig = appConfig.Value;
            SetUpHttpClient();
        }
 
        public async Task<IEnumerable<MusicFestivalDto>> GetMusicFestivals()
        {
            var request = new Uri(_appConfig.FestivalDataServiceApiGetFestivalEndpointUri, UriKind.Relative);

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(request);
                var responseContent = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    IEnumerable<MusicFestivalDto> result = JsonConvert.DeserializeObject<IEnumerable<MusicFestivalDto>>(responseContent);
                    return result;
                }
                else
                {
                    throw new FestivalApplicationException(response, responseContent);
                }
            }
            catch (Exception ex)
            {
                // TODO: log error
                throw;
            }
        }

        #region Private methods

        private void SetUpHttpClient()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add(HttpRequestHeader.ContentType.ToString(), "application/json");
            _httpClient.BaseAddress = new Uri(_appConfig.FestivalDataServiceApiBaseAddress);
        }

        #endregion
    }
}
