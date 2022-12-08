using Microsoft.EntityFrameworkCore;
using WorldCupFoodie.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<WorldCupFoodieContext>(options => options.UseSqlServer(builder.Configuration["DefaultConnection"]));

//allow our Angular app to talk to our C# API by setting up CORS and bypassing the default Same-Origin Policy
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            Microsoft.AspNetCore.Cors.Infrastructure.CorsPolicyBuilder corsPolicyBuilder = policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
