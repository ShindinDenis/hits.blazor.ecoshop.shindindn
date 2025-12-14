using Microsoft.JSInterop;

namespace EcoShop.Services
{
    public class ThemeService
    {
        private readonly IJSRuntime _js;
        private bool _isInitialized = false; // Флаг: проверяли ли мы уже тему?
        
        public bool IsDarkMode { get; private set; } = false;
        
        public event Action? OnChange;

        public ThemeService(IJSRuntime js)
        {
            _js = js;
        }

        public async Task InitializeAsync()
        {
            // САМОЕ ВАЖНОЕ ИСПРАВЛЕНИЕ:
            // Если мы уже инициализировались в этой сессии, не делаем это снова.
            // Это предотвращает сброс темы при переходе по вкладкам.
            if (_isInitialized) return;

            try 
            {
                var theme = await _js.InvokeAsync<string>("window.themeManager.getTheme");
                IsDarkMode = theme == "dark";
                _isInitialized = true; // Запоминаем, что мы уже знаем тему
                NotifyStateChanged();
            }
            catch
            {
                // Игнорируем ошибки JS (например, при пре-рендеринге)
            }
        }

        public async Task ToggleThemeAsync()
        {
            IsDarkMode = !IsDarkMode;
            var newTheme = IsDarkMode ? "dark" : "light";
            
            await _js.InvokeVoidAsync("window.themeManager.setTheme", newTheme);
            
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}