using IndividualsDirectory.Api.Filters;
using IndividualsDirectory.Api.Middlewares;
using IndividualsDirectory.Application;
using IndividualsDirectory.Application.Common;
using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Infrastructure;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<IndividualsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(IndividualsDirectory.Application.AssemblyRefference).Assembly));
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[] { "en-US", "ka-GE" };
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures.Select(c => new CultureInfo(c)).ToList();
    options.SupportedUICultures = options.SupportedCultures;
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidateModelAttribute>();
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseRequestLocalization();
app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseMiddleware<LocalizationMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();