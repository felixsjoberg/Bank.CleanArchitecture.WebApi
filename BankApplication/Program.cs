using BankApplication.Api.Filters;
using BankApplication.Api.Middleware;
using BankApplication.Application;
using BankApplication.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication()
                .AddInfrastructure(builder.Configuration);

//builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();

app.UseRouting();
app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

app.Run();

