using System.Net.Http.Json;
using BlazorAPIClient.Dtos;

namespace BlazorAPIClient.DataServices{

    public class RestSpaceXDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public RestSpaceXDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            return await _httpClient.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}