using MarsKapu;
using MarsKapu.Application.BusinessLogic;
using MarsKapu.Application.Contracts.BusinessLogic;
using MarsKapu.Application.Contracts.Repositories;
using MarsKapu.Application.Contracts.Services;
using MarsKapu.Controllers;
using MarsKapu.Repositories;
using MarsKapu.Services;
using MarsKapu.State;
using MarsKapu.Utilities;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spectre.Console;

using IHost host = CreateHostBuilder(args).Build();
using var scope = host.Services.CreateScope();

var services = scope.ServiceProvider;

try
{
    services.GetRequiredService<App>().Run(args);
}
catch (Exception)
{
	throw;
}

static IHostBuilder CreateHostBuilder(string[] args)
{
    return Host.CreateDefaultBuilder(args)
        .ConfigureServices((_, services) =>
        {
            services.AddSingleton<IApplicationBusinessLogic, ApplicationBusinessLogic>();
            services.AddSingleton<IResearchBusinessLogic, ResearchBusinessLogic>();
            services.AddSingleton<ISupplyBusinessLogic, SupplyBusinessLogic>();
            services.AddSingleton<ILifeSupportSystemBusinessLogic, LifeSupportSystemBusinessLogic>();
            services.AddSingleton<IAdministrationBusinessLogic, AdministrationBusinessLogic>();

            services.AddSingleton<INewsDataRepository, NewsDataRepository>();
            services.AddSingleton<IResearchDataRepository, ResearchDataRepository>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<ISupplyService, SupplyService>();
            services.AddSingleton<ILifeSupportSystemService, LifeSupportSystemService>();

            services.AddSingleton<ApplicationController>();
            services.AddSingleton<ResearchController>();
            services.AddSingleton<LifeSupportController>();
            services.AddSingleton<SupplyController>();
            services.AddSingleton<AdministrationController>();


            services.AddSingleton<AppState>();
            services.AddSingleton<ControllerProvider>();
            services.AddSingleton<App>();
        });
}