using MazingiraBora.Data;
using Microsoft.EntityFrameworkCore;

public class LoginDetailsRepository{
 public async static Task<List<Login>>GetLoggedInUsersAsync(){
  using(var db = new MazingiraDbContext()){
   return await db.LoginDetails.ToListAsync();
  }
 }

 public async static Task<Login>GetLoggedInUserByUserNameAsync(string UserName){
  using(var db = new MazingiraDbContext()){
   return await db.LoginDetails.FirstOrDefaultAsync(user=>user.UserName == UserName);
  }
 }

 public async static Task<bool> CreateLoginAsync(Login loginToCreate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    await db.LoginDetails.AddAsync(loginToCreate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }
 }

 public async static Task<bool>UpdateLoginAsync(Login loginToUpdate){
  using(var db = new MazingiraDbContext()){
   try{
    db.LoginDetails.Update(loginToUpdate);
    return await db.SaveChangesAsync() >=1;
   }
   catch(Exception e){
    return false;
   }
  }
 }

 public async static Task<bool>DeleteLoginAsync(string UserName){
  using(var db = new MazingiraDbContext()){
   try{
    Login loginToDelete = await GetLoggedInUserByUserNameAsync(UserName);
    db.Remove(loginToDelete);
    return await db.SaveChangesAsync() >=1;
   }
   catch(Exception e){
    return false;
   }
  }
 }
}