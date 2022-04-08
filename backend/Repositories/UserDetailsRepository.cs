using MazingiraBora.Data;
using MazingiraBora.Models;
using Microsoft.EntityFrameworkCore;

public class UserDetailsRepository{
 public async static Task<List<SignUp>>GetUserDetailsAsync(){
  using(var db = new MazingiraDbContext()){
   return await db.Users.ToListAsync();
  }
 }
 public async static Task <SignUp> GetUserByUserNameAsync(string UserName)
 {

  using(var db = new MazingiraDbContext() ){
   return await db.Users.FirstOrDefaultAsync(user => user.UserName == UserName);
  }
 }

 public async static Task<bool> CreateUserAsync(SignUp userToCreate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    await db.Users.AddAsync(userToCreate);
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
    db.Users.Update(userToUpdate);
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