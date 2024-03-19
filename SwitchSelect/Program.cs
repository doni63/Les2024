using Microsoft.EntityFrameworkCore;
using SwitchSelect.Data;
using SwitchSelect.Service;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//fazendo get string de conexao
var connectionString = builder.Configuration.GetConnectionString("SwitchSelectConnection");

builder.Services.AddDbContext<SwitchSelectContext>(options => options.UseMySql
(connectionString, ServerVersion.AutoDetect(connectionString)));

builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromMinutes(20); // Tempo de expira��o da sess�o
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ClienteService>();
builder.Services.AddScoped<AdminService>();
builder.Services.AddScoped<CarrinhoService>();
builder.Services.AddSession();
builder.Services.AddControllersWithViews();
builder.Services.AddMemoryCache(); //habilitando memoria cache
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();//habilitando HttpContextAcessor, 




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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
