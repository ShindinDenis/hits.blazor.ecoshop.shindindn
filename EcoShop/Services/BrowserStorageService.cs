using Microsoft.JSInterop;
using System.Text.Json;

namespace EcoShop.Services
{
    // Простая обертка над localStorage браузера
    public class BrowserStorageService
    {
        private readonly IJSRuntime _js;

        public BrowserStorageService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task SaveDataAsync<T>(string key, T data)
        {
            var json = JsonSerializer.Serialize(data);
            await _js.InvokeVoidAsync("localStorage.setItem", key, json);
        }

        public async Task<T?> GetDataAsync<T>(string key)
        {
            var json = await _js.InvokeAsync<string>("localStorage.getItem", key);
            if (string.IsNullOrWhiteSpace(json)) return default;
            
            try 
            {
                return JsonSerializer.Deserialize<T>(json);
            }
            catch 
            {
                return default;
            }
        }
    }
}