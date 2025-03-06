using Microsoft.EntityFrameworkCore;
using Radzen;
using RpaPlatform.Components;
using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.Business.Service;
using RpaPlatformProject.DataAccess;
using RpaPlatformProject.DataAccess.Repositories;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<RpaDbContext>(options =>
	options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IScheduleRepository, ScheduleRepository>();
builder.Services.AddScoped<IRobotRepository, RobotRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<ILogService, LogService>();

builder.Services.AddRadzenComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
	.AddInteractiveServerRenderMode();

app.Run();
