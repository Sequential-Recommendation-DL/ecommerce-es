using Marten.Services;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ShopappES.Application.UnitOfWork;
using ShopappES.Infrastructure;
using ShopappES.Infrastructure.Persistence.Postgres.MapperProfile;
using ShopappES.Infrastructure.Persistence.Postgres.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
    options.SingleLine = true;
    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
});


//Inject DI Service
builder.Services
    .AddPostgresService(builder.Configuration)
    .AddAutoMapperService(builder.Configuration)
    .AddSwaggerGen()
    .AddEndpointsApiExplorer()
    .AddScoped<IShopappESUnitOfWork, ShopappESUnitOfWork>()
    .AddHealthChecks()
;

var app = builder.Build();

app.MapHealthChecks("/", new HealthCheckOptions
{
    ResponseWriter = async (context, report) =>
    {
        context.Response.ContentType = "application/json";

        var response = new
        {
            status = report.Status.ToString(),
            info = $"HelloWorld/{Environment.MachineName}",
            database = report.Entries.ContainsKey("npgsql") ? report.Entries["npgsql"].Status.ToString() : "Not Checked",
            timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        await context.Response.WriteAsJsonAsync(response);
    }
});
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


