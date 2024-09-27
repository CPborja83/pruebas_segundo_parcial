using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace pruebas_segundo_parcial.Services
{
    public class CarteleraService
    {
        private readonly HttpClient _httpClient;

        public CarteleraService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<EstructuraItem> GetItemAsync(string imdbID)
        {
            var response = await _httpClient.GetFromJsonAsync<EstructuraItem>($"https://movie.azurewebsites.net/api/cartelera?imdbID={imdbID}");
            return response;
        }

        public async Task<IEnumerable<EstructuraItem>> GetItemsAsync(string title = "", string ubication = "")
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<EstructuraItem>>($"https://movie.azurewebsites.net/api/cartelera?title={title}&ubication={ubication}");
            return response;
        }

        public async Task PostItemAsync(EstructuraItem item)
        {
            await _httpClient.PostAsJsonAsync("https://movie.azurewebsites.net/api/cartelera", item);
        }

        public async Task PutItemAsync(EstructuraItem item)
        {
            await _httpClient.PutAsJsonAsync($"https://movie.azurewebsites.net/api/cartelera?imdbID={item.ImdbID}", item);
        }

        public async Task DeleteItemAsync(string imdbID)
        {
            await _httpClient.DeleteAsync($"https://movie.azurewebsites.net/api/cartelera?imdbID={imdbID}");
        }
    }

    public class EstructuraItem
    {
        public string ImdbID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
        public string Description { get; set; }
        public string Ubication { get; set; }
        public bool Estado { get; set; }
    }
}
