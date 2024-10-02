using LogisticApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

public class AuthController : Controller
{
    private readonly string connectionString = $"User Id=adminLogistics;Password=adminLogistiocs;Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=Ivan)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)))";

    // GET: Страница входа
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpGet]
    public IActionResult AccessDenied(string returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl; // Если необходимо
        return View();
    }

    // POST: Обработка логина
    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        var userData = await LoadUserDataAsync(username, password);
        if (userData != null)
        {
            // Создание списка заявок для ClaimsIdentity
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userData.Username),
                new Claim(ClaimTypes.Role, userData.Role) // Здесь добавляем роль пользователя
            };

            // Создание ClaimsIdentity
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            // Вход в систему
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal);

            // Перенаправление на разные панели в зависимости от роли
            switch (userData.Role)
            {
                case "driver":
                    return Redirect("/DriverDashboard"); // Переход на просто /DriverDashboard
                case "admin":
                    return Redirect("/AdminDashboard");
                case "logist":
                    return Redirect("/LogisticianDashboard");
                default:
                    ModelState.AddModelError("", "Неверная роль пользователя.");
                    return View();
            }
        }

        ModelState.AddModelError("", "Неверное имя пользователя или пароль.");
        return View();
    }

    // Метод для загрузки данных пользователя
    private async Task<User> LoadUserDataAsync(string username, string password)
    {
        using (var connection = new OracleConnection(connectionString))
        {
            Console.WriteLine("Connected To Server!");
            await connection.OpenAsync();

            // SQL-запрос с параметрами
            string query = "SELECT user_id, username, role FROM USERS WHERE username =: usern AND password =: passw";

            using (var command = new OracleCommand(query, connection))
            {
                // Добавляем параметры
                command.Parameters.Add(new OracleParameter("usern", username));
                command.Parameters.Add(new OracleParameter("passw", password));

                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (await reader.ReadAsync())
                    {
                        // Если найден пользователь, загружаем данные (без пароля)
                        var userId = reader.GetInt32(0);
                        var userName = reader.GetString(1);
                        var userRole = reader.GetString(2);
                        Console.WriteLine($"userId: {userId}, userName: {userName}, userRole: {userRole}");
                        // Выводим данные пользователя в консоль

                        return new User
                        {
                            UserId = userId,
                            Username = userName,
                            Role = userRole,
                        };
                    }
                    else
                    {
                        Console.WriteLine("No user found with the given credentials.");
                    }
                }
            }
        }
        Console.WriteLine($"Username: '{username}', Password: '{password}'");

        // Пользователь не найден
        Console.WriteLine("User not found.");
        return null;
    }
}
