using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using SplitItScrap;
using SplitItScrap.Domain.LibAdapters.HtmlParser;
using SplitItScrap.Domain.LibAdapters.HtmlParser.HTMLAgilityPack;
using SplitItScrap.Domain.Services.Actors;
using SplitItScrap.Domain.Services.HtmlHandlers;
using SplitItScrap.DB.Repositories.Actors;
using SplitItScrap.DB;
using SplitItScrap.Domain.Repositories;
using SplitItScrap.Domain.Services.Providers;
using SplitItScrap.Domain.Services.Uploads;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
ConfigureSwagger(builder.Services);


builder.Services.AddDbContext<SplitItScrapDbContext>(options =>
    options.UseInMemoryDatabase("InMemoryDb"));

RegisterServices(builder.Services);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Splitit scrap API V1");
    });
}

app.UseAuthorization();

app.MapControllers();

app.Run();

static void RegisterServices(IServiceCollection services)
{
    services.AddAutoMapper(typeof(SplitItScrapAutoMapperProfile));

    services.AddScoped<IHtmlParser, HTMLAgilityPackAdapter>();
    services.AddScoped<IHtmlService, HtmlService>();
    services.AddTransient<IUploadService, UploadService>();
    services.AddTransient<IActorsService, ActorsService>();
    services.AddScoped<IActorRepository, ActorRepository>();
    services.AddScoped<IMDBProvider>();
    services.AddScoped<IProviderFactory, ProviderFactory>();
}

static void ConfigureSwagger(IServiceCollection services)
{
    services.AddEndpointsApiExplorer();
    services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Splitit scrap API",
            Version = "v1"
        });
    });
}
