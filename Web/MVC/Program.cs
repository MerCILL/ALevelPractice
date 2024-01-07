using System.IdentityModel.Tokens.Jwt;
using Infrastructure.Configuration;
using Infrastructure.Extensions;
using Infrastructure.Identity;
using Infrastructure.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using MVC.Services;
using MVC.Services.Interfaces;
using MVC.ViewModels;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.AddConfiguration();

var identityUrl = configuration.GetValue<string>("IdentityUrl");
var callBackUrl = configuration.GetValue<string>("CallBackUrl");
var redirectUrl = configuration.GetValue<string>("RedirectUri");
var sessionCookieLifetime = configuration.GetValue("SessionCookieLifetimeMinutes", 60);


//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
//})
//    .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
//    .AddOpenIdConnect(options =>
//    {
//        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//        options.Authority = identityUrl;
//        options.Events.OnRedirectToIdentityProvider = async n =>
//        {
//            n.ProtocolMessage.RedirectUri = redirectUrl;
//            await Task.FromResult(0);
//        };
//        options.Events.OnTicketReceived = async context =>
//        {
//            var client = context.HttpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
//            var accessToken = await context.HttpContext.GetTokenAsync("access_token");
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var response = await client.GetAsync("http://localhost:5003/user-id");
//            if (response.IsSuccessStatusCode)
//            {
//                var userId = await response.Content.ReadAsStringAsync();
//                Console.WriteLine($"User ID: {userId}");
//            }
//            else
//            {
//                Console.WriteLine($"Unable to call BFF: {response.StatusCode}");
//            }
//        };
//        options.Events.OnRedirectToIdentityProviderForSignOut = async context =>
//        {
//            var client = context.HttpContext.RequestServices.GetRequiredService<IHttpClientFactory>().CreateClient();
//            var accessToken = await context.HttpContext.GetTokenAsync("access_token");
//            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);
//            var response = await client.GetAsync("http://localhost:5003/user-id");
//            if (response.IsSuccessStatusCode)
//            {
//                var userId = await response.Content.ReadAsStringAsync();
//                Console.WriteLine($"User ID: {userId}");
//            }
//            else
//            {
//                Console.WriteLine($"Unable to call BFF: {response.StatusCode}");
//            }
//        };
//        options.SignedOutRedirectUri = callBackUrl;
//        options.ClientId = "mvc_pkce";
//        options.ClientSecret = "secret";
//        options.ResponseType = "code";
//        options.SaveTokens = true;
//        options.GetClaimsFromUserInfoEndpoint = true;
//        options.RequireHttpsMetadata = false;
//        options.UsePkce = true;
//        options.Scope.Add("openid");
//        options.Scope.Add("profile");
//        options.Scope.Add("mvc");
//    });


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
    .AddCookie(setup => setup.ExpireTimeSpan = TimeSpan.FromMinutes(sessionCookieLifetime))
    .AddOpenIdConnect(options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
        options.Authority = identityUrl;
        options.Events.OnRedirectToIdentityProvider = async n =>
        {
            n.ProtocolMessage.RedirectUri = redirectUrl;
            await Task.FromResult(0);
        };
        options.SignedOutRedirectUri = callBackUrl;
        options.ClientId = "mvc_pkce";
        options.ClientSecret = "secret";
        options.ResponseType = "code";
        options.SaveTokens = true;
        options.GetClaimsFromUserInfoEndpoint = true;
        options.RequireHttpsMetadata = false;
        options.UsePkce = true;
        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("mvc");
    });


builder.Services.Configure<AppSettings>(configuration);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();
builder.Services.AddTransient<IIdentityParser<ApplicationUser>, IdentityParser>();

var app = builder.Build();

// ADDED
var httpClientFactory = app.Services.GetRequiredService<IHttpClientFactory>();
var client = httpClientFactory.CreateClient();

// ADDED
var response1 = await client.GetAsync("http://localhost:5003/user-id"); 
if (response1.IsSuccessStatusCode)
{
    var userId = await response1.Content.ReadAsStringAsync();
    Console.WriteLine($"User ID: {userId}");
}
else
{
    Console.WriteLine($"Unable to call BFF: {response1.StatusCode}");
}

var response2 = await client.GetAsync("http://localhost:5003/message");
if (response2.IsSuccessStatusCode)
{
    var userId = await response2.Content.ReadAsStringAsync();
    Console.WriteLine($"User ID: {userId}");
}
else
{
    Console.WriteLine($"Unable to call BFF: {response2.StatusCode}");
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseCookiePolicy(new CookiePolicyOptions { MinimumSameSitePolicy = SameSiteMode.Lax });

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute("default", "{controller=Catalog}/{action=Index}/{id?}");
    endpoints.MapControllerRoute("defaultError", "{controller=Error}/{action=Error}");
    endpoints.MapControllers();
});

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}