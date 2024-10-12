using AutoMapper;
using Market.Data.Entity;
using Market.Data.Models;
using Market.Data.Business;
using Market.Data.Repository;
using Market.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Market.DependencyInjection {
    public class ConfigurationDI {
        public static void ConfigureServices(IServiceCollection services) {
            ConfigureMapper(services);
            ConfigureBusiness(services);
            ConfigureRepository(services);
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
    }
}
