using CarteiraDigital.Api.Extensions;
using CarteiraDigital.Application;
using CarteiraDigital.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();
builder.Services.AddApplication().AddValidators();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => 
    {
        c.DocumentTitle = "Carteira API - Test";
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Carteira API - Test");
    });

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
