using Catalog.API.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CatalogDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("CatalogDB")));
builder.Services.AddScoped<CatalogDbContextSeed>();

builder.Services.AddScoped<ICatalogTypeRepository, CatalogTypeRepository>();
builder.Services.AddScoped<ICatalogTypeService, CatalogTypeService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

InitializeDatabase(app);

app.Run();

async void InitializeDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        try
        {
            var catalogContext = services.GetRequiredService<CatalogDbContext>();
            var catalogContextSeed = services.GetRequiredService<CatalogDbContextSeed>();
            await catalogContextSeed.SeedAsync(catalogContext);
        }
        catch (Exception ex)
        {
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError(ex, "An error occurred seeding the DB.");
        }
    }
}
