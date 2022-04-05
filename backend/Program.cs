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

app.MapGet("/get-all-nominees",async ()=> await NomineeRepository.GetNomineesAsync())
.WithTags("NOMINEE ENDPOINTS");

app.MapGet("/get-nominee-by-NomineeUserName/{NomineeUserName}",async(string NomineeUserName) =>{
    Nominees  nomineeToReturn = await NomineeRepository.GetNomineeByNomineeUserNameAsync(NomineeUserName);
    if (nomineeToReturn != null)
    {
        return Results.Ok(nomineeToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapPost("/create-nominee-by-NomineeUserName/{NomineeUserName}",async(Nominees nomineeToCreate) =>{
    bool createSucessful = await NomineeRepository.CreateNomineeAsync(nomineeToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapPut("/update-nominee",async(Nominees nomineeToUpdate) =>{
    bool updateSucessful = await NomineeRepository.UpdateNomineeAsync(nomineeToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapDelete("/delete-nominee-by-NomineeUserName/{NomineeUserName}",async(string NomineeUserName) =>{
    bool deleteSucessful = await NomineeRepository.DeleteNomineeAsync(NomineeUserName);
    if (deleteSucessful)
    {
        return Results.Ok("Delete Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("NOMINEE ENDPOINTS");

app.MapGet("/get-all-voters",async ()=> await VoterRepository.GetVotersAsync())
.WithTags("VOTER ENDPOINTS");

app.MapGet("/get-voter-by-VoterUserName/{VoterUserName}",async(string VoterUserName) =>{
    Voter  voterToReturn = await VoterRepository.GetVoterByVoterUserNameAsync(VoterUserName);
    if (voterToReturn != null)
    {
        return Results.Ok(voterToReturn);
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");

app.MapPost("/create-voter-by-VoterUserName/{VoterUserName}",async(Voter voterToCreate) =>{
    bool createSucessful = await VoterRepository.CreateVoterAsync(voterToCreate);
    if (createSucessful)
    {
        return Results.Ok("Create Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");

app.MapPut("/update-voter",async(Voter voterToUpdate) =>{
    bool updateSucessful = await VoterRepository.UpdateVoterAsync(voterToUpdate);
    if (updateSucessful)
    {
        return Results.Ok("Update Successful");
    }
    else{
        return Results.BadRequest();
    }
}).WithTags("VOTER ENDPOINTS");

app.MapDelete("/delete-voter-by-VoterUserName/{VoterUserName}",async(string VoterUserName) =>{
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
