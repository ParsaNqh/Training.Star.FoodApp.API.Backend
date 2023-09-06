using Infrastructure.Data;
using Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);

app.MapPost("request", async (StarFoodAppDB db) =>
{
    return Results.Ok(db.ApplicationUsers
        .ToList());
});

app.Run();

