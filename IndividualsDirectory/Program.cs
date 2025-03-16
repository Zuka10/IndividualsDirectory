using IndividualsDirectory.Api.Filters;
using IndividualsDirectory.Api.Middlewares;
using IndividualsDirectory.Application;
using IndividualsDirectory.Application.Common;
using IndividualsDirectory.Domain.Abstractions;
using IndividualsDirectory.Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddDbContext<IndividualsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
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