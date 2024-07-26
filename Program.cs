using Proje.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//razor eklenebilir
builder.Services.ConfigureDbContext(builder.Configuration);

builder.Services.ConfigureIdentity();

builder.Services.ConfigureSession();
builder.Services.ConfigureRepositorieRegistration();
builder.Services.ConfigureServiceManagerRegistration();
// automapper eklenebilir

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseSession();

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// app.ConfigureAndCheckMigration();
// app.ConfigureDefaultAdminUser();

app.Run();
