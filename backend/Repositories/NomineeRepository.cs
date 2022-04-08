using MazingiraBora.Data;
using MazingiraBora.Models;
using Microsoft.EntityFrameworkCore;
public class NomineeRepository{
 public async static Task<List<Nominees>>GetNomineesAsync(){
  using(var db = new MazingiraDbContext()){
   return await db.NomineesTable.ToListAsync();
  }
 }

 public async static Task <Nominees> GetNomineeByNomineeUserNameAsync(string NomineeUserName)
 {

  using(var db = new MazingiraDbContext() ){
   return await db.NomineesTable.FirstOrDefaultAsync(nominees => nominees.NomineeUserName == NomineeUserName);
  }
 }

 public async static Task<bool> CreateNomineeAsync(Nominees nomineeToCreate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    await db.NomineesTable.AddAsync(nomineeToCreate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }
 }

 public async static Task<bool> UpdateNomineeAsync(Nominees nomineeToUpdate)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    db.NomineesTable.Update(nomineeToUpdate);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }

  }

 }

 public async static Task<bool> DeleteNomineeAsync(string NomineeUserName)
 {
  using(var db = new MazingiraDbContext()){
   try
   {
    Nominees nomineeToDelete = await GetNomineeByNomineeUserNameAsync(NomineeUserName);
    db.Remove(nomineeToDelete);
    return await db.SaveChangesAsync() >= 1;
    
   }
   catch (Exception e)
   {
    return false;
   }
  }
 }

}