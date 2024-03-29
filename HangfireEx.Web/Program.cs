using Hangfire;
using HangfireExample.Web.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IEmailSender, EmailSender>();

string conString = builder.Configuration.GetConnectionString("DefaultConnection");



builder.Services.AddHangfire(config => config.UseSqlServerStorage(conString));

builder.Services.AddHangfireServer();
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseHangfireDashboard("/hangfire");

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
