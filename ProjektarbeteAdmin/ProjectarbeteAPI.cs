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

        /// <summary>
        /// Calls the API and gets one event by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Event</returns>
        public async Task<Event?> GetEvent(Guid? id)
        {      
            var res = await httpClient.GetAsync($"{Url}/{id}");

            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<Event>() : null;
        }

        /// <summary>
        /// Calls the API and gets all the events from the Events table.
        /// </summary>
        /// <returns>List of event</returns>
        public async Task<IEnumerable<Event?>?> GetAllEvents()
        {
            var res = await httpClient.GetAsync($"{Url}");

            return res.IsSuccessStatusCode ? await res.Content.ReadFromJsonAsync<List<Event>>() : null;
        }

        /// <summary>
        /// Calls the API and deletes event with the passed id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>true or false</returns>
        public async Task<bool> DeleteEvent(Guid? id)
        {
            var res = await httpClient.DeleteAsync($"{Url}/{id}");

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        /// <summary>
        /// Calls the API and update event.
        /// </summary>
        /// <param name="eventToUpdate"></param>
        /// <returns>true or false</returns>
        public async Task<bool> UpdateEvent(Event e)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
            var res = await httpClient.PutAsync($"{Url}", eventJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }

        /// <summary>
        /// Calls the API, creates a new event and adds it to the db.
        /// </summary>
        /// <param name="newEvent"></param>
        /// <returns>true or false</returns>
        public async Task<bool> CreateEvent(Event e)
        {
            var eventJson = new StringContent(JsonSerializer.Serialize(e), Encoding.UTF8, "application/json");
            var res = await httpClient.PostAsync($"{Url}", eventJson);

            return res.IsSuccessStatusCode && await res.Content.ReadFromJsonAsync<bool>();
        }
    }
}
