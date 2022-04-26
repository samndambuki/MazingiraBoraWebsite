using MazingiraBora.Data;
using MazingiraBora.Models;
using Microsoft.EntityFrameworkCore;
public class VoterRepository{

 public async static Task<List<Voter>>GetVotersAsync(){
  using(var db = new MazingiraDbContext()){
   return await db.Voters.ToListAsync();
  }
 }

 public async static Task <Voter> GetVoterByVoterUserNameAsync(string VoterUserName)
 {

  using(var db = new MazingiraDbContext() ){
   return await db.Voters.FirstOrDefaultAsync(voters => voters.VoterUserName == VoterUserName);
  }
 }

 public async static Task<bool> CreateVoterAsync(Voter voterToCreate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    await db.Voters.AddAsync(voterToCreate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }
 }

 public async static Task<bool> UpdateVoterAsync(Voter voterToUpdate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    db.Voters.Update(voterToUpdate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }

 }

 public async static Task<bool> DeleteVoterAsync(string VoterUserName)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    Voter voterToDelete = await GetVoterByVoterUserNameAsync(VoterUserName);
    db.Remove(voterToDelete);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }
  }
 }

}