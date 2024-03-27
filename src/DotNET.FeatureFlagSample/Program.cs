using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using DotNET.FeatureFlagSample.Data;
using Microsoft.FeatureManagement;
using DotNET.FeatureFlagSample.Filters;

var builder = WebApplication.CreateBuilder(args);

// Retrieve the App Config connection string
string AppConfigConnectionString = builder.Configuration.GetConnectionString("AppConfig");

// Load configuration from Azure App Configuration
builder.Configuration.AddAzureAppConfiguration(options =>
{
    options.Connect(AppConfigConnectionString);
    options.UseFeatureFlags();
});

// Add Azure App Configuration middleware to the container of services
builder.Services.AddAzureAppConfiguration();

// Add feature management to the container of services
builder.Services.AddFeatureManagement().WithTargeting<UserTargetingContextAccessor>(); ;

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Use Azure App Configuration middleware for dynamic configuration refresh
app.UseAzureAppConfiguration();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
