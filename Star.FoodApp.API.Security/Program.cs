using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Star.FoodApp.API.Security.DTOs;
using Star.FoodApp.Core.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StarFoodAppDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MainDB"));
}); 

builder.Services.AddCors(option=> 
    option.AddDefaultPolicy(builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();



app.MapPost("/login", (StarFoodAppDB db, LoginDto login) =>
{
    var result = db.ApplicationUsers.FirstOrDefault(m => m.Username == login.Username && m.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new
        {
            Message = "نام کاربری یا کلمه عبرو صحیح نیست",
            Success = false
        });
    }
    return Results.Ok(new
    {
        Message = "خوش آمدید",
        Success = true

    });

});

app.Run();

