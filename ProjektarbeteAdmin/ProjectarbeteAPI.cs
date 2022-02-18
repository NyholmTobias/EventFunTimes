using EventFunTimesAPI.Models;
using ProjektarbeteAdmin.Interfaces;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ProjektarbeteAdmin
{
    public class ProjectarbeteAPI : IProjectarbeteApi
    {
        private readonly HttpClient httpClient = new();
        private readonly string Url = "https://localhost:5001/api/v1/EventHost";

        public async Task<Event?> GetEvent(Guid? id)
        {      
            var res = await httpClient.GetAsync($"{Url}/{id}");

            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<Event>() : null;
        }

        public async Task<IEnumerable<Event?>?> GetAllEvents()
        {
            var res = await httpClient.GetAsync($"{Url}");

            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<List<Event>>() : null;
        }

        public async Task<bool> DeleteEvent(Guid? id)
        {
            var res = await httpClient.DeleteAsync($"{Url}/{id}");

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> UpdateEvent(Event e)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
            var res = await httpClient.PutAsync($"{Url}", eventJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> CreateEvent(Event e)
        {
            //Had to do this because of ReferenceLoopHandling
            e.OpeningHours.Clear();
            var eventJson = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync($"{Url}", eventJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> CreateOpeningHours(List<OpeningHours> newOpeningHours)
        {
            var openingHoursJson = new StringContent(JsonSerializer.Serialize(newOpeningHours), Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync($"https://localhost:5001/api/v1/openingHours", openingHoursJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> UpdateOpeningHours(List<OpeningHours> OpeningHoursToUpdate)
        {
            var openingHoursJson = new StringContent(JsonSerializer.Serialize(OpeningHoursToUpdate), Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync($"https://localhost:5001/api/v1/openingHours", openingHoursJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }
    }
}
