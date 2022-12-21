using BankApplication.Application;
using BankApplication.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

builder.Services.AddControllers();
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
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

