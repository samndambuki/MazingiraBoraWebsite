using MazingiraBora.Models;
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

app.MapGet("/users",async ()=> await UserDetailsRepository.GetUserDetailsAsync())
.WithTags("USERS ENDPOINTS");

app.MapGet("/users/{UserName}",async(string UserName) =>{
    SignUp  userToReturn = await UserDetailsRepository.GetUserByUserNameAsync(UserName);
    if (userToReturn != null)
    {
        return Results.Ok(userToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("USERS ENDPOINTS");

app.MapPost("/users",async(SignUp userToCreate) =>{
    bool createSucessful = await UserDetailsRepository.CreateUserAsync(userToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("USERS ENDPOINTS");

app.MapPut("/users",async(SignUp userToUpdate) =>{
    bool updateSucessful = await UserDetailsRepository.UpdateUserAsync(userToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("USERS ENDPOINTS");

app.MapDelete("/users/{userName}",async(string UserName) =>{
    bool deleteSucessful = await UserDetailsRepository.DeleteUserAsync(UserName);
    if (deleteSucessful)
    {
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("USERS ENDPOINTS");


app.MapPost("/userlogin",async(SignUp loginToCreate) =>{
   
    bool createSucessful = await LoginDetailsRepository.CreateLoginAsync(loginToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("USERS ENDPOINTS");


app.MapGet("/nominees",async ()=> await NomineeRepository.GetNomineesAsync())
.WithTags("NOMINEE ENDPOINTS");

app.MapGet("/nominees/{NomineeUserName}",async(string NomineeUserName) =>{
    Nominees  nomineeToReturn = await NomineeRepository.GetNomineeByNomineeUserNameAsync(NomineeUserName);
    if (nomineeToReturn != null)
    {
        return Results.Ok(nomineeToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapPost("/nominees",async(Nominees nomineeToCreate) =>{
    bool createSucessful = await NomineeRepository.CreateNomineeAsync(nomineeToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapPut("/nominees",async(Nominees nomineeToUpdate) =>{
    bool updateSucessful = await NomineeRepository.UpdateNomineeAsync(nomineeToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapDelete("/nominees/{NomineeUserName}",async(string NomineeUserName) =>{
    bool deleteSucessful = await NomineeRepository.DeleteNomineeAsync(NomineeUserName);
    if (deleteSucessful)
    {
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapGet("/voters",async ()=> await VoterRepository.GetVotersAsync())
.WithTags("VOTER ENDPOINTS");

app.MapGet("/voters/{VoterUserName}",async(string VoterUserName) =>{
    Voter  voterToReturn = await VoterRepository.GetVoterByVoterUserNameAsync(VoterUserName);
    if (voterToReturn != null)
    {
        return Results.Ok(voterToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");

app.MapPost("/voters",async(Voter voterToCreate) =>{
    bool createSucessful = await VoterRepository.CreateVoterAsync(voterToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");

app.MapPut("/voters",async(Voter voterToUpdate) =>{
    bool updateSucessful = await VoterRepository.UpdateVoterAsync(voterToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");

app.MapDelete("/voters/{VoterUserName}",async(string VoterUserName) =>{
    bool deleteSucessful = await VoterRepository.DeleteVoterAsync(VoterUserName);
    if (deleteSucessful)
    {
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");


app.UseAuthorization();

app.MapControllers();

app.Run();
