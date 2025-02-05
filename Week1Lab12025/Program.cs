using Microsoft.EntityFrameworkCore;
using Tracker.WebAPIClient;
using Week1Lab12025.Models;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddControllersWithViews();

// Add DbContext
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection String 'DefaultConnection' not found.");

builder.Services.AddDbContext<UserContext>(options =>
    options.UseSqlServer(dbConnectionString));

// Register the DbSeeder as a service
builder.Services.AddScoped<DbSeeder>();

var app = builder.Build();

// Retrieve the DbSeeder service and invoke the Seed method
using (var scope = app.Services.CreateScope())
{
    var dbSeeder = scope.ServiceProvider.GetRequiredService<DbSeeder>();
    dbSeeder.Seed();
}

// Tracking activity
ActivityAPIClient.Track(StudentID: "S00237889", StudentName: "Ryan Daly",
activityName: "Rad302 2025 Week 1 Lab 1", Task: "Database initializer setup successfully");

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

