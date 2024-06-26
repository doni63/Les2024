using Microsoft.EntityFrameworkCore;
using Serilog;
using SwitchSelect.Data;
using SwitchSelect.Models.Carrinho;
using SwitchSelect.Repositorios;
using SwitchSelect.Repositorios.Interfaces;
using SwitchSelect.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container
var connectionString = builder.Configuration.GetConnectionString("SwitchSelectConnection");

builder.Services.AddDbContext<SwitchSelectContext>(options => options.UseMySql
(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddControllersWithViews();

builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromMinutes(20); // Tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<CarrinhoService>();
builder.Services.AddScoped<EnderecoService>();
builder.Services.AddScoped<CartaoService>();
builder.Services.AddTransient<IJogoRepositorio, JogoRepositorio>();
builder.Services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();
builder.Services.AddTransient<IClienteRepositorio, ClienteRepositorio>();
builder.Services.AddTransient<IEnderecoRepositorio, EnderecoRepositorio>();
builder.Services.AddTransient<ICartaoRepositorio, CartaoRepositorio>();
builder.Services.AddScoped(c => CarrinhoCompra.GetCarrinho(c));
builder.Services.AddSession();
builder.Services.AddMemoryCache(); //habilitando memoria cache
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();//habilitando a session
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//rota para JogoList
app.MapControllerRoute(
    name: "jogoFiltro",
    pattern: "Jogo/{action}/{categoria?}",
    defaults: new {controller = "Jogo", action = "JogoList"}
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
