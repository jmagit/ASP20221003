using Curso.Core;
using Curso.Data;
using Curso.Domains.Contracts.Repositories;
using Curso.Domains.Contracts.Services;
using Curso.Domains.Services;
using Curso.Infraestructure.Repositories;
using Curso.Infraestructure.UoW;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDbContext<TiendaDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaConnection")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
// builder.Services.AddTransient<IProductRepository, ProductRepositoryMock>();
builder.Services.AddTransient<IProductService, ProductoService>();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IValidationAttributeAdapterProvider, CustomValidationAttributeAdapterProvider>();

string tipo = builder.Configuration.GetSection("Position")["Title"];



var app = builder.Build();

Console.WriteLine(tipo);

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment()) {
    app.UseMigrationsEndPoint();
} else {
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

// infomes/2000/1

app.MapControllerRoute(
    name: "informes",
    pattern: "informes/{year:int:min(2000)}/{mouth:int:range(1,12)}",
    defaults: new { controller = "Demos", action = "Reports" }
    );

// infomes/1999/14
app.MapControllerRoute(
    name: "informes2",
    pattern: "informes/{year:int}/{mouth=1)}",
    defaults: new { controller = "Demos", action = "Reports" }
    );

// /Products/Edit/680/Bicicleta/Montaña
app.MapControllerRoute(
    name: "seo",
    pattern: "{controller=Home}/{action=Index}/{id}/{**kk}");

app.MapControllerRoute(
    name: "fotos",
    pattern: "{controller=Home}/{action=Photo}/{id}.gif");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllers();

app.MapRazorPages();

app.Run();
