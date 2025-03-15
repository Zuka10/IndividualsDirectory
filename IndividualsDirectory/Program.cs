using IndividualsDirectory.Api.Filters;
using IndividualsDirectory.Application;
using IndividualsDirectory.Application.Common;
using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Infrastructure;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var supportedCultures = new[]
{
    new CultureInfo("en-US"),
    new CultureInfo("ka-GE"),
    new CultureInfo("fr-FR"),
    new CultureInfo("es-ES")
};

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<IndividualsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(IndividualsDirectory.Application.AssemblyRefference).Assembly));

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();