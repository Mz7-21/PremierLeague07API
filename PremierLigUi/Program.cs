using PremierLigUi.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient<DashboardService>(client =>
{
    client.BaseAddress = new Uri(
        builder.Configuration["ApiSettings:BaseUrl"]!);
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<DashboardService>();

builder.Services.AddHttpClient<FixtureService>();

builder.Services.AddHttpClient<StandingService>();

builder.Services.AddHttpClient<MatchDetailService>();

builder.Services.AddHttpClient<AdminTeamService>();

builder.Services.AddHttpClient<AdminMatchService>();

builder.Services.AddHttpClient<AdminMatchEventService>();

builder.Services.AddHttpClient<AdminStatisticService>();

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

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "admin",
    areaName: "Admin",
    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dashboard}/{action=Index}/{id?}");

app.Run();
