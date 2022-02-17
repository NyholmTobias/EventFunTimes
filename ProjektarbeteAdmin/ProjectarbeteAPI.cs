using Projektarbete.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ProjektarbeteAdmin
{
    public class ProjectarbeteAPI : IProjectarbeteApi
    {
        private readonly HttpClient httpClient = new();
        private readonly string Url = "https://localhost:3000/api/v1/EventHost/";

        public async Task<Event?> GetEvent(Guid? id)
        {      
            var res = await httpClient.GetAsync($"{Url}GetEvent/{id}");

            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<Event>() : null;
        }

        public async Task<IEnumerable<Event?>?> GetAllEvents()
        {
            var res = await httpClient.GetAsync($"{Url}GetAllEvents");

            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<List<Event>>() : null;
        }

        public async Task<bool> DeleteEvent(Guid? id)
        {
            var res = await httpClient.DeleteAsync($"{Url}DeleteEvent/{id}");

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> UpdateEvent(Event e)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
            var res = await httpClient.PutAsync($"{Url}UpdateEvent", eventJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        public async Task<bool> CreateEvent(Event e)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync($"{Url}CreateEvent", eventJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }
    }
}
