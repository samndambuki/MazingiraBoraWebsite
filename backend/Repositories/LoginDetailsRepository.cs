using MazingiraBora.Data;
using MazingiraBora.Models;


public class LoginDetailsRepository 
{
 public async static Task<bool> CreateLoginAsync(SignUp loginToCreate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    await db.Users.AddAsync(loginToCreate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }
 }
}