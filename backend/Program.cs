using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    SwaggerGenOptions => {
        SwaggerGenOptions.SwaggerDoc("v1",new OpenApiInfo {Title="MAZINGIRA BORA WEBSITE BACKEND",Version="v1"});
    }
);

var app = builder.Build();

 app.UseSwagger();
 app.UseSwaggerUI(SwaggerUIOptions => {
     SwaggerUIOptions.DocumentTitle = "MAZINGIRA BORA WEBSITE BACKEND";
     SwaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json","MAZINGIRA BORA API SERVING MAZINGIRA BORA WEBSITE");
     SwaggerUIOptions.RoutePrefix = string.Empty;

    
 } );

 // Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapGet("/get-all-users",async ()=> await UserDetailsRepository.GetUserDetailsAsync())
.WithTags("USERS ENDPOINTS");


app.UseAuthorization();

app.MapControllers();

app.Run();
