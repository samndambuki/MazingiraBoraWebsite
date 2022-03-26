using MazingiraBora.Data;
using Microsoft.EntityFrameworkCore;

public class UserDetailsRepository{
 public async static Task<List<SignUp>>GetUserDetailsAsync(){
  using(var db = new MazingiraDbContext()){
   return await db.SignUpDetails.ToListAsync();
  }
 }
 public async static Task <SignUp> GetUserByUserNameAsync(string UserName)
 {

  using(var db = new MazingiraDbContext() ){
   return await db.SignUpDetails.FirstOrDefaultAsync(user => user.UserName == UserName);
  }
 }

 public async static Task<bool> CreateUserAsync(SignUp userToCreate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    await db.SignUpDetails.AddAsync(userToCreate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }
 }
 public async static Task<bool> UpdateUserAsync(SignUp userToUpdate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    db.SignUpDetails.Update(userToUpdate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }

 }
 public async static Task<bool> DeleteUserAsync(string UserName)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    SignUp userToDelete = await GetUserByUserNameAsync(UserName);
    db.Remove(userToDelete);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }
  }
 }
} 