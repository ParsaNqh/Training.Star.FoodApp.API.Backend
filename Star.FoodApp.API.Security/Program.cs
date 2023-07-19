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

app.MapPost("/register", async (StarFoodAppDB db, ApplicationUser user) =>
{
    await db.ApplicationUsers.AddAsync(user);
    await db.SaveChangesAsync();
    Results.Ok();
});

app.MapPost("/login", async (StarFoodAppDB db, LoginDto login) =>
{
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(m => m.Username == login.Username && m.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto()
        {
            Message = "نام کاربری یا کلمه عبور صحیح نیست",
            Success = false
        });
    }
    return Results.Ok(new LoginResultDto()
    {
        Message = "خوش آمدید",
        Success = true
    });

});

app.Run();

