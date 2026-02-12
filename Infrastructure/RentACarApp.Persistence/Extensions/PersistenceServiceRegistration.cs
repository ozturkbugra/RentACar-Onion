using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RentACarApp.Application.Features.RepositoryPattern.CommentRepositories;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.AppUserInterfaces;
using RentACarApp.Application.Interfaces.BlogInterfaces;
using RentACarApp.Application.Interfaces.BrandInterfaces;
using RentACarApp.Application.Interfaces.CarFeatureInterfaces;
using RentACarApp.Application.Interfaces.CarInterfaces;
using RentACarApp.Application.Interfaces.CarPricingInterfaces;
using RentACarApp.Application.Interfaces.RentACarInterfaces;
using RentACarApp.Application.Interfaces.ReviewInterfaces;
using RentACarApp.Application.Interfaces.TagCloudInterfaces;
using RentACarApp.Persistence.Context;
using RentACarApp.Persistence.Repositories;
using RentACarApp.Persistence.Repositories.AppUserRepositories;
using RentACarApp.Persistence.Repositories.BrandRepositories;
using RentACarApp.Persistence.Repositories.CarFeatureRepositories;
using RentACarApp.Persistence.Repositories.CarPricingRepositories;
using RentACarApp.Persistence.Repositories.CarRepositories;
using RentACarApp.Persistence.Repositories.CommandRepositories;
using RentACarApp.Persistence.Repositories.NewFolder;
using RentACarApp.Persistence.Repositories.RentACarRepositories;
using RentACarApp.Persistence.Repositories.ReviewRepositories;
using RentACarApp.Persistence.Repositories.TagCloudRepositories;

namespace RentACarApp.Persistence.Extensions
{
    public static class PersistenceServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            // 1. Bağlantı Cümlesi
            services.AddDbContext<RentACarAppContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("RentACarContext")));

            // 2. Genel Repositories
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            // 3. Özel Repositories
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<ICarPricingRepository, CarPricingRepository>();
            services.AddScoped<ITagCloudRepository, TagCloudRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IRentACarRepository, RentACarRepository>();
            services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IAppUserRepository, AppUserRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(CommentRepository<>));

        }

    }
}
