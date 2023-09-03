using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Api.Controllers;
using ClassManagerServer.EventHandlers;
using MediatR; // Make sure to add this for MediatR extensions.
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register MediatR and specify the assembly containing your command handlers.
// Replace 'ClassManagerServer.EventHandlers' with the appropriate assembly if it's not correct.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies( new[] { typeof(CreateUserCommandHandler).Assembly });
});


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
