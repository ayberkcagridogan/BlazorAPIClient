using System.Text;
using System.Text.Json;
using BlazorAPIClient.Dtos;

namespace  BlazorAPIClient.DataServices{

    public class GraphQLDataService : ISpaceXDataService
    {
        private readonly HttpClient _httpClient;

        public GraphQLDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<LaunchDto[]> GetAllLaunches()
        {
            var queryObject = new {
                query = @"{launches {id is_tentative mission_name launch_date_local}}" ,
                variables = new {}
            };

            var launcQuery = new StringContent(
                JsonSerializer.Serialize(queryObject),
                Encoding.UTF8 ,
                "application/json");

            var response = await _httpClient.PostAsync("graphql" , launcQuery);

            if(response.IsSuccessStatusCode){

                var gqlData = await JsonSerializer.DeserializeAsync<GqlData>
                                    (await response.Content.ReadAsStreamAsync());

                return gqlData.Data.Launches;
            }
            return null;
        }
    }
}