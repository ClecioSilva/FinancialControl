using FinancialControl.Application.DependencyInjection;
using FinancialControl.Infrastructure.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);


// Controllers
builder.Services.AddControllers();


// Application Layer
builder.Services.AddApplication();


// Infrastructure Layer
builder.Services.AddInfrastructure(
    builder.Configuration);


// Swagger
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