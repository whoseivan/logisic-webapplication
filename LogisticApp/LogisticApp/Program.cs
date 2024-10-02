using LogisticApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Регистрация контекста базы данных
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));


// Добавляем службы для сессий
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login"; // Путь к странице входа
        options.AccessDeniedPath = "/Auth/AccessDenied"; // Путь к странице доступа
    });


builder.Services.AddDistributedMemoryCache(); // Хранение в памяти для кеширования сессий
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Время ожидания сессии
    options.Cookie.HttpOnly = true; // Защита от JavaScript
    options.Cookie.IsEssential = true; // Делает сессию обязательной
});

// Добавляем другие службы, если нужно
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Используем сессии
app.UseSession();

// Конфигурация маршрутизации и другие middleware
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Login}/{id?}");

// Добавляем маршрут для DriverDashboard
app.MapControllerRoute(
    name: "driverDashboard",
    pattern: "DriverDashboard",
    defaults: new { controller = "Driver", action = "DriverDashboard" });

// Добавляем маршрут для AdminDashboard
app.MapControllerRoute(
    name: "adminDashboard",
    pattern: "AdminDashboard",
    defaults: new { controller = "Admin", action = "AdminDashboard" });

// Добавляем маршрут для Logistician
app.MapControllerRoute(
    name: "logisticianDashboard",
    pattern: "LogisticianDashboard",
    defaults: new { controller = "Logistician", action = "LogisticianDashboard" });

app.Run();
