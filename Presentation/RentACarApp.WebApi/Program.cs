using RentACarApp.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACarApp.Application.Features.Mappings;
using RentACarApp.Application.Interfaces;
using RentACarApp.Application.Interfaces.CarInterfaces;
using RentACarApp.Application.Services;
using RentACarApp.Persistence.Context;
using RentACarApp.Persistence.Repositories;
using RentACarApp.Persistence.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<RentACarAppContext>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<ICarRepository, CarRepository>();

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

builder.Services.AddAutoMapper(typeof(AboutMapping).Assembly);
builder.Services.AddAutoMapper(typeof(BannerMapping).Assembly);
builder.Services.AddAutoMapper(typeof(BrandMapping).Assembly);
builder.Services.AddAutoMapper(typeof(CarMapping).Assembly);
builder.Services.AddAutoMapper(typeof(CategoryMapping).Assembly);
builder.Services.AddAutoMapper(typeof(ContactMapping).Assembly);
builder.Services.AddAutoMapper(typeof(FeatureMapping).Assembly);

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
