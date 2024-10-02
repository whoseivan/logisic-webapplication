using LogisticApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// ����������� ��������� ���� ������
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseOracle(builder.Configuration.GetConnectionString("DefaultConnection")));


// ��������� ������ ��� ������
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login"; // ���� � �������� �����
        options.AccessDeniedPath = "/Auth/AccessDenied"; // ���� � �������� �������
    });


builder.Services.AddDistributedMemoryCache(); // �������� � ������ ��� ����������� ������
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // ����� �������� ������
    options.Cookie.HttpOnly = true; // ������ �� JavaScript
    options.Cookie.IsEssential = true; // ������ ������ ������������
});

// ��������� ������ ������, ���� �����
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ���������� ������
app.UseSession();

// ������������ ������������� � ������ middleware
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Auth}/{action=Login}/{id?}");

// ��������� ������� ��� DriverDashboard
app.MapControllerRoute(
    name: "driverDashboard",
    pattern: "DriverDashboard",
    defaults: new { controller = "Driver", action = "DriverDashboard" });

// ��������� ������� ��� AdminDashboard
app.MapControllerRoute(
    name: "adminDashboard",
    pattern: "AdminDashboard",
    defaults: new { controller = "Admin", action = "AdminDashboard" });

// ��������� ������� ��� Logistician
app.MapControllerRoute(
    name: "logisticianDashboard",
    pattern: "LogisticianDashboard",
    defaults: new { controller = "Logistician", action = "LogisticianDashboard" });

app.Run();
