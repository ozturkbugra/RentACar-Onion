using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.IdentityModel.Tokens;
using RentACarApp.Application.Features.CQRS.Handlers.AboutHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BannerHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.BrandHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CarHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.CategoryHandlers;
using RentACarApp.Application.Features.CQRS.Handlers.ContactHandlers;
using RentACarApp.Application.Features.Mediator.Commands.ReviewCommands;
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
using RentACarApp.Application.Services;
using RentACarApp.Application.Tools;
using RentACarApp.Application.Validators.ReviewValidators;
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
using RentACarApp.WebApi.Hubs;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpClient();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyHeader()
        .AllowAnyMethod()
        .SetIsOriginAllowed((host) => true)
        .AllowCredentials();
    });
});

builder.Services.AddSignalR();

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
    opt=>
    {
        opt.RequireHttpsMetadata = false;
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidAudience = JwtTokenDefaults.ValidAudiance,
            ValidIssuer = JwtTokenDefaults.ValidIssuer,
            ClockSkew = TimeSpan.Zero,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key)),
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true
        };
    });

// Assembly içindeki tüm FluentValidation validator'larýný DI container'a ekler
builder.Services.AddValidatorsFromAssemblyContaining<CreateReviewValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateReviewValidator>();


// MediatR'ý projeye ekler ve ilgili assembly'deki tüm Command/Handler sýnýflarýný register eder
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateReviewCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(UpdateReviewCommand).Assembly);
});

// MediatR pipeline'ýna ValidationBehavior ekler
// Her request önce validation'dan geçer, hata varsa handler çalýþmaz
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

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
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();


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


// Global hata yakalama kodu
app.UseExceptionHandler(config =>
{
    config.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        if (exception is FluentValidation.ValidationException validationException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new
            {
                Errors = validationException.Errors.Select(x => x.ErrorMessage)
            });
        }
    });
});


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<CarHub>("/carhub");


app.Run();
