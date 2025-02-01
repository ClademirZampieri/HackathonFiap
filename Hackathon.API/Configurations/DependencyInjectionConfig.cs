﻿using Hackathon.Data.Interfaces;
using Hackathon.Data.Repository;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Services;

namespace Hackathon.API.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            //Services
            services.AddScoped<IAppointmentServices, AppointmentServices>();
            services.AddScoped<IUserServices, UserServices>();

            //Repositories
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}