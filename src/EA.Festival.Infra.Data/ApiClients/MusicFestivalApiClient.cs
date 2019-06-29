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

namespace EA.Festival.Infrastructure.ApiClients
{
    public class MusicFestivalApiClient : IMusicFestivalApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly AppConfig _appConfig;

        public MusicFestivalApiClient(HttpClient httpClient, IOptions<AppConfig> appConfig)
        {
            _httpClient = httpClient;
            _appConfig = appConfig.Value;
        }
 
        public async Task<IEnumerable<MusicFestivalDto>> GetMusicFestivals()
        {
            var request = new Uri(_appConfig.MusicFestivalApiGetFestivalEndpointUri, UriKind.Relative);

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

    }
}
