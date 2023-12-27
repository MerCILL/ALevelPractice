//using MVC.Services.Interfaces;
//using MVC.Services;
//using MVC;

//var configuration = GetConfiguration();

//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddControllersWithViews();

//builder.Services.AddHttpClient();
//builder.Services.AddScoped<IHttpClientService, HttpClientService>();
//builder.Services.AddScoped<TestService>();
//builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Product}/{action=ShowProducts}/{id?}");

//app.Run();

//IConfiguration GetConfiguration()
//{
//    var builder = new ConfigurationBuilder()
//        .SetBasePath(Directory.GetCurrentDirectory())
//        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
//        .AddEnvironmentVariables();

//    return builder.Build();
//}



using MVC;
using MVC.Services;
using MVC.Services.Interfaces;

var configuration = GetConfiguration();

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<AppSettings>(configuration);

builder.Services.AddHttpClient();
builder.Services.AddTransient<IHttpClientService, HttpClientService>();
builder.Services.AddTransient<ICatalogService, CatalogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();

app.UseRouting();
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