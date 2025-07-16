using Application.Core;
using Application.TotalAnesthesia.Queries;
using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//service to call and update or create DB
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<GetActivityList.Handler>());
builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

var app = builder.Build();
// allowing access to from DB to Vit(react)
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("http://localhost:3000", "https://localhost:3000"));

// Configure the HTTP request pipeline.
app.MapControllers();

// creating service scope ( using = garbage collector)
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
    //loading DB
    var context = services.GetRequiredService<AppDbContext>();
    await context.Database.MigrateAsync(); // create db if not already exist
    await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
    var logger = services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An error Ocurred During migration.");
}

app.Run();
