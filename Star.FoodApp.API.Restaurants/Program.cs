using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Star.FoodApp.API.Restaurants.DTOs;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);


app.MapPost("/requestlist", async (StarFoodAppDB db) =>
{
    return Results.Ok(
            db.Restaurants
            .Where(r => r.IsApproved == false)
            .ToList());
});
app.MapGet("/requestcount", async (StarFoodAppDB db) =>
{
    return Results.Ok(new Requestcount
    {
        Count = await db.Restaurants.CountAsync(r => r.IsApproved == false) 
    });
});

app.Run();


