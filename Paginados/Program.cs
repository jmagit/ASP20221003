using Curso.Domains.Contracts.Repositories;
using Curso.Domains.Contracts.Services;
using Curso.Domains.Services;
using Curso.Infraestructure.Repositories;
using Curso.Infraestructure.UoW;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TiendaDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("TiendaConnection")));

builder.Services.AddTransient<IProductRepository, ProductRepository>();
// builder.Services.AddTransient<IProductRepository, ProductRepositoryMock>();
builder.Services.AddTransient<IProductService, ProductoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if(!app.Environment.IsDevelopment()) {
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
