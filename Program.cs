using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using GraduateJobFinder.Data;
using GraduateJobFinder.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<GraduateJobFinderContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("GraduateJobFinderContext") ?? throw new InvalidOperationException("Connection string 'GraduateJobFinderContext' not found.")));
}
else
{
    builder.Services.AddDbContext<GraduateJobFinderContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionGraduateJobFinderContext") ?? throw new InvalidOperationException("Connection string 'GraduateJobFinderContext' not found.")));

}

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
