using Microsoft.Extensions.DependencyInjection;
using RentACarApp.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.ContactHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACarApp.Persistence.Extensions
{
    public static class ApplicationServiceRegistration
    {
        public static void AddManualHandlers(this IServiceCollection services)
        {
            services.AddScoped<GetAboutQueryHandler>();
            services.AddScoped<GetAboutByIdQueryHandler>();
            services.AddScoped<CreateAboutCommandHandler>();
            services.AddScoped<UpdateAboutCommandHandler>();
            services.AddScoped<RemoveAboutCommandHandler>();

            services.AddScoped<GetBannerQueryHandler>();
            services.AddScoped<GetBannerByIdQueryHandler>();
            services.AddScoped<CreateBannerCommandHandler>();
            services.AddScoped<UpdateBannerCommandHandler>();
            services.AddScoped<RemoveBannerCommandHandler>();

            services.AddScoped<GetBrandQueryHandler>();
            services.AddScoped<GetBrandByIdQueryHandler>();
            services.AddScoped<CreateBrandCommandHandler>();
            services.AddScoped<UpdateBrandCommandHandler>();
            services.AddScoped<RemoveBrandCommandHandler>();

            services.AddScoped<GetCarQueryHandler>();
            services.AddScoped<GetCarByIdQueryHandler>();
            services.AddScoped<CreateCarCommandHandler>();
            services.AddScoped<UpdateCarCommandHandler>();
            services.AddScoped<RemoveCarCommandHandler>();
            services.AddScoped<GetCarWithBrandQueryHandler>();
            services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
            services.AddScoped<GetCarsWithPricingQueryHandler>();
            services.AddScoped<GetCarByIdWithBrandQueryHandler>();

            services.AddScoped<GetCategoryQueryHandler>();
            services.AddScoped<GetCategoryByIdQueryHandler>();
            services.AddScoped<CreateCategoryCommandHandler>();
            services.AddScoped<UpdateCategoryCommandHandler>();
            services.AddScoped<RemoveCategoryCommandHandler>();

            services.AddScoped<GetContactQueryHandler>();
            services.AddScoped<GetContactByIdQueryHandler>();
            services.AddScoped<CreateContactCommandHandler>();
            services.AddScoped<UpdateContactCommandHandler>();
            services.AddScoped<RemoveContactCommandHandler>();
        }
    }
}
