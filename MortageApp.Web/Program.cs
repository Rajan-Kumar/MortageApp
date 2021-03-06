using Microsoft.EntityFrameworkCore;
using Mortgage.Data;
using Mortgage.Services.Implementation;
using Mortgage.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MortgageDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IMortgageDetails, MortgageDetails>();
builder.Services.AddScoped<IMortgageDbDetails, MortgageDbDetails>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
