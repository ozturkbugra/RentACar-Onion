using RentACarApp.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACarApp.Application.Features.Mappings;
using RentACarApp.Application.Features.RepositoryPattern.CommentRepositories;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.BlogInterfaces;
using RentACarApp.Application.Interfaces.BrandInterfaces;
using RentACarApp.Application.Interfaces.CarFeatureInterfaces;
using RentACarApp.Application.Interfaces.CarInterfaces;
using RentACarApp.Application.Interfaces.CarPricingInterfaces;
using RentACarApp.Application.Interfaces.RentACarInterfaces;
using RentACarApp.Application.Interfaces.ReviewInterfaces;
using RentACarApp.Application.Interfaces.TagCloudInterfaces;
using RentACarApp.Application.Services;
using RentACarApp.Persistence.Context;
using RentACarApp.Persistence.Repositories;
using RentACarApp.Persistence.Repositories.BrandRepositories;
using RentACarApp.Persistence.Repositories.CarFeatureRepositories;
using RentACarApp.Persistence.Repositories.CarPricingRepositories;
using RentACarApp.Persistence.Repositories.CarRepositories;
using RentACarApp.Persistence.Repositories.CommandRepositories;
using RentACarApp.Persistence.Repositories.NewFolder;
using RentACarApp.Persistence.Repositories.RentACarRepositories;
using RentACarApp.Persistence.Repositories.ReviewRepositories;
using RentACarApp.Persistence.Repositories.TagCloudRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<RentACarAppContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<ICarPricingRepository, CarPricingRepository>();
builder.Services.AddScoped<ITagCloudRepository, TagCloudRepository>();
builder.Services.AddScoped<IBrandRepository, BrandRepository>();
builder.Services.AddScoped<IRentACarRepository, RentACarRepository>();
builder.Services.AddScoped<ICarFeatureRepository, CarFeatureRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));

builder.Services.AddScoped<GetAboutQueryHandler>();
builder.Services.AddScoped<GetAboutByIdQueryHandler>();
builder.Services.AddScoped<CreateAboutCommandHandler>();
builder.Services.AddScoped<UpdateAboutCommandHandler>();
builder.Services.AddScoped<RemoveAboutCommandHandler>();

builder.Services.AddScoped<GetBannerQueryHandler>();
builder.Services.AddScoped<GetBannerByIdQueryHandler>();
builder.Services.AddScoped<CreateBannerCommandHandler>();
builder.Services.AddScoped<UpdateBannerCommandHandler>();
builder.Services.AddScoped<RemoveBannerCommandHandler>();

builder.Services.AddScoped<GetBrandQueryHandler>();
builder.Services.AddScoped<GetBrandByIdQueryHandler>();
builder.Services.AddScoped<CreateBrandCommandHandler>();
builder.Services.AddScoped<UpdateBrandCommandHandler>();
builder.Services.AddScoped<RemoveBrandCommandHandler>();

builder.Services.AddScoped<GetCarQueryHandler>();
builder.Services.AddScoped<GetCarByIdQueryHandler>();
builder.Services.AddScoped<CreateCarCommandHandler>();
builder.Services.AddScoped<UpdateCarCommandHandler>();
builder.Services.AddScoped<RemoveCarCommandHandler>();
builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
builder.Services.AddScoped<GetLast5CarsWithBrandQueryHandler>();
builder.Services.AddScoped<GetCarsWithPricingQueryHandler>();
builder.Services.AddScoped<GetCarByIdWithBrandQueryHandler>();

builder.Services.AddScoped<GetCategoryQueryHandler>();
builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
builder.Services.AddScoped<CreateCategoryCommandHandler>();
builder.Services.AddScoped<UpdateCategoryCommandHandler>();
builder.Services.AddScoped<RemoveCategoryCommandHandler>();

builder.Services.AddScoped<GetContactQueryHandler>();
builder.Services.AddScoped<GetContactByIdQueryHandler>();
builder.Services.AddScoped<CreateContactCommandHandler>();
builder.Services.AddScoped<UpdateContactCommandHandler>();
builder.Services.AddScoped<RemoveContactCommandHandler>();

builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
