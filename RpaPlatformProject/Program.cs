using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using Radzen;
using RpaPlatformProject;
using RpaPlatformProject.Business.Interface;
using RpaPlatformProject.Business.Service;
using RpaPlatformProject.DataAccess;
using RpaPlatformProject.DataAccess.Repositories;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddDbContext<RpaDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IScheduleRepository,  ScheduleRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IRobotRepository, RobotRepository>();

builder.Services.AddScoped<IScheduleService, ScheduleService>();
builder.Services.AddScoped<ILogService, LogService>();
builder.Services.AddScoped<IRobotService, RobotService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddRadzenComponents();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
