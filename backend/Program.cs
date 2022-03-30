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
.WithTags("SIGNUP ENDPOINTS");

app.MapGet("/get-user-by-userName/{UserName}",async(string UserName) =>{
    SignUp  userToReturn = await UserDetailsRepository.GetUserByUserNameAsync(UserName);
    if (userToReturn != null)
    {
        return Results.Ok(userToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("SIGNUP ENDPOINTS");

app.MapPost("/create-user-by-userName/{UserName}",async(SignUp userToCreate) =>{
    bool createSucessful = await UserDetailsRepository.CreateUserAsync(userToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("SIGNUP ENDPOINTS");

app.MapPut("/update-user",async(SignUp userToUpdate) =>{
    bool updateSucessful = await UserDetailsRepository.UpdateUserAsync(userToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("SIGNUP ENDPOINTS");

app.MapDelete("/delete-user-by-userName/{userName}",async(string UserName) =>{
    bool deleteSucessful = await UserDetailsRepository.DeleteUserAsync(UserName);
    if (deleteSucessful)
    {
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("SIGNUP ENDPOINTS");

app.MapGet("/get-all-loggedinusers",async ()=> await LoginDetailsRepository.GetLoggedInUsersAsync())
.WithTags("LOGIN ENDPOINTS");

app.MapGet("get-loggedinusers-by-userName{UserName}",async(string UserName)=>{
    Login  loginToReturn = await LoginDetailsRepository.GetLoggedInUserByUserNameAsync(UserName);
    if (loginToReturn != null)
    {
        return Results.Ok(loginToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("LOGIN ENDPOINTS");

app.MapPost("/create-login-by-userName/{UserName}",async(Login loginToCreate) =>{
    bool createSucessful = await LoginDetailsRepository.CreateLoginAsync(loginToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("LOGIN ENDPOINTS");

app.MapPut("/update-login",async(Login loginToUpdate) =>{
    bool updateSucessful = await LoginDetailsRepository.UpdateLoginAsync(loginToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("LOGIN ENDPOINTS");

app.MapDelete("/delete-loggedinuser-by-userName/{userName}",async(string UserName) =>{
    bool deleteSucessful = await LoginDetailsRepository.DeleteLoginAsync(UserName);
    if (deleteSucessful)
    {
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("LOGIN ENDPOINTS");

app.UseAuthorization();

app.MapControllers();

app.Run();
