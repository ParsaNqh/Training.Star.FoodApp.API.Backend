using Infrastructure.Data;
using Infrastructure.Security;

var builder = WebApplication.CreateBuilder(args);


SecurityServices.AddServices(builder);
var app = builder.Build();
SecurityServices.UseServices(app);




app.Run();