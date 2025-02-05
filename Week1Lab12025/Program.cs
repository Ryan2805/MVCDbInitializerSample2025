using Tracker.WebAPIClient;
using Week1Lab12025.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var dbConnectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection String 'DefaultConnection' not found.");

builder.Services.AddDbContext<UserContext>(options => 
            options.UseSqlServer(dbConnectionString));


var app = builder.Build();

//Retrieve the user context class from the services container 

using (var scope = app.Services.CreateScope())
{
    var _ctx  = scope.ServiceProvider.GetRequiredService<UserContext>();
    var hostenvironment = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

    DbSeeder dbSeeder = new DbSeeder (_ctx, hostenvironment);
    dbSeeder.Seed();




}
ActivityAPIClient.Track(StudentID: "S00237889", StudentName: "Ryan Daly",
activityName: "Rad302 2025 Week 1 Lab 1", Task: " Database initializer setup successfully ");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
