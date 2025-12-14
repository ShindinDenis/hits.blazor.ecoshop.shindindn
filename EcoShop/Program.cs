using EcoShop.Components;
using EcoShop.Data; // Добавили
using EcoShop.Services;
using Microsoft.EntityFrameworkCore; // Добавили

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=ecoshop.db"));    
builder.Services.AddScoped<StoreService>();
builder.Services.AddScoped<BrowserStorageService>(); // <-- НОВЫЙ СЕРВИС
builder.Services.AddScoped<CartService>();

builder.Services.AddScoped<EcoShop.Services.ThemeService>(); 

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

// app.UseHttpsRedirection(); // Отключено для локальной разработки

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();