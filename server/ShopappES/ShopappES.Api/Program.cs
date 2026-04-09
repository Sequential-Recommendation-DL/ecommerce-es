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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();


