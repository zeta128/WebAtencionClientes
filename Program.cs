using Microsoft.EntityFrameworkCore;
using WebAtencionClientes.Infraestructure.Persistence;
using WebAtencionClientes.Services;
using WebAtencionClientes.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AtencionClientesContext>(ac =>
{
    var conexion = builder.Configuration.GetConnectionString("ConexionDBAtencionClientes");
    ac.UseSqlServer(conexion);
});
builder.Services.AddControllersWithViews();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IServiceInfoClients,ServiceInfoClients>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
