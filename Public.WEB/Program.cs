using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add MVC services
builder.Services.AddControllersWithViews();

// Enable session (for token/user info)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Register HttpClient for API communication
builder.Services.AddHttpClient("PublicApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7061"); // Your API base URL
});

// Register your custom services (like IAuthService)
builder.Services.AddScoped<Public.WEB.Services.Authentication.IAccountService, Public.WEB.Services.Authentication.AccountService>();
builder.Services.AddScoped<Public.WEB.Services.User.IUserService, Public.WEB.Services.User.UserService>();

var app = builder.Build();

// Middleware setup
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); 

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();
