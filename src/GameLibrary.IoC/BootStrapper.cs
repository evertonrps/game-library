﻿using AutoMapper;
using GameLibrary.Data.Context;
using GameLibrary.Data.Repository;
using GameLibrary.Data.UoW;
using GameLibrary.Domain.Interfaces.Repositories;
using GameLibrary.Domain.Interfaces.Services;
using GameLibrary.Domain.Services;

//using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace GameLibrary.IoC
{
    public static class BootStrapper
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            // services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            services.AddDbContext<GameLibraryContext>();

            services.AddScoped(typeof(IGameRepository), typeof(GameRepository));
            services.AddScoped(typeof(IDeveloperRepository), typeof(DeveloperRepository));
            services.AddScoped(typeof(IPlatformRepository), typeof(PlatformRepository));
            services.AddScoped(typeof(IPlatformTypeRepository), typeof(PlatformTypeRepository));
            services.AddScoped(typeof(IGamePlatformRepository), typeof(GamePlatformRepository));
            services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
            services.AddScoped(typeof(ITokenService), typeof(TokenService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}