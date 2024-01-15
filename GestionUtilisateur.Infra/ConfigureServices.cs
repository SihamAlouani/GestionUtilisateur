using GestionUtilisateur.Application.Interfaces;
using GestionUtilisateur.Domain.Models;
using GestionUtilisateur.Infra.Db;
using GestionUtilisateur.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionUtilisateur.Infra
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<GestionBibContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("defaultconnection"))
                         .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));


            services.AddDbContext<AuthDbContext>(options =>
                  options.UseSqlServer(configuration.GetConnectionString("authconnection"))
                         .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole())));


            services.AddScoped<IUtilisateurRepository, UtilisateurRepository>();
            return services;
        }
    }
}
