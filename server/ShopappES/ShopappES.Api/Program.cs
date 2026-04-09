using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using ShopappES.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddSimpleConsole(options =>
{
    options.IncludeScopes = true;
    options.SingleLine = true;
    options.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inject DI Service
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddHealthChecks()
    .AddNpgSql(builder.Configuration.GetConnectionString("Postgres")!); // Kiểm tra luôn cả DB cho chắc
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


