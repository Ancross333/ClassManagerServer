using ClassManagerServer.Api.Commands.User_Authentication;
using ClassManagerServer.Api.Controllers;
using ClassManagerServer.Api.Requests;
using ClassManagerServer.Api.Validations;
using ClassManagerServer.EventHandlers;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR; // Make sure to add this for MediatR extensions.
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc();
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

// Register MediatR and specify the assembly containing your command handlers.
// Replace 'ClassManagerServer.EventHandlers' with the appropriate assembly if it's not correct.
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies( new[] { Assembly.GetExecutingAssembly() });
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
