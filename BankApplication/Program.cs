﻿using BankApplication.Api;
using BankApplication.Application;
using BankApplication.Application.Customers.Queries;
using BankApplication.Infrastructure;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

    builder.Services
                .AddPresentation()
                .AddApplication()
                .AddInfrastructure(builder.Configuration);

//builder.Services.AddSingleton<ProblemDetailsFactory, BankApplicationProblemDetailsFactory>
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler("/error");


app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.Run();

