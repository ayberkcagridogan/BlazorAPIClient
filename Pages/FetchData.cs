using System.Net.Http.Json;
using BlazorAPIClient.Dtos;
using Microsoft.AspNetCore.Components;

namespace BlazorAPIClient.Pages{

    public partial class FetchData {

        [Inject]
        private HttpClient Http{ get; set;}
        private LaunchDto[]? launches;

        protected override async Task OnInitializedAsync()
        {
            launches = await Http.GetFromJsonAsync<LaunchDto[]>("/rest/launches");
        }
    }
}