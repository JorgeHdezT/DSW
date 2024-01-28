using Microsoft.EntityFrameworkCore;
using PO01_HernandezJorge_v1.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// LA conexión....
builder.Services.AddDbContext<HernandezContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("HernandezContext"));
});

var app = builder.Build();

// La inicialización del seeder

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
