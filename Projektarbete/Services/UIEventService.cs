using EventFunTimesUI.Models;
using EventFunTimesUI.Services.Interfaces;

namespace EventFunTimesUI.Services
{
    public class UIEventService : IUIEventService
    {
        private readonly HttpClient _httpClient;

        public UIEventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<EventResponse>> GetEvents()
        {
            var response = await _httpClient.GetAsync("api/v1/EventHost/GetCandidates");

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<List<EventResponse>>();
            }
            else
            {
                var eventResponse = await response.Content.ReadFromJsonAsync<List<EventResponse>>();
                if (eventResponse.Count <= 0)
                {
                    eventResponse.Add(new EventResponse { });
                }

                return eventResponse;
            }

        }
    }
}
