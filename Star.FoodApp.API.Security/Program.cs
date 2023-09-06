using Infrastructure.Data;
using Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Star.FoodApp.API.Security.DTOs;
using Star.FoodApp.Core.Entities;
using Star.FoodApp.Core.Enum;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);

app.MapPost("/register", async (StarFoodAppDB db, ApplicationUser user) =>
{
    var rg = new Random();
    user.VerificationCode = rg.Next(100000, 999999).ToString();
    await db.ApplicationUsers.AddAsync(user);
    await db.SaveChangesAsync();
    return Results.Ok();
});

app.MapPost("/login", async (StarFoodAppDB db, LoginDto login) =>
{
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(m => m.Type != ApplicationUserType.SystemAdmin &&
    m.Verified &&
    m.Username == login.Username &&
    m.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto()
        {
            Message = "نام کاربری یا کلمه عبور صحیح نیست",
            Success = false
        });
    }
    var claims = new[]
    {
        new Claim("Type",result.Type.ToString()),
        new Claim("Username",result.Username.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"],
        claims,
        expires: DateTime.UtcNow.AddHours(5),
        signingCredentials: signIn
);
    return Results.Ok(new LoginResultDto()
    {
        Type = result.Type.ToString(),
        Message = "خوش آمدید",
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Success = true
    });

});

app.MapPost("/adminlogin", async (StarFoodAppDB db, LoginDto login) =>
{
    if (!db.ApplicationUsers.Any())
    {
        await db.ApplicationUsers.AddAsync(new ApplicationUser
        {
            Email = "admin@admin",
            Fullname = "مدیریت سامانه",
            Username = "admin",
            Password = "admin",
            City = "hamedan",
            Type = ApplicationUserType.SystemAdmin,
            Verified = true
        });
        await db.SaveChangesAsync();
    }
    var result = await db.ApplicationUsers.FirstOrDefaultAsync(m => m.Type == ApplicationUserType.SystemAdmin &&
    m.Verified &&
    m.Username == login.Username &&
    m.Password == login.Password);
    if (result == null)
    {
        return Results.Ok(new LoginResultDto()
        {
            Message = "نام کاربری یا کلمه عبور صحیح نیست",
            Success = false
        });
    }
    var claims = new[]
    {
        new Claim("Type",result.Type.ToString()),
        new Claim("Username",result.Username.ToString()),
    };
    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]));
    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
    var token = new JwtSecurityToken(
        builder.Configuration["Jwt:Issuer"],
        builder.Configuration["Jwt:Audience"],
        claims,
        expires: DateTime.UtcNow.AddHours(5),
        signingCredentials: signIn
);
    return Results.Ok(new LoginResultDto()
    {
        Type = result.Type.ToString(),
        Message = "خوش آمدید",
        Token = new JwtSecurityTokenHandler().WriteToken(token),
        Success = true
    });

});

app.Run();

