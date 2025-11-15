using FootballClubBlazor.Models;
using System.Net.Http.Json;

namespace FootballClubBlazor.Services
{
    public class UsuarioService
    {
        private readonly HttpClient _http;
        private readonly string apiUrl = "https://localhost:7188/api/usuarios"; // HTTPS API

        public UsuarioService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<Usuario>> GetUsuariosAsync()
        {
            var result = await _http.GetFromJsonAsync<List<Usuario>>(apiUrl);
            return result ?? new List<Usuario>();
        }

        public async Task<Usuario> AddUsuarioAsync(Usuario usuario)
        {
            var response = await _http.PostAsJsonAsync(apiUrl, usuario);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<Usuario>();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            var response = await _http.PutAsJsonAsync($"{apiUrl}/{usuario.Id}", usuario);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteUsuarioAsync(int id)
        {
            var response = await _http.DeleteAsync($"{apiUrl}/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}


