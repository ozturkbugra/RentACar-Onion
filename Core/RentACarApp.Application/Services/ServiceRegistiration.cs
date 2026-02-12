using AutoMapper;
using FluentValidation; // Eklendi
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using RentACarApp.Application.Validators.ReviewValidators; // Validator referansı için (herhangi biri olur)
using System.Reflection;

namespace RentACarApp.Application.Services
{
    public static class ServiceRegistiration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            // 1. AutoMapper Kaydı
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // 2. MediatR Kaydı (Bu satır tüm Handler'ları bulmak için)
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(ServiceRegistiration).Assembly);
            });

            // Bu satır, Assembly içindeki tüm Validator sınıflarını (AbstractValidator) bulur.
            services.AddValidatorsFromAssembly(typeof(ServiceRegistiration).Assembly);

            // 4. Pipeline Behavior (Validation için Araya Girme)
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        }
    }
}