using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Areas.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AreasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AreasContext") ?? throw new InvalidOperationException("Connection string 'AreasContext' not found.")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});

// Add services to the container.
builder.Services.AddControllersWithViews();

// Ajouter les services pour Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{

    //app.UseMigrationsEndPoint();
    // Utiliser Swagger
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    
} 

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("AllowAll");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Admin",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
