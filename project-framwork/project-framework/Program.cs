using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using project_framework.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<project_frameworkContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("project_frameworkContext") ?? throw new InvalidOperationException("Connection string 'project_frameworkContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
