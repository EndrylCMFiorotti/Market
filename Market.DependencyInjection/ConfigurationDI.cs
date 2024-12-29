using AutoMapper;
using Market.Data.Business;
using Market.Data.Entity;
using Market.Data.Interfaces;
using Market.Data.Models;
using Market.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Market.DependencyInjection {
    public class ConfigurationDI {
        public static void ConfigureServices(IServiceCollection services) {
            ConfigureServiceCookie(services);
            ConfigureRepository(services);
            ConfigureMapper(services);
            ConfigureBusiness(services);
        }

        private static void ConfigureMapper(IServiceCollection services) {
            var autoMapper = new MapperConfiguration(config => {
                config.CreateMap<User, UserModel>().ReverseMap();
                config.CreateMap<UserModel, User>().ReverseMap();
            });

            services.AddSingleton(autoMapper.CreateMapper());
        }

        private static void ConfigureBusiness(IServiceCollection services) {
            services.AddScoped<BLLogin>();
        }

        private static void ConfigureRepository(IServiceCollection services) {
            services.AddScoped<ILoginRepository, LoginRespository>();
        }

        private static void ConfigureServiceCookie(IServiceCollection services) {
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromDays(1);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }
    }
}
