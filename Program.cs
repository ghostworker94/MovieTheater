using Microsoft.EntityFrameworkCore;
using MovieTheater;
using MovieTheater.DataBaseContext;
using MovieTheater.Services;
using MovieTheaterBlazor.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

builder.Services.AddScoped<MovieService>();
builder.Services.AddScoped<SeatService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<MovieApiService>();
builder.Services.AddScoped<Seed>();

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DatabaseContext") ??
throw new InvalidOperationException("Connection string 'DatabaseContext' not found.")));

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<HttpClient>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var seeder = services.GetRequiredService<Seed>();
    //seeder.SeedSeatData();
    //seeder.SeedGenreData();

    var movieService = services.GetRequiredService<MovieApiService>();
    movieService.UpdateDatabaseWithMovies().Wait();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();
